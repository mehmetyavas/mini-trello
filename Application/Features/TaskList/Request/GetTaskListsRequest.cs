using System.ComponentModel.DataAnnotations;
using Application.Features.TaskList.Response;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.TaskList.Request;

public class GetTaskListsRequest:IRequest<IResult<List<TaskListResponse>>>
{
    [Required]
    public long WorkSpaceId { get; set; }
}