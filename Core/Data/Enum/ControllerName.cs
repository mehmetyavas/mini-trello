using Core.Attributes;

namespace Core.Data.Enum;

public enum ControllerName
{
    [BaseActionName(ActionName.WeatherForecast)]
    WeatherForecast,
    [BaseActionName(ActionName.RoleGet)] Role,
    [BaseActionName(ActionName.FileGet)] File,
    [BaseActionName(ActionName.UserGet)] User,

    [BaseActionName(ActionName.TokenBlackList)]
    Admin,

    [BaseActionName(ActionName.PermissionGet)]
    Permission,

    [BaseActionName(ActionName.RolePermissionGet)]
    RolePermission
}