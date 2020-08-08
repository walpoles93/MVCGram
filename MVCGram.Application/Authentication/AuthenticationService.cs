using MVCGram.Domain.Users;
using System;
using System.Threading.Tasks;

namespace MVCGram.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<ApplicationResponse<AuthenticationData>> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.FindByUsernameAsync(username);

            if (user != null && user.Password.Matches(password))
            {
                var data = new AuthenticationData
                {
                    UserId = user.Id,
                    Username = user.Username
                };

                return ApplicationResponse<AuthenticationData>.Success(data);
            }

            return ApplicationResponse<AuthenticationData>.Failure("Username or password are incorrect");
        }
    }
}
