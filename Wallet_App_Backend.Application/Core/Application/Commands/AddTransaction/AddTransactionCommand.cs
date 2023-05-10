using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Wallet_App_Backend.Application.Common.Models;

namespace Wallet_App_Backend.Application.Core.Application.Commands.AddTransaction
{
    public class AddTransactionCommand : IRequest<bool>
    {
        public WalletTransactionModel TransactionModel { get; set; }
    }
}
