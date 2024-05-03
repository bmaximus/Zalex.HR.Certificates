using Microsoft.AspNetCore.Mvc;

namespace Zalex.HR.Certificates.Api.Authorization
{
    public class ApiKeyAuthorizationAttribute : TypeFilterAttribute
    {
        public ApiKeyAuthorizationAttribute() : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
