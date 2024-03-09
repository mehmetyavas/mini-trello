using Core.Data.Enum;

namespace Core.Data.Dto.User;

public class UserClaimsDto
{
    public Guid Id { get; set; }
    public string GivenName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<long> Roles { get; set; } = new();

    public List<ActionName> Permissions { get; set; } = new();

    public string? AvatarUrl { get; set; }

    public bool IsAdmin()
    {
        return Roles.Contains((long)Enum.Roles.Admin);
    }
}