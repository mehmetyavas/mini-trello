using Application.Features.RolePermissions.Request;
using Core.Data;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.RolePermissions.Handler.Command;

public class DeleteRolePermissionHandler : IRequestHandler<DeleteRolePermissionRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public DeleteRolePermissionHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //TODO: refactor this
    //TODO: if baseAction is deleted from role then delete other related permissions
    public async Task<IResult> Handle(DeleteRolePermissionRequest request, CancellationToken cancellationToken)
    {
        EnumExtensions.CheckPermissionValuesIsCorrect(request.PermissionId);


        var role = await _unitOfWork.Roles
            .Query()
            .IgnoreQueryFilters()
            .IgnoreAutoIncludes()
            .Include(rp => rp.RolePermissions)
            .ThenInclude(a => a.Action)
            .FirstOrDefaultAsync(x => x.Id == request.RoleId, cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(LangKeys.RoleNotFound);
        }

        var permissions = role.RolePermissions.ToList()
            .FindAll(x => request.PermissionId.Contains((int)x.ActionId));


        if (!permissions.Any())
        {
            throw new NotFoundException(LangKeys.PermissionNotFound);
        }


        permissions.ForEach(perm =>
        {
            if (perm.ActionId.GetControllerName().GetBaseActionName() == perm.ActionId)
            {
                var getControllerActions = perm.ActionId.GetControllerName().GetActionsOfControllerName();

                var permissionsToDelete = permissions.FindAll(x => getControllerActions.Contains(x.ActionId));

                permissionsToDelete.ForEach(p =>
                {
                    _unitOfWork.RolePermissions.HardDelete(p);
                    permissions.Remove(p);
                });
            }

            _unitOfWork.RolePermissions.HardDelete(perm);
        });


        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.Success);
    }
}