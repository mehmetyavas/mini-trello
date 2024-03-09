using Core.Data;
using Core.Data.Entity;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.RolePermissions.Request;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.RolePermissions.Handler.Command;

public class CreateRolePermissionHandler : IRequestHandler<CreateRolePermissionRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public CreateRolePermissionHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //TODO: refactor this
    public async Task<IResult> Handle(CreateRolePermissionRequest request, CancellationToken cancellationToken)
    {
        if (request.PermissionId.Count < 1)
        {
            throw new InvalidOperationException(LangKeys.ActionRequired.Localize());
        }

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

        var rolePermissions = role.RolePermissions.Select(x => (int)x.ActionId).ToList();


        CheckRequestIncludesBasePermissions(
            rolePermissions: rolePermissions,
            request: request.PermissionId
        );


        var newPermissions = request.PermissionId.Except(rolePermissions);


        foreach (var newPerm in newPermissions)
        {
            _unitOfWork.RolePermissions.Add(new RolePermission
            {
                ActionId = (ActionName)newPerm,
                Role = role,
            });
        }

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.Success);
    }

    #region ValidationMethods

    private void CheckRequestIncludesBasePermissions(IReadOnlyCollection<int> rolePermissions,
        IReadOnlyCollection<int> request)
    {
        var requestBaseActions =
            request.Select(x => ((ActionName)x).GetControllerName().GetBaseActionName()).Distinct();


        var checkRoleBaseAction =
            rolePermissions.Count > 0 &&
            rolePermissions.Any(x => requestBaseActions.Contains((ActionName)x));

        if (!checkRoleBaseAction)
        {
            var requestActions = request.Select(x => (ActionName)x);

            if (!requestBaseActions.Any(x => requestActions.Contains(x)))
            {
                throw new InvalidOperationException(LangKeys.BaseActionRequired.Localize());
            }
        }
    }

    #endregion
}