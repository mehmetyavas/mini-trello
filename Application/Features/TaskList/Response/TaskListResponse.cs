using System.ComponentModel.DataAnnotations;

namespace Application.Features.TaskList.Response;

public class TaskListResponse:TaskListBaseResponse
{
    [Required]
    public long WorkSpaceId { get; set; }

    public long Id { get; set; }
}