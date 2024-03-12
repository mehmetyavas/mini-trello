using Core.ActionFilters;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration;

public static class FilterConfiguration
{
    public static void ConfigureFilters(this IServiceCollection services)
    {
        services.AddMvc(
            options =>
            {
                options.Filters.Add(typeof(ModelStateFilter), order: 1);
                //HATALI, RESULTFILTER'I CALISTIRMA
                // options.Filters.Add(typeof(ResultFilter), order: 2);
                options.EnableEndpointRouting = true;
            });
    }
}