using Core.Data.Dto.Auth;
using Core.Utilities.Results;
using MediatR;

namespace WebAPI.Business.Auth.Request;

public class LoginWithToken : TokenDto, IRequest<IResult<AuthResponse>>
{
}