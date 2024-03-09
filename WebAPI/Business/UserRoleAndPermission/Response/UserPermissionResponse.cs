using Core.Data.Dto.Permission;
using Core.Data.Dto.User;

namespace WebAPI.Business.UserRoleAndPermission.Response;

public class UserPermissionResponse
{
    public required UserDto User { get; set; }
    public required IEnumerable<ControllerNameDto> Permissions { get; set; } = new List<ControllerNameDto>();
}