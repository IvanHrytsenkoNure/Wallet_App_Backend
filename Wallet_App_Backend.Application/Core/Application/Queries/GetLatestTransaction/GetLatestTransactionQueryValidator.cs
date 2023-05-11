using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Application.Interfaces;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetLatestTransaction
{
    public class GetLatestTransactionQueryValidator : AbstractValidator<GetLatestTransactionQuery>
    {
        private readonly IApplicationDbContext _context;

        public GetLatestTransactionQueryValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(request => request.UserId).NotEqual(Guid.Empty);

            RuleFor(x => x)
                .MustAsync(UserBeExisting).WithMessage($"Requested user could not be found");
        }

        public async Task<bool> UserBeExisting(GetLatestTransactionQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AnyAsync(x => x.Id == request.UserId, cancellationToken);
        }


    }
}
