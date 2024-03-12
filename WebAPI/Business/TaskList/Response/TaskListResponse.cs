using System.ComponentModel.DataAnnotations;
using WebAPI.Business.WorkSpace.Response;

namespace WebAPI.Business.TaskList.Response;

public class TaskListResponse:TaskListBaseResponse
{
    [Required]
    public long WorkSpaceId { get; set; }
}