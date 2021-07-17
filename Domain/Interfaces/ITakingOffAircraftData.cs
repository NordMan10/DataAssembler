

namespace OptimalMotion2.Domain
{
    public interface ITakingOffAircraftData
    {
        IAircraftId Id { get; }
        ITakingOffAircraftMoments Moments { get; }
        ITakingOffAircraftIntervals Intervals { get; } 
        IRunway Runway { get; }
        ISpecPlatform SpecPlatform { get; } 
        bool ProcessingIsNeeded { get; }
    }
}
