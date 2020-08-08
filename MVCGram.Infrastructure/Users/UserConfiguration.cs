using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGram.Domain.Users;

namespace MVCGram.Infrastructure.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(u => u.Username);
            builder.Property(u => u.Username)
                .IsRequired();

            builder.OwnsOne(u => u.Password, password =>
            {
                password.Property(p => p.Hash)
                .IsRequired();

                password.Property(p => p.Salt)
                    .IsRequired();
            });
        }
    }
}
