using Core.Data.Dto.User;

namespace Application.Features.Role.Response;

public class UsersByRoleResponse
{
    public required RoleResponse Roles { get; set; }
    public required IEnumerable<UserDto> Users { get; set; } = null!;
}