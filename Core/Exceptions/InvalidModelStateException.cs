using Microsoft.AspNetCore.Mvc;

namespace Core.Exceptions;

public class InvalidModelStateException:Exception
{
    public InvalidModelStateException(SerializableError invalidKeys)
    {
        InvalidKeys = invalidKeys.Select(inValidKey => new KeyValuePair<string, string[]>(inValidKey.Key, (string[])inValidKey.Value)).ToList();
    }

    public List<KeyValuePair<string, string[]>> InvalidKeys { get; init; }
}