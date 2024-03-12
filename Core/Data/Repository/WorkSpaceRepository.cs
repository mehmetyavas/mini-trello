using Core.Data.Entity;
using Core.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repository;

public class WorkSpaceRepository : BaseRepository<WorkSpace, AppDbContext>
{
    public WorkSpaceRepository(AppDbContext context) : base(context)
    {
    }

    public IQueryable<WorkSpace> IncludeCreator()
    {
        return Context.WorkSpaces.Include(u => u.CreatorUser);
    }
}