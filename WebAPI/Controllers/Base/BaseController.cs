using Core.Attributes;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers.Base;

/// <inheritdoc />
[ApiController]
[Route("api/[controller]/[action]")]
[Authorize]
[NeedPermission]
public class BaseController : Controller
{
    private IMediator? _mediator;

    /// <summary>
    /// It is for getting the Mediator instance creation process from the base controller.
    /// </summary>
    protected IMediator Mediator => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>())!;

    /// <summary>
    /// Get Result response with Data Parameter
    /// </summary>
    /// <param name="result"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>returns data type of T with result</returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetResponse<T>(IResult<T> result)
    {
        return result.Success
            ? Ok(result)
            : BadRequest(result);
    }

    /// <summary>
    /// Get Result Response Without  Data
    /// </summary>
    /// <param name="result"></param>
    /// <returns> returns only result</returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetResponse(IResult result)
    {
        return result.Success
            ? Ok(result)
            : BadRequest(result);

        //TODO BadRequest hiç bir zaman dönmüyor. Burayı tekrar kurgula ve bana kontrol ettir.
    }

    /// <summary>
    /// get Response without result
    /// </summary>
    /// <param name="result"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>returns data only type of T</returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetResponseOnlyResultData<T>(IResult<T> result)
    {
        return result.Success
            ? Ok(result.Data)
            : BadRequest(result.Message);
    }


    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<string> GetAccessToken()
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        return token!;
    }
}