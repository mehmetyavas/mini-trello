using Core.Attributes.CustomAttributes;
using Core.Data.Entity;
using Core.Data.Enum;
using Core.Extensions;
using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
using static EntityFrameworkCore.Triggered.ChangeType;
using Task = System.Threading.Tasks.Task;

namespace Core.Data.Trigger;

public class TaskListBeforeTrigger : IBeforeSaveTrigger<TaskList>
{
    private readonly AppDbContext _dbContext;

    public TaskListBeforeTrigger(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task BeforeSave(ITriggerContext<TaskList> context, CancellationToken cancellationToken)
    {
        var getMaxOrderNo = await _dbContext.TaskLists.Select(x => x.Order).MaxAsync(cancellationToken);

        if (getMaxOrderNo == byte.MaxValue)
        {
            throw new OverflowException(LangKeys.MaxTaskListValue.Localize());
        }

        if (context.ChangeType == Added)
        {
            context.Entity.Order = (byte)(getMaxOrderNo + 1);
            context.Entity.Slug = context.Entity.Title.ToSlug();
        }

        if (context is { ChangeType: Modified, Entity.RowStatus: RowStatus.Active })
        {
            context.Entity.Slug = context.Entity.Title.ToSlug();
        }

        await Task.CompletedTask;
    }
}