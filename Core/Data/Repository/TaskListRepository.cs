using Core.Data.Entity;
using Core.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repository;

public class TaskListRepository:BaseRepository<TaskList,AppDbContext>
{
    public TaskListRepository(AppDbContext context) : base(context)
    {
    }

    public IQueryable<TaskList> IncludeWorkSpace()
    {
        return Context.TaskLists
            .Include(ws => ws.WorkSpace);
    }
    
}