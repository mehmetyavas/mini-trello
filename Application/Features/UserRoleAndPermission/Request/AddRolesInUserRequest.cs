using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.UserRoleAndPermission.Request;

public class AddRolesInUserRequest : IRequest<IResult>
{
    public required Guid UserId { get; set; }
    public required List<long> RoleId { get; set; } = new();
}