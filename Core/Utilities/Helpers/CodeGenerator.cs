using System.Security.Cryptography;

namespace Core.Utilities.Helpers;

public static class CodeGenerator
{
    public static string CreateVerifyToken()
    {
        return Guid.NewGuid().ToString();
    }

    public static long CreateLoginCode() => new Random().NextInt64(100000, 999999);
}