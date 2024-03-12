using Core.Data;
using Core.Data.Dto.Auth;
using Core.Data.Dto.User;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Auth.Request;
using WebAPI.Business.Facebook;
using WebAPI.Business.Google;
using WebAPI.Business.Mail;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Auth;

public class LoginProviderManager
{
    private readonly FacebookManager _facebookManager;
    private readonly UnitOfWork _unitOfWork;
    private readonly GoogleManager _googleManager;
    private readonly MailManager _mailManager;

    public LoginProviderManager(FacebookManager facebookManager, UnitOfWork unitOfWork, GoogleManager googleManager,
        MailManager mailManager)
    {
        _facebookManager = facebookManager;
        _unitOfWork = unitOfWork;
        _googleManager = googleManager;
        _mailManager = mailManager;
    }

    public async Task<IResult<AuthResponse>> LoginWithFacebook(string accessToken, bool rememberMe,
        CancellationToken cancellationToken = default)
    {
        var isTokenValid = await _facebookManager.ValidateToken(accessToken, cancellationToken);
        if (!isTokenValid.Data.Data.IsValid)
        {
            return new ErrorResult<AuthResponse>(LangKeys.AuthorizationsDenied.ToString());
        }

        var facebookUserInfo = await _facebookManager.GetUserInfo(accessToken, cancellationToken);

        var user = await _unitOfWork.Users.GetAsync(x => x.Email == facebookUserInfo.Data.Email, cancellationToken);

        if (user is null)
        {
            _unitOfWork.Users.Add(new Core.Data.Entity.Default.User
            {
                Fullname = $"{facebookUserInfo.Data.FirstName} {facebookUserInfo.Data.LastName}",
                Email = facebookUserInfo.Data.Email,
                MobilePhone = null,
                Gender = Gender.NotSpecified,
                AvatarUrl = facebookUserInfo.Data.Picture.PictureData.Url.ToString(),
                BirthDate = default,
                VerifyToken = "Facebook",
                IsVerified = true,
                VerifiedAt = DateTime.Now,
            });

            await _unitOfWork.SaveAsync(cancellationToken);

            user = await _unitOfWork.Users.GetAsync(x => x.Email == facebookUserInfo.Data.Email, cancellationToken);
        }

        var userClaims = _unitOfWork.Users.LoginClaims(user);

        var newUserLogin =
            await _unitOfWork.UserLogins.Login(userClaims, LoginProvider.Facebook, rememberMe,
                cancellationToken);


        _unitOfWork.Users.Update(user);

        await _unitOfWork.SaveAsync(cancellationToken);


        return new SuccessResult<AuthResponse>(newUserLogin);
    }

    public async Task<IResult<AuthResponse>> LoginWithGoogle(string token, bool rememberMe,
        CancellationToken cancellationToken = default)
    {
        var googleUserInfo = await _googleManager.GetUserInfo(token, cancellationToken);

        var user = await _unitOfWork.Users.GetAsync(x => x.Email == googleUserInfo.Data.Email, cancellationToken);

        if (user is null)
        {
            _unitOfWork.Users.Add(new Core.Data.Entity.Default.User
            {
                Fullname = $"{googleUserInfo.Data.GivenName} {googleUserInfo.Data.FamilyName}",
                Email = googleUserInfo.Data.Email,
                MobilePhone = null,
                Gender = Gender.NotSpecified,
                AvatarUrl = googleUserInfo.Data.Picture,
                BirthDate = default,
                VerifyToken = "Google",
                IsVerified = true,
                VerifiedAt = DateTime.Now,
            });

            await _unitOfWork.SaveAsync(cancellationToken);

            user = await _unitOfWork.Users.GetAsync(x => x.Email == googleUserInfo.Data.Email, cancellationToken);
        }


        var userClaims = _unitOfWork.Users.LoginClaims(user!);

        var newUserLogin =
            await _unitOfWork.UserLogins.Login(userClaims, LoginProvider.Google, rememberMe, cancellationToken);


        _unitOfWork.Users.Update(user);

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult<AuthResponse>(newUserLogin);
    }


    public async Task<IResult<AuthResponse>> LoginWithPassword(
        string email,
        string password,
        bool rememberMe)
    {
        var user = await _unitOfWork.Users.Query()
            .FirstOrDefaultAsync(x => x.Email == email);

        if (user is null)
            return new ErrorResult<AuthResponse>(LangKeys.EmailOrPasswordIncorrect.ToString());

        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash))
        {
            return new ErrorResult<AuthResponse>(LangKeys.EmailOrPasswordIncorrect);
        }

        if (!user.IsVerified)
        {
            return new ErrorResult<AuthResponse>(LangKeys.UserIsNotVerified);
        }

        var userClaims = _unitOfWork.Users.LoginClaims(user!);

        var newUserLogin =
            await _unitOfWork.UserLogins.Login(userClaims, LoginProvider.Password, rememberMe);


        _unitOfWork.Users.Update(user);

        await _unitOfWork.SaveAsync();


        return new SuccessResult<AuthResponse>(newUserLogin);
    }

    public async Task<IResult> SendLoginCode(string email, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetAsync(x =>
            x.Email == email, cancellationToken);


        //returned success for Email Privacy
        if (user is null)
            return new SuccessResult(LangKeys.CheckEmailForLoginCode.Localize());

        //returned success for Email Privacy
        if (!user.IsVerified)
            return new SuccessResult(LangKeys.CheckEmailForLoginCode.Localize());


        var loginCode = await _unitOfWork.Users.LoginCode();

        user.LoginCode = loginCode;
        user.LoginCodeExpiredAt = DateTime.Now.AddMinutes(3);

        _unitOfWork.Users.Update(user);


        await _mailManager.SendLoginCodeAsync(email, loginCode.ToString(), cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);

        return new SuccessResult(LangKeys.CheckEmailForLoginCode.Localize());
    }
}