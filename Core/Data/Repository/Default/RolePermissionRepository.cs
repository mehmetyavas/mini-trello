using Core.Data.Entity.Default;
using Core.Data.Repository.Base;

namespace Core.Data.Repository.Default;

public class RolePermissionRepository : BaseRepository<RolePermission, AppDbContext>
{
    public RolePermissionRepository(AppDbContext context) : base(context)
    {
    }
}