using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.WorkSpace.Response;

namespace WebAPI.Business.WorkSpace.Request;

public class GetUserWorkSpacesRequest : IRequest<IResult<List<WorkSpaceResponse>>>
{
    public Guid UserId { get; set; }
}