using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.User.Request;

public record DeleteUserCommand(Guid Id) : IRequest<IResult>;