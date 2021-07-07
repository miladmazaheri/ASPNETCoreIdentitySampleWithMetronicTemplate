using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pars.Entities.Identity;
using Pars.Services.Contracts.Identity;

namespace Pars.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyName = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key was not provided"
                };
                return;
            }

            var apiKeyService = context.HttpContext.RequestServices.GetRequiredService<IApiKeyService>();

            var user = await apiKeyService.FindUserByApiKeyAsync(extractedApiKey);

            if (user == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key is not valid"
                };
                return;
            }
            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.GivenName, user.DisplayName),
                new(ClaimTypes.AuthenticationMethod, ApiKeyName),
            };
            context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims));
            

            await next();
        }
    }
}
