using Raspberry.IO.GeneralPurpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.Positioning.MotorControl
{
    public interface IMotorDriver
    {
        ConnectorPin Pin1 { get; set; }

        ConnectorPin Pin2 { get; set; }

        void Initialize();

        void Start(Direction direction);

        void Start(Direction direction, int time);

        void Stop();
    }
}