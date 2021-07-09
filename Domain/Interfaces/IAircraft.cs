using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptimalMotion2.Enums;
using OptimalMotion2.Domain.Interfaces;

namespace OptimalMotion2.Domain
{
    public interface IAircraft
    {
        IAircraftId Id { get; set; }
        IMoment OrderMoment { get; set; }
        int GetRunwayId();
        //IInterval GetRunwayOccupationInterval();
    }
}
