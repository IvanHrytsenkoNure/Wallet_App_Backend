using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.Infrastructure.Persistence.Configurations
{
    public class WalletTransactionEntityConfiguration : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.HasOne(x => x.TransactionUser)
                .WithMany(y => y.WalletTransaction)
                .HasForeignKey(x => x.TransactionUserId);

            builder.HasOne(x => x.AuthorizedUser)
                .WithMany(y => y.AuthorizedWalletTransactions)
                .HasForeignKey(x => x.AuthorizedUserId);
        }
    }
}
