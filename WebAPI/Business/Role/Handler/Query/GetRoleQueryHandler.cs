using Core.Data;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Role.Request;
using WebAPI.Business.Role.Response;
using WebAPI.Business.RolePermissions.Response;

namespace WebAPI.Business.Role.Handler.Query;

public class GetRoleQueryHandler : IRequestHandler<GetRoleRequest, IResult<RoleResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public GetRoleQueryHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<RoleResponse>> Handle(GetRoleRequest request, CancellationToken cancellationToken)
    {
        var role = request.IncludePermissions
            ? await _unitOfWork.Roles
                .Query()
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .Include(perm => perm.RolePermissions)
                .ThenInclude(action => action.Action)
                .FirstOrDefaultAsync(x => x.Id == request.RoleId,
                    cancellationToken)
            : await _unitOfWork.Roles
                .Query()
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Id == request.RoleId,
                    cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(LangKeys.RoleNotFound.Localize());
        }


        var result = new RoleResponse
        {
            Role = role.Name,
            Id = role.Id,
            Description = role.Description,
            Status = role.RowStatus.Localize(),
            Permissions = request.IncludePermissions
                ? role.RolePermissions.Select(rp => new RolePermissionResponse
                    {
                        Id = (int)rp.ActionId,
                        Permission = rp.ActionId.Localize()
                    })
                    .ToList()
                : new List<RolePermissionResponse>(),
            IsStrict = role.IsStrict
        };


        return new SuccessResult<RoleResponse>(result);
    }
}