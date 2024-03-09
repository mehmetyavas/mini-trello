using Core.Data.Enum;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.Role.Response;

namespace WebAPI.Business.Role.Request;

public class UpdateRoleRequest : IRequest<IResult<RoleResponse>>
{
    public long RoleId { get; set; }
    public string? Role { get; set; }
    public string? Description { get; set; }
    public RowStatus? Status { get; set; }
}