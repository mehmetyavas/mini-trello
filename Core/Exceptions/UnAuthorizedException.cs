using Core.Data.Enum;
using Core.Extensions;

namespace Core.Exceptions;

[Serializable]
public class UnAuthorizedException : UnauthorizedAccessException
{

    public UnAuthorizedException() : base(LangKeys.UnAuthorized.Localize())
    {
    }

    public UnAuthorizedException(LangKeys message) : base(message.Localize())
    {
    }

    public UnAuthorizedException(string message) : base(message)
    {
    }
}