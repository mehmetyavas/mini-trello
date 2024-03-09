using System.Security.Authentication;
using Core.Data;
using Core.Data.Dto.Auth;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.User.Request;

namespace WebAPI.Business.User.Handler.Command;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandWithToken, IResult<AuthResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<AuthResponse>> Handle(UpdateUserCommandWithToken request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .GetAsync(
                expression: x => x.Id == _unitOfWork.UserId,
                ignore: true,
                cancellationToken: cancellationToken);

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


        var userLogin =
            await _unitOfWork.UserLogins.GetAsync(x => x.AccessToken == request.AccessToken, cancellationToken);

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
                false,
                cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult<AuthResponse>(newUserLogin);
    }
}