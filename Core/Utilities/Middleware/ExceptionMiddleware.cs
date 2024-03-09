using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;
using Core.Exceptions;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Utilities.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var message = e.Message;

        if (e.GetType() == typeof(ValidationException))
        {
            message = e.Message;
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (e.GetType() == typeof(ArgumentException))
        {
            message = "Geçersiz Argüman!";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (e.GetType() == typeof(ForbiddenException))
        {
            message = e.Message;
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        }
        else if (e.GetType() == typeof(AuthenticationException) ||
                 e.GetType() == typeof(UnAuthorizedException) ||
                 e.GetType() == typeof(UnauthorizedAccessException))
        {
            message = e.Message;
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else if (e.GetType() == typeof(ApplicationException))
        {
            message = e.Message;
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }

        await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorResult(message: message)));
    }
}