

namespace OptimalMotion2.Domain
{
    public class LandingAircraftIntervals : ILandingAircraftIntervals
    {
        public LandingAircraftIntervals(IInterval landing)
        {
            Landing = landing;
        }

        public IInterval Landing { get; }
    }
}
