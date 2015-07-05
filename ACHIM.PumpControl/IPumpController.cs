using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.PumpControl
{
    public interface IPumpController
    {
        int RPiPin { get; set; }

        void SetPin();

        void Start();

        void Stop();
    }
}