using System.ComponentModel.DataAnnotations;
using Application.Features.Role.Response;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.Role.Request;

public record GetRoleRequest([Required] long RoleId, bool IncludePermissions = false) : IRequest<IResult<RoleResponse>>;