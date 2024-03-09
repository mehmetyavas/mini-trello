using Core.Attributes.CustomAttributes;
using Core.Data.Dto.Auth;
using Core.Utilities.Results;
using MediatR;

namespace WebAPI.Business.User.Request;

public class UpdateUserCommand : IRequest<IResult<AuthResponse>>
{
    public string? FullName { get; set; }
    [PhoneNumber] public string? MobilePhone { get; set; }
}

public class UpdateUserCommandWithToken : UpdateUserCommand
{
    public string AccessToken { get; set; } = null!;
}