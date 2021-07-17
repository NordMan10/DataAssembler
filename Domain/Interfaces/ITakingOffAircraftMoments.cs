using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptimalMotion2.Enums;

namespace OptimalMotion2.Domain
{
    public interface ITakingOffAircraftMoments
    {
        IMoment TakingOff { get; }
        IMoment EngineStart { get; set; }
        IMoment ArriveToPS { get; set; }
        IMoment ArriveToES { get; set; }
    }
}
