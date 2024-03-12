using System.ComponentModel.DataAnnotations;
using Core.Attributes.CustomAttributes;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.TaskList.Response;

namespace WebAPI.Business.TaskList.Request;

public class CreateTaskListRequest:IRequest<IResult<TaskListResponse>>
{
    public long WorkSpaceId { get; set; }

    [Required, MinLength(3), MaxLength(25)]
    public string Title { get; set; } = null!;
    [MaxValue(255)]
    public byte Order { get; set; }

}