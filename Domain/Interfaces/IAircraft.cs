

namespace OptimalMotion2.Domain
{
    public interface IAircraft
    {
        IAircraftId Id { get; set; }
        IMoment OrderMoment { get; set; }
        int GetRunwayId();
    }
}
