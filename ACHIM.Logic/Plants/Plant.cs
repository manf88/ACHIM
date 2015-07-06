using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.Logic.Plants
{
    public class Plant : IPlant
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public double ProperSoilMoisture { get; set; }

        public double SoilMoisture { get; set; }

        public void CheckSoilMoisture()
        {
            if (ProperSoilMoisture > SoilMoisture)
                RaiseNeedWater();
        }

        public event NeedWaterEventHandler OnNeedWater;

        public void RaiseNeedWater()
        {
            if (OnNeedWater != null)
            {
                OnNeedWater(this);
            }
        }
    }
}
