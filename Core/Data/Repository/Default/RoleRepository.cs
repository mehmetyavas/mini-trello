using Core.Data.Entity.Default;
using Core.Data.Enum;
using Core.Data.Repository.Base;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repository.Default;

public class RoleRepository : BaseRepository<Role, AppDbContext>
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }

    /// <summary>
    /// It throws an error if the given role is present in the Roles enum list.
    /// </summary>
    /// <param name="role"></param>
    /// <exception cref="Exception"></exception>
    public void CheckStrictRoles(string? role)
    {
        
        var strictRoles = System.Enum.GetValues<Roles>().ToList();

        if (strictRoles.Any(x => x.ToString().Equals(role, StringComparison.InvariantCultureIgnoreCase)))
        {
            throw new Exception(LangKeys.StrictRoleCannotBeChanged.Localize());
        }
    }

    public bool IsStrictRole(string role)
    {
        var strictRoles = System.Enum.GetValues<Roles>().ToList();

        if (!strictRoles.Any(x => x.ToString().Equals(role, StringComparison.InvariantCultureIgnoreCase)))
        {
            return false;
        }

        return true;
    }

    public async Task CheckRoles(string role, CancellationToken cancellationToken = default)
    {
        var checkAllRoles = await Context.Roles
            .AsQueryable()
            .IgnoreAutoIncludes()
            .IgnoreQueryFilters()
            .AnyAsync(r => EF.Functions.ILike(r.Name, role),
                cancellationToken);

        if (checkAllRoles)
        {
            throw new Exception(LangKeys.ThisRoleExist.Localize());
        }
    }
}