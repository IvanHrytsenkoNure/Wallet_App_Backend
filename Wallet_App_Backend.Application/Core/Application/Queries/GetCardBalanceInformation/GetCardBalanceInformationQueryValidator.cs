using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Application.Interfaces;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetCardBalanceInformation
{
    public class GetCardBalanceInformationQueryValidator : AbstractValidator<GetCardBalanceInformationQuery>
    {
        private readonly IApplicationDbContext _context;

        public GetCardBalanceInformationQueryValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(request => request.UserId).NotEqual(Guid.Empty);

            RuleFor(x => x)
                .MustAsync(UserBeExisting).WithMessage($"Requested user could not be found");
        }

        public async Task<bool> UserBeExisting(GetCardBalanceInformationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AnyAsync(x => x.Id == request.UserId, cancellationToken);
        }


    }
}
