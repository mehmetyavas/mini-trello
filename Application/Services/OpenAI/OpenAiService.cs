using Core.Utilities.Helpers;
using OpenAI_API;

namespace WebAPI.Services.OpenAI;

public class OpenAiService
{


    public async Task<string> CompleteSentence(string text)
    {

        var api = new OpenAIAPI(AppConfig.OpenAIKey);
        var result = await api.Completions.GetCompletion(text);
        return result;

    }
}