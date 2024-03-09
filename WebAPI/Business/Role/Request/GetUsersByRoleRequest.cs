using System.ComponentModel.DataAnnotations;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.Role.Response;

namespace WebAPI.Business.Role.Request;

public record GetUsersByRoleRequest([Required] long RoleId) : IRequest<IResult<UsersByRoleResponse>>;