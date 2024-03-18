using Application.Features.Permission.Request;
using Core.Data.Dto.Permission;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;

namespace Application.Features.Permission.Handler.Query;

public class GetPermissionsQuery : IRequestHandler<GetPermissionsRequest, IResult<List<ControllerNameDto>>>
{
    public async Task<IResult<List<ControllerNameDto>>> Handle(GetPermissionsRequest request,
        CancellationToken cancellationToken)
    {
        var actions = Enum.GetValues<ActionName>().AsEnumerable();

        var result = actions.GetPermissionDtos().ToList(); 
        
        
        await Task.CompletedTask;

        return new SuccessResult<List<ControllerNameDto>>(result);
    }
}