using Application.Features.UserRoleAndPermission.Response;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.UserRoleAndPermission.Request;

public record GetRolesByUserRequest(Guid UserId) : IRequest<IResult<UserRoleResponse>>;