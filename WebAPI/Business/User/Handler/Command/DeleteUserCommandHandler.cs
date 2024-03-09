using Core.Data;
using Core.Data.Enum;
using Core.Exceptions;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.User.Request;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.User.Handler.Command;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IResult>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly ITokenManager _tokenManager;

    public DeleteUserCommandHandler(UnitOfWork unitOfWork, ITokenManager tokenManager)
    {
        _unitOfWork = unitOfWork;
        _tokenManager = tokenManager;
    }

    public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .Query()
            .IgnoreQueryFilters()
            .Include(ul => ul.UserLogins)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        if (user is null)
            throw new UnAuthorizedException(LangKeys.UserNotFound);

        await _unitOfWork.Users.SoftDelete(user, cancellationToken);

        var userLogins = user.UserLogins.ToList();

        await _tokenManager.Deactivate(userLogins.Select(x => x.AccessToken).ToList());

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.Deleted);
    }
}