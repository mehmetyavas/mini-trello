using Core.Attributes.CustomAttributes;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.RolePermissions.Request;

public record CreateRolePermissionRequest : IRequest<IResult>
{
    public required int RoleId { get; set; }
    
   [ListMinLength(1)] 
    public required List<int> PermissionId { get; set; } = new();
}