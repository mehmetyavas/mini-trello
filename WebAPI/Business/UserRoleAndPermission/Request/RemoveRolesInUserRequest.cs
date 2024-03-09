using Core.Attributes.CustomAttributes;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.UserRoleAndPermission.Request;

public class RemoveRolesInUserRequest : IRequest<IResult>
{
    public required Guid UserId { get; set; }

    [ListMinLength(1)]
    //UniqueList Attriute 
    public required List<long> RoleIds { get; set; } = new();
}