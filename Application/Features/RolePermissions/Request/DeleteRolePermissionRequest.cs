using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.RolePermissions.Request;

public record DeleteRolePermissionRequest : IRequest<IResult>
{
    public required int RoleId { get; set; }
    public required List<int> PermissionId { get; set; } = new();
}