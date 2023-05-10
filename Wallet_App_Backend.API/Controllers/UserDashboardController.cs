using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wallet_App_Backend.Application.Core.Application.Queries.GetCardBalanceInformation;
using Wallet_App_Backend.Application.Core.Application.Queries.GetLatestTransaction;
using Wallet_App_Backend.Application.Core.Application.Queries.GetUserPoints;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.API.Controllers
{
    [Route("api/[controller]")]
    public class UserDashboardController : BaseController
    {
        [HttpGet("cardBalanceInfo")]
        public async Task<ActionResult<GetCardBalanceInformationQueryResult>> GetCardBalanceInfo([FromQuery] GetCardBalanceInformationQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("userPoints")]
        public async Task<ActionResult<GetUserPointsQueryResult>> GetUserPoints([FromQuery] GetUserPointsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

    }
}