using Application.Features.UserRoleAndPermission.Response;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.UserRoleAndPermission.Request;

public record GetPermissionsByUserRequest(Guid UserId):IRequest<IResult<UserPermissionResponse>>;