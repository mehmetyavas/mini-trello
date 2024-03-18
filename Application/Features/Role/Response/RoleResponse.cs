using Application.Features.RolePermissions.Response;

namespace Application.Features.Role.Response;

public class RoleResponse
{
    public required long Id { get; set; }
    public required string Role { get; set; } = null!;
    public string? Description { get; set; }
    public required string Status { get; set; }
    public required bool IsStrict { get; set; }
    public List<RolePermissionResponse>? Permissions { get; set; } = new();
}