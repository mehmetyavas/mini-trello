using Core.Utilities.Results;
using MediatR;

namespace Application.Features.TaskList.Request;

public class DeleteTaskListRequest:IRequest<IResult>
{
    public long Id { get; set; }
    
}