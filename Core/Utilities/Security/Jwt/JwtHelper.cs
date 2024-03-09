using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Data.Dto.App;
using Core.Data.Dto.User;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Jwt;

public static class JwtHelper
{
    private static readonly TokenOptions JwtConfig = AppConfig.AuthenticationConfig;


    public static string GenerateAccessToken(UserClaimsDto claimsInput, bool rememberMe)
    {
        var roleClaims =
            claimsInput.Roles.Select(roleId => new Claim(ClaimTypes.Role, roleId.ToString()));


        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, claimsInput.Id.ToString()),
            new(ClaimTypes.Email, claimsInput.Email),
            new(ClaimTypes.GivenName, claimsInput.GivenName),
            new(JwtClaimTypes.TokenType.ToString(), JwtTokenTypes.Access.ToString()),
        };

        claims.AddRange(roleClaims);

        if (claimsInput.Roles.Any(x => x != (long)Roles.Admin))
        {
            var permissionClaims =
                claimsInput.Permissions.Select(action =>
                    new Claim(JwtClaimTypes.Permission.ToString(), action.GetValueString()));

            claims.AddRange(permissionClaims);
        }


        var expires = DateTime.UtcNow.AddDays(rememberMe ? JwtConfig.AccessExpiration : 1);

        return GenerateJwt(claims, expires);
    }

    private static string GenerateJwt(List<Claim> claims, DateTime expires)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            JwtConfig.Issuer,
            JwtConfig.Audience,
            claims,
            expires: expires,
            signingCredentials: credentials
        );
        var generateJwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return generateJwtToken;
    }


    public static string GenerateRefreshToken(UserClaimsDto claimsInput)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, claimsInput.Id.ToString()),
            new(ClaimTypes.Email, claimsInput.Email),
            new(ClaimTypes.GivenName, claimsInput.GivenName),
            new(JwtClaimTypes.TokenType.ToString(), JwtTokenTypes.Refresh.ToString())
        };

        var expires = DateTime.UtcNow.AddDays(JwtConfig.RefreshExpiration);

        return GenerateJwt(claims, expires);
    }


    public static async Task<TokenValidationResult> ValidateRefreshToken(string refreshToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secret)),
            ValidateLifetime = true,
            ValidAudience = JwtConfig.Audience,
            ValidIssuer = JwtConfig.Issuer,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.Zero
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        return await tokenHandler.ValidateTokenAsync(refreshToken, tokenValidationParameters);
    }


    public static async Task<TokenValidationResult> ValidateExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secret)),
            ValidateLifetime = false,
            ValidAudience = JwtConfig.Audience,
            ValidIssuer = JwtConfig.Issuer
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        return await tokenHandler.ValidateTokenAsync(token, tokenValidationParameters);
    }
}