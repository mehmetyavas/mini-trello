using System.ComponentModel.DataAnnotations;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Auth.Request;

public class LoginRequest : IRequest<IResult>
{
    [Required] public LoginProvider Provider { get; set; } = LoginProvider.Mail;

    [EmailAddress] public string? Email { get; set; }
    public string? AccessToken { get; set; }

    public bool RememberMe { get; set; }


    public bool CheckProviderProperty()
    {
        return Provider switch
        {
            LoginProvider.Mail => Email is not null,
            LoginProvider.Google => AccessToken is not null,
            LoginProvider.Facebook => AccessToken is not null,
            LoginProvider.Apple => true,
            LoginProvider.Sms => true,
            _ => throw new NotFoundException(LangKeys.InvalidProvider.Localize())
        };
    }
}