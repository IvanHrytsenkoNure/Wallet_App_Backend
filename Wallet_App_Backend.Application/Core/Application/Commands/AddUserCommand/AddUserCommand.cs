using MediatR;

namespace Wallet_App_Backend.Application.Core.Application.Commands.AddUserCommand
{
    public class AddUserCommand : IRequest<bool>
    {
        public Guid CreatorId { get; set; }
        public string Name { get; set; }
    }
}
