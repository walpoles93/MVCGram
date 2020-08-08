using Microsoft.EntityFrameworkCore;
using MVCGram.Domain.Users;
using System;
using System.Threading.Tasks;

namespace MVCGram.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly MVCGramContext _db;

        public UserRepository(MVCGramContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Add(User user)
        {
            _db.Users.Add(user);
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            return user;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
