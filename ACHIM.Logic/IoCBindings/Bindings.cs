using ACHIM.MotorControl;
using ACHIM.PumpControl;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.Logic.IoCBindings
{
    internal class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMotorController>().To<MotorController>();
            Bind<IPumpController>().To<PumpController>();
        }
    }
}