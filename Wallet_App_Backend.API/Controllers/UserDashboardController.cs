using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wallet_App_Backend.Application.Core.Application.Queries.GetCardBalanceInformation;
using Wallet_App_Backend.Application.Core.Application.Queries.GetLatestTransaction;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserDashboardController : BaseController
    {
        public UserDashboardController()
        {
                
        }

        /// <summary>
        /// Gets Card Balance Information
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /transactions
        /// </remarks>
        /// <returns>Returns Card Balance Info</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect request</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<GetCardBalanceInformationQueryResult>> GetCardBalanceInfo([FromQuery] GetCardBalanceInformationQuery query)
        {

            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}