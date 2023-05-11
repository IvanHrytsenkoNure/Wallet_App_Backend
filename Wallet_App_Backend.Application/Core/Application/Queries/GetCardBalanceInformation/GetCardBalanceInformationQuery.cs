using MediatR;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetCardBalanceInformation
{
    public class GetCardBalanceInformationQuery : IRequest<GetCardBalanceInformationQueryResult>
    {
        public Guid UserId { get; set; }

    }
}
