using System.ComponentModel.DataAnnotations;
using Core.Attributes.CustomAttributes;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.UserRoleAndPermission.Request;

public record AddPermissionsToUserRequest : IRequest<IResult>
{
    [Required] public Guid UserId { get; set; }

    [Required, ListMinLength(1)] public IEnumerable<int> PermissionIds { get; set; } = new List<int>();
}