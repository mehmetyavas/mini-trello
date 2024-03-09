using Core.Data;
using Core.Data.Enum;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.User;

namespace WebAPI.Business.Auth;

public class AuthManager
{
    private readonly UnitOfWork _unitOfWork;
    private readonly ITokenManager _tokenManager;
    private readonly UserLoginSyncService _userLoginSyncService;

    public AuthManager(UnitOfWork unitOfWork,
        ITokenManager tokenManager, UserLoginSyncService userLoginSyncService)
    {
        _unitOfWork = unitOfWork;
        _tokenManager = tokenManager;
        _userLoginSyncService = userLoginSyncService;
    }


    public async Task SyncDefunctUserLogins()
    {
        var expiredInActives = _unitOfWork.UserLogins.GetExpiredInActives();
        var inActives = _unitOfWork.UserLogins.GetInActives();


        foreach (var expiredInActive in expiredInActives)
        {
            _unitOfWork.UserLogins.HardDelete(expiredInActive);
        }


        await _unitOfWork.SaveAsync();


        await _tokenManager.ClearTokens(expiredInActives.Select(x => x.AccessToken).ToList());
        await _tokenManager.Deactivate(inActives.Select(x => x.AccessToken).ToList());
    }

    public Result SyncDefunctUserLoginsRequest()
    {
        _userLoginSyncService.StopAsync(CancellationToken.None);
        _userLoginSyncService.StartAsync(CancellationToken.None);
        return new SuccessResult(LangKeys.RefreshTokenBlackListSuccessful);
    }


    public async Task DeactivateUser(Guid userId)
    {
        var userLogins = await _unitOfWork.UserLogins.Query().Where(x => x.UserId == userId).ToListAsync();


        await _tokenManager.Deactivate(userLogins.Select(x => x.AccessToken).ToList());
    }

    public async Task DeactivateUser(List<Guid> userIds)
    {
        var userLogins = await _unitOfWork.UserLogins
            .Query()
            .Where(x => userIds.Any(y => y == x.UserId))
            .ToListAsync();


        await _tokenManager.Deactivate(userLogins.Select(x => x.AccessToken).ToList());
    }


    public IResult<List<string>> GetTokenBlackList()
    {
        return new SuccessResult<List<string>>(_tokenManager.GetAll());
    }
}