using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet_App_Backend.Application.Interfaces;
using Wallet_App_Backend.Data;
using Wallet_App_Backend.Data.Enums;

namespace Wallet_App_Backend.Application.Core.Services
{
    public class SeasonsHelper : ISeasonsHelper
    {
        public Season GetSeasonOfDate(DateTime date)
        {

            return (Season)Math.Ceiling((date.Month - Constants.SeasonCalculationOffset) / Constants.MonthsInSeason);
        }

        public int GetSeasonDayNumberOfDate(DateTime date)
        {
            var season = GetSeasonOfDate(date);

            var seasonStartMonthNumber = (int)season*3;

            var seasonDayNumber = 0;

            while (seasonStartMonthNumber < DateTime.Now.Month)
            {
                seasonDayNumber += DateTime.DaysInMonth(DateTime.Now.Year, seasonStartMonthNumber);

                seasonStartMonthNumber++;
            }

            seasonDayNumber += date.Day;

            return seasonDayNumber;
        }
    }
}
