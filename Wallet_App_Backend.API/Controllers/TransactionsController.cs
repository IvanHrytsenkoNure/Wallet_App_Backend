using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wallet_App_Backend.Application.Core.Application.Queries.GetLatestTransaction;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TransactionsController : BaseController
    {
        private readonly IMapper _mapper;

        public TransactionsController (IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of Transactions
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /transactions
        /// </remarks>
        /// <returns>Returns NoteListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect request</response>
        /// <response code="404"> Transactions were not found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<GetLatestTransactionQueryResult>> GetAll([FromQuery] GetLatestTransactionQuery query)
        {
            
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
