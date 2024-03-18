using System.ComponentModel.DataAnnotations;
using Application.Features.Role.Request;
using Application.Features.Role.Response;
using Core.Attributes;
using Core.Data.Enum;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers;

[BackOffice]
public class RoleController : BaseController
{
    /// <summary>
    /// get Role 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<RoleResponse>>))]
    [ActionKey(ActionName.RoleGet)]
    [HttpGet]
    public async Task<IActionResult> Get(int roleId, [FromQuery] bool includePermissions = false,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new GetRoleRequest(roleId), cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// get Roles 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<RoleResponse>>))]
    [ActionKey(ActionName.RoleGet)]
    [HttpGet]
    public async Task<IActionResult> GetRoles([FromQuery] GetRolesRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// create Role 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<RoleResponse>>))]
    [ActionKey(ActionName.RoleCreate)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleRequest request, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// update Role 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<RoleResponse>>))]
    [ActionKey(ActionName.RoleUpdate)]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateRoleRequest request, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// delete Role 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<RoleResponse>>))]
    [ActionKey(ActionName.RoleDelete)]
    [HttpDelete]
    public async Task<IActionResult> Delete(int roleId, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new DeleteRoleRequest(roleId), cancellationToken);

        return GetResponse(result);
    }


    /// <summary>
    /// get users by Role 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<UsersByRoleResponse>))]
    [ActionKey(ActionName.RoleUserList)]
    [HttpGet]
    public async Task<IActionResult> GetUsersByRole([FromQuery, Required] int roleId,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new GetUsersByRoleRequest(roleId), cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// add users  to role 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<RoleResponse>>))]
    [ActionKey(ActionName.AddUserInRole)]
    [HttpPost]
    public async Task<IActionResult> AddUsersInRole(AddUsersInRoleRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// delete users in Role 
    /// </summary>
    /// <returns> </returns>
    //TODO xml returns tagi araştır. Dönüş tipi obje olarak verilebiliyor mu
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<RoleResponse>>))]
    [ActionKey(ActionName.RemoveUserInRole)]
    [HttpDelete]
    public async Task<IActionResult> RemoveUsersInRole(RemoveUsersInRoleRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }
}