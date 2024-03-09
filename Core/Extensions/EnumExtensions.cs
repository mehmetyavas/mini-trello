using System.Collections;
using System.Globalization;
using System.Resources;
using Core.Attributes;
using Core.Data.Dto.Permission;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Resources;
using Microsoft.OpenApi.Extensions;
using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

namespace Core.Extensions;

public static class EnumExtensions
{
    private static readonly ResourceManager ResourceManager = new(typeof(LangResources));

    public static string GetResxKey(this Enum enumValue)
    {
        switch (enumValue)
        {
            case LangKeys:
                return enumValue.ToString();
            default:
                return string.Concat(enumValue.GetType().Name, enumValue.ToString());
        }
    }

    public static string GetValueString(this ActionName value)
    {
        return ((int)value).ToString();
    }

    public static string GetValueString(this Roles value)
    {
        return ((int)value).ToString();
    }


    public static string Localize(this Enum enumValue)
    {
        var localized = ResourceManager.GetString(enumValue.GetResxKey());
        if (string.IsNullOrEmpty(localized))
        {
            return enumValue.ToString();
        }
        else
        {
            return localized;
        }
    }

    public static string Localize(this Enum enumValue, CultureInfo culture)
    {
        var localized = ResourceManager.GetString(enumValue.GetResxKey(), culture);
        if (string.IsNullOrEmpty(localized))
        {
            return enumValue.ToString();
        }
        else
        {
            return localized;
        }
    }

    public static string Localize(this Enum enumValue, ActionName[] actionNameParameters)
    {
        var localizedParams = actionNameParameters.Select(x => x.Localize()).ToArray();
        var localized = enumValue.Localize();
        if (string.IsNullOrEmpty(localized))
        {
            return string.Concat(enumValue.ToString(), localizedParams);
        }
        else
        {
            return string.Format(localized, localizedParams);
        }
    }

    public static string Localize(this Enum enumValue, string[] localizedParams)
    {
        var localized = enumValue.Localize();
        if (string.IsNullOrEmpty(localized))
        {
            return string.Concat(enumValue.ToString(), " ", string.Join(" ", localizedParams));
        }
        else
        {
            return string.Format(localized, localizedParams);
        }
    }

    /// <summary>
    /// returns base action by the controllername
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static ActionName GetBaseActionName(this ControllerName enumValue)
    {
        var attribute = enumValue.GetAttributeOfType<BaseActionNameAttribute>();

        if (attribute == null) throw new Exception(LangKeys.AppError.Localize());
        else return attribute.ActionName;
    }

    /// <summary>
    /// returns actions by the controllername
    /// </summary>
    /// <param name="controllerName"></param>
    /// <returns></returns>
    public static IEnumerable<ActionName> GetActionsOfControllerName(this ControllerName controllerName)
    {
        //TODO: kontrol edilecek
        var actions = Enum.GetValues<ActionName>().ToList();

        var deneme = actions.Where(x => x.GetControllerName() == controllerName);

        foreach (var action in actions)
        {
            var controller = action.GetControllerName();


            if (controller == controllerName)
            {
                yield return action;
            }
        }
    }

    /// <summary>
    /// returns controllername by the action
    /// </summary>
    /// <param name="actionName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static ControllerName GetControllerName(this ActionName actionName)
    {
        var attribute = actionName.GetAttributeOfType<ActionPropertiesAttribute>();

        if (attribute is null) throw new Exception(LangKeys.AppError.Localize());
        else return attribute.ControllerName;
    }

    /// <summary>
    /// returns HttpMethod by the action
    /// </summary>
    /// <param name="actionName"></param>
    /// <returns></returns>
    public static HttpMethod GetHttpMethod(this ActionName actionName)
    {
        var attribute = actionName.GetAttributeOfType<ActionPropertiesAttribute>();

        return attribute.Method;
    }

    public static string GetDisplayName(this HttpMethod method)
    {
        switch (method)
        {
            case HttpMethod.Get:
                return LangKeys.GetAction.Localize();
            case HttpMethod.Post:
                return LangKeys.PostAction.Localize();
            case HttpMethod.Delete:
                return LangKeys.DeleteAction.Localize();
            case HttpMethod.Put:
                return LangKeys.PutAction.Localize();
            default:
                return method.ToString();
        }
    }

    public static IEnumerable<ControllerNameDto> GetPermissionDtos(this IEnumerable<ActionName> actions)
    {
        var result = actions.GroupBy(g => g.GetControllerName()).Select(gPerm => new ControllerNameDto
        {
            ControllerName = gPerm.Key!.Localize(),
            Methods = gPerm
                .GroupBy(gAct => gAct.GetHttpMethod())
                .Select(act => new HttpMethodDto(act.Key)
                {
                    Permissions = act.Select(perm => new PermissionResponse(perm))
                        .OrderByDescending(ord => ord.BasePermission)
                })
                .ToList(),
            BasePermission = new PermissionResponse(gPerm.Key.GetBaseActionName())
        });

        return result;
    }

    /// <summary>
    /// this method checks if the permission values are actually actions
    /// </summary>
    /// <param name="permissions"></param>
    /// <exception cref="NotFoundException"></exception>
    public static void CheckPermissionValuesIsCorrect(List<int> permissions)
    {
        var actions = Enum.GetValues<ActionName>().ToList();

        var intersection = actions.Select(x => (int)x).Intersect(permissions);

        if (intersection.Count() != permissions.Count)
        {
            throw new NotFoundException(LangKeys.PermissionNotFound);
        }
    }
}