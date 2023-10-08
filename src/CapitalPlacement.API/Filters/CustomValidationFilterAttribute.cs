using CapitalPlacement.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CapitalPlacement.API.Filters;

public class CustomValidationFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .ToDictionary(e => e.Key, e => e.Value.Errors.Select(x => x.ErrorMessage).ToArray());
            var errorMessages = errors.SelectMany(a => a.Value).ToList();
            var response = Result.Failure(errorMessages, errorMessages.FirstOrDefault() ?? "one or more validation error occured");


            context.Result = new JsonResult(response) { StatusCode = 400 };
        }
    }

    public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
        }

        return base.OnActionExecutionAsync(context, next);
    }

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .ToDictionary(e => e.Key, e => e.Value.Errors.Select(x => x.ErrorMessage).ToArray());
            var errorMessages = errors.SelectMany(a => a.Value).ToList();
            var response = Result.Failure(errorMessages, errorMessages?.FirstOrDefault() ?? "one or more validation error exists");


            context.Result = new JsonResult(response) { StatusCode = 400 };
        }

        base.OnResultExecuting(context);
    }
}