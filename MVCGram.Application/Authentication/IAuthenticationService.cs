using System.Threading.Tasks;

namespace MVCGram.Application.Authentication
{
    public interface IAuthenticationService
    {
        Task<ApplicationResponse<AuthenticationData>> AuthenticateAsync(string username, string password);
    }
}
