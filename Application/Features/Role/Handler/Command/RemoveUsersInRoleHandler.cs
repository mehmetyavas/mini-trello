using Application.Features.Auth;
using Application.Features.Role.Request;
using Core.Data;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Role.Handler.Command;


public class RemoveUsersInRoleHandler : IRequestHandler<RemoveUsersInRoleRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly AuthManager _authManager;

    public RemoveUsersInRoleHandler(UnitOfWork unitOfWork, AuthManager authManager)
    {
        _unitOfWork = unitOfWork;
        _authManager = authManager;
    }

    public async Task<IResult> Handle(RemoveUsersInRoleRequest request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.Users
            .IgnoreFilterAndInclude()
            .Include(ur => ur.UserRoles)
            .ThenInclude(r => r.Role)
            .Where(x => request.Email.Contains(x.Email))
            .ToListAsync(cancellationToken);

        if (users.Count != request.Email.Count())
        {
            throw new NotFoundException(LangKeys.UserNotFound.Localize());
        }

        var checkUserRoleCount = users.SelectMany(x => x.UserRoles);

        var checkRoles = checkUserRoleCount.GroupBy(x => x.UserId);


        foreach (var role in checkRoles)
        {
            if (role.Select(x => x.Role).Count() < 2)
            {
                throw new NotFoundException(LangKeys.UserMustHaveAtLeastOneRole);
            }
        }


        var userRoles = users.SelectMany(r => r.UserRoles)
            .Where(x => x.RoleId == request.RoleId)
            .ToList();

        if (!userRoles.Any(x => request.Email.Contains(x.User.Email)))
        {
            throw new Exception(LangKeys.RoleNotFound.Localize());
        }

        foreach (var userRole in userRoles)
        {
            _unitOfWork.UserRoles.HardDelete(userRole);
        }

        await _authManager.DeactivateUser(userRoles.Select(x => x.UserId).ToList());

        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult(LangKeys.Deleted);
    }
}