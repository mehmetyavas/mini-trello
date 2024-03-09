using Core.Data.Dto.User;
using WebAPI.Business.Role.Response;

namespace WebAPI.Business.UserRoleAndPermission.Response;

public class UserRoleResponse
{
    public required UserDto User { get; set; }
    public required IEnumerable<RoleResponse> Roles { get; set; } = new List<RoleResponse>();
}