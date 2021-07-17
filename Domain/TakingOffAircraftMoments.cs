using System.Collections.Generic;
using OptimalMotion2.Enums;

namespace OptimalMotion2.Domain
{
    public class TakingOffAircraftMoments : ITakingOffAircraftMoments
    {
        /// <summary>
        /// Warning! Check value of moments! It may be null
        /// </summary>
        /// <param name="creationMoment"></param>
        /// <param name="engineStartMoment"></param>
        /// <param name="arriveToPSMoment"></param>
        /// <param name="arriveToESMoment"></param>
        public TakingOffAircraftMoments(IMoment takingOffMoment, IMoment engineStartMoment = null,
            IMoment arriveToPSMoment = null, IMoment arriveToESMoment = null
            )
        {
            TakingOff = takingOffMoment;
            EngineStart = engineStartMoment;
            ArriveToPS = arriveToPSMoment;
            ArriveToES = arriveToESMoment;
        }
        
        public IMoment TakingOff { get; }
        /// <summary>
        /// May be null!
        /// </summary>
        public IMoment EngineStart { get; set; }
        /// <summary>
        /// May be null!
        /// </summary>
        public IMoment ArriveToPS { get; set; }
        /// <summary>
        /// May be null!
        /// </summary>
        public IMoment ArriveToES { get; set; }
    }
}
