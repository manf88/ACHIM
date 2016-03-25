using Raspberry.IO.GeneralPurpose;
using ACHIM.Positioning.MotorControl;
using Ninject;
using ACHIM.General.IoCBindings;
using System.Reflection;

namespace ACHIM.StopSwitch.Test
{
    internal class Program
    {
        private static IMotorController motorControl;
        private static Direction _currentDirection;

        private static void Main(string[] args)
        {
            var kernel = new StandardKernel(new Bindings());
            kernel.Load(Assembly.GetExecutingAssembly());

            motorControl = kernel.Get<IMotorController>();
            motorControl.MotorPin1 = ConnectorPin.P1Pin11;
            motorControl.MotorPin2 = ConnectorPin.P1Pin13;
            motorControl.Initialize();

            RegisterStopSwitches();

            motorControl.StartTestRun();

            while (true)
            {

            }
        }

        private static void RegisterStopSwitches()
        {
            var switch1 = new Positioning.StopSwitch();
            switch1.Pin = ConnectorPin.P1Pin08;
            switch1.Initialize();
            motorControl.RegisterSwitch(switch1);

            var switch2 = new Positioning.StopSwitch();
            switch2.Pin = ConnectorPin.P1Pin10;
            switch2.Initialize();
            motorControl.RegisterSwitch(switch2);

            var switch3 = new Positioning.StopSwitch();
            switch3.Pin = ConnectorPin.P1Pin12;
            switch3.Initialize();
            motorControl.RegisterSwitch(switch3);

            var switch4 = new Positioning.StopSwitch();
            switch4.Pin = ConnectorPin.P1Pin16;
            switch4.Initialize();
            motorControl.RegisterSwitch(switch4);

            var switch5 = new Positioning.StopSwitch();
            switch5.Pin = ConnectorPin.P1Pin18;
            switch5.Initialize();
            motorControl.RegisterSwitch(switch5);
        }
    }
}