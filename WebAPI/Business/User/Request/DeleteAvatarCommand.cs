using Core.Data.Dto.Auth;
using Core.Utilities.Results;
using MediatR;

namespace WebAPI.Business.User.Request;

public class DeleteAvatarCommand : IRequest<IResult<AuthResponse>>
{
    public string AvatarUrl { get; set; } = null!;
    public string AccessToken { get; set; } = null!;
}