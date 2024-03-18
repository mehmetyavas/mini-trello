using Application.Features.WorkSpace.Response;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.WorkSpace.Request;

public class GetUserWorkSpacesRequest : IRequest<IResult<List<WorkSpaceResponse>>>
{
    public Guid UserId { get; set; }
}