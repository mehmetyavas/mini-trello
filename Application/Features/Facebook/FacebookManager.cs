using Application.Features.Facebook.Response;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Newtonsoft.Json;

namespace Application.Features.Facebook;

public class FacebookManager
{
    private string TokenValidationUrl { get; }
    private string UserInfoUrl { get; }

    private readonly IHttpClientFactory _client;

    public FacebookManager(IHttpClientFactory client)
    {
        _client = client;
        TokenValidationUrl = AppConfig.Facebook.Links.TokenValidationUrl;
        UserInfoUrl = AppConfig.Facebook.Links.UserInfoUrl;
    }

    public async Task<IResult<FacebookValidationResponse>> ValidateToken(string accessToken,
        CancellationToken cancellationToken = default)
    {
        var formattedUrl = string.Format(TokenValidationUrl,
            accessToken,
            AppConfig.Facebook.Login.AppId,
            AppConfig.Facebook.Login.AppSecret);

        var result = await _client.CreateClient().GetAsync(formattedUrl, cancellationToken);
        result.EnsureSuccessStatusCode();

        var response = await result.Content.ReadAsStringAsync(cancellationToken);

        var deserialize = JsonConvert.DeserializeObject<FacebookValidationResponse>(response);

        return new SuccessResult<FacebookValidationResponse>(deserialize!);
    }

    public async Task<IResult<FacebookResponse>> GetUserInfo(string accessToken,
        CancellationToken cancellationToken = default)
    {
        var formattedUrl = string.Format(UserInfoUrl,
            "first_name,last_name,picture,email",
            accessToken);

        var result = await _client.CreateClient().GetAsync(formattedUrl, cancellationToken);
        result.EnsureSuccessStatusCode();

        var response = await result.Content.ReadAsStringAsync(cancellationToken);

        var deserialize = JsonConvert.DeserializeObject<FacebookResponse>(response);

        return new SuccessResult<FacebookResponse>(deserialize!);
    }
}