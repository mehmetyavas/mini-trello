using System.ComponentModel.DataAnnotations;
using Core.Attributes;
using Core.Data.Enum;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Business.UserRoleAndPermission.Request;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers;

[BackOffice]
public class UserRoleAndPermissionController : BaseController
{
    /// <summary>
    /// remove permissions from user 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [ActionKey(ActionName.UserRemovePermission)]
    [HttpDelete]
    public async Task<IActionResult> RemovePermission(RemovePermissionsFromUserRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// delete Roles from user 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [ActionKey(ActionName.UserRemoveRole)]
    [HttpDelete]
    public async Task<IActionResult> DeleteRoles(RemoveRolesInUserRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// add permissions to user 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [ActionKey(ActionName.UserAddPermission)]
    [HttpPost]
    public async Task<IActionResult> AddPermission(AddPermissionsToUserRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// add roles to user 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [ActionKey(ActionName.UserAddRole)]
    [HttpPost]
    public async Task<IActionResult> AddRoles(AddRolesInUserRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// Get permissions By user 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [ActionKey(ActionName.UserPermissionGet)]
    [HttpGet]
    public async Task<IActionResult> UserPermissions([FromQuery, Required] Guid userId,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new GetPermissionsByUserRequest(userId), cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// Get Roles By User 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [ActionKey(ActionName.UserRoleGet)]
    [HttpGet]
    public async Task<IActionResult> UserRole([FromQuery, Required] Guid userId,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new GetRolesByUserRequest(userId), cancellationToken);

        return GetResponse(result);
    }
}