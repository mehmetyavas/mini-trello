using Core.Data.Entity;
using Core.Data.Enum;
using Core.Extensions;
using EntityFrameworkCore.Triggered;
using static EntityFrameworkCore.Triggered.ChangeType;

namespace Core.Data.Trigger;

public  class WorkSpaceBeforeTrigger:IBeforeSaveTrigger<WorkSpace>
{
    public async Task BeforeSave(ITriggerContext<WorkSpace> context, CancellationToken cancellationToken)
    {
        if (context.ChangeType == Added)
        {
            context.Entity.Slug = context.Entity.Title.ToSlug();
        }

        if (context is { ChangeType: Modified, Entity.RowStatus: RowStatus.Active })
        {
            context.Entity.Slug = context.Entity.Title.ToSlug();
        }

        await Task.CompletedTask;
    }
}