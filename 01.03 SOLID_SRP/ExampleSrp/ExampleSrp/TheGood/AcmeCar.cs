using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSrp.TheGood
{
    public delegate void Logging(string message);
    public class AcmeCar
    {
        public LockState IsLocked { get; private set; }
        private event Logging OnStatusChange;
        private event Logging OnException;

        public AcmeCar(ILogger exceptionLogger, ILogger statusLogger)
        {
            if ((exceptionLogger == null) || (statusLogger == null))
            {
                throw new NullReferenceException("Some of the arguments is null");
            }
            else
            {
                this.OnException += exceptionLogger.Log;
                this.OnStatusChange += statusLogger.Log;
            }
            
        }
        public void Lock()
        {
            try
            {
                //
                this.IsLocked = LockState.Locked;
                //log state change in computer
                this.OnStatusChange("CarLocked");

            }
            catch (Exception)
            {
                this.OnException("There was an error locking the car!");
            }
        }

        public void Unlock()
        {
            try
            {
                //
                this.IsLocked = LockState.Unlocked;
                //
                this.OnStatusChange("CarUnlocked");
            }
            catch (Exception)
            {
                this.OnException("There was an error unlocking the car!");
            }

        }

    }

    public enum LockState
    {
        Error = 0,
        Locked = 1,
        Unlocked = 2,

    }
}
