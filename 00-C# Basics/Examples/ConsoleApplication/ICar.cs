using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICar
    {
        void Execute(int delay);
    }

    public interface IKillerCar
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="delay"></param>
        void Execute(int delay);
    }
}
