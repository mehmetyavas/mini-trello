using Core.Data.Dto.User;

namespace WebAPI.Business.WorkSpace.Response;

public class WorkSpaceResponse
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public UserDto CreatorUser { get; set; } = null!;
}