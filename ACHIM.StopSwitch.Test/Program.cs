using RaspberryPiDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACHIM.StopSwitch.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GPIOMem switch1 = new GPIOMem(ACHIM.Helper.PinConverter.getPin(8));
            GPIOMem switch2 = new GPIOMem(ACHIM.Helper.PinConverter.getPin(10));
            GPIOMem switch3 = new GPIOMem(ACHIM.Helper.PinConverter.getPin(12));
            GPIOMem switch4 = new GPIOMem(ACHIM.Helper.PinConverter.getPin(16));
            GPIOMem switch5 = new GPIOMem(ACHIM.Helper.PinConverter.getPin(18));

            while (true)
            {
                Console.WriteLine(switch1.Read() + " | " + switch2.Read() + " | " + switch3.Read() + " | " + switch4.Read() + " | " + switch5.Read() + " | ");

                Thread.Sleep(1000);
            }
        }
    }
}