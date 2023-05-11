using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
