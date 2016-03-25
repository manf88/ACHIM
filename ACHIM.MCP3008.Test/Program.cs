using Raspberry.IO.Components.Converters.Mcp3008;
using Raspberry.IO.GeneralPurpose;
using System;
using System.Threading;

namespace ACHIM.MCP3008.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.MCP3008 hans = new Helper.MCP3008();
            hans.Initialize(
                ConnectorPin.P1Pin12,
                ConnectorPin.P1Pin16,
                ConnectorPin.P1Pin18,
                ConnectorPin.P1Pin22);

            while (true)
            {
                Console.WriteLine(hans.ReadChannelInVolt(Mcp3008Channel.Channel0, 3.3));
                Thread.Sleep(500);
                Console.CursorTop--;
            }
        }
    }
}
