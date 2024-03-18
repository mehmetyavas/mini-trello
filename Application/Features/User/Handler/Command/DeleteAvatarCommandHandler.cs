using System.Security.Authentication;
using Application.Features.User.Request;
using Core.Data;
using Core.Data.Dto.Auth;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Services.FileUploader;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Handler.Command;

public class DeleteAvatarCommandHandler : IRequestHandler<DeleteAvatarCommand, IResult<AuthResponse>>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly ITokenManager _tokenManager;
    private readonly FileUploader _fileUploader;

    public DeleteAvatarCommandHandler(UnitOfWork unitOfWork, ITokenManager tokenManager, FileUploader fileUploader)
    {
        _unitOfWork = unitOfWork;
        _tokenManager = tokenManager;
        _fileUploader = fileUploader;
    }

    public async Task<IResult<AuthResponse>> Handle(DeleteAvatarCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .Query()
            .FirstOrDefaultAsync(x => x.Id == _unitOfWork.UserId, cancellationToken);


        if (user is null)
        {
            throw new UnAuthorizedException(LangKeys.UserNotFound.Localize());
        }


        user.AvatarUrl = null;


        _unitOfWork.Users.Update(user);


        var userLogin =
            await _unitOfWork.UserLogins.GetAsync(x => x.AccessToken == request.AccessToken, cancellationToken);

        if (userLogin is null)
        {
            throw new AuthenticationException(LangKeys.UnAuthorized.Localize());
        }


        var provider = userLogin!.LoginProvider;
        await _unitOfWork.UserLogins.SoftDelete(userLogin!, cancellationToken);

        await _tokenManager.Deactivate(request.AccessToken);


        var newUserLogin =
            await _unitOfWork.UserLogins.Login(
                _unitOfWork.Users.LoginClaims(user),
                provider,
                false, cancellationToken);


        if (string.IsNullOrWhiteSpace(request.AvatarUrl))
        {
            await _unitOfWork.SaveAsync(cancellationToken);
            return new SuccessResult<AuthResponse>(LangKeys.Deleted);
        }


        var file = _fileUploader.DeleteFile(request.AvatarUrl, FileDirectory.Avatar);


        if (!file.Success)
            return new ErrorResult<AuthResponse>(file.Message);

        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult<AuthResponse>(newUserLogin, "Avatar Silindi!");
    }
}