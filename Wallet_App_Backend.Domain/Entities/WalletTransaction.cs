using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet_App_Backend.Data.Common;
using Wallet_App_Backend.Data.Enums;

namespace Wallet_App_Backend.Data.Entities
{
    public class WalletTransaction : BaseEntity<Guid>
    {

        public WalletTransactionType TransactionType { get; set; }
        public double TransactionAmount { get; set; }
        public string  TransactionName { get; set; }
        public string  TransactionDescription { get; set; }
        public DateTime  TransactionDate { get; set; }
        public WalletTransactionStatus TransactionStatus { get; set; }
        public string TransactionIconPath { get; set; }

        public Guid TransactionUserId { get; set; }
        public User TransactionUser { get; set; }

        public Guid? AuthorizedUserId { get; set; }
        public User? AuthorizedUser { get; set; }

    }
}
