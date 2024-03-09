using Core.Data.Entity.Base;
using Newtonsoft.Json;

namespace WebAPI.Business.Facebook.Response;

public class FacebookResponse : IDto
{
    [JsonProperty("first_name")] public string FirstName { get; set; } = null!;

    [JsonProperty("last_name")] public string LastName { get; set; } = null!;

    [JsonProperty("picture")] public Picture Picture { get; set; } = null!;

    [JsonProperty("email")] public string Email { get; set; } = null!;

    [JsonProperty("id")] public string Id { get; set; } = null!;
}

public class Picture
{
    [JsonProperty("data")] public PictureData PictureData { get; set; } = new();
}

public class PictureData
{
    [JsonProperty("height")] public long Height { get; set; }

    [JsonProperty("is_silhouette")] public bool IsSilhouette { get; set; }

    [JsonProperty("url")] public Uri Url { get; set; } = null!;

    [JsonProperty("width")] public long Width { get; set; }
}