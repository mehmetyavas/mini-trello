using System.Security.Claims;
using Core.Data.Dto.User;
using Core.Data.Enum;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Core.Extensions;

public static class ClaimsPrincipalExtension
{
    public static List<string> GetTokenProps(this ClaimsPrincipal claims, string key)
    {
        if (!claims.Claims.Any())
        {
            return new List<string>();
        }

        return claims.Claims.Where(x => x.Type.EndsWith(key))!.Select(x => x.Value).ToList();
    }

    public static string? GetId(this ClaimsPrincipal? claims)
    {
        if (claims is null ||
            !claims.Claims.Any())
        {
            return null;
        }

        var id = claims.Claims
            .First(x => x.Type.EndsWith(ClaimTypes.NameIdentifier) ||
                        x.Type.EndsWith(JwtRegisteredClaimNames.Jti))
            .Value;
        return id;
    }

    public static List<ActionName> GetPermissions(this ClaimsPrincipal user)
    {
        var permissions = user.Claims.Where(c => c.Type == JwtClaimTypes.Permission.ToString());
        return permissions.Select(x => (ActionName)Enum.Parse(typeof(ActionName), x.Value)).ToList();
    }

    public static bool CheckAuthenticate(this ClaimsPrincipal? claim, out Guid userId)
    {
        if (claim == null)
        {
            userId = Guid.Empty;
            return false;
        }

        if (!claim.Identity!.IsAuthenticated)
        {
            userId = Guid.Empty;
            return false;
        }

        if (!Guid.TryParse(claim.GetId(), out var guid))
        {
            userId = Guid.Empty;
            return false;
        }

        userId = guid;


        return true;
    }

    public static UserClaimsDto GetClaimsDto(this ClaimsPrincipal? claims)
    {
        return new UserClaimsDto
        {
            Id = Guid.Parse(claims.GetId()!),
            GivenName = claims?.GetTokenProps(ClaimTypes.GivenName).First()!,
            Email = claims?.GetTokenProps(ClaimTypes.Email).First()!,
            Roles = claims?.GetTokenProps(ClaimTypes.Role)
                .Select(x => (long)Convert.ToInt32(x))
                .ToList()!,
            Permissions = claims?.GetTokenProps(JwtClaimTypes.Permission.ToString())
                .Select(x => (ActionName)Convert.ToInt32(x))
                .ToList()!
        };
    }
}