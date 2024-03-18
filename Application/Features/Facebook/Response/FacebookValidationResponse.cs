using Newtonsoft.Json;

namespace Application.Features.Facebook.Response;

public class FacebookValidationResponse
{
    [JsonProperty("data")] public FacebookValidationData Data { get; set; } = new();
}

public class FacebookValidationData
{
    [JsonProperty("app_id")] public string AppId { get; set; } = null!;

    [JsonProperty("type")] public string Type { get; set; } = null!;

    [JsonProperty("application")] public string Application { get; set; } = null!;

    [JsonProperty("data_access_expires_at")]
    public long DataAccessExpiresAt { get; set; }

    [JsonProperty("expires_at")] public long ExpiresAt { get; set; }

    [JsonProperty("is_valid")] public bool IsValid { get; set; }

    [JsonProperty("scopes")] public List<string> Scopes { get; set; } = new();

    [JsonProperty("user_id")] public string UserId { get; set; } = null!;
}