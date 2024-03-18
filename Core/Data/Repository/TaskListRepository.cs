using Core.Data.Entity;
using Core.Data.Enum;
using Core.Data.Repository.Base;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repository;

public class TaskListRepository : BaseRepository<TaskList, AppDbContext>
{
    public TaskListRepository(AppDbContext context) : base(context)
    {
    }

    public IQueryable<TaskList> IncludeWorkSpace()
    {
        return Context.TaskLists
            .Include(ws => ws.WorkSpace);
    }

    public async Task CheckSlug(string title)
    {
        var task = await Context.TaskLists
            .IgnoreAutoIncludes()
            .AsNoTracking()
            .Select(x => x.Slug)
            .Where(x => x == title.ToSlug())
            .FirstOrDefaultAsync();

        if (task is not null)
        {
            throw new InvalidOperationException(LangKeys.TaskExist.Localize());
        }
    }

    public async Task<int> GenerateRowOrder(CancellationToken cancellationToken = default)
    {
        var query = Context.TaskLists
            .IgnoreAutoIncludes()
            .AsNoTracking()
            .Select(x => x.Order)
            .AsQueryable();

        var orderNos = await query.ToListAsync(cancellationToken);

        if (!orderNos.Any())
        {
            return 1;
        }

        var maxValue = orderNos.Max(x => x);

        if (maxValue == byte.MaxValue)
        {
            throw new OverflowException("Daha fazla task eklenemez");
        }

        return maxValue + 1;
    }


    public async Task UpdateOrderNos(byte order,long updatedIdOrder)
    {
        var tasklists = await Context.TaskLists
            .IgnoreAutoIncludes()
            .Where(x => x.Order >= order && x.Id != updatedIdOrder)
            .ToListAsync();

        var currentOrder = order;
        tasklists.ForEach(taskList =>
        {
            currentOrder++;
            taskList.Order = currentOrder;

            Context.TaskLists.Update(taskList);
        });
    }
}