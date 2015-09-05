using Raspberry.IO.GeneralPurpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACHIM.Positioning.MotorControl
{
    public enum Direction { LEFT, RIGHT }

    public class MotorDriver : IMotorDriver
    {
        private PinConfiguration _pinConfig1;
        private PinConfiguration _pinConfig2;

        private GpioConnectionSettings _settings;

        private GpioConnection _connection;

        public MotorDriver()
        {
        }

        public void Initialize()
        {
            if (Pin1 == Pin2)
                throw new NullReferenceException("Set the Pins before calling Initialize()");

            _pinConfig1 = Pin1.Output();
            _pinConfig2 = Pin2.Output();

            _settings = new GpioConnectionSettings()
            {
                Driver = new GpioConnectionDriver()
            };
            _connection = new GpioConnection(_settings);
            _connection.Add(_pinConfig1);
            _connection.Add(_pinConfig2);
        }

        public ConnectorPin Pin1{ get; set; }

        public ConnectorPin Pin2 { get; set; }

        public void Start(Direction direction)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    _settings.Driver.Write(_pinConfig1.Pin, false);
                    _settings.Driver.Write(_pinConfig2.Pin, true);
                    break;

                case Direction.RIGHT:
                    _settings.Driver.Write(_pinConfig1.Pin, true);
                    _settings.Driver.Write(_pinConfig2.Pin, false);
                    break;

                default:
                    break;
            }
        }

        public void Start(Direction direction, int time)
        {
            Start(direction);
            Thread.Sleep(time);
            Stop();
        }

        public void Stop()
        {
            _settings.Driver.Write(_pinConfig1.Pin, true);
            _settings.Driver.Write(_pinConfig2.Pin, true);
        }
    }
}