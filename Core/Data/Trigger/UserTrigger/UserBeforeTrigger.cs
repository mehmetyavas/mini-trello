using Core.Data.Entity;
using Core.Data.Entity.Default;
using Core.Data.Enum;
using Core.Data.Trigger.Base;
using Core.Extensions;
using EntityFrameworkCore.Triggered;

namespace Core.Data.Trigger.UserTrigger;

public class UserBeforeTrigger : IBeforeSaveTrigger<User>
{
    private readonly AppDbContext _dbContext;

    public UserBeforeTrigger(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task BeforeSave(ITriggerContext<User> context, CancellationToken cancellationToken)
    {

        if (context.ChangeType == ChangeType.Modified)
        { 
            if (!context.UnmodifiedEntity!.IsVerified&&
                context.Entity.IsVerified)
            {
                
                _dbContext.UserRoles.Add(new UserRole
                {
                    RoleId = (long)Roles.User,
                    User = context.Entity
                });
                
                _dbContext.WorkSpaces.Add(new WorkSpace
                {
                    Title = $"Welcome, {context.Entity.Fullname}",
                    Slug = $"Welcome, {context.Entity.Fullname}".ToSlug(),
                    Description = "Default Workspace",
                    CreatorUserId = context.Entity.Id,
                    CreatorUser = context.Entity,
                });
            }
        }

        await Task.CompletedTask;
        
    }
}