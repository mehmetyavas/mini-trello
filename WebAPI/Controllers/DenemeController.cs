using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;
using WebAPI.Services.OpenAI;

namespace WebAPI.Controllers;

[AllowAnonymous]
public class DenemeController:BaseController
{
    private OpenAiService _openAiService;

    public DenemeController(OpenAiService openAiService)
    {
        _openAiService = openAiService;
    }

    [HttpGet]
    public async Task<IActionResult> CompleteSentence(string text)
    {
        var result = await _openAiService.CompleteSentence(text);

        return Ok(result);
    }
}