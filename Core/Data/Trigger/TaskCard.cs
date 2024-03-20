using Core.Data.Entity;
using Core.Data.Enum;
using Core.Extensions;
using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
using static EntityFrameworkCore.Triggered.ChangeType;
namespace Core.Data.Trigger;

public class TaskCardBeforeTrigger:IBeforeSaveTrigger<TaskCard>
{
    
    private readonly AppDbContext _dbContext;

    public TaskCardBeforeTrigger(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task BeforeSave(ITriggerContext<TaskCard> context, CancellationToken cancellationToken)
    {
        var getMaxOrderNo = await _dbContext.TaskCards.Select(x => x.Order).MaxAsync(cancellationToken);

        if (getMaxOrderNo == byte.MaxValue)
        {
            throw new OverflowException(LangKeys.MaxTaskListValue.Localize());
        }

        if (context.ChangeType == Added)
        {
            context.Entity.Order = (byte)(getMaxOrderNo + 1);
            context.Entity.Slug = context.Entity.Title.ToSlug();
            context.Entity.Priority = TaskPriority.Default;
        }

        if (context is { ChangeType: Modified, Entity.RowStatus: RowStatus.Active })
        {
            context.Entity.Slug = context.Entity.Title.ToSlug();
        }

        await Task.CompletedTask;
    }
}