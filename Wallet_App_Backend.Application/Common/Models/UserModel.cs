using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet_App_Backend.Application.Common.Mappings;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.Application.Common.Models
{
    public class UserModel : IMapWith<WalletTransaction>
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserModel>();
            profile.CreateMap<UserModel, User>();
        }
    }
}
