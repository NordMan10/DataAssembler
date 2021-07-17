using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalMotion2.Domain
{
    public interface ISpecPlatform
    {
        int Id { get; }

        Tuple<int, int> GetProcessingAndSafeMergeDelay(IInterval aircraftInterval, int safeMergeValueParam);
    }
}
