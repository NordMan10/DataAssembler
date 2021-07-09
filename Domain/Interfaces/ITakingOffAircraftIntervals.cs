using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptimalMotion2.Enums;

namespace OptimalMotion2.Domain
{
    public interface ITakingOffAircraftIntervals
    {
        IInterval MotionFromParkingToPS { get; }
        IInterval MotionFromPSToES { get; }
        IInterval Takeoff { get; }
        IInterval MotionFromParkingToSP { get; }
        IInterval MotionFromSPToPS { get; }
    }
}
