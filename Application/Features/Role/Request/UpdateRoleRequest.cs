using Application.Features.Role.Response;
using Core.Data.Enum;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.Role.Request;

public class UpdateRoleRequest : IRequest<IResult<RoleResponse>>
{
    public long RoleId { get; set; }
    public string? Role { get; set; }
    public string? Description { get; set; }
    public RowStatus? Status { get; set; }
}