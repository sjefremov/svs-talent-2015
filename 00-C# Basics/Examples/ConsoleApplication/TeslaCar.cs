using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class TeslaCar:Car
    {
        private static TeslaCar sTesla;

        static TeslaCar()
        {
            sTesla = new TeslaCar();
        }


        public TeslaCar()
        {
        }


        public static TeslaCar GetTesla()
        {
            return sTesla;
        }

        public override void StartTheCar(int delay)
        {
            Console.WriteLine("Start the car tesla!");
        }
    }
}
