using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSrp.TheGood
{
    public class StatusLogger : ILogger
    {
        private static StatusLogger sStatusLogerInstance;
        static StatusLogger()
        {
            sStatusLogerInstance = new StatusLogger();
        }
        private StatusLogger()
        {
            
        }
        public void Log(string message)
        {
            Console.WriteLine("Status message on client phone: " + message);
        }
        public static StatusLogger GetInstance()
        {
            return sStatusLogerInstance;
        }
    }
}
