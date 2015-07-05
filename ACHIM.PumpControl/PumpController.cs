using ACHIM.Helper;
using RaspberryPiDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.PumpControl
{
    public class PumpController : IPumpController
    {
        private GPIOMem _gpio;

        public int RPiPin
        {
            get;
            set;
        }

        public void Start()
        {
            _gpio.Write(false);
        }

        public void Stop()
        {
            _gpio.Write(true);
        }

        public void SetPin()
        {
            _gpio = new GPIOMem(PinConverter.getPin(RPiPin));
        }
    }
}