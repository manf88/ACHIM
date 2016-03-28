using Raspberry.IO.GeneralPurpose;

namespace ACHIM.PumpControl
{
    public class PumpController : IPumpController
    {
        public ConnectorPin RPiPin
        {
            get;
            set;
        }

        public void Start()
        {
            //_gpio.Write(false);
        }

        public void Stop()
        {
            //_gpio.Write(true);
        }
    }
}