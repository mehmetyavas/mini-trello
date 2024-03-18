using Core.Data.Dto.Auth;
using Core.Data.Dto.File;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.User.Request;

public class UpdateAvatarCommand : FileRequest, IRequest<IResult<AuthResponse>>
{
    public string AccessToken { get; set; } = null!;
}