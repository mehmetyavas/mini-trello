using System.ComponentModel.DataAnnotations;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.TaskList.Response;

namespace WebAPI.Business.TaskList.Request;

public class GetTaskListsRequest:IRequest<IResult<List<TaskListResponse>>>
{
    [Required]
    public long WorkSpaceId { get; set; }
}