using Core.Data.Dto.User;
using Core.Utilities.Security.Jwt;

namespace Core.Data.Dto.Auth;

public class AuthResponse
{
    public required UserDto User { get; set; } = null!;

    public required TokenResponse TokenResponse { get; set; } = null!;
}