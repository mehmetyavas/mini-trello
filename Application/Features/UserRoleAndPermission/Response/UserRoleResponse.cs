using Application.Features.Role.Response;
using Core.Data.Dto.User;

namespace Application.Features.UserRoleAndPermission.Response;

public class UserRoleResponse
{
    public required UserDto User { get; set; }
    public required IEnumerable<RoleResponse> Roles { get; set; } = new List<RoleResponse>();
}