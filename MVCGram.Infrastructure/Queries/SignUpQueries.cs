using Microsoft.EntityFrameworkCore;
using MVCGram.Application.SignUp;
using System;
using System.Threading.Tasks;

namespace MVCGram.Infrastructure.Queries
{
    public class SignUpQueries : ISignUpQueries
    {
        private readonly MVCGramContext _db;

        public SignUpQueries(MVCGramContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<bool> UsernameExists(string username)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

            return user != null;
        }
    }
}
