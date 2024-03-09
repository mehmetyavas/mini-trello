using System.Linq.Expressions;
using System.Security.Authentication;
using Core.Data;
using Core.Data.Dto.Auth;
using Core.Data.Dto.File;
using Core.Data.Enum;
using Core.Extensions;
using Core.Services.FileUploader;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Auth;
using WebAPI.Business.User.Request;
using WebAPI.Business.User.Response;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.User;

public class UserManager
{
    private readonly UnitOfWork _unitOfWork;
    private readonly FileUploader _fileUploader;
    private readonly ITokenManager _tokenManager;
    private readonly AuthManager _authManager;

    public UserManager(UnitOfWork unitOfWork, FileUploader fileUploader, ITokenManager tokenManager,
        AuthManager authManager)
    {
        _unitOfWork = unitOfWork;
        _fileUploader = fileUploader;
        _tokenManager = tokenManager;
        _authManager = authManager;
    }

    public async Task<IResult<List<UserResponse>>> GetUsers(string search,
        CancellationToken cancellationToken = default)
    {
        Expression<Func<Core.Data.Entity.User, bool>>? expression = null;

        var isInt = Guid.TryParse(search, out var id);

        if (isInt)
            expression = x => x.Id == id;
        else if (!string.IsNullOrWhiteSpace(search))
        {
            expression = x => x.Email.Contains(search) || x.Fullname.Contains(search);
        }


        var query = expression == null
            ? _unitOfWork.Users
                .Query()
            : _unitOfWork.Users
                .Query()
                .Where(expression);

        var user = await query.Select(x => new UserResponse())
            .ToListAsync(cancellationToken);


        return new SuccessResult<List<UserResponse>>(user);
    }

    public async Task<IResult> DeleteUser(Guid id)
    {
        var user = await _unitOfWork.Users.GetAsync(x => x.Id == id, ignore: true);

        if (user is null)
            return new ErrorResult(LangKeys.UserNotFound);

        await _unitOfWork.Users.SoftDelete(user);

        await _authManager.DeactivateUser(user.Id);

        await _unitOfWork.SaveAsync();

        return new SuccessResult();
    }

    public async Task<IResult<AuthResponse>> UpdateUser(UpdateUserCommand request, string accessToken)
    {
        var user = await _unitOfWork.Users
            .GetAsync(
                expression: x => x.Id == _unitOfWork.UserId,
                ignore: true);

        if (user is null)
            return new ErrorResult<AuthResponse>(LangKeys.UserNotFound);

        user.Fullname = request.FullName ?? user.Fullname;

        if (!string.IsNullOrWhiteSpace(request.MobilePhone))
        {
            if (request.MobilePhone != user.MobilePhone)
            {
                user.MobilePhone = request.MobilePhone;
            }
        }


        _unitOfWork.Users.Update(user);


        var userLogin = await _unitOfWork.UserLogins.GetAsync(x => x.AccessToken == accessToken);

        if (userLogin is null)
        {
            throw new AuthenticationException(LangKeys.UnAuthorized.Localize());
        }

        var provider = userLogin!.LoginProvider;
        await _unitOfWork.UserLogins.SoftDelete(userLogin!);

        var newUserLogin =
            await _unitOfWork.UserLogins.Login(
                _unitOfWork.Users.LoginClaims(user),
                provider,
                false);

        await _unitOfWork.SaveAsync();


        return new SuccessResult<AuthResponse>(newUserLogin);
    }


    public async Task<IResult<AuthResponse>> AddAvatar(FileRequest request, string accessToken,
        CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users
            .Query()
            .FirstOrDefaultAsync(x => x.Id == _unitOfWork.UserId,
                cancellationToken);

        if (user is null)
        {
            throw new AuthenticationException(LangKeys.UserNotFound.Localize());
        }


        string newAvatar;

        if (string.IsNullOrWhiteSpace(user.AvatarUrl))
        {
            var fileResult = await _fileUploader.SaveFileAsync(request);

            if (!fileResult.Success)
                return new ErrorResult<AuthResponse>(fileResult.Message);
            newAvatar = fileResult.Data.Name;
        }
        else
        {
            var fileResult = await _fileUploader.UpdateFileAsync(request, user.AvatarUrl);

            if (!fileResult.Success)
                return new ErrorResult<AuthResponse>(fileResult.Message);
            newAvatar = fileResult.Data.Name;
        }


        user.AvatarUrl = newAvatar;

        _unitOfWork.Users.Update(user);

        var userLogin = await _unitOfWork.UserLogins.GetAsync(x => x.AccessToken == accessToken, cancellationToken);

        if (userLogin is null)
        {
            throw new AuthenticationException(LangKeys.UnAuthorized.Localize());
        }

        var provider = userLogin!.LoginProvider;
        await _unitOfWork.UserLogins.SoftDelete(userLogin!, cancellationToken);

        var newUserLogin =
            await _unitOfWork.UserLogins.Login(
                _unitOfWork.Users.LoginClaims(user),
                provider,
                false, cancellationToken);


        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult<AuthResponse>(newUserLogin, LangKeys.AvatarUpdatedSuccessfully);
    }


    public async Task<IResult<AuthResponse>> DeleteAvatar(string avatarUrl, string accessToken,
        CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetAsync(x => x.Id == _unitOfWork.UserId, cancellationToken);
        if (user is null)
        {
            throw new AuthenticationException(LangKeys.UserNotFound.Localize());
        }


        user.AvatarUrl = null;


        _unitOfWork.Users.Update(user);


        var userLogin = await _unitOfWork.UserLogins.GetAsync(x => x.AccessToken == accessToken, cancellationToken);

        if (userLogin is null)
        {
            throw new AuthenticationException(LangKeys.UnAuthorized.Localize());
        }

        var provider = userLogin!.LoginProvider;
        await _unitOfWork.UserLogins.SoftDelete(userLogin!, cancellationToken);

        var newUserLogin =
            await _unitOfWork.UserLogins.Login(
                _unitOfWork.Users.LoginClaims(user),
                provider,
                false, cancellationToken);


        if (string.IsNullOrWhiteSpace(avatarUrl))
        {
            await _unitOfWork.SaveAsync(cancellationToken);
            return new SuccessResult<AuthResponse>("Silindi!");
        }


        var file = _fileUploader.DeleteFile(avatarUrl, FileDirectory.Avatar);


        if (!file.Success)
            return new ErrorResult<AuthResponse>(file.Message);

        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult<AuthResponse>(newUserLogin, "Avatar Silindi!");
    }
}