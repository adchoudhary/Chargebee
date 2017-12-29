using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChargeBee.Models;
using ChargeBee.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChargebeeWebhookConsumer
{
    [Route("api/[controller]")]
    public class ChargebeeController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller> [FromBody]string data
        [HttpPost]
        public void Post(HttpRequest Request)
        {
            //Console.WriteLine(Request.HttpMethod);
            //Console.WriteLine(Request.RawUrl);

            Event events = new Event("Request.InputStream");
            EventTypeEnum eventType = (EventTypeEnum)events.EventType;  // to get the event type
            Event.EventContent content = events.Content;
            String subscriptionId = content.Subscription.Id;  //get subscription ID
            String customerEmail = content.Customer.Email;     // get customer email ID 

            Console.WriteLine(subscriptionId);
            Console.WriteLine(customerEmail);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
