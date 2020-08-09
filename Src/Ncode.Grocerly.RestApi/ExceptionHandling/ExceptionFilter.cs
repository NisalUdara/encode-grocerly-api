using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ncode.Grocerly.Application.Exceptions;

namespace Ncode.Grocerly.RestApi.ExceptionHandling
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is UnregisteredShopperException)
            {
                context.Result = new NoContentResult();
                context.ExceptionHandled = true;
            }
            else if (context.Exception is DuplicateUsernameException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
            else if (context.Exception is UnauthorizedShopperException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
            
        }
    }
}
