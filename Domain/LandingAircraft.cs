using System.Collections.Generic;
using OptimalMotion2.Enums;

namespace OptimalMotion2.Domain
{
    public class LandingAircraft : ILandingAircraft
    {
        public LandingAircraft(ILandingAircraftData data)
        {
            Id = data.Id;
            runwayId = data.RunwayId;
            Moments = data.Moments;
            OrderMoment = Moments.Landing;
            Intervals = data.Intervals;
        }

        private int runwayId;

        public IAircraftId Id { get; set; }
        public ILandingAircraftMoments Moments { get; }
        public ILandingAircraftIntervals Intervals { get; }
        public IMoment OrderMoment { get; set; }

        public int GetRunwayId()
        {
            return runwayId;
        }

        //public IInterval GetRunwayOccupationInterval()
        //{
        //    var endMoment = new Moment(Moments[Enums.Moments.Landing].Value + Intervals[Enums.Intervals.Landing]);

        //    return new Interval(Moments[Enums.Moments.Landing], endMoment);
        //}
    }
}
