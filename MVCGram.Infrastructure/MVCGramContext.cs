using Microsoft.EntityFrameworkCore;
using MVCGram.Domain.Users;

namespace MVCGram.Infrastructure
{
    public class MVCGramContext : DbContext
    {
        public MVCGramContext(DbContextOptions<MVCGramContext> options) :
            base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MVCGramContext).Assembly);
        }
    }
}
