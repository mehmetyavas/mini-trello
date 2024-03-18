using Core.Data.Dto.User;

namespace Application.Features.WorkSpace.Response;

public class WorkSpaceResponse
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public UserDto CreatorUser { get; set; } = null!;
}