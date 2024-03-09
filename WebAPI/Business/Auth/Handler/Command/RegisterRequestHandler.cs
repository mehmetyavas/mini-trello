using Core.Data;
using Core.Data.Enum;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using MediatR;
using WebAPI.Business.Auth.Request;
using WebAPI.Business.Mail;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Auth.Handler.Command;

public class RegisterRequestHandler : IRequestHandler<RegisterRequest, IResult>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly MailManager _mailManager;

    public RegisterRequestHandler(UnitOfWork unitOfWork, MailManager mailManager)
    {
        _unitOfWork = unitOfWork;
        _mailManager = mailManager;
    }

    public async Task<IResult> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var isThereAnyUser =
            await _unitOfWork.Users
                .GetAsync(x => x.Email == request.Email, cancellationToken);


        if (isThereAnyUser is not null)
            return new SuccessResult(LangKeys.RegistrationSuccessful.ToString());


        var verifyToken = CodeGenerator.CreateVerifyToken();

        var user = new Core.Data.Entity.User
        {
            RowStatus = RowStatus.Active,
            Fullname = request.FullName,
            Email = request.Email,
            MobilePhone = request.MobilPhones,
            IsVerified = false,
            VerifyToken = verifyToken,
        };

        _unitOfWork.Users.Add(user);


        _unitOfWork.UserRoles.Add(new Core.Data.Entity.UserRole
        {
            RowStatus = RowStatus.Active,
            RoleId = (long)Roles.User,
            User = user
        });

        await _mailManager.SendRegisterMailAsync(request.Email, verifyToken, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult(LangKeys.RegistrationSuccessful.ToString());
    }
}