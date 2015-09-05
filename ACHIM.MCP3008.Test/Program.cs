using Raspberry.IO.Components.Converters.Mcp3008;
using Raspberry.IO.Components.Sensors;
using Raspberry.IO.Components.Sensors.Temperature.Tmp36;
using Raspberry.IO.GeneralPurpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitsNet;

namespace ACHIM.MCP3008.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            const ConnectorPin adcClock = ConnectorPin.P1Pin23;
            const ConnectorPin adcMiso = ConnectorPin.P1Pin21;
            const ConnectorPin adcMosi = ConnectorPin.P1Pin19;
            const ConnectorPin adcCs = ConnectorPin.P1Pin22;

            Console.WriteLine("MCP-3008 Sample: Reading temperature on Channel 0 and luminosity on Channel 1");
            Console.WriteLine();
            Console.WriteLine("\tClock: {0}", adcClock);
            Console.WriteLine("\tCS: {0}", adcCs);
            Console.WriteLine("\tMOSI: {0}", adcMosi);
            Console.WriteLine("\tMISO: {0}", adcMiso);
            Console.WriteLine();

            ElectricPotential voltage = ElectricPotential.FromVolts(3.3);

            var driver = new MemoryGpioConnectionDriver(); //GpioConnectionSettings.DefaultDriver;

            using (var adcConnection = new Mcp3008SpiConnection(
                driver.Out(adcClock),
                driver.Out(adcCs),
                driver.In(adcMiso),
                driver.Out(adcMosi)))
            using (var temperatureConnection = new Tmp36Connection(
                adcConnection.In(Mcp3008Channel.Channel0),
                voltage))
            using (var lightConnection = new VariableResistiveDividerConnection(
                adcConnection.In(Mcp3008Channel.Channel1),
                ResistiveDivider.ForLowerResistor(ElectricResistance.FromKiloohms(10))))
            {
                Console.CursorVisible = false;

                while (!Console.KeyAvailable)
                {
                    var temperature = adcConnection.In(Mcp3008Channel.Channel0).Read().Value;
                    var resistor = adcConnection.In(Mcp3008Channel.Channel1).Read().Value;

                    Console.WriteLine("ch1 = {0} | ch2 = {1})", temperature, resistor);

                    Console.CursorTop--;

                    Thread.Sleep(2000);
                }
            }

            Console.CursorTop++;
            Console.CursorVisible = true;
        }
    }
}
