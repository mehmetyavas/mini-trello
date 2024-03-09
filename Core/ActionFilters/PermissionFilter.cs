using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.ActionFilters;

public class PermissionFilter : IActionFilter
{
    private ICollection<ActionName> ActionNames { get; }

    public PermissionFilter(ICollection<ActionName> actionNames)
    {
        ActionNames = actionNames;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!ActionNames.Any()) return;
        var userPermissions = context.HttpContext.User.GetPermissions();


        if (!userPermissions.Any(x => ActionNames.Contains(x)))
        {
            throw new ForbiddenException(LangKeys.LackOfPermission);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}