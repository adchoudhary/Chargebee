using ChargeBee.Models;
using ChargeBee.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ChargebeeMVCapp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post(HttpRequestBase Request)
        {
            Console.WriteLine(Request.HttpMethod);
            Console.WriteLine(Request.RawUrl);

            Event events = new Event(Request.InputStream);
            EventTypeEnum eventType = (EventTypeEnum)events.EventType;  // to get the event type
            Event.EventContent content = events.Content;
            String subscriptionId = content.Subscription.Id;  //get subscription ID
            String customerEmail = content.Customer.Email;     // get customer email ID 

            Console.WriteLine(subscriptionId);
            Console.WriteLine(customerEmail);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
