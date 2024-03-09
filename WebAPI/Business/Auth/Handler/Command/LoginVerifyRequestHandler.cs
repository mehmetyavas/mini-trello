using Core.Data;
using Core.Data.Dto.Auth;
using Core.Data.Enum;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Auth.Request;

namespace WebAPI.Business.Auth.Handler.Command;

public class LoginVerifyRequestHandler : IRequestHandler<LoginVerifyRequest, IResult<AuthResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public LoginVerifyRequestHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<AuthResponse>> Handle(LoginVerifyRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.Query()
            .FirstOrDefaultAsync(x => x.LoginCode == request.LoginCode, cancellationToken);

        if (user is null)
            return new ErrorResult<AuthResponse>(LangKeys.UserNotFound.ToString());
        

        if (user.LoginCodeExpiredAt < DateTime.Now)
            return new ErrorResult<AuthResponse>(LangKeys.LoginExpired.ToString());

        var userClaims = _unitOfWork.Users.LoginClaims(user!);


        var newUserLogin =
            await _unitOfWork.UserLogins.Login(userClaims, LoginProvider.Mail, request.RememberMe,
                cancellationToken);


        _unitOfWork.Users.Update(user);

        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult<AuthResponse>(newUserLogin);
    }
}