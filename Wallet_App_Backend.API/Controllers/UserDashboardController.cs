using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Wallet_App_Backend.Application.Core.Application.Queries.GetCardBalanceInformation;
using Wallet_App_Backend.Application.Core.Application.Queries.GetUserPoints;

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

        [HttpGet("paymentDue")]
        public async Task<ActionResult<GetUserPointsQueryResult>> GetPaymentDue()
        {
            var result = new
            {
                DueInfo =
                    $"You've paid your {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month)} balance"
            };
            return Ok(result);
        }

    }
}