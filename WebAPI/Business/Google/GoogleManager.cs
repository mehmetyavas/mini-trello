using System.Net;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Newtonsoft.Json;
using WebAPI.Business.Google.Response;

namespace WebAPI.Business.Google;

public class GoogleManager
{
    private readonly IHttpClientFactory _clientFactory;

    public GoogleManager(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IResult<GoogleRawTokenDto>> GetUserInfo(string token,
        CancellationToken cancellationToken = default)
    {
        var userinfoRequest = new HttpRequestMessage(HttpMethod.Get, AppConfig.Google.UserInfoUrl);
        userinfoRequest.Headers.Add("Authorization", $"Bearer {token}");


        var result = await _clientFactory.CreateClient().SendAsync(userinfoRequest, cancellationToken);


        if (result.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnAuthorizedException(LangKeys.GoogleTokenError);
        }

        result.EnsureSuccessStatusCode();

        var response = await result.Content.ReadAsStringAsync(cancellationToken);


        var mapUserInfo = JsonConvert.DeserializeObject<GoogleRawTokenDto>(response);


        return new SuccessResult<GoogleRawTokenDto>(mapUserInfo!);
    }
}