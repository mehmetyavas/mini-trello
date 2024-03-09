using Core.Data;
using Core.Data.Entity;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.UserRoleAndPermission.Request;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.UserRoleAndPermission.Handler.Command;

public class AddRolesInUserHandler : IRequestHandler<AddRolesInUserRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public AddRolesInUserHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(AddRolesInUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .IgnoreFilterAndInclude()
            .Include(ur => ur.UserRoles)
            .ThenInclude(r => r.Role)
            .Where(x => x.Id == request.UserId)
            .FirstOrDefaultAsync(cancellationToken);

        user = user.CheckNull(LangKeys.UserNotFound);

        var userRoles = user.UserRoles;


        var checkRoleIsExist = userRoles.Where(x => request.RoleId.Any(y => y == x.Role.Id));

        if (checkRoleIsExist.Any())
        {
            throw new Exception(LangKeys.ThisRoleExist.Localize());
        }


        var roles = await _unitOfWork.Roles
            .Query()
            .IgnoreAutoIncludes()
            .IgnoreQueryFilters()
            .Where(x => request.RoleId.Any(y => y == x.Id))
            .ToListAsync(cancellationToken);

        if (roles.Count != request.RoleId.Count)
        {
            throw new NotFoundException(LangKeys.RoleNotFound);
        }

        roles.ForEach(r =>
        {
            _unitOfWork.UserRoles.Add(new UserRole
            {
                Role = r,
                User = user
            });
        });

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.Success);
    }
}