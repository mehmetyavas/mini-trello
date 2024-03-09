using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Auth.Request;

public record LogoutFromAllRequest() : IRequest<IResult>;