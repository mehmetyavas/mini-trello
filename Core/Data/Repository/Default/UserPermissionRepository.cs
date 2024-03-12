using Core.Data.Entity.Default;
using Core.Data.Enum;
using Core.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repository.Default;

public class UserPermissionRepository : BaseRepository<UserPermission, AppDbContext>
{
    public UserPermissionRepository(AppDbContext context) : base(context)
    {
    }


    public async Task<List<ActionName>> GetUserPermissions(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var roles = await Context.Roles
            .AsQueryable()
            .Include(rc => rc.UserRoles)
            .Include(rp => rp.RolePermissions)
            .ThenInclude(a => a.Action)
            .Where(x => x.UserRoles.Select(u => u.UserId).Contains(userId))
            .ToListAsync(cancellationToken);


        var userPermissions = await Context.UserPermissions
            .Where(x => x.UserId.Equals(userId))
            .Select(a => a.ActionName)
            .ToListAsync(cancellationToken);


        var rolePermissions = roles.Select(x => x.RolePermissions);

        foreach (var roleActions in rolePermissions)
        {
            userPermissions.AddRange(roleActions.Select(a => a.ActionId));
        }


        return userPermissions.Distinct().OrderBy(x => x).ToList();
    }
}