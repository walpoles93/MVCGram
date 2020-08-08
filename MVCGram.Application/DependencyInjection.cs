using MVCGram.Application.Authentication;
using MVCGram.Application.SignUp;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ISignUpService, SignUpService>();

            return services;
        }
    }
}
