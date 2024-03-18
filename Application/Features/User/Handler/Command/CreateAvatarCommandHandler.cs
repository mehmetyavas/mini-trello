using Application.Features.User.Request;
using Core.Data;
using Core.Data.Dto.Auth;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Services.FileUploader;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Handler.Command;

public class CreateAvatarCommandHandler : IRequestHandler<UpdateAvatarCommand, IResult<AuthResponse>>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly FileUploader _fileUploader;
    private readonly ITokenManager _tokenManager;

    public CreateAvatarCommandHandler(UnitOfWork unitOfWork, FileUploader fileUploader, ITokenManager tokenManager)
    {
        _unitOfWork = unitOfWork;
        _fileUploader = fileUploader;
        _tokenManager = tokenManager;
    }

    public async Task<IResult<AuthResponse>> Handle(UpdateAvatarCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .Query()
            .FirstOrDefaultAsync(x => x.Id == _unitOfWork.UserId,
                cancellationToken);

        if (user is null)
        {
            throw new UnAuthorizedException(LangKeys.UserNotFound);
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

        var userLogin =
            await _unitOfWork.UserLogins.GetAsync(x => x.AccessToken == request.AccessToken, cancellationToken);

        if (userLogin is null)
        {
            throw new UnAuthorizedException(LangKeys.UnAuthorized);
        }

        var provider = userLogin!.LoginProvider;
        await _unitOfWork.UserLogins.SoftDelete(userLogin!, cancellationToken);

        // deactivate old token from redis cache
        await _tokenManager.Deactivate(request.AccessToken);


        var newUserLogin =
            await _unitOfWork.UserLogins.Login(
                _unitOfWork.Users.LoginClaims(user),
                provider,
                false, cancellationToken);


        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult<AuthResponse>(newUserLogin, LangKeys.AvatarUpdatedSuccessfully);
    }
}