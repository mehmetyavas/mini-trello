using Core.Data.Enum;
using Core.Extensions;

namespace Core.Utilities.Results;

public class ErrorResult : Result
{
    public ErrorResult(string message)
        : base(false, message)
    {
    }
    public ErrorResult(LangKeys message)
        : base(false, message.Localize())
    {
    }

    public ErrorResult()
        : base(false)
    {
    }
}

public class ErrorResult<T> : Result<T>
{
    public ErrorResult(T data, string message)
        : base(data, false, message)
    {
    }
    public ErrorResult(T data, LangKeys message)
        : base(data, false, message.Localize())
    {
    }

    public ErrorResult(T data)
        : base(data, false)
    {
    }

    public ErrorResult(string message)
        : base(default!, false, message)
    {
    }
    public ErrorResult(LangKeys message)
        : base(default!, false, message.Localize())
    {
    }

    public ErrorResult()
        : base(default!, false)
    {
    }
}