using Raspberry.IO.GeneralPurpose;
using System;
using System.Threading;

namespace ACHIM.SoilSensor.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var pin1 = ConnectorPin.P1Pin22.Input();

            var driver = new GpioConnectionDriver();

            var settings = new GpioConnectionSettings();

            settings.Driver = driver;

            using (var hans = new GpioConnection(settings))
            {
                hans.Add(pin1);

                while (true)
                {
                    Console.WriteLine(settings.Driver.Read(pin1.Pin));
                    Thread.Sleep(100);
                }
            }
        }
    }
}
