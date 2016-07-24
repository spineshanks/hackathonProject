using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hackathon2016.HomeGenie.WebApi.Controllers
{
    public class DeviceController : ApiController
    {
        public HttpResponseMessage Post([FromBody]string value)
        {
            AzureIotConnector.ConnectionFacade connection = new AzureIotConnector.ConnectionFacade();
            connection.SendMessageToDevice(value);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        
        public IHttpActionResult Get(string value,string secret)
        {
            if (!string.IsNullOrEmpty(secret) && secret=="shashwat")
            {
                Task.Run(()=>new AzureIotConnector.ConnectionFacade().SendMessageToDevice(value));
            }            
            return Ok();
        }
    }
}
