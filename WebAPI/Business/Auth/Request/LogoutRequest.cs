using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Auth.Request;

public class LogoutRequest : IRequest<IResult>
{
    public string AccessToken { get; set; } = null!;
}