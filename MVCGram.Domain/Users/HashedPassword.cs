using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Linq;
using System.Security.Cryptography;

namespace MVCGram.Domain.Users
{
    public class HashedPassword
    {
        public HashedPassword(string password)
        {
            Salt = GenerateSalt();
            Hash = GenerateHash(Salt, password);
        }

        private HashedPassword()
        {
        }

        public byte[] Hash { get; }

        public byte[] Salt { get; }

        public bool Matches(string password)
        {
            var hash = GenerateHash(Salt, password);

            return hash.SequenceEqual(Hash);
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            return salt;
        }

        private byte[] GenerateHash(byte[] salt, string password)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);
        }
    }
}
