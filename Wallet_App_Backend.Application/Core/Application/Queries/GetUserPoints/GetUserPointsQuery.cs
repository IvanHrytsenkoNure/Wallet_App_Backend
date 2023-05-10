using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetUserPoints
{
    public class GetUserPointsQuery : IRequest<GetUserPointsQueryResult>
    {
        public Guid UserId { get; set; }

    }
}
