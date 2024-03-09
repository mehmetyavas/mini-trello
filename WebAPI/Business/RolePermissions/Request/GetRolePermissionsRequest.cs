using Core.Data.Dto.Permission;
using Core.Utilities.Results;
using MediatR;

namespace WebAPI.Business.RolePermissions.Request;

public record GetRolePermissionsRequest : IRequest<IResult<List<ControllerNameDto>>>
{
    public GetRolePermissionsRequest(int roleId)
    {
        RoleId = roleId;
    }
    
    public int RoleId { get; init; }
};