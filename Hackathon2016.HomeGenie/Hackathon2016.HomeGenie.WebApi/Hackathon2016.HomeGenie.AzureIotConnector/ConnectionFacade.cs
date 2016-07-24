using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon2016.HomeGenie.AzureIotConnector
{
    public class ConnectionFacade
    {
        public async void SendMessageToDevice(string message)
        {
            AzureIntegration azureIntg = new AzureIntegration();
            await azureIntg.SendCloudToDeviceMessage(message);
        }
    }
}
