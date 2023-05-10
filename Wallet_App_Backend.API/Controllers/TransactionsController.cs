using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wallet_App_Backend.Application.Core.Application.Commands.AddTransaction;
using Wallet_App_Backend.Application.Core.Application.Commands.AddUserCommand;
using Wallet_App_Backend.Application.Core.Application.Queries.GetLatestTransaction;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.API.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : BaseController
    {

        [HttpGet("transactions")]
        public async Task<ActionResult<GetLatestTransactionQueryResult>> GetUserTransactions([FromQuery] GetLatestTransactionQuery query)
        {
            
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("createTransaction")]
        public async Task<ActionResult<bool>> CreateUser([FromBody] AddTransactionCommand command)
        {

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
