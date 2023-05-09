using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet_App_Backend.Application.Core.Application.Queries.GetLatestTransaction;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetCardBalanceInformation
{
    public class GetCardBalanceInformationQuery : IRequest<GetCardBalanceInformationQueryResult>
    {
        public Guid UserId { get; set; }

    }
}
