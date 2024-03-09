using Core.Data;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Role.Request;
using WebAPI.Business.Role.Response;

namespace WebAPI.Business.Role.Handler.Command;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleRequest, IResult<RoleResponse>>
{
    private readonly UnitOfWork _unitOfWork;

    public UpdateRoleCommandHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<RoleResponse>> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(request.Role))
        {
            _unitOfWork.Roles.CheckStrictRoles(request.Role);
        }


        var role = await _unitOfWork.Roles
            .Query()
            .IgnoreAutoIncludes()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(r => r.Id == request.RoleId,
                cancellationToken);
        
        role = role.CheckNull(LangKeys.RoleNotFound);


        if (!string.IsNullOrWhiteSpace(request.Role))
        {
            role.Name = request.Role;
        }

        if (!string.IsNullOrWhiteSpace(request.Description))
        {
            role.Description = request.Description;
        }

        role.RowStatus = request.Status ?? role.RowStatus;

        _unitOfWork.Roles.Update(role);

        await _unitOfWork.SaveAsync(cancellationToken);

        var result = new RoleResponse
        {
            Id = role.Id,
            Role = role.Name,
            Description = role.Description,
            Status = role.RowStatus.Localize(),
            IsStrict = role.IsStrict
        };


        return new SuccessResult<RoleResponse>(result);
    }
}