using Core.Data.Dto.Auth;
using Core.Data.Dto.User;
using Core.Data.Entity;
using Core.Data.Enum;
using Core.Data.Repository.Base;
using Core.Utilities.Helpers;
using Core.Utilities.Security.Jwt;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repository;

public class UserLoginRepository : BaseRepository<UserLogin, AppDbContext>
{
    public UserLoginRepository(AppDbContext context) : base(context)
    {
    }


    public async Task<AuthResponse> Login(UserClaimsDto userClaims, LoginProvider provider,
        bool rememberMe,
        CancellationToken cancellationToken = default)
    {
        var accessToken = JwtHelper.GenerateAccessToken(userClaims, rememberMe);
        var refreshToken = rememberMe ? JwtHelper.GenerateRefreshToken(userClaims) : null;

        var userActiveLoginsCount = await UserActiveLoginsCount(userClaims.Id);

        if (userActiveLoginsCount >= AppConfig.Settings.LoginLimit)
            throw new Exception(LangKeys.LoginLimitExceeded.ToString());

        var newUserLogin = new UserLogin
        {
            LoginProvider = provider,
            UserId = userClaims.Id,
            ProviderKey = userClaims.Id.ToString(),
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            AccessTokenExpiresOn =
                DateTime.UtcNow.AddDays(rememberMe ? AppConfig.AuthenticationConfig.AccessExpiration : 1),
            RefreshTokenExpiresOn =
                DateTime.UtcNow.AddDays(rememberMe ? AppConfig.AuthenticationConfig.RefreshExpiration : 1)
        };

        await Context.UserLogins.AddAsync(newUserLogin, cancellationToken);

        return new AuthResponse()
        {
            User = new UserDto
            {
                Id = userClaims.Id,
                Email = userClaims.Email,
                Fullname = userClaims.GivenName,
                AvatarUrl = userClaims.AvatarUrl,
            },
            TokenResponse = new TokenResponse
            {
                Permissions =
                    userClaims.IsAdmin() ? new List<int>() : userClaims.Permissions.Select(x => (int)x).ToList(),
                Roles = userClaims.Roles.Select(x => ((Roles)x).ToString()).ToList(),
                AccessToken = newUserLogin.AccessToken,
                AccessExpiration = newUserLogin.AccessTokenExpiresOn,
                RefreshToken = newUserLogin.RefreshToken,
                RefreshExpiration = newUserLogin.RefreshTokenExpiresOn,
                AvatarUrl = userClaims.AvatarUrl
            },
        };
    }

    private async Task<int> UserActiveLoginsCount(Guid userId)
    {
        return await Context.UserLogins.CountAsync(x => x.UserId == userId);
    }


    public IQueryable<UserLogin> GetInActives()
    {
        return Context.UserLogins.IgnoreQueryFilters()
            .Where(x => x.RowStatus != RowStatus.Active);
    }

    public IQueryable<UserLogin> GetExpiredInActives()
    {
        return Context.UserLogins.IgnoreQueryFilters()
            .Where(x =>
                x.RowStatus != RowStatus.Active && x.RefreshTokenExpiresOn > DateTime.UtcNow);
    }
}