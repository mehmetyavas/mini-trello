using Core.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Middleware;

public class Deneme
{
    private readonly RequestDelegate _next;

    public Deneme(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
        var attribute = endpoint?.Metadata.GetMetadata<DenemeAttribute>();

        if ( endpoint is null || attribute is null )
        {
            await _next(context);
        }
        else
        {
            var db = context.RequestServices.GetService<UnitOfWork>();

            await db!.BeginTransactionAsync();
            try
            {
                await _next(context);
                await db.CommitTransactionAsync();
            }
            catch ( Exception e )
            {
                await db.RollbackTransactionAsync();
            }
        }
    }
}

public interface ITransactionMarker
{
}

public class DenemeAttribute: Attribute
{
}

public class Deneme2Attribute: Attribute
{
}