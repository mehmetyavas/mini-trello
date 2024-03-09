using Core.Data;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Auth.Request;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Auth.Handler.Command;

public class LogoutRequestHandler:IRequestHandler<LogoutRequest,IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public LogoutRequestHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(LogoutRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserLogins
            .Query()
            .IgnoreAutoIncludes()
            .SingleOrDefaultAsync(x => x.AccessToken == request.AccessToken, cancellationToken);

        if (user is null) throw new NotFoundException(LangKeys.UserNotFound.Localize());

        await _unitOfWork.UserLogins.SoftDelete(user, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.LogoutSuccessful.Localize());
    }
}