using Core.Attributes;
using Core.Data.Dto.Auth;
using Core.Data.Enum;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Business.Auth;
using WebAPI.Business.Auth.Request;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers;

[AllowAnonymous]
public class AuthController : BaseController
{
    private readonly AuthManager _auth;

    public AuthController(AuthManager authManager)
    {
        _auth = authManager;
    }

    /// <summary>
    /// Login the System
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// Token for Authentication
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<AuthResponse>))]
    [HttpPost]
    public async Task<IActionResult> LoginVerify([FromBody] LoginVerifyRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// Register the System
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequest register,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(register, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// Verify The User
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [HttpPost]
    public async Task<IActionResult> RegisterVerify([FromBody] RegisterVerifyRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// logout
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [HttpDelete]
    public async Task<IActionResult> Logout(CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new LogoutRequest { AccessToken = await GetAccessToken() }, cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [HttpDelete]
    public async Task<IActionResult> LogoutFromAll(CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new LogoutFromAllRequest(), cancellationToken);

        return GetResponse(result);
    }

    /// <summary>
    /// Authenticate From RefreshToken
    /// </summary>
    /// <returns> </returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<AuthResponse>))]
    //TODO burayı sadeleştir sadece HttpPost ve SuccessResponseType kalsa yeter 
    [HttpPost]
    public async Task<IActionResult> RefreshToken(LoginWithToken request, CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(request, cancellationToken);

        return GetResponse(result);
    }


    /// <summary>
    ///  Get Token Black List From Redis Memory
    /// </summary>
    /// <remarks>Tokens in the list, will be blocked</remarks>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult<List<string>>))]
    [HttpGet]
    [BackOffice]
    [ActionKey(ActionName.TokenBlackList)]
    public IActionResult TokenBlackList()
    {
        return GetResponse(_auth.GetTokenBlackList());
    }

    /// <summary>
    /// Refresh Token Black List.
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResult))]
    [HttpPost]
    [BackOffice]
    [ActionKey(ActionName.SyncUserLogins)]
    public IActionResult RefreshTokenBlackList()
    {
        return GetResponse(_auth.SyncDefunctUserLoginsRequest());
    }
}