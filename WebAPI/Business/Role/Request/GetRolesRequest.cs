using Core.Data.Dto.Pagination;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.Role.Response;

namespace WebAPI.Business.Role.Request;

public class GetRolesRequest : BasePagingRequest, IRequest<IResult<PagingResponse<List<RoleResponse>>>>
{
    public bool IncludePermissions { get; set; } = false;
}