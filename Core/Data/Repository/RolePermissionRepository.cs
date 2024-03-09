using Core.Data.Entity;
using Core.Data.Repository.Base;

namespace Core.Data.Repository;

public class RolePermissionRepository : BaseRepository<RolePermission, AppDbContext>
{
    public RolePermissionRepository(AppDbContext context) : base(context)
    {
    }
}