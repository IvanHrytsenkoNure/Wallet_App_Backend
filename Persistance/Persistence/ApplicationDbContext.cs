using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet_App_Backend.Application.Interfaces;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }

    }
}
