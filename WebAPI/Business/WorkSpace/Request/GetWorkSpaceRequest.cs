using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.WorkSpace.Response;

namespace WebAPI.Business.WorkSpace.Request;

public class GetWorkSpaceRequest:IRequest<IResult<WorkSpaceResponse>>
{
    public long Id { get; set; }
}