using AutoMapper;
using MediatR;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Application.Common.Models;
using Wallet_App_Backend.Application.Interfaces;
using Wallet_App_Backend.Application.Common.Exceptions;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetLatestTransaction
{
    public class GetLatestTransactionQueryHandler : IRequestHandler<GetLatestTransactionQuery, GetLatestTransactionQueryResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetLatestTransactionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetLatestTransactionQueryResult> Handle(GetLatestTransactionQuery request, CancellationToken cancellationToken)
        {
            var transactionsList = await _dbContext.WalletTransactions.Where(x => x.TransactionUserId == request.UserId)
                .Include(x=> x.AuthorizedUser)
                .Include(x=> x.TransactionUser)
                .ProjectTo<WalletTransactionModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (!transactionsList.Any())
            {
                throw new NotFoundException(nameof(transactionsList));
            }

            return new GetLatestTransactionQueryResult()
            {
                LatestTransactionsList = transactionsList
            };
        }
    }
}
