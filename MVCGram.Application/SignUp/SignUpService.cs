using MVCGram.Domain.Users;
using System;
using System.Threading.Tasks;

namespace MVCGram.Application.SignUp
{
    public class SignUpService : ISignUpService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISignUpQueries _signUpQueries;

        public SignUpService(
            IUserRepository userRepository,
            ISignUpQueries signUpQueries)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _signUpQueries = signUpQueries ?? throw new ArgumentNullException(nameof(signUpQueries));
        }

        public async Task<ApplicationResponse> SignUp(SignUpRequest request)
        {
            if (await _signUpQueries.UsernameExists(request.Username))
            {
                return ApplicationResponse.Failure("Username already exists.");
            }

            var user = new User(request.Username, request.Password);
            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();

            return ApplicationResponse.Success();
        }
    }
}
