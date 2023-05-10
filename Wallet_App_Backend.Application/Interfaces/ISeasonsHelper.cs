using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet_App_Backend.Data.Enums;

namespace Wallet_App_Backend.Application.Interfaces
{
    public interface ISeasonsHelper
    {
        Season GetSeasonOfDate(DateTime date);

        int GetSeasonDayNumberOfDate(DateTime date);

    }
}
