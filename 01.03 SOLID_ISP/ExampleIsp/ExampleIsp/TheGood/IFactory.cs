using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleIsp.TheGood
{
    public interface IFactory
    {
        int StartShift();

        int CloseShift();

        int StartProductionLane();

        int StopProductionLane();

        int ProduceBody();

        int ProduceEngine();

        int ProduceGears();

        int ProduceHeadLamps();

        int ProduceElectronics();

        //the painters
        int Paint(int paintColour);

    }
}
