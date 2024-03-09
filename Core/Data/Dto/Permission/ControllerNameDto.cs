namespace Core.Data.Dto.Permission;

public class ControllerNameDto
{
    public string? ControllerName { get; set; }
    public required PermissionResponse BasePermission { get; set; }

    public IEnumerable<HttpMethodDto> Methods { get; set; } = null!;
}