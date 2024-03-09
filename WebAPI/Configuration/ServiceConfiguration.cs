using Core.ActionFilters;
using Core.Services;
using Core.Services.FileUploader;
using Core.Utilities.Helpers;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebAPI.Business.Auth;
using WebAPI.Business.Facebook;
using WebAPI.Business.Google;
using WebAPI.Business.Mail;
using WebAPI.Business.User;
using WebAPI.Services.User;

namespace WebAPI.Configuration;

public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<UserResolverServices>();
        services.AddTransient<ITokenManager, TokenManager>();
        services.AddSingleton<UserLoginSyncService>();
        services.AddHostedService<UserLoginSyncService>();
        services.AddScoped<LoginProviderManager>();
        services.AddScoped<AuthManager>();
        // services.AddScoped<RoleManager>();
        services.AddScoped<UserManager>();
        services.AddScoped<MailManager>();
        services.AddScoped<FacebookManager>();
        services.AddScoped<GoogleManager>();
        services.AddScoped<FileUploader>();
        services.AddStackExchangeRedisCache(action =>
        {
            action.Configuration = AppConfig.ConnectionStringsCache.Redis;
        });

        services.TryAddEnumerable(ServiceDescriptor.Singleton<IFilterProvider, BaseFilterProvider>());
    }
}