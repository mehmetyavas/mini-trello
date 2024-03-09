using System.ComponentModel.DataAnnotations;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Role.Request;

public record DeleteRoleRequest([Required] long Id) : IRequest<IResult>;