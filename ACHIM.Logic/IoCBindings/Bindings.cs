using ACHIM.Logic.Plants;
using ACHIM.Positioning;
using ACHIM.Positioning.MotorControl;
using ACHIM.PumpControl;
using Ninject.Modules;

namespace ACHIM.Logic.IoCBindings
{
    internal class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMotorDriver>().To<MotorDriver>();
            Bind<IMotorController>().To<MotorController>();
            Bind<IPumpController>().To<PumpController>();
            Bind<IStopSwitch>().To<StopSwitch>();
            Bind<IPlant>().To<Plant>();
        }
    }
}