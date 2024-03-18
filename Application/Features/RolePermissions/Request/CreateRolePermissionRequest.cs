using Core.Attributes.CustomAttributes;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.RolePermissions.Request;

public record CreateRolePermissionRequest : IRequest<IResult>
{
    public required int RoleId { get; set; }
    
   [ListMinLength(1)] 
    public required List<int> PermissionId { get; set; } = new();
}