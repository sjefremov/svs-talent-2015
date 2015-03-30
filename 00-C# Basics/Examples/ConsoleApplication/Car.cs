using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    /// <summary>
    /// Delegate that will be called on each car start
    /// </summary>
    /// <param name="timeStarted"></param>
    /// <param name="numberOfStart"></param>
    public delegate void CarStarted(DateTime timeStarted, int numberOfStart);

    public class Car:ICar, IKillerCar
    {


        public int TotalNumberOfStarts { get; private set; }

        public event CarStarted OnCarstarted;

        public CarStarted OnCarSstartedDelegate { get; set; }

        public virtual void StartTheCar(int delay)
        {
            //TODO start engine
            //TODO lock the car
            this.TotalNumberOfStarts++;
            //raise event
            this.OnCarstarted(DateTime.Now, this.TotalNumberOfStarts);
        }

        void ICar.Execute(int delay)
        {
            Console.WriteLine("Execute something without kill");
        
        }

        void IKillerCar.Execute(int delay)
        {
            Console.WriteLine("Execute something with kill");
        }

    }
}
