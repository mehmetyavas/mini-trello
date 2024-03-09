using Core.Data;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Auth.Request;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Auth.Handler.Command;

public class LogoutFromAllRequestHandler : IRequestHandler<LogoutFromAllRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public LogoutFromAllRequestHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(LogoutFromAllRequest request, CancellationToken cancellationToken)
    {
        var userLogins = await _unitOfWork.UserLogins
            .Query()
            .Where(x => x.UserId == _unitOfWork.UserId)
            .ToListAsync(cancellationToken);

        if (!userLogins.Any()) return new SuccessResult(LangKeys.LogoutSuccessful.Localize());


        foreach (var login in userLogins)
        {
            await _unitOfWork.UserLogins.SoftDelete(login, cancellationToken);
        }

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.LogoutAllSuccessful.Localize());
    }
}