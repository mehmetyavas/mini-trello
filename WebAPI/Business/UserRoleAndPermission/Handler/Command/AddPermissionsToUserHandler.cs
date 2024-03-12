using Core.Data;
using Core.Data.Entity;
using Core.Data.Entity.Default;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.UserRoleAndPermission.Request;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.UserRoleAndPermission.Handler.Command;

public class AddPermissionsToUserHandler : IRequestHandler<AddPermissionsToUserRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public AddPermissionsToUserHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(AddPermissionsToUserRequest request, CancellationToken cancellationToken)
    {
        CheckBasePermission(request.PermissionIds);


        var user = await _unitOfWork.Users
            .Query()
            .IgnoreAutoIncludes()
            .IgnoreQueryFilters()
            .Include(up => up.UserPermissions)
            .SingleOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(LangKeys.UserNotFound);
        }

        CheckUserPermissions(
            request.PermissionIds,
            user.UserPermissions.Select(x => x.ActionName));


        foreach (var permission in request.PermissionIds)
        {
            _unitOfWork.UserPermissions.Add(new UserPermission
            {
                ActionName = (ActionName)permission,
                User = user
            });
        }

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.Success);
    }

    /// <summary>
    /// user requestten gelen permissionı ekleyebilmek için BasePermission'a sahip olması gerekir
    /// </summary>
    /// <param name="requestPerms"></param>
    /// <param name="userPerms"></param>
    private void CheckUserPermissions(IEnumerable<int> requestPerms, IEnumerable<ActionName> userPerms)
    {
        var requestBasePermissions = requestPerms
            .Select(x => ((ActionName)x).GetControllerName().GetBaseActionName()).Distinct();


        if (!requestBasePermissions.Any(userPerms.Contains))
        {
            if (!requestPerms.Select(x => (ActionName)x).Any(requestBasePermissions.Contains))
            {
                throw new Exception(LangKeys.BaseActionRequired.Localize());
            }
        }
    }

    /// <summary>
    /// requestten gelen permissionlar aynı zamanda basePermission içeriyor olması gerekir?????
    /// </summary>
    /// <param name="requestPerms"></param>
    /// <exception cref="Exception"></exception>
    private void CheckBasePermission(IEnumerable<int> requestPerms)
    {
        // var basePermissions = requestPerms
        //     .Select(x => ((ActionName)x).GetControllerName().GetBaseActionName());
        //
        // var intersectPerms = requestPerms
        //     .Select(x => (ActionName)x).Intersect(basePermissions);
        // if (intersectPerms.Count() != basePermissions.Count())
        // {
        //     throw new Exception(LangKeys.BaseActionRequired.Localize());
        // }
    }
}