using ACHIM.Positioning;
using ACHIM.Positioning.MotorControl;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.General.IoCBindings
{
    internal class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMotorDriver>().To<MotorDriver>();
            Bind<IMotorController>().To<MotorController>();
            //Bind<IPumpController>().To<PumpController>();
            Bind<IStopSwitch>().To<ACHIM.Positioning.StopSwitch>();
            //Bind<IPlant>().To<Plant>();
        }
    }
}