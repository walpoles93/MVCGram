using System.Threading.Tasks;

namespace MVCGram.Application.SignUp
{
    public interface ISignUpQueries
    {
        Task<bool> UsernameExists(string username);
    }
}
