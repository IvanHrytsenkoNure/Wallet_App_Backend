using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Application.Common.Exceptions;
using Wallet_App_Backend.Application.Interfaces;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.Application.Core.Application.Commands.AddTransaction
{
    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, bool>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddTransactionCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<bool> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {

            if (!(await _dbContext.Users.AnyAsync(x => x.Id == request.TransactionModel.UserModel.Id, cancellationToken)))
            {
                throw new NotFoundException("Transaction user");
            }

            await _dbContext.WalletTransactions.AddAsync(_mapper.Map<WalletTransaction>(request.TransactionModel), cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
