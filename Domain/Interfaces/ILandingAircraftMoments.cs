using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptimalMotion2.Enums;

namespace OptimalMotion2.Domain
{
    public interface ILandingAircraftMoments
    {
        IMoment Landing { get; }
    }
}
