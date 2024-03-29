using System.ComponentModel.DataAnnotations;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Auth.Request;

public class LoginRequest : IRequest<IResult>
{
    [Required] public LoginProvider Provider { get; set; } = LoginProvider.Mail;

    [EmailAddress] public string? Email { get; set; }
    public string? AccessToken { get; set; }
    public string? Password { get; set; }

    public bool RememberMe { get; set; }


    public bool CheckProviderProperty()
    {
        return Provider switch
        {
            LoginProvider.Mail => !string.IsNullOrWhiteSpace(Email),
            LoginProvider.Google => !string.IsNullOrWhiteSpace(AccessToken),
            LoginProvider.Facebook => !string.IsNullOrWhiteSpace(AccessToken),
            LoginProvider.Password => !string.IsNullOrWhiteSpace(Email)&&
                                      !string.IsNullOrWhiteSpace(Password),
            LoginProvider.Apple => true,
            LoginProvider.Sms => true,
            _ => throw new NotFoundException(LangKeys.InvalidProvider.Localize())
        };
    }
}