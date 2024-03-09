using Core.Attributes;
using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

namespace Core.Data.Enum;

public enum ActionName
{
    [ActionProperties(ControllerName.WeatherForecast, HttpMethod.Get, commonAction: true)]
    WeatherForecast,


    [ActionProperties(ControllerName.File, HttpMethod.Get, commonAction: true)]
    FileGet,

    [ActionProperties(ControllerName.File, HttpMethod.Post, commonAction: true)]
    FileCreate,

    [ActionProperties(ControllerName.File, HttpMethod.Delete, commonAction: true)]
    FileDelete,


    [ActionProperties(ControllerName.Permission, HttpMethod.Get)]
    PermissionGet,

    [ActionProperties(ControllerName.Role, HttpMethod.Get)]
    RoleGet,

    [ActionProperties(ControllerName.Role, HttpMethod.Post)]
    RoleCreate,

    [ActionProperties(ControllerName.Role, HttpMethod.Put)]
    RoleUpdate,

    [ActionProperties(ControllerName.Role, HttpMethod.Delete)]
    RoleDelete,


    [ActionProperties(ControllerName.Role, HttpMethod.Get)]
    RoleUserList,

    [ActionProperties(ControllerName.Role, HttpMethod.Post)]
    AddUserInRole,

    [ActionProperties(ControllerName.Role, HttpMethod.Delete)]
    RemoveUserInRole,


    [ActionProperties(ControllerName.RolePermission, HttpMethod.Get)]
    RolePermissionGet,

    [ActionProperties(ControllerName.RolePermission, HttpMethod.Post)]
    RolePermissionCreate,

    [ActionProperties(ControllerName.RolePermission, HttpMethod.Post)]
    RolePermissionDelete,


    [ActionProperties(ControllerName.User, HttpMethod.Get, commonAction: true)]
    UserGet,

    [ActionProperties(ControllerName.User, HttpMethod.Put, commonAction: true)]
    UserUpdate,

    [ActionProperties(ControllerName.User, HttpMethod.Put, commonAction: true)]
    UserAvatar,

    [ActionProperties(ControllerName.User, HttpMethod.Delete)]
    UserDelete,

    [ActionProperties(ControllerName.User, HttpMethod.Delete)]
    UserRemovePermission,

    [ActionProperties(ControllerName.User, HttpMethod.Delete)]
    UserRemoveRole,


    [ActionProperties(ControllerName.User, HttpMethod.Post)]
    UserAddPermission,

    [ActionProperties(ControllerName.User, HttpMethod.Post)]
    UserAddRole,

    [ActionProperties(ControllerName.User, HttpMethod.Get)]
    UserPermissionGet,

    [ActionProperties(ControllerName.User, HttpMethod.Get)]
    UserRoleGet,


    [ActionProperties(ControllerName.Admin, HttpMethod.Get)]
    TokenBlackList,

    [ActionProperties(ControllerName.Admin, HttpMethod.Post)]
    SyncUserLogins,
}