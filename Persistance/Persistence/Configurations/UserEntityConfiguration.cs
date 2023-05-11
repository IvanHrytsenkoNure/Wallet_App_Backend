using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.Infrastructure.Persistence.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.AuthorizedWalletTransactions)
                .WithOne(y => y.AuthorizedUser)
                .HasForeignKey(x => x.AuthorizedUserId);

            builder.HasMany(x => x.WalletTransaction)
                .WithOne(y => y.TransactionUser)
                .HasForeignKey(x => x.TransactionUserId);
        }
    }
}
