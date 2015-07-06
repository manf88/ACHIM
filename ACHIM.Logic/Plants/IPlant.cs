using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.Logic.Plants
{
    public delegate void NeedWaterEventHandler(IPlant plant);

    public interface IPlant
    {
        string Name { get; set; }

        int Number { get; set; }

        double ProperSoilMoisture { get; set; }

        double SoilMoisture { get; set; }

        void CheckSoilMoisture();

        event NeedWaterEventHandler OnNeedWater;

        void RaiseNeedWater();
    }
}
