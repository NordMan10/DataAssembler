

namespace OptimalMotion2.Domain
{
    public class TakingOffAircraftData : ITakingOffAircraftData
    {
        public TakingOffAircraftData(IAircraftId id, ITakingOffAircraftMoments moments,
            ITakingOffAircraftIntervals intervals, IRunway runway,
            ISpecPlatform specPlatform, bool processingIsNeeded)
        {
            Id = id;
            Moments = moments;
            Intervals = intervals;
            Runway = runway;
            SpecPlatform = specPlatform;
            ProcessingIsNeeded = processingIsNeeded;
        }

        public IAircraftId Id { get; }
        public ITakingOffAircraftMoments Moments { get; }
        public ITakingOffAircraftIntervals Intervals { get; }
        public IRunway Runway { get; }
        public ISpecPlatform SpecPlatform { get; }
        public bool ProcessingIsNeeded { get; }
    }
}
