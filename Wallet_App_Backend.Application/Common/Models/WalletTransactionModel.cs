using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet_App_Backend.Application.Common.Mappings;
using Wallet_App_Backend.Data.Entities;
using Wallet_App_Backend.Data.Enums;

namespace Wallet_App_Backend.Application.Common.Models
{
    public class WalletTransactionModel :  IMapWith<WalletTransaction>
    {

        public WalletTransactionType TransactionType { get; set; }
        public double TransactionAmount { get; set; }
        public string TransactionName { get; set; }
        public string TransactionDescription { get; set; }
        public DateTime TransactionDate { get; set; }
        public WalletTransactionStatus TransactionStatus { get; set; }
        public string TransactionIconPath { get; set; }
        public string CreatedBy { get; set; }
        public UserModel UserModel { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<WalletTransaction, WalletTransactionModel>()
                .ForMember(x=> x.UserModel, y=> y.MapFrom(z=> z.TransactionUser));
            profile.CreateMap<WalletTransactionModel, WalletTransaction>()
                .ForMember(x=> x.TransactionUser, y=> y.Ignore())
                .ForMember(x=> x.TransactionUserId, y=> y.MapFrom(z=> z.UserModel.Id));


        }
    }
}
