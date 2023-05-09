using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetLatestTransaction
{
    public class GetLatestTransactionQuery : IRequest<GetLatestTransactionQueryResult>
    {
        public Guid UserId { get; set; }

    }
}
