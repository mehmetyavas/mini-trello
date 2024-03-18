using Application.Features.Auth.Request;
using Core.Data;
using Core.Data.Enum;
using Core.Utilities.Results;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Auth.Handler.Command;

public class RegisterVerifyRequestHandler:IRequestHandler<RegisterVerifyRequest,IResult>
{
    private readonly UnitOfWork _unitOfWork;

    public RegisterVerifyRequestHandler(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(RegisterVerifyRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetAsync(x => x.VerifyToken == request.Token,cancellationToken);


        if (user is null)
            return new ErrorResult(LangKeys.VerificationFailed.ToString());


        if (user.IsVerified)
            return new ErrorResult(LangKeys.AlreadyVerified.ToString());


        user.IsVerified = true;
        user.VerifiedAt = DateTime.Now;

        _unitOfWork.Users.Update(user);

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.Verificationsuccessful.ToString());
    }
}