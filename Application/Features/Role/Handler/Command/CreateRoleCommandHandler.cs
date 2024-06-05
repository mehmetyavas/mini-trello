using Application.Features.Role.Request;
using Core.Data;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Middleware;
using Core.Utilities.Results;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Role.Handler.Command;

[Deneme]
public class CreateRoleCommandHandler: IRequestHandler<CreateRoleRequest, IResult>,ITransactionMarker
{
    private readonly UnitOfWork _unitOfWork;

    public CreateRoleCommandHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [Deneme]
    public async Task<IResult> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        _unitOfWork.Roles.CheckStrictRoles(request.Role);

        await _unitOfWork.Roles.CheckRoles(request.Role, cancellationToken);


        _unitOfWork.Roles.Add(new Core.Data.Entity.Default.Role
        {
            Name = request.Role,
            Description = request.Description,
        });

        await _unitOfWork.SaveAsync(cancellationToken);

        throw new Exception();
    
        return new SuccessResult(LangKeys.Success.Localize());


        if ( false )
        {
        }
    }
}