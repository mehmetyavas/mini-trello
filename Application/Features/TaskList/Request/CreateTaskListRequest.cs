using System.ComponentModel.DataAnnotations;
using Application.Features.TaskList.Response;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.TaskList.Request;

public class CreateTaskListRequest:IRequest<IResult<TaskListResponse>>
{
    public long WorkSpaceId { get; set; }

    [Required, MinLength(3), MaxLength(25)]
    public string Title { get; set; } = null!;

}