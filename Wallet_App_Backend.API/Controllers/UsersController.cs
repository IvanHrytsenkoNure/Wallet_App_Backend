using Microsoft.AspNetCore.Mvc;
using Wallet_App_Backend.Application.Core.Application.Commands.AddUserCommand;
using Wallet_App_Backend.Application.Core.Application.Queries.GetAllUsers;

namespace Wallet_App_Backend.API.Controllers
{
    [Route("api/[controller]")]

    public class UsersController : BaseController
    {


        [HttpGet("users")]
        public async Task<ActionResult<GetAllUsersQueryResult>> GetUsers([FromQuery] GetAllUsersQuery query)
        {

            var result = await Mediator.Send(query);
            return Ok(result);
        }


        [HttpPost("createUser")]
        public async Task<ActionResult<bool>> CreateUser([FromBody] AddUserCommand command)
        {

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
