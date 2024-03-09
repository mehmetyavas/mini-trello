using System.ComponentModel.DataAnnotations;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.Role.Response;

namespace WebAPI.Business.Role.Request;

public record GetRoleRequest([Required] long RoleId, bool IncludePermissions = false) : IRequest<IResult<RoleResponse>>;