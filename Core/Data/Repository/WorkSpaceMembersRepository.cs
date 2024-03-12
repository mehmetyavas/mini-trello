using Core.Data.Entity;
using Core.Data.Repository.Base;

namespace Core.Data.Repository;

public class WorkSpaceMembersRepository:BaseRepository<WorkSpaceMember,AppDbContext>
{
    public WorkSpaceMembersRepository(AppDbContext context) : base(context)
    {
    }
}