using Wallet_App_Backend.Application.Common.Models;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetLatestTransaction
{
    public class GetLatestTransactionQueryResult
    {
        public List<WalletTransactionModel> LatestTransactionsList { get; set; }
    }
}
