using Raspberry.IO.GeneralPurpose;

namespace ACHIM.PumpControl
{
    public interface IPumpController
    {
        ConnectorPin RPiPin { get; set; }

        void Start();

        void Stop();
    }
}