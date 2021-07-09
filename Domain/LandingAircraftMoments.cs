

namespace OptimalMotion2.Domain
{
    public class LandingAircraftMoments : ILandingAircraftMoments
    {
        public LandingAircraftMoments(IMoment landing)
        {
            Landing = landing;
        }

        public IMoment Landing { get; }

    }
}
