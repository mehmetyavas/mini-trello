using System.ComponentModel.DataAnnotations;
using Core.Attributes.CustomAttributes;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.RolePermissions.Request;

public class UpdateRolePermissionRequest : IRequest<IResult>
{
    [Required] public int RoleId { get; set; }

    [ListMinLength(1)] public List<int> PermissionIds { get; set; } = new();
}