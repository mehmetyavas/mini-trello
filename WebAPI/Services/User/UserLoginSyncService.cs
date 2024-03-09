using Core.Utilities.Helpers;
using WebAPI.Business.Auth;

namespace WebAPI.Services.User;

public class UserLoginSyncService : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private Timer _timer;

    public UserLoginSyncService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(Work, null, TimeSpan.Zero, TimeSpan.FromDays(AppConfig.Settings.UserLoginSyncInterval));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    private void Work(object state)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var authManager = scope.ServiceProvider.GetService<AuthManager>();
        try
        {
            if (authManager != null) authManager.SyncDefunctUserLogins().Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}