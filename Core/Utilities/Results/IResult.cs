using Newtonsoft.Json;

namespace Core.Utilities.Results;

public interface IResult
{
    [JsonProperty("success")] bool Success { get; }
    [JsonProperty("message")] string? Message { get; }
}

public interface IResult<out T> : IResult
{
    T Data { get; }
}