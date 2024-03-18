using Core.Attributes.CustomAttributes;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Role.Request;

public class RemoveUsersInRoleRequest : IRequest<IResult>
{
    public required int RoleId { get; set; }
    [Email] public required IEnumerable<string> Email { get; set; } = new List<string>();
}