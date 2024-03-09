using Core.Data;
using Core.Data.Dto.Permission;
using Core.Data.Dto.User;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.UserRoleAndPermission.Request;
using WebAPI.Business.UserRoleAndPermission.Response;

namespace WebAPI.Business.UserRoleAndPermission.Handler.Query;

public class GetPermissionsByUserHandler : IRequestHandler<GetPermissionsByUserRequest, IResult<UserPermissionResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public GetPermissionsByUserHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<UserPermissionResponse>> Handle(GetPermissionsByUserRequest request,
        CancellationToken cancellationToken)
    {
        // burada hem userin rollerinin permissionlarını hem de userin permissionlarını alıcaz.
        //rollerin permissionlarıni ayırt edebilecek bir değişken olmalı

        var roleQuery = _unitOfWork.UserRoles
            .Query()
            .IgnoreAutoIncludes()
            .IgnoreQueryFilters()
            .Include(x => x.User)
            .Include(r => r.Role)
            .ThenInclude(rp => rp.RolePermissions)
            .Where(x => x.UserId == request.UserId);

        var user = await roleQuery.Select(user => new UserDto
        {
            Id = user.User.Id,
            Email = user.User.Email,
            Fullname = user.User.Fullname,
            AvatarUrl = user.User.AvatarUrl
        }).FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(LangKeys.UserNotFound);
        }

        var rolePermission = await roleQuery
            .SelectMany(rPerm => rPerm.Role.RolePermissions.Select(act => new PermissionResponse(act.ActionId)
            {
                ReadonlyBy = act.Role.Name
            }))
            .ToListAsync(cancellationToken);


        var userPermission = await _unitOfWork.UserPermissions
            .Query()
            .IgnoreAutoIncludes()
            .IgnoreQueryFilters()
            .Where(x => x.UserId == request.UserId)
            .Select(act => new PermissionResponse(act.ActionName))
            .ToListAsync(cancellationToken);


        var concat = rolePermission
            .Concat(userPermission)
            .GroupBy(x => x.Id)
            .SelectMany(x => x)
            .DistinctBy(x => x.Id);

        var response = new UserPermissionResponse
        {
            User = user,
            Permissions = concat
                .GroupBy(g => ((ActionName)g.Id).GetControllerName())
                .Select(x => new ControllerNameDto
                {
                    ControllerName = x.Key.Localize(),
                    Methods = x.ToList()
                        .GroupBy(gHttp => ((ActionName)gHttp.Id).GetHttpMethod())
                        .Select(act => new HttpMethodDto(act.Key)
                        {
                            Permissions = act
                                .Select(perm => new PermissionResponse((ActionName)perm.Id)
                                {
                                    ReadonlyBy = perm.ReadonlyBy
                                })
                                .OrderByDescending(ord => ord.BasePermission)
                        }).ToList(),
                    BasePermission = new PermissionResponse(x.Key.GetBaseActionName())
                })
        };

        return new SuccessResult<UserPermissionResponse>(response);
    }
}