using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.UserRoleAndPermission.Response;

namespace WebAPI.Business.UserRoleAndPermission.Request;

public record GetPermissionsByUserRequest(Guid UserId):IRequest<IResult<UserPermissionResponse>>;