using Core.Data.Dto.Auth;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.Auth.Request;

public class LoginWithToken : TokenDto, IRequest<IResult<AuthResponse>>
{
}