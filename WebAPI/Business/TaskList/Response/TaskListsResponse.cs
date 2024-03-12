using WebAPI.Business.WorkSpace.Response;

namespace WebAPI.Business.TaskList.Response;

public class TaskListsResponse
{

    public long WorkSpaceId { get; set; }
    public List<TaskListBaseResponse> TaskLists { get; set; } = new();
}