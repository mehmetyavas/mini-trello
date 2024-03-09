using Core.Data.Entity;
using Core.Data.Repository.Base;

namespace Core.Data.Repository;

public class UserRolesRepository : BaseRepository<UserRole, AppDbContext>
{
    public UserRolesRepository(AppDbContext context) : base(context)
    {
    }

}