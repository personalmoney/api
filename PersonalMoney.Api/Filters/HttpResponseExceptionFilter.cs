using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalMoney.Api.Helpers;

namespace PersonalMoney.Api.Filters
{
    /// <summary>
    /// Http exception response filter
    /// </summary>
    /// <seealso cref="IActionFilter" />
    /// <seealso cref="IOrderedFilter" />
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        /// <inheritdoc />
        public int Order { get; set; } = int.MaxValue - 10;

        /// <inheritdoc />
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        /// <inheritdoc />
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!(context.Exception is PersonalMoneyException exception))
            {
                return;
            }
            var data = new Dictionary<string, string>
            {
                ["code"] = exception.Code,
                ["message"] = exception.Message
            };
            context.Result = new BadRequestObjectResult(data);
            context.ExceptionHandled = true;
        }
    }
}