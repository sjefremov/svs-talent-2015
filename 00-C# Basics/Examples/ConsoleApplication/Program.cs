using System;
using gen = System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TeslaCar tesla = TeslaCar.GetTesla();
            System.Collections.Generic.Dictionary<string, string> v = null;
            gen.Dictionary<string, string> t = null;

            Car theExperimentalCar = new Car();
            //ICar theInterfaceCar = theExperimentalCar as ICar;
            //theExperimentalCar.
            //theExperimentalCar.OnCarstarted += HandleCarStart;
            //theExperimentalCar.OnCarstarted += HandleCarStartTwo;
            //theExperimentalCar.OnCarSstartedDelegate = new CarStarted(HandleCarStart);
            //theExperimentalCar.OnCarSstartedDelegate = null;
            
            for (int i = 0; i < 10; i++)
            {

                if (i == 5)
                    theExperimentalCar = new TeslaCar();
                theExperimentalCar.OnCarstarted += HandleCarStart;
                theExperimentalCar.OnCarstarted += HandleCarStartTwo;
                //
                theExperimentalCar.StartTheCar(10);
                //
                theExperimentalCar.OnCarstarted -= HandleCarStart;
                theExperimentalCar.OnCarstarted -= HandleCarStartTwo;

            }
            Console.ReadLine();
        }

        private static void HandleCarStart(DateTime timeStart, int numberOfStarts)
        {
            Console.WriteLine("The car has been started again on {0}, this is start no: {1}",timeStart,numberOfStarts);
        }

        private static void HandleCarStartTwo(DateTime timeStart, int numberOfStarts)
        {
            Console.WriteLine("Two:The car has been started again on {0}, this is start no: {1}", timeStart, numberOfStarts);
        }
    }
}
