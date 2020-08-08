using System;

namespace MVCGram.Domain.Users
{
    public class User
    {
        public User(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException(nameof(username));
            }

            Username = username;
            ChangePassword(password);
        }

        private User()
        {
        }

        public int Id { get; }

        public string Username { get; }

        public HashedPassword Password { get; private set; }

        public void ChangePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException(nameof(password));
            }

            Password = new HashedPassword(password);
        }
    }
}
