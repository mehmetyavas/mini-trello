using System.ComponentModel.DataAnnotations;
using Application.Features.Role.Response;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.Role.Request;

public record GetUsersByRoleRequest([Required] long RoleId) : IRequest<IResult<UsersByRoleResponse>>;