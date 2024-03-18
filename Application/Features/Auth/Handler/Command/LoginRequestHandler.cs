using Application.Features.Auth.Request;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Auth.Handler.Command;

public class LoginRequestHandler : IRequestHandler<LoginRequest, IResult>
{
    private readonly LoginProviderManager _providerManager;

    public LoginRequestHandler(LoginProviderManager providerManager)
    {
        _providerManager = providerManager;
    }

    public async Task<IResult> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        if (!request.CheckProviderProperty())
        {
            throw new ArgumentException(LangKeys.InvalidArgument.Localize());
        }

        var result = request.Provider switch
        {
            LoginProvider.Mail => await _providerManager.SendLoginCode(request.Email!, cancellationToken),
            LoginProvider.Google => await _providerManager.LoginWithGoogle(request.AccessToken!, request.RememberMe,
                cancellationToken),
            LoginProvider.Facebook => await _providerManager.LoginWithFacebook(request.AccessToken!, request.RememberMe,
                cancellationToken),
            LoginProvider.Apple => new ErrorResult(LangKeys.NotSupported),
            LoginProvider.Password => await _providerManager.LoginWithPassword(
                request.Email,
                request.Password,
                request.RememberMe),
            _ => new ErrorResult(LangKeys.NotSupported),
        };


        return result!;
    }
}