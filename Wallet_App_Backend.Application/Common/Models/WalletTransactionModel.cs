using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public string TransactionDate { get; set; }
        public WalletTransactionStatus TransactionStatus { get; set; }
        public string TransactionIconPath { get; set; }
        public string CreatedBy { get; set; }
        public UserModel UserModel { get; set; }
        public UserModel AuthorizedUserModel { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<WalletTransaction, WalletTransactionModel>()
                .ForMember(x => x.AuthorizedUserModel, y => y.MapFrom(z => z.AuthorizedUser))
                .ForMember(x => x.UserModel, y => y.MapFrom(z => z.TransactionUser))
                .ForMember(x => x.TransactionAmount, y => y.MapFrom(z => AmountCalculation(z)))
                .ForMember(x => x.TransactionDate, y => y.MapFrom(z => DateConverter(z)))
                .ForMember(x => x.TransactionDescription, y => y.MapFrom(z => DescriptionConverter(z)));
            profile.CreateMap<WalletTransactionModel, WalletTransaction>()
                .ForMember(x=> x.AuthorizedUser, y=> y.Ignore())
                .ForMember(x=> x.TransactionUser, y=> y.Ignore())
                .ForMember(x => x.TransactionDate, y=> y.MapFrom(z=> DateTime.Parse(z.TransactionDate)))
                .ForMember(x=> x.TransactionUserId, y=> y.MapFrom(z=> z.UserModel.Id))
                .ForMember(x=> x.AuthorizedUserId, y=> y.MapFrom(z=> z.AuthorizedUserModel.Id));
            
        }

        private static double AmountCalculation(WalletTransaction src)
        {
            return src.TransactionType == WalletTransactionType.Payment
                ? src.TransactionAmount
                : -src.TransactionAmount;
        }

        private static string DescriptionConverter(WalletTransaction src)
        {
            return src.TransactionStatus == WalletTransactionStatus.Pending
                ? string.Join(" ", new[] { WalletTransactionStatus.Pending.ToString(), src.TransactionDescription })
                : src.TransactionDescription;
        }

        private static string DateConverter(WalletTransaction src)
        {
            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
            DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);

            string authorizedUserName = "";

            if (src.AuthorizedUser != null && src.AuthorizedUser.Id != src.TransactionUser.Id)
            {
                authorizedUserName = src.AuthorizedUser.Name;
            }

            if (DateTime.Compare(currentWeekStartDate, src.TransactionDate) > 0)
            {
                return
                    string.Join(" ", new[] { authorizedUserName, src.TransactionDate.ToShortDateString() });
            }

            return string.Join(" ", new[] { authorizedUserName, src.TransactionDate.DayOfWeek.ToString() });
        }
    }
}
