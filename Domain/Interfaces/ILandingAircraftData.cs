

namespace OptimalMotion2.Domain
{
    public interface ILandingAircraftData
    {
        IAircraftId Id { get; }
        int RunwayId { get; }
        ILandingAircraftMoments Moments { get; } 
        ILandingAircraftIntervals Intervals { get; }
    }
}
