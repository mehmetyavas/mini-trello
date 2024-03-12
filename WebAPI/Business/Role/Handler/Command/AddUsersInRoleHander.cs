using Core.Data;
using Core.Data.Entity;
using Core.Data.Entity.Default;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Role.Request;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Role.Handler.Command;

public class AddUsersInRoleHander : IRequestHandler<AddUsersInRoleRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public AddUsersInRoleHander(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(AddUsersInRoleRequest request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.Users
            .IgnoreFilterAndInclude()
            .Include(ur => ur.UserRoles)
            .ThenInclude(r => r.Role)
            .Where(x => request.UserId.Contains(x.Id))
            .ToListAsync(cancellationToken);

        if (users.Count != request.UserId.Count())
        {
            throw new NotFoundException(LangKeys.UserNotFound);
        }


        // check this user exist for this role before
        var userRole = users.SelectMany(ur => ur.UserRoles)
            .Any(x => x.RoleId == request.RoleId);

        if (userRole)
        {
            throw new Exception(LangKeys.ThisRoleExist.Localize());
        }

        var role = await _unitOfWork.Roles
            .Query()
            .FirstOrDefaultAsync(x => x.Id == request.RoleId, cancellationToken);

        role = role.CheckNull(LangKeys.RoleNotFound);

        foreach (var user in users)
        {
            _unitOfWork.UserRoles.Add(new UserRole
            {
                Role = role,
                User = user
            });
        }

        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult(LangKeys.Success);
    }
}