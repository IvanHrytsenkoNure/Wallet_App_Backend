using MediatR;
using Wallet_App_Backend.Application.Interfaces;

namespace Wallet_App_Backend.Application.Core.Application.Queries.GetUserPoints
{
    public class GetUserPointsQueryHandler : IRequestHandler<GetUserPointsQuery, GetUserPointsQueryResult>
    {

        private readonly ISeasonsHelper _seasonsHelper;

        public GetUserPointsQueryHandler(ISeasonsHelper seasonsHelper)
        {
            _seasonsHelper = seasonsHelper;
        }

        public Task<GetUserPointsQueryResult> Handle(GetUserPointsQuery request, CancellationToken cancellationToken)
        {

            var dayNumberInCurrentSeason = _seasonsHelper.GetSeasonDayNumberOfDate(DateTime.Now);

            var calculatedPoints = CalculatePoints(dayNumberInCurrentSeason);

            var roundedPointsValue = FormatToKiloForm(calculatedPoints);

            return Task.FromResult(new GetUserPointsQueryResult() { UserPointsAmount = roundedPointsValue });
        }

        public static long CalculatePoints(int dayNumber)
        {
            long firstDayPoint = 2;
            long secondDayPoint = 3;
            switch (dayNumber)
            {
                case 1:
                    return firstDayPoint;
                case 2:
                    return secondDayPoint;
                default:
                    long currentDayPoint = secondDayPoint;
                    long previousDayPoint = firstDayPoint;

                    for (int i = 3; i <= dayNumber; i++)
                    {
                        var currentDayPointCopy = currentDayPoint;
                        currentDayPoint = (long)Math.Round(previousDayPoint + 0.6 * currentDayPoint, MidpointRounding.AwayFromZero);

                        previousDayPoint = currentDayPointCopy;
                    };

                    return currentDayPoint;
            }
        }


        public static string FormatToKiloForm(long value)
        {
            //if (value >= 1000)
            //    return FormatToKiloForm(value / 1000) + "K";

            return (value / 1000) + "K";
        }


    }
}
