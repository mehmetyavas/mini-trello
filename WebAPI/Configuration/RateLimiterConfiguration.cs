using AspNetCoreRateLimit;

namespace WebAPI.Configuration;

public static class RateLimiterConfiguration
{
    public static void ConfigureRateLimiter(this WebApplicationBuilder builder)
    {
        var rateLimitingOptions = builder.Configuration.GetSection("IpRateLimiting").Get<IpRateLimitOptions>()!;
        builder.Services.Configure<IpRateLimitOptions>(options =>
        {
            options.GeneralRules = rateLimitingOptions.GeneralRules;
            // Diğer ayarlamaları burada ekleyin
        });

        builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));

        builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
    }
}