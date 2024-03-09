using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.UserRoleAndPermission.Response;

namespace WebAPI.Business.UserRoleAndPermission.Request;

public record GetRolesByUserRequest(Guid UserId) : IRequest<IResult<UserRoleResponse>>;