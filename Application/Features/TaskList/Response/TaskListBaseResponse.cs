namespace Application.Features.TaskList.Response;

public class TaskListBaseResponse
{
    public string Title { get; set; } = null!;
    public byte Order { get; set; }
}