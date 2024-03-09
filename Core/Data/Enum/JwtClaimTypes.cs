namespace Core.Data.Enum;

public enum JwtClaimTypes
{
    Id,
    Name,
    Email,
    UserName,
    Gender,
    AvatarUrl,
    Role,
    Permission,
    TokenType
}

public enum JwtTokenTypes
{
    Access,
    Refresh
}