using Core.Utilities.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration;

public static class CorsConfiguration
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowOrigin",
                builder => builder
                    .WithOrigins(AppConfig.AppClient)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
        });
    }
}