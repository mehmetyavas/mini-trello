using Core.Data.Enum;
using Core.Extensions;

namespace Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base(LangKeys.NotFound.Localize())
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(LangKeys message) : base(message.Localize())
    {
    }
}