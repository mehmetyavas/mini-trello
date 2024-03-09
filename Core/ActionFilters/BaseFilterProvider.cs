using System.Reflection;
using System.Security.Authentication;
using Core.Attributes;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.ActionFilters;

public class BaseFilterProvider : IFilterProvider
{
    public void OnProvidersExecuting(FilterProviderContext context)
    {
        if (context.ActionContext.ActionDescriptor is not ControllerActionDescriptor actionDescriptor)
        {
            return;
        }


        var controllerType = actionDescriptor.ControllerTypeInfo;

        var anonymousAttribute = controllerType.GetCustomAttribute<AllowAnonymousAttribute>()
            ??actionDescriptor.MethodInfo.GetCustomAttribute<AllowAnonymousAttribute>();


        var actionKeyAttributes =
            actionDescriptor.MethodInfo.GetCustomAttributes<ActionKeyAttribute>().ToList();

        if (anonymousAttribute is not null && !actionKeyAttributes.Any()) return;

        if (context.ActionContext.HttpContext.User.Identity is { IsAuthenticated: false })
        {
            throw new UnAuthorizedException(LangKeys.LoginRequired.Localize());
        }

        var user = context.ActionContext.HttpContext.User.GetClaimsDto();

        if (user.IsAdmin()) return;

        var permissionFilters = actionKeyAttributes.Select(attr => new PermissionFilter(attr.Permissions));

        foreach (var permissionFilter in permissionFilters)
        {
            context.Results.Add(new FilterItem(
                new FilterDescriptor(permissionFilter, FilterScope.Action),
                permissionFilter));
        }
    }

    public void OnProvidersExecuted(FilterProviderContext context)
    {
    }

    public int Order { get; } = 0;
}