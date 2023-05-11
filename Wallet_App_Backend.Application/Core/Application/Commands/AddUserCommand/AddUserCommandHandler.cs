using MediatR;
using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Application.Interfaces;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.Application.Core.Application.Commands.AddUserCommand
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
    {

        private readonly IApplicationDbContext _dbContext;

        public AddUserCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            var creator = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.CreatorId, cancellationToken);

            if (creator == null)
            {
                return false;
            }

            await _dbContext.Users.AddAsync(new User()
            {
                Name = request.Name,
                CreatedBy = creator.Id.ToString()
            }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
