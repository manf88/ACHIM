using Raspberry.IO.GeneralPurpose;
using System;
using System.Threading;
using ACHIM.Positioning.MotorControl;
using Ninject;
using ACHIM.General.IoCBindings;
using System.Reflection;

namespace ACHIM.StopSwitch.Test
{
    internal class Program
    {
        private static IMotorController motorControl;
        private static Direction currentDirection;

        private static void Main(string[] args)
        {
            var kernel = new StandardKernel(new Bindings());
            kernel.Load(Assembly.GetExecutingAssembly());

            motorControl = kernel.Get<IMotorController>();
            motorControl.MotorPin1 = ConnectorPin.P1Pin11;
            motorControl.MotorPin2 = ConnectorPin.P1Pin13;
            motorControl.Initialize();

            Initialize();

            motorControl.StartTestRun();

            while (true)
            {

            }
        }

        private static void Initialize()
        {
            //InputPinConfiguration pin1, pin2, pin3, pin4, pin5;

            //pin1 = ConnectorPin.P1Pin08.Input().OnStatusChanged(p =>
            //{
            //    Console.WriteLine("Switch1 turned {0}", p ? "on" : "off");
            //});
            //pin2 = ConnectorPin.P1Pin10.Input().OnStatusChanged(p =>
            //{
            //    Console.WriteLine("Switch2 turned {0}", p ? "on" : "off");
            //});
            //pin3 = ConnectorPin.P1Pin12.Input().OnStatusChanged(p =>
            //{
            //    Console.WriteLine("Switch3 turned {0}", p ? "on" : "off");
            //});
            //pin4 = ConnectorPin.P1Pin16.Input().OnStatusChanged(p =>
            //{
            //    Console.WriteLine("Switch4 turned {0}", p ? "on" : "off");
            //});
            //pin5 = ConnectorPin.P1Pin18.Input().OnStatusChanged(p =>
            //{
            //    Console.WriteLine("Switch5 turned {0}", p ? "on" : "off");
            //});

            //var witch1 = new GpioConnection(pin1);
            //var witch2 = new GpioConnection(pin2);
            //var witch3 = new GpioConnection(pin3);
            //var witch4 = new GpioConnection(pin4);
            //var witch5 = new GpioConnection(pin5);

            var switch1 = new ACHIM.Positioning.StopSwitch();
            switch1.Pin = ConnectorPin.P1Pin08;
            switch1.Initialize();
            motorControl.RegisterSwitch(switch1);

            var switch2 = new ACHIM.Positioning.StopSwitch();
            switch2.Pin = ConnectorPin.P1Pin10;
            switch2.Initialize();
            motorControl.RegisterSwitch(switch2);

            var switch3 = new ACHIM.Positioning.StopSwitch();
            switch3.Pin = ConnectorPin.P1Pin12;
            switch3.Initialize();
            motorControl.RegisterSwitch(switch3);

            var switch4 = new ACHIM.Positioning.StopSwitch();
            switch4.Pin = ConnectorPin.P1Pin16;
            switch4.Initialize();
            motorControl.RegisterSwitch(switch4);

            var switch5 = new ACHIM.Positioning.StopSwitch();
            switch5.Pin = ConnectorPin.P1Pin18;
            switch5.Initialize();
            motorControl.RegisterSwitch(switch5);
        }
    }
}