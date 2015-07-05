using ACHIM.Helper;
using RaspberryPiDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACHIM.MotorControl
{
    public enum Direction { LEFT, RIGHT }

    public class MotorController : IMotorController
    {
        private GPIOMem _gpio1;
        private GPIOMem _gpio2;

        public MotorController()
        {
        }

        public void setPins()
        {
            _gpio1 = new GPIOMem(PinConverter.getPin(PIN1));
            _gpio2 = new GPIOMem(PinConverter.getPin(PIN2));
        }

        public int PIN1 { get; set; }

        public int PIN2 { get; set; }

        public void Start(Direction direction)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    _gpio1.Write(false);
                    break;

                case Direction.RIGHT:
                    _gpio2.Write(false);
                    break;

                default:
                    break;
            }
        }

        public void Start(Direction direction, int time)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    _gpio1.Write(false);
                    Thread.Sleep(time);
                    break;

                case Direction.RIGHT:
                    _gpio2.Write(false);
                    Thread.Sleep(time);
                    break;

                default:
                    break;
            }

            Stop();
        }

        public void Stop()
        {
            _gpio1.Write(true);
            _gpio2.Write(true);
        }
    }
}