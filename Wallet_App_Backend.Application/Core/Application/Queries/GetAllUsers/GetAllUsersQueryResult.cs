using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet_App_Backend.Application.Common.Models;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryResult
    {
        public List<UserModel> UsersList { get; set; }
    }
}
