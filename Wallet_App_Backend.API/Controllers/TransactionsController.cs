﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
