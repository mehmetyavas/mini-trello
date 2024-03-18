using Application.Features.Permission.Request;
using Application.Features.RolePermissions.Response;
using Core.Attributes;
using Core.Data.Enum;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers;

[BackOffice]
public class PermissionController : BaseController
{
    /// <summary>
    /// get Permissions 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<RolePermissionResponse>>))]
    [ActionKey(ActionName.PermissionGet)]
    [HttpGet]
    public async Task<IActionResult> GetPermissions(CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new GetPermissionsRequest(), cancellationToken);

        return GetResponse(result);
    }
}