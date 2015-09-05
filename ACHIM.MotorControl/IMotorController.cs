using Raspberry.IO.GeneralPurpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.Positioning.MotorControl
{
    public interface IMotorController
    {
        ConnectorPin MotorPin1 { get; set; }

        ConnectorPin MotorPin2 { get; set; }
        
        int NumberOfSwitches { get; }

        void Initialize();

        void GoToStart();

        void GoToSwitchPosition(int stopSwitchNumber);

        void RegisterSwitch(IStopSwitch stopSwitch);

        void UnregisterSwitch(int stopSwitchNumber);

        void StartTestRun();
    }
}
