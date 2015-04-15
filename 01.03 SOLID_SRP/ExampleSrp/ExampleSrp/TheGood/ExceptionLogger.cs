using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSrp.TheGood
{
    public class ExceptionLogger : ILogger
    {
        private static ExceptionLogger sExceptionLogerInstance;
        static ExceptionLogger()
        {
            sExceptionLogerInstance = new ExceptionLogger();
        }
        private ExceptionLogger()
        {
            
        }
        public void Log(string message)
        {
            Console.WriteLine("Exception message on cloud: " + message);
        }
        public static ExceptionLogger GetInstance()
        {
            return sExceptionLogerInstance;
        }
    }
}
