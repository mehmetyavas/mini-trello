using Newtonsoft.Json;

namespace Application.Features.Google.Response;

public class GoogleRawTokenDto
{
    [JsonProperty("sub")] public string Sub { get; set; } = null!;
    [JsonProperty("name")] public string Name { get; set; } = null!;
    [JsonProperty("given_name")] public string GivenName { get; set; } = null!;
    [JsonProperty("family_name")] public string FamilyName { get; set; } = null!;
    [JsonProperty("picture")] public string Picture { get; set; } = null!;
    [JsonProperty("email")] public string Email { get; set; } = null!;
    [JsonProperty("email_verified")] public bool EmailVerified { get; set; }
    [JsonProperty("locale")] public string Locale { get; set; } = null!;
}