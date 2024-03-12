using Core.Attributes;
using Core.Data.Entity.Default;
using Core.Data.Enum;
using Core.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using Action = Core.Data.Entity.Default.Action;

namespace Core.Data.Repository.Default;

public class ActionRepository : BaseRepository<Action, AppDbContext>
{
    public ActionRepository(AppDbContext context) : base(context)
    {
    }

    private async Task ClearClaims()
    {
        await Context.Actions.ExecuteDeleteAsync();
    }

    public async Task CreateBasePermission()
    {
        await ClearClaims();

        var actionNames = System.Enum.GetValues(typeof(ActionName)).Cast<ActionName>();


        var actionQuery = Context.Actions.AsQueryable();

        foreach (var item in actionNames)
        {
            var action = await actionQuery
                .FirstOrDefaultAsync(x => x.Id == item);


            if (action is not null)
                continue;

            var attribute = item.GetAttributeOfType<ActionPropertiesAttribute>();


            var addeedRecord = Context.Actions.Add(new Action
            {
                RowStatus = RowStatus.Active,
                Id = item,
                ActionName = item.ToString(),
                CreatedAt = DateTime.Now
            });


            if (attribute?.CommonAction == true)
            {
                Context.RolePermissions.Add(new RolePermission
                {
                    CreatedAt = DateTime.Now,
                    RoleId = (long)Roles.User,
                    Action = addeedRecord.Entity
                });
            }


            Context.RolePermissions.Add(new RolePermission
            {
                CreatedAt = DateTime.Now,
                RoleId = (long)Roles.Admin,
                Action = addeedRecord.Entity
            });
        }

        var recordsToDelete =
            await actionQuery
                .Where(x => !(actionNames.Contains(x.Id)))
                .ToListAsync();


        foreach (var item in recordsToDelete)
        {
            Context.Actions.Remove(item);
        }


        await Context.SaveChangesAsync();
    }
}