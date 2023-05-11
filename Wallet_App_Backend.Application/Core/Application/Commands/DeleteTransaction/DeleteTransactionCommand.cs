using MediatR;

namespace Wallet_App_Backend.Application.Core.Application.Commands.DeleteTransaction
{
    public class DeleteTransactionCommand : IRequest<bool>
    {

        public Guid TransactionId { get; set; }

    }
}
