using Core.Data;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.Role.Request;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Role.Handler.Command;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public CreateRoleCommandHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
       
        _unitOfWork.Roles.CheckStrictRoles(request.Role);

        await _unitOfWork.Roles.CheckRoles(request.Role, cancellationToken);


        _unitOfWork.Roles.Add(new Core.Data.Entity.Role
        {
            Name = request.Role,
            Description = request.Description,
        });

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.Success.Localize());
    }
}