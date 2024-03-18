using Application.Features.RolePermissions.Request;
using Core.Data;
using Core.Data.Dto.Permission;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RolePermissions.Handler.Query;

public class GetRolePermissionsHandler
    : IRequestHandler<GetRolePermissionsRequest, IResult<List<ControllerNameDto>>>
{
    private readonly UnitOfWork _unitOfWork;

    public GetRolePermissionsHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<List<ControllerNameDto>>> Handle(GetRolePermissionsRequest request,
        CancellationToken cancellationToken)
    {

        var rolePermissions = await _unitOfWork.RolePermissions
            .Query()
            .IgnoreQueryFilters()
            .IgnoreAutoIncludes()
            .Where(x => x.RoleId == request.RoleId)
            .Select(res => res.ActionId)
            .ToListAsync(cancellationToken);

        var roleActions = rolePermissions.GetPermissionDtos();


        return new SuccessResult<List<ControllerNameDto>>(roleActions.ToList());


    }
}