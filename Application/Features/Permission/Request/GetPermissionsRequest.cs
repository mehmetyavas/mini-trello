using Core.Data.Dto.Permission;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.Permission.Request;

public class GetPermissionsRequest : IRequest<IResult<List<ControllerNameDto>>>
{
}