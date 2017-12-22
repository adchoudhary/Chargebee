using ChargeBee.Models;
using ChargeBee.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChargebeeMVCapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public void Chargebee(HttpRequestBase Request)
        {
            Event events = new Event(Request.InputStream);
            EventTypeEnum eventType = (EventTypeEnum)events.EventType;  // to get the event type
            Event.EventContent content = events.Content;
            String subscriptionId = content.Subscription.Id;  //get subscription ID
            String customerEmail = content.Customer.Email;     // get customer email ID 
        }

    }

    
}
