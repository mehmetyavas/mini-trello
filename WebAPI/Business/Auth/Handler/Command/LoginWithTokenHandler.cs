using Core.Data;
using Core.Data.Dto.Auth;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Auth.Request;

namespace WebAPI.Business.Auth.Handler.Command;

public class LoginWithTokenHandler : IRequestHandler<LoginWithToken, IResult<AuthResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public LoginWithTokenHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<AuthResponse>> Handle(LoginWithToken request, CancellationToken cancellationToken)
    {
        var loginClaims = await _unitOfWork.Users.LoginClaims(request);

        var userLogin = await _unitOfWork.UserLogins
            .Query()
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.AccessToken == request.AccessToken, cancellationToken);

        if (userLogin == null ||
            userLogin.RowStatus != RowStatus.Active ||
            userLogin.RefreshToken != request.RefreshToken) throw new UnAuthorizedException();

        await _unitOfWork.UserLogins.SoftDelete(userLogin, cancellationToken);

        var newUserLogin =
            await _unitOfWork.UserLogins.Login(loginClaims, userLogin.LoginProvider, true,
                cancellationToken);


        var user = userLogin.User;


        _unitOfWork.Users.Update(user);

        await _unitOfWork.SaveAsync(cancellationToken);
        return new SuccessResult<AuthResponse>(newUserLogin, LangKeys.RefreshTokenSuccessful);
    }
}