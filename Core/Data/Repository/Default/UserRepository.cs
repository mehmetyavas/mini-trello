using System.Security.Claims;
using Core.Data.Dto.Auth;
using Core.Data.Dto.User;
using Core.Data.Entity.Default;
using Core.Data.Enum;
using Core.Data.Repository.Base;
using Core.Exceptions;
using Core.Utilities.Helpers;
using Core.Utilities.Security.Jwt;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repository.Default;

public class UserRepository : BaseRepository<User, AppDbContext>
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }


    public async Task<long> LoginCode()
    {
        long newCode;
        do
            newCode = CodeGenerator.CreateLoginCode();
        while (await Context.Users.AnyAsync(x => x.LoginCode == newCode));

        return newCode;
    }


    public async Task Provider(LoginProvider provider, string value, bool rememberMe)
    {
    }


    public UserClaimsDto LoginClaims(User user)
    {
        if (user is null)
        {
            throw new Exception(LangKeys.UserNotFound.ToString());
        }

        return new UserClaimsDto
        {
            Id = user.Id,
            GivenName = user.Fullname,
            Email = user.Email,
            Roles = user.Roles(),
            Permissions = user.Permissions(),
            AvatarUrl = user.AvatarUrl
        };
    }

    public async Task<UserClaimsDto> LoginClaims(string email)
    {
        var user = await FindByEmailForLoginClaims(email);

        if (user is null)
        {
            throw new Exception(LangKeys.UserNotFound.ToString());
        }

        return new UserClaimsDto
        {
            Id = user.Id,
            GivenName = user.Fullname,
            Email = user.Email,
            Roles = user.Roles(),
            Permissions = user.Permissions(),
            AvatarUrl = user.AvatarUrl
        };
    }

    public async Task<UserClaimsDto> LoginClaims(TokenDto input)
    {
        var accessTokenValidationResult = await JwtHelper.ValidateExpiredToken(input.AccessToken);

        if (!accessTokenValidationResult.IsValid) throw new UnAuthorizedException();

        var refreshTokenValidationResult = await JwtHelper.ValidateRefreshToken(input.RefreshToken);

        if (!refreshTokenValidationResult.IsValid) throw new ForbiddenException();


        var email = accessTokenValidationResult.Claims[ClaimTypes.Email].ToString();

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ApplicationException(LangKeys.EmailPermissionRequired.ToString());
        }

        var user = await FindByEmailForLoginClaims(email!);


        if (user is null)
        {
            throw new Exception(LangKeys.UserNotFound.ToString());
        }
        //user.NullCheck(LangKeys.UserNotFound);

        return new UserClaimsDto
        {
            Id = user.Id,
            GivenName = user.Fullname,
            Email = user.Email,
            Roles = user.Roles(),
            Permissions = user.Permissions(),
            AvatarUrl = user.AvatarUrl,
            // MobilePhones = user.MobilePhones
        };
    }

    private async Task<User?> FindByEmailForLoginClaims(string email)
    {
        return await Context.Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .ThenInclude(x => x.RolePermissions)
            .SingleOrDefaultAsync(x => x.Email == email);
    }


    public IQueryable<User> IgnoreFilterAndInclude()
    {
        return Context.Users
            .AsQueryable()
            .IgnoreAutoIncludes()
            .IgnoreQueryFilters();
    }
}