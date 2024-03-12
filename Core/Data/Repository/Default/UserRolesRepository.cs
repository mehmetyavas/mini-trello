using Core.Data.Entity.Default;
using Core.Data.Repository.Base;

namespace Core.Data.Repository.Default;

public class UserRolesRepository : BaseRepository<UserRole, AppDbContext>
{
    public UserRolesRepository(AppDbContext context) : base(context)
    {
    }

}