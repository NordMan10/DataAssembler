

namespace OptimalMotion2.Domain
{
    public class TakingOffAircraftIntervals : ITakingOffAircraftIntervals
    {
        public TakingOffAircraftIntervals(
            IInterval motionFromParkingToPS, IInterval motionFromPSToES, IInterval takeoff,
            IInterval motionFromParkingToSP, IInterval motionFromSPToPS)
        {
            MotionFromParkingToPS = motionFromParkingToPS;
            MotionFromPSToES = motionFromPSToES;
            Takeoff = takeoff;
            MotionFromParkingToSP = motionFromParkingToSP;
            MotionFromSPToPS = motionFromSPToPS;
        }


        public IInterval MotionFromParkingToPS { get; }
        public IInterval MotionFromPSToES { get; }
        public IInterval Takeoff { get; }
        public IInterval MotionFromParkingToSP { get; }
        public IInterval MotionFromSPToPS { get; }
    }
}
