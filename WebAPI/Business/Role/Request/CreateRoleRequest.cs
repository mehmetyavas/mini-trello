using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Role.Request;

public class CreateRoleRequest : IRequest<IResult>
{
    public string Role { get; set; } = null!;
    public string Description { get; set; } = null!;
}