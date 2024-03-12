using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.ActionFilters;

public class ModelStateFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid)
        {
            return;
        }


        var inValidKeys = (SerializableError)new UnprocessableEntityObjectResult(context.ModelState).Value!;

        throw new InvalidModelStateException(inValidKeys);
    }

    public void OnActionExecuted(ActionExecutedContext context)
     {
    }
}