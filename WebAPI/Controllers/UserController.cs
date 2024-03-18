using Application.Features.User.Request;
using Application.Features.User.Response;
using Core.Attributes;
using Core.Data.Dto.Auth;
using Core.Data.Enum;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers;

public class UserController : BaseController
{
    /// <summary>
    /// get Users 
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<UserResponse>>))]
    [ActionKey(ActionName.UserGet)]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetUsersQuery request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// delete user
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [BackOffice]
    [ActionKey(ActionName.UserDelete)]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteUserCommand request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }


    /// <summary>
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<AuthResponse>))]
    [ActionKey(ActionName.UserUpdate)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<AuthResponse>))]
    [ActionKey(ActionName.UserAvatar)]
    [HttpPut]
    public async Task<IActionResult> UpdateAvatar([FromBody] UpdateAvatarCommand request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<AuthResponse>))]
    [ActionKey(ActionName.UserAvatar)]
    [HttpDelete]
    public async Task<IActionResult> DeleteAvatar([FromBody] DeleteAvatarCommand request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }
}