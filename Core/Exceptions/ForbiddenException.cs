using System.Net;
using Core.Data.Enum;
using Core.Extensions;

namespace Core.Exceptions;

[Serializable]
public class ForbiddenException : Exception
{

    public ForbiddenException() : base(LangKeys.Forbidden.Localize())
    {
    }

    public ForbiddenException(LangKeys messageKey) : base(messageKey.Localize())
    {
        if (messageKey.Equals(LangKeys.TokenExpired)) IsTokenExpired = true;
    }


    public bool IsTokenExpired { get; init; }
}