using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Controllers
{
    public class FeedbackController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        static string IDE = "";
        // GET: Feedback
        public ActionResult Index(string idElevator)
        {
            IDE = idElevator;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Feedback f)
        {
            f.idElevator = IDE;
            f.statusFeedback = 0;
            client.addFeedback(f);
            return RedirectToAction("Index", "ProductCustomer");
        }
    }
}