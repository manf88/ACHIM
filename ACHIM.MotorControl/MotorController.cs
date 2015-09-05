using ACHIM.Positioning.MotorControl;
using Raspberry.IO.GeneralPurpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.Positioning.MotorControl
{
    /// <summary>
    /// The Motor Controller class has the pupose of driving the motor to the correct positions (plants).
    /// </summary>
    public class MotorController : IMotorController
    {
        private int lastSwitchPos;

        private Direction _currentDirection;

        private int _currentSwitchPosition;

        private IMotorDriver _motorDriver;

        private List<IStopSwitch> _stopSwitches;

        public int NumberOfSwitches { get { return _stopSwitches.Count; } }

        public ConnectorPin MotorPin1 { get; set; }

        public ConnectorPin MotorPin2 { get; set; }

        public MotorController(IMotorDriver motorDriver)
        {
            _motorDriver = motorDriver;

            _stopSwitches = new List<IStopSwitch>();

            _currentDirection = Direction.RIGHT;            
        }

        public void Initialize()
        {
            InitializeMotor();
        }

        public void GoToStart()
        {
            _currentDirection = Direction.RIGHT;

            _motorDriver.Start(_currentDirection, 3000);

            _currentDirection = Direction.LEFT;
        }

        public void GoToSwitchPosition(int stopSwitchNumber)
        {
            //count left to right

        }

        public void RegisterSwitch(IStopSwitch stopSwitch)
        {
            _stopSwitches.Add(stopSwitch);
            stopSwitch.OnPressed += OnActivatedSwitch;

            stopSwitch.Number = NumberOfSwitches;

            Console.WriteLine("Registered Switch Number: {0}", stopSwitch.Number);
        }

        private void OnActivatedSwitch(object sender, EventArgs e)
        {
            var sendingSwitch = (IStopSwitch)sender;
            _currentSwitchPosition = sendingSwitch.Number;

            Console.WriteLine("Head passed switch number {0}", _currentSwitchPosition);
        }

        public void UnregisterSwitch(int stopSwitchNumber)
        {
            throw new NotImplementedException();
        }

        public void StartTestRun()
        {
            GoToStart();

            //_motorDriver.Start(Direction.RIGHT, 3000);

            _motorDriver.Start(Direction.LEFT, 3000);
        }

        private void InitializeMotor()
        {
            _motorDriver.Pin1 = MotorPin1;
            _motorDriver.Pin2 = MotorPin2;
            _motorDriver.Initialize();
        }


    }
}
