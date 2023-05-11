using Wallet_App_Backend.Data.Common;

namespace Wallet_App_Backend.Data.Entities
{
    public class User : BaseEntity<Guid>
    {

        public string Name { get; set; }
        public List<WalletTransaction> WalletTransaction { get; set; } = new List<WalletTransaction>();
        public List<WalletTransaction> AuthorizedWalletTransactions { get; set; } = new List<WalletTransaction>();

    }
}
