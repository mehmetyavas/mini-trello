using Application.Features.Auth;
using Application.Features.UserRoleAndPermission.Request;
using Core.Data;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.UserRoleAndPermission.Handler.Command;

public class RemoveRolesInUserHandler : IRequestHandler<RemoveRolesInUserRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly AuthManager _authManager;

    public RemoveRolesInUserHandler(UnitOfWork unitOfWork, AuthManager authManager)
    {
        _unitOfWork = unitOfWork;
        _authManager = authManager;
    }

    public async Task<IResult> Handle(RemoveRolesInUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .IgnoreFilterAndInclude()
            .Include(ur => ur.UserRoles)
            .ThenInclude(r => r.Role)
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        user = user.CheckNull(LangKeys.UserNotFound);


        var checkUserRoleCount = user.UserRoles.Count > 1;


        if (!checkUserRoleCount)
        {
            throw new Exception(LangKeys.UserMustHaveAtLeastOneRole.Localize());
        }


        var roles = user.UserRoles.Where(x => request.RoleIds.Contains(x.RoleId)).ToList();


        if (roles.Count() != request.RoleIds.Count)
        {
            throw new NotFoundException(LangKeys.RoleNotFound);
        }

        if ((user.UserRoles.Count - roles.Count) < 1)
        {
            throw new Exception(LangKeys.UserMustHaveAtLeastOneRole.Localize());
        }


        roles.ForEach(role =>
        {
            _unitOfWork.UserRoles.HardDelete(role); 
        });

        await _authManager.DeactivateUser(user.Id);

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.Deleted);
    }
}