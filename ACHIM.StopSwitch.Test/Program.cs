using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Raspberry.IO.GeneralPurpose;


namespace ACHIM.StopSwitch.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var pin1 = ConnectorPin.P1Pin08.Input().OnStatusChanged(p => 
                {
                    Console.WriteLine("hans turned {0}", p ? "on" : "off");
                });
            var switch2 = ConnectorPin.P1Pin10.Input();
            var switch3 = ConnectorPin.P1Pin12.Input();
            var switch4 = ConnectorPin.P1Pin16.Input();
            var switch5 = ConnectorPin.P1Pin18.Input();

            var switch1 = new GpioConnection(pin1);


            using (var hans = new GpioConnection())
            {
                hans.Add(pin1);
                Console.ReadKey(true);
            }
        }
    }
}