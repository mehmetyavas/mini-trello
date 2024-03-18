using Application.Features.Role.Request;
using Core.Data;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Role.Handler.Command;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public DeleteRoleCommandHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await _unitOfWork.Roles
            .Query()
            .IgnoreAutoIncludes()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(LangKeys.RoleNotFound);
        }

        _unitOfWork.Roles.CheckStrictRoles(role.Name);


        _unitOfWork.Roles.HardDelete(role);

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.Success);
    }
}