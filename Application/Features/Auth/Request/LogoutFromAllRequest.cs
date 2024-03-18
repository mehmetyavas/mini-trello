using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Auth.Request;

public record LogoutFromAllRequest() : IRequest<IResult>;