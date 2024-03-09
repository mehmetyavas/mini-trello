using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.User.Request;

public record DeleteUserCommand(Guid Id) : IRequest<IResult>;