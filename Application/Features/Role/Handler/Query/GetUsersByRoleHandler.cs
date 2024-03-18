using Application.Features.Role.Request;
using Application.Features.Role.Response;
using Application.Features.RolePermissions.Response;
using Core.Data;
using Core.Data.Dto.User;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Role.Handler.Query;

public class GetUsersByRoleHandler : IRequestHandler<GetUsersByRoleRequest, IResult<UsersByRoleResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public GetUsersByRoleHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<UsersByRoleResponse>> Handle(GetUsersByRoleRequest request,
        CancellationToken cancellationToken)
    {
        var role = await _unitOfWork.Roles
            .Query()
            .IgnoreAutoIncludes()
            .IgnoreQueryFilters()
            .Include(ur => ur.UserRoles)
            .ThenInclude(u => u.User)
            .Where(r => r.Id == request.RoleId)
            .Select(res => new UsersByRoleResponse
            {
                Users = res.UserRoles.Select(userRole => new UserDto
                {
                    Id = userRole.User.Id,
                    Email = userRole.User.Email,
                    Fullname = userRole.User.Fullname,
                    AvatarUrl = userRole.User.AvatarUrl
                }),
                Roles = new RoleResponse
                {
                    Id = res.Id,
                    Role = res.Name,
                    Description = res.Description,
                    Status = res.RowStatus.Localize(),
                    IsStrict = res.IsStrict,
                    Permissions = new List<RolePermissionResponse>()
                }
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(LangKeys.RoleNotFound);
        }

        return new SuccessResult<UsersByRoleResponse>(role);
    }
    
    
    
}