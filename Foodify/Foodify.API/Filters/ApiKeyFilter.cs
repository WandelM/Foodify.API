using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Foodify.API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyFilter : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "x-api-key";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var key) == false)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = configuration.GetValue<string>(ApiKeyHeaderName);

            if (apiKey.Equals(key) == false)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
