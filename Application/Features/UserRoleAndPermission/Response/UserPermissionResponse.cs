using Core.Data.Dto.Permission;
using Core.Data.Dto.User;

namespace Application.Features.UserRoleAndPermission.Response;

public class UserPermissionResponse
{
    public required UserDto User { get; set; }
    public required IEnumerable<ControllerNameDto> Permissions { get; set; } = new List<ControllerNameDto>();
}