using System.Threading.Tasks;

namespace MVCGram.Domain.Users
{
    public interface IUserRepository
    {
        void Add(User user);

        Task<int> SaveChangesAsync();

        Task<User> FindByUsernameAsync(string username);

        Task<User> GetAsync(int id);
    }
}
