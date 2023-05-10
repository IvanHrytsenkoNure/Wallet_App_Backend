using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Wallet_App_Backend.Application.Core.Application.Commands.AddUserCommand
{
    public class AddUserCommand : IRequest<bool>
    {
        public Guid CreatorId { get; set; }
    }
}
