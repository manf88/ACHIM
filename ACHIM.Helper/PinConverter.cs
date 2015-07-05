using RaspberryPiDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.Helper
{
    public static class PinConverter
    {
        public static GPIOPins getPin(int pin)
        {
            switch (pin)
            {
                case 3: return GPIOPins.V2_GPIO_02;
                case 5: return GPIOPins.V2_GPIO_03;
                case 7: return GPIOPins.V2_GPIO_04;
                case 8: return GPIOPins.V2_GPIO_14;
                case 10: return GPIOPins.V2_GPIO_15;
                case 11: return GPIOPins.V2_GPIO_17;
                case 12: return GPIOPins.V2_GPIO_18;
                case 13: return GPIOPins.V2_GPIO_27;
                case 15: return GPIOPins.V2_GPIO_22;
                case 16: return GPIOPins.V2_GPIO_23;
                case 18: return GPIOPins.V2_GPIO_24;
                case 19: return GPIOPins.V2_GPIO_10;
                case 21: return GPIOPins.V2_GPIO_09;
                case 22: return GPIOPins.V2_GPIO_25;
                case 23: return GPIOPins.V2_GPIO_11;
                case 24: return GPIOPins.V2_GPIO_08;
                case 26: return GPIOPins.V2_GPIO_07;
                default:
                    return GPIOPins.GPIO_NONE;
                    break;
            }
        }
    }
}