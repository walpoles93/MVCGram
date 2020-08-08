using Microsoft.EntityFrameworkCore;
using MVCGram.Application.SignUp;
using MVCGram.Domain.Users;
using MVCGram.Infrastructure;
using MVCGram.Infrastructure.Queries;
using MVCGram.Infrastructure.Users;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<MVCGramContext>(options =>
            {
                options.UseInMemoryDatabase("MVCGramContext");
            });

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ISignUpQueries, SignUpQueries>();

            return services;
        }
    }
}
