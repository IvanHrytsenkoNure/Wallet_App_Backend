using MediatR;
using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Application.Common.Exceptions;
using Wallet_App_Backend.Application.Interfaces;

namespace Wallet_App_Backend.Application.Core.Application.Commands.DeleteTransaction
{
    internal class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, bool>
    {

        private readonly IApplicationDbContext _dbContext;

        public DeleteTransactionCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction =
                await _dbContext.WalletTransactions
                    .FirstOrDefaultAsync(x => x.Id == request.TransactionId, cancellationToken);

            if (transaction == null)
            {
                throw new NotFoundException("Transaction");
            }

            _dbContext.WalletTransactions.Remove(transaction);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
