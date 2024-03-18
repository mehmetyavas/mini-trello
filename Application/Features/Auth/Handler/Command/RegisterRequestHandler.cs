using Application.Features.Auth.Request;
using Application.Features.Mail;
using Core.Data;
using Core.Data.Entity.Default;
using Core.Data.Enum;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Auth.Handler.Command;

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


        var pwdSalt = Array.Empty<byte>();
        var pwdHash = Array.Empty<byte>();
        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            HashingHelper.CreatePasswordHash(request.Password, out pwdSalt, out pwdHash);
        }

        var verifyToken = CodeGenerator.CreateVerifyToken();

        var user = new Core.Data.Entity.Default.User
        {
            RowStatus = RowStatus.Active,
            Fullname = request.FullName,
            Email = request.Email,
            MobilePhone = request.MobilPhones,
            IsVerified = false,
            VerifyToken = verifyToken,
            PasswordSalt = pwdSalt,
            PasswordHash = pwdHash,
        };

        _unitOfWork.Users.Add(user);


        _unitOfWork.UserRoles.Add(new UserRole
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