using Application.Features.TaskList.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;
using WebAPI.Services.OpenAI;

namespace WebAPI.Controllers;

[AllowAnonymous]
public class DenemeController : BaseController
{
    private OpenAiService _openAiService;

    private IMediator _mediator;

    public DenemeController(OpenAiService openAiService, IMediator mediator)
    {
        _openAiService = openAiService;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> CompleteSentence(string text)
    {
        var result = await _openAiService.CompleteSentence(text);

        return Ok(result);
    }

    [HttpPost]
    public IActionResult DenemeVal(CreateTaskListRequest request)
    {
        return Ok(request);
    }

    
    [HttpPost]
    public async Task<IActionResult> CreateTask(CreateTaskListRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}