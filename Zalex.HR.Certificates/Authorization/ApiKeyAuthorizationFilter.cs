using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Zalex.HR.Certificates.Api.Authorization
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("x-api-key", out var apiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!IsValid(apiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }

        private bool IsValid(string apiKey)
        {
            return apiKey == Constants.Constants.ApiKey;
        }
    }
}
