using AutoMapper;
using Wallet_App_Backend.Application.Common.Mappings;
using Wallet_App_Backend.Data.Entities;

namespace Wallet_App_Backend.Application.Common.Models
{
    public class UserModel : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserModel>();
            profile.CreateMap<UserModel, User>();
        }
    }
}
