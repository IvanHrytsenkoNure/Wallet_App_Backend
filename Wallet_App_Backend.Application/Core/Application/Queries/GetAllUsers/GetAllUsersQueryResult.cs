using Wallet_App_Backend.Application.Common.Models;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryResult
    {
        public List<UserModel> UsersList { get; set; }
    }
}
