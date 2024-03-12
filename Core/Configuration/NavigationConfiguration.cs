using Core.Data.Entity;
using Core.Data.Entity.Default;
using Microsoft.EntityFrameworkCore;

namespace Core.Configuration;

public static class NavigationConfiguration
{
    internal static void SetAutoIncludes(this ModelBuilder builder)
    {

        builder.Entity<User>().Navigation(x => x.UserLogins).AutoInclude();
        builder.Entity<User>().Navigation(x => x.UserRoles).AutoInclude();
        builder.Entity<User>().Navigation(x => x.UserPermissions).AutoInclude();
        builder.Entity<Role>().Navigation(x => x.RolePermissions).AutoInclude();

        builder.Entity<UserRole>().Navigation(x => x.Role).AutoInclude();
        builder.Entity<UserRole>().Navigation(x => x.User).AutoInclude();

        builder.Entity<RolePermission>().Navigation(x => x.Role).AutoInclude();
        builder.Entity<RolePermission>().Navigation(x => x.Action).AutoInclude();
    }
}