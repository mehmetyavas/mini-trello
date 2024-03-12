using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.TaskList.Response;

namespace WebAPI.Business.TaskList.Request;

public class GetTaskListRequest:IRequest<IResult<TaskListResponse>>
{
    public long Id { get; set; }
}