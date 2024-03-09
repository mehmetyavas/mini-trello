using Core.Data.Dto.App;
using Core.Data.Dto.Email;
using Core.Data.Dto.FacebookDtos;
using Core.Data.Dto.GoogleDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Helpers;

public static class AppConfig
{
    public static MailCreds MailCreds = null!;

    // public static Mail MailBody = null!;
    public static string ConnectionString = null!;
    public static AppInfo AppInfo = null!;

    public static Facebook Facebook = null!;
    public static Google Google = null!;

    public static TokenOptions AuthenticationConfig = null!;

    public static Settings Settings = null!;
    public static string AppClient = null!;

    public static ConnectionStringsCache ConnectionStringsCache = null!;

    public static string WebRootPath =>
        ServiceTool.ServiceProvider!.GetRequiredService<IWebHostEnvironment>().WebRootPath;

    public static Mail MailBody { get; set; } = null!;


    public static void Build(IConfiguration conf)
    {
        MailCreds = conf.GetSection("MailCred").Get<MailCreds>()!;
        AppInfo = conf.GetSection("AppInfo").Get<AppInfo>()!;
        // MailBody = conf.GetSection("Mail").Get<Mail>()!;
#if !DEBUG
         ConnectionString = conf.GetConnectionString("DefaultConnection")!;
#else
        ConnectionString = conf.GetConnectionString("TestConnection")!;
#endif


        AuthenticationConfig = conf.GetSection("TokenOptions").Get<TokenOptions>()!;

        Settings = conf.GetSection(nameof(Settings)).Get<Settings>()!;

        Facebook = conf.GetSection("Facebook").Get<Facebook>()!;

        Google = conf.GetSection(nameof(Google)).Get<Google>()!;

        AppClient = AppInfo.AppUrl;
        MailBody = conf.GetSection("Mail").Get<Mail>()!;

        ConnectionStringsCache = conf.GetSection(nameof(ConnectionStringsCache)).Get<ConnectionStringsCache>()!;
    }
}

public class ConnectionStringsCache
{
    public string Redis { get; set; } = null!;
}

public class Settings
{
    public int LoginLimit { get; set; }
    public int UserLoginSyncInterval { get; set; }
    public int DefaultRedisEntryExpiration { get; set; }
}