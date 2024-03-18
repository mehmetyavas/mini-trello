using Application.Features.TaskList.Response;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.TaskList.Request;

public class GetTaskListRequest:IRequest<IResult<TaskListResponse>>
{
    public long Id { get; set; }
}