using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Role.Request;

public class AddUsersInRoleRequest : IRequest<IResult>
{
    public required IEnumerable<Guid> UserId { get; set; } = new List<Guid>();
    public required int RoleId { get; set; }
}