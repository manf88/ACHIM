using ACHIM.Logic.IoCBindings;
using ACHIM.MotorControl;
using ACHIM.PumpControl;
using Ninject;
using RaspberryPiDotNet;
using System;
using System.Reflection;
using System.Threading;

namespace ACHIM.Logic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new Bindings());
            kernel.Load(Assembly.GetExecutingAssembly());

            IMotorController motorControl = kernel.Get<IMotorController>();
            IPumpController pumpControl = kernel.Get<IPumpController>();

            motorControl.PIN1 = 11;
            motorControl.PIN2 = 15;
            motorControl.setPins();

            pumpControl.RPiPin = 3;
            pumpControl.SetPin();

            while (true)
            {
                motorControl.Stop();
                pumpControl.Stop();

                Thread.Sleep(1000);

                Console.WriteLine("Resetting ...");
                motorControl.Start(Direction.LEFT, 1100);

                Thread.Sleep(1000);

                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine(string.Format("Step ... {0}", i));
                    motorControl.Start(Direction.RIGHT, 180);
                    Thread.Sleep(1000);
                    pumpControl.Start();
                    Thread.Sleep(1000);
                    pumpControl.Stop();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}