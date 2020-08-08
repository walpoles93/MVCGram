using System.Threading.Tasks;

namespace MVCGram.Application.SignUp
{
    public interface ISignUpService
    {
        Task<ApplicationResponse> SignUp(SignUpRequest request);
    }
}
