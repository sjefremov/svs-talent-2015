using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleIsp.TheGood
{
    public class MotoFactory:IFactory, IFactoryMoto
    {
        int IFactory.StartShift()
        {
            throw new NotImplementedException();
        }

        int IFactory.CloseShift()
        {
            throw new NotImplementedException();
        }

        int IFactory.StartProductionLane()
        {
            throw new NotImplementedException();
        }

        int IFactory.StopProductionLane()
        {
            throw new NotImplementedException();
        }

        int IFactory.ProduceBody()
        {
            throw new NotImplementedException();
        }

        int IFactory.ProduceEngine()
        {
            throw new NotImplementedException();
        }

        int IFactory.ProduceGears()
        {
            throw new NotImplementedException();
        }

        int IFactory.ProduceHeadLamps()
        {
            throw new NotImplementedException();
        }

        int IFactory.ProduceElectronics()
        {
            throw new NotImplementedException();
        }

        int IFactory.Paint(int paintColour)
        {
            throw new NotImplementedException();
        }

        int IFactoryMoto.ProduceFrame()
        {
            throw new NotImplementedException();
        }

        int IFactoryMoto.ProduceHandles()
        {
            throw new NotImplementedException();
        }

        int IFactoryMoto.ProduceTank()
        {
            throw new NotImplementedException();
        }

        int IFactoryMoto.ProduceEngine()
        {
            throw new NotImplementedException();
        }

        int IFactoryMoto.ProduceGears()
        {
            throw new NotImplementedException();
        }

        int IFactoryMoto.Paint(int paintColour)
        {
            throw new NotImplementedException();
        }
    }
}
