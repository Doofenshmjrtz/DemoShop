using IResult = DemoShop.Domain.Core.Common.Interfaces.IResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoShop.Api.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class ResultFilterAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var resultContext = await next();
        
        if (resultContext.Result is ObjectResult { Value: IResult result })
        {
            if (result.IsSuccess)
                resultContext.Result = new OkObjectResult(result.GetType().GetProperty("Value")?.GetValue(result));
            else
                resultContext.Result = new BadRequestObjectResult(result.GetType().GetProperty("Error")?.GetValue(result));
        }
    }
}