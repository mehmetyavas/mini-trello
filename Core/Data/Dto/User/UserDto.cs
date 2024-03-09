using Core.Data.Entity.Base;

namespace Core.Data.Dto.User;

public class UserDto :IDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public string? AvatarUrl { get; set; }
}