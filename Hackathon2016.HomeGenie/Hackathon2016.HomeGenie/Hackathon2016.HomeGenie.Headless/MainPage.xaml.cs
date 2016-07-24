using Microsoft.Azure.Devices.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hackathon2016.HomeGenie.Headless
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static GpioPin GPIO_PIN;
        public MainPage()
        {
            this.InitializeComponent();
            GPIO_PIN = GpioController.GetDefault().OpenPin(4);
            ReceiveDataFromAzure();            
        }

        public async static Task ReceiveDataFromAzure()
        {
            DeviceClient iotDevice = DeviceClient.Create(ConnectionStrings.IotHubUri,
                    AuthenticationMethodFactory.
                        CreateAuthenticationWithRegistrySymmetricKey(ConnectionStrings.DeviceId, ConnectionStrings.DeviceKey),
                    TransportType.Http1);

            while (true)
            {
                var receivedMessage = await iotDevice.ReceiveAsync();

                if (receivedMessage != null)
                {
                    var message = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                    if (!string.IsNullOrEmpty(message))
                    {
                        bool? isOff = null;
                        if (message=="off")
                        {
                            isOff = true;
                        }
                        else if(message=="on")
                        {
                            isOff = false;
                        }
                        if (isOff.HasValue)
                            await Task.Run(() => TogglePinState(4, isOff.Value));
                    }
                    await iotDevice.CompleteAsync(receivedMessage);
                }
            }
        }

        public static void TogglePinState(int pinNumber, bool isHigh)
        {            
            var value = (isHigh) ? GpioPinValue.High : GpioPinValue.Low;
            GPIO_PIN.Write(value);
            GPIO_PIN.SetDriveMode(GpioPinDriveMode.Output);
        }
    }
}
