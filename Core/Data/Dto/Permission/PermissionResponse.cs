using Core.Data.Entity.Base;
using Core.Data.Enum;
using Core.Extensions;
using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

namespace Core.Data.Dto.Permission;

public class HttpMethodDto
{
    public HttpMethodDto(HttpMethod method)
    {
        Method = method.GetDisplayName();
    }

    public string Method { get; set; }
    public IEnumerable<PermissionResponse> Permissions { get; set; } = new List<PermissionResponse>();
}

public class PermissionResponse : IDto
{
    public PermissionResponse(ActionName action)
    {
        Id = (int)action;
        BasePermission = action.GetControllerName().GetBaseActionName() == action;
        PermissionName = action.Localize();
    }

    public  int Id { get; set; }
    public  bool BasePermission { get; set; }
    public  string PermissionName { get; set; }
    public string? ReadonlyBy { get; set; }
}