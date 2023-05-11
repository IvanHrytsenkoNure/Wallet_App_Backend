using MediatR;
using Wallet_App_Backend.Data;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetCardBalanceInformation
{
    public class GetCardBalanceInformationQueryHandler : IRequestHandler<GetCardBalanceInformationQuery, GetCardBalanceInformationQueryResult>
    {
        public Task<GetCardBalanceInformationQueryResult> Handle(GetCardBalanceInformationQuery request, CancellationToken cancellationToken)
        {
            var random= new Random();

            var balanceAmount = random.Next(1500);

            return Task.FromResult(new GetCardBalanceInformationQueryResult()
            {
                Balance = balanceAmount,
                AvailableAmount = Constants.MaxCardLimit - balanceAmount
            });
        }
    }
}
