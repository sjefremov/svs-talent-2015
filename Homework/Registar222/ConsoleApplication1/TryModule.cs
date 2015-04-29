using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class TryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Ninja>();
        }
    }
    public interface IWeapon
    {
        void sord();
    }
    public class Ninja : IWeapon
    {
        public void sord()
        {
            Console.WriteLine("Ninja: I am using Sord");
        }
    }
    public class sourav
    {
        IWeapon ObjWeapon = null;
        public sourav(IWeapon tmpWeapon)
        {
            this.ObjWeapon = tmpWeapon;
        }

        public void Attack()
        {
            this.ObjWeapon.sord();
        }
    }  
}
