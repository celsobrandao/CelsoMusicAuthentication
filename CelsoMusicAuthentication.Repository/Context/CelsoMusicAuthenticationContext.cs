using Microsoft.EntityFrameworkCore;

namespace CelsoMusicAuthentication.Repository.Context
{
    public class CelsoMusicAuthenticationContext : DbContext
    {
        public CelsoMusicAuthenticationContext(DbContextOptions<CelsoMusicAuthenticationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CelsoMusicAuthenticationContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
