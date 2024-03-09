using Core.Data.Dto.Permission;
using Core.Utilities.Results;
using MediatR;

namespace WebAPI.Business.Permission.Request;

public class GetPermissionsRequest : IRequest<IResult<List<ControllerNameDto>>>
{
}