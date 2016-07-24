using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace BoardController
{
    public class RaspberryPi2Controller
    {
        private static GpioPin GPIO_PIN;

        public static void TogglePinState(int pinNumber, bool isHigh)
        {
            GPIO_PIN = GpioController.GetDefault().OpenPin(pinNumber);
            var value = (isHigh) ? GpioPinValue.High : GpioPinValue.Low;
            GPIO_PIN.Write(value);
            GPIO_PIN.SetDriveMode(GpioPinDriveMode.Output);            
        }
    }
}
