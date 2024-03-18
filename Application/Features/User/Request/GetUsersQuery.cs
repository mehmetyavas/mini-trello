using Application.Features.User.Response;
using Core.Data.Dto.Pagination;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.User.Request;

public class GetUsersQuery : BasePagingRequest, IRequest<IResult<PagingResponse<List<UserResponse>>>>
{
    public string? Search { get; set; }
}