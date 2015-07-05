using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.MotorControl
{
    public interface IMotorController
    {
        int PIN1 { get; set; }

        int PIN2 { get; set; }

        void setPins();

        void Start(Direction direction);

        void Start(Direction direction, int time);

        void Stop();
    }
}