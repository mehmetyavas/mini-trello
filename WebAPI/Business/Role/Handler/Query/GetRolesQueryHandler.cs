using Core.Data;
using Core.Data.Dto.Pagination;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Role.Request;
using WebAPI.Business.Role.Response;
using WebAPI.Business.RolePermissions.Response;

namespace WebAPI.Business.Role.Handler.Query;

public class GetRolesQueryHandler : IRequestHandler<GetRolesRequest, IResult<PagingResponse<List<RoleResponse>>>>
{
    private readonly UnitOfWork _unitOfWork;

    public GetRolesQueryHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<PagingResponse<List<RoleResponse>>>> Handle(GetRolesRequest request, CancellationToken cancellationToken)
    {
        var query = request.IncludePermissions
            ? _unitOfWork.Roles
                .Query()
                .IgnoreQueryFilters()
                .IgnoreAutoIncludes()
                .Include(perm => perm.RolePermissions)
                .ThenInclude(act => act.Action)
                .AscOrDescOrder(request.SortDirection,request.SortBy)
            : _unitOfWork.Roles
                .Query()
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .AscOrDescOrder(request.SortDirection, request.SortBy);




        var roles = await _unitOfWork.Roles.PagingListAsync(request, query, cancellationToken);


        var rolesResponse = roles.List.Select(res => request.IncludePermissions
                ? new RoleResponse
                {
                    Role = res.Name,
                    Id = res.Id,
                    Status = res.RowStatus.Localize(),
                    Description = res.Description,
                    Permissions = res.RolePermissions.Select(rp => new RolePermissionResponse()
                        {
                            Id = (int)rp.ActionId,
                            Permission = rp.ActionId.Localize()
                        })
                        .ToList(),
                    IsStrict = res.IsStrict
                }
                : new RoleResponse
                {
                    Role = res.Name,
                    Id = res.Id,
                    Status = res.RowStatus.Localize(),
                    Description = res.Description,
                    IsStrict = res.IsStrict,
                });




        if (roles.List.Count < 1)
        {
            throw new Exception(LangKeys.AppError.Localize());
        }
        

        


        return new SuccessResult<PagingResponse<List<RoleResponse>>>(data: new PagingResponse<List<RoleResponse>>
            (data:rolesResponse.ToList(),
             pageSize:rolesResponse.Count(),
             currentPage:request.Page,
             totalItems:roles.count
             ),LangKeys.Success);
    }
}