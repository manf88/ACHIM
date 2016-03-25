using Raspberry.IO.Components.Converters.Mcp3008;
using Raspberry.IO.GeneralPurpose;
using System;

namespace ACHIM.Helper
{
    /// <summary>
    /// Wrapper class for the MCP3008 A/D converter.
    /// </summary>
    public class MCP3008 : IDisposable
    {
        private MemoryGpioConnectionDriver _driver;
        private Mcp3008SpiConnection _adcConnection;

        public void Initialize(ConnectorPin adcClock, ConnectorPin adcMiso, ConnectorPin adcMosi, ConnectorPin adcCs)
        {
            AdcClock = adcClock;
            AdcMiso = adcMiso;
            AdcMosi = adcMosi;
            AdcCs = adcCs;

            Console.WriteLine("MCP-3008 Sample: Reading temperature on Channel 0 and luminosity on Channel 1");
            Console.WriteLine();
            Console.WriteLine("\tClock: {0}", adcClock);
            Console.WriteLine("\tCS: {0}", adcCs);
            Console.WriteLine("\tMOSI: {0}", adcMosi);
            Console.WriteLine("\tMISO: {0}", adcMiso);
            Console.WriteLine();

            _driver = new MemoryGpioConnectionDriver();
            _adcConnection = new Mcp3008SpiConnection(
                _driver.Out(AdcClock),
                _driver.Out(AdcCs),
                _driver.In(AdcMiso),
                _driver.Out(AdcMosi));
        }

        public void Dispose()
        {
            if (_adcConnection != null)
                _adcConnection.Close();
        }

        public ConnectorPin AdcClock { get; private set; }

        public ConnectorPin AdcMiso { get; private set; }

        public ConnectorPin AdcMosi { get; private set; }

        public ConnectorPin AdcCs { get; private set; }

        /// <summary>
        /// Gets the current value from one of the channels (0 - 1024).
        /// </summary>
        public double ReadChannel(Mcp3008Channel channel)
        {
            return Convert.ToDouble(_adcConnection.In(channel).Read().Value);
        }

        /// <summary>
        /// Gets the value from the specified channel in volts regarding to the reference value.
        /// </summary>
        public double ReadChannelInVolt(Mcp3008Channel channel, double referenceVoltage = 3.3)
        {
            var value = ReadChannel(channel);
            return ChannelValueToVolt(value, referenceVoltage);
        }

        private double ChannelValueToVolt(double value, double referenceVoltage)
        {
            return Math.Round((referenceVoltage / 1024) * value, 2);
        }
    }
}
