

namespace OptimalMotion2.Domain
{
    public class LandingAircraftData : ILandingAircraftData
    {
        public LandingAircraftData(IAircraftId id, ILandingAircraftMoments moments,
            ILandingAircraftIntervals intervals, int runwayIndex)
        {
            Id = id;
            RunwayId = runwayIndex;
            Moments = moments;
            Intervals = intervals;
        }

        public IAircraftId Id { get; }
        public int RunwayId { get; }
        public ILandingAircraftMoments Moments { get; }
        public ILandingAircraftIntervals Intervals { get; }
    }
}
