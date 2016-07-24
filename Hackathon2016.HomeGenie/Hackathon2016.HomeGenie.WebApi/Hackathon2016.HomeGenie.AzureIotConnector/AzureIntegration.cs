using Microsoft.Azure.Devices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon2016.HomeGenie.AzureIotConnector
{
    internal class AzureIntegration
    {
        private ServiceClient serviceClient;
        private string connectionString;
        private string deviceId;

        internal AzureIntegration()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AzureConnectionString"].ConnectionString;
            deviceId = ConfigurationManager.AppSettings["deviceId"];
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
        }

        internal async Task SendCloudToDeviceMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                var hubMessage = new Message(Encoding.ASCII.GetBytes(message));
                await serviceClient.SendAsync(deviceId, hubMessage);
            }
            else
                throw new ArgumentNullException("message");            
        }
    }
}
