using Application.Features.Role.Response;
using Core.Data.Dto.Pagination;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.Role.Request;

public class GetRolesRequest : BasePagingRequest, IRequest<IResult<PagingResponse<List<RoleResponse>>>>
{
    public bool IncludePermissions { get; set; } = false;
}