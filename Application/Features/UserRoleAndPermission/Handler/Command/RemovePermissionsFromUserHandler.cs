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

public class RemovePermissionsFromUserHandler : IRequestHandler<RemovePermissionsFromUserRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public RemovePermissionsFromUserHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(RemovePermissionsFromUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .Query()
            .Include(up => up.UserPermissions)
            .Where(x => x.Id == request.UserId)
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(LangKeys.UserNotFound);
        }

        if (request.PermissionIds.Count() > user.UserPermissions.Count)
        {
            throw new ArgumentException(LangKeys.PermissionError.Localize());
        }

        var intersection = user.UserPermissions.Select(x => (int)x.ActionName).Intersect(request.PermissionIds);

        if (intersection.Count() != request.PermissionIds.Count())
        {
            throw new ArgumentException(LangKeys.PermissionError.Localize());
        }

        foreach (var permission in request.PermissionIds)
        {
            _unitOfWork.UserPermissions.HardDelete(user.UserPermissions.Single(x => (int)x.ActionName == permission));
        }

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.Deleted);
    }
}