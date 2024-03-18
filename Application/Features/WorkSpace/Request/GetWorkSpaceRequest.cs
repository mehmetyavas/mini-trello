using Application.Features.WorkSpace.Response;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.WorkSpace.Request;

public class GetWorkSpaceRequest:IRequest<IResult<WorkSpaceResponse>>
{
    public long Id { get; set; }
}