using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Application.Interfaces;
using Wallet_App_Backend.Data.Entities;
using Wallet_App_Backend.Infrastructure.Persistence.Configurations;

namespace Wallet_App_Backend.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityConfiguration());
            builder.ApplyConfiguration(new WalletTransactionEntityConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
