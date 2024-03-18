using Application.Features.RolePermissions.Request;
using Application.Features.RolePermissions.Response;
using Core.Attributes;
using Core.Data.Enum;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers;

[BackOffice]
public class RolePermissionsController : BaseController
{
    /// <summary>
    /// get RolePermissions 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<RolePermissionResponse>>))]
    [ActionKey(ActionName.RolePermissionGet)]
    [HttpGet]
    public async Task<IActionResult> GetRolePermissions(int roleId, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new GetRolePermissionsRequest(roleId), cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// Create RolePermissions 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [ActionKey(ActionName.RolePermissionCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateRolePermissions(CreateRolePermissionRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// Delete RolePermissions 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [ActionKey(ActionName.RolePermissionDelete)]
    [HttpDelete]
    public async Task<IActionResult> DeleteRolePermissions(DeleteRolePermissionRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }
}