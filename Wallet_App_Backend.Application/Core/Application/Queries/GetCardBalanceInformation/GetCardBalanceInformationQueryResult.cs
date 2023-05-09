using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetCardBalanceInformation
{
    public class GetCardBalanceInformationQueryResult
    {
        public double Balance { get; set; }
        public double AvailableAmount { get; set; }

    }
}
