using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<GetAllUsersQueryResult>
    {
    }
}
