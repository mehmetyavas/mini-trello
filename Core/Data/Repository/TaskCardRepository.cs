using Core.Data.Entity;
using Core.Data.Repository.Base;

namespace Core.Data.Repository;

public class TaskCardRepository:BaseRepository<TaskCard,AppDbContext>
{
    public TaskCardRepository(AppDbContext context) : base(context)
    {
    }
}