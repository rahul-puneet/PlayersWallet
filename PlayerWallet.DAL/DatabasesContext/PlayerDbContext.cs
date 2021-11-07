using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlayerWallet.DAL.Entities;

namespace PlayerWallet.DAL.DatabasesContext
{
    public class PlayerDbContext : DbContext
    {

        public PlayerDbContext(DbContextOptions<PlayerDbContext> dbContextOptions):base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerDTO>()
                .HasMany(b => b.PlayerWalletDetails)
                .WithOne(e=>e.PlayerDTO)
                .HasForeignKey(p=>p.RegistrationId);

        }

        public DbSet<PlayerWalletDTO> PlayerWalletBalance { get; set; }
        public DbSet<PlayerDTO> PlayerDetails { get; set; }
    }
}
