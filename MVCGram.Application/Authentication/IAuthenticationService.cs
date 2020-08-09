using MVCGram.Domain.Users;
using System.Threading.Tasks;

namespace MVCGram.Application.Authentication
{
    public interface IAuthenticationService
    {
        Task<ApplicationResponse<AuthenticationData>> AuthenticateAsync(string username, string password);

        Task<ApplicationResponse> SetCurrentUserAsync(int userId);

        User GetCurrentUser();
    }
}
