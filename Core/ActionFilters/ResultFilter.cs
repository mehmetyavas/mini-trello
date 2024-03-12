using Core.Data.Dto.ErrorModelStateDto;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Core.ActionFilters;

public class ResultFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is BadRequestObjectResult obj)
        {
            context.HttpContext.Response.StatusCode = obj.StatusCode ?? default;


            context.HttpContext.Response.ContentType = "application/json";
            await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(
                new ErrorResult<List<ErrorModelState>>
                {
                    Success = false,
                    Message = "InvalidRequest",
                    Data = context.ModelState.Select(x => new ErrorModelState
                    {
                        Key = x.Key,
                        Errors = x.Value?.Errors.Select(er => new ErrorModel
                        {
                            Message = er.ErrorMessage
                        }).ToList()
                    }).ToList()
                }));
        }
    }
}