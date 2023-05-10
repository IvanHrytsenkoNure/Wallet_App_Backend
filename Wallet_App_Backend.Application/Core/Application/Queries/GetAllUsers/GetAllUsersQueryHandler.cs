using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Application.Common.Exceptions;
using Wallet_App_Backend.Application.Common.Models;
using Wallet_App_Backend.Application.Interfaces;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersQueryResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAllUsersQueryResult> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {

            var usersList = await _dbContext.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (!usersList.Any())
            {
                throw new NotFoundException(nameof(usersList));

            }

            return new GetAllUsersQueryResult { UsersList = usersList };

        }
    }
}
