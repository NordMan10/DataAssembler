using OptimalMotion2.Enums;

namespace OptimalMotion2.Domain
{
    public class ChartMomentData : IChartMomentData
    {
        public ChartMomentData(IAircraftId aircraftId, IMoment moment, AircraftType type, ChartMomentDataType subType)
        {
            AircraftId = aircraftId;
            Moment = moment;
            Type = type;
            SubType = subType;
        }

        public IAircraftId AircraftId { get; }
        public IMoment Moment { get; }
        public AircraftType Type { get; }
        public ChartMomentDataType SubType { get; }

    }
}
