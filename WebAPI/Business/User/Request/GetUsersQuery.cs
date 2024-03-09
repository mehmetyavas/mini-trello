using Core.Data.Dto.Pagination;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.User.Response;

namespace WebAPI.Business.User.Request;

public class GetUsersQuery : BasePagingRequest, IRequest<IResult<PagingResponse<List<UserResponse>>>>
{
    public string? Search { get; set; }
}