using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Application.Filter
{
    [ExcludeFromCodeCoverage]
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var message = context.ModelState
                   .SelectMany(x => x.Value.Errors)
                   .Select(x => x.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(message);
            }
        }
    }
}
