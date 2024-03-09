using Core.Data;
using Core.Data.Dto.User;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Role.Response;
using WebAPI.Business.RolePermissions.Response;
using WebAPI.Business.UserRoleAndPermission.Request;
using WebAPI.Business.UserRoleAndPermission.Response;

namespace WebAPI.Business.UserRoleAndPermission.Handler.Query;

public class GetRolesByUserHandler : IRequestHandler<GetRolesByUserRequest, IResult<UserRoleResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public GetRolesByUserHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<UserRoleResponse>> Handle(GetRolesByUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .Query()
            .IgnoreAutoIncludes()
            .IgnoreQueryFilters()
            .Include(ur => ur.UserRoles)
            .ThenInclude(r => r.Role)
            .Where(x => x.Id == request.UserId)
            .Select(selector: res => new UserRoleResponse
            {
                User = new UserDto
                {
                    Id = res.Id,
                    Email = res.Email,
                    Fullname = res.Fullname,
                    AvatarUrl = res.AvatarUrl
                },
                Roles = res.UserRoles.Select(ur => new RoleResponse
                {
                    Id = ur.Role.Id,
                    Role = ur.Role.Name,
                    Description = ur.Role.Description,
                    Status = ur.Role.RowStatus.Localize(),
                    IsStrict = ur.Role.IsStrict,
                    Permissions = new List<RolePermissionResponse>()
                })
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(LangKeys.UserNotFound);
        }

        return new SuccessResult<UserRoleResponse>(user);
    }
}