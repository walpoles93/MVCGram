using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MVCGram.Application.Authentication;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCGram.Web.Middleware
{
    public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(
            HttpContext httpContext,
            IAuthenticationService authenticationService)
        {
            var userIdClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                var userId = int.Parse(userIdClaim.Value);

                await authenticationService.SetCurrentUserAsync(userId);
            }

            await _next(httpContext);
        }
    }

    public static class CurrentUserMiddlewareExtension
    {
        public static IApplicationBuilder UseCurrentUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CurrentUserMiddleware>();
        }
    }
}