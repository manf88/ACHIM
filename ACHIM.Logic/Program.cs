using ACHIM.Logic.IoCBindings;
using ACHIM.Positioning.MotorControl;
using ACHIM.Positioning;
using ACHIM.PumpControl;
using System;
using System.Reflection;
using System.Threading;
using System.Collections.Generic;
using ACHIM.Logic.Plants;

namespace ACHIM.Logic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PlantManager manager = new PlantManager();

            foreach (var plant in manager.Plants)
            {
                plant.CheckSoilMoisture();
            }

            Console.Read();
        }
    }
}