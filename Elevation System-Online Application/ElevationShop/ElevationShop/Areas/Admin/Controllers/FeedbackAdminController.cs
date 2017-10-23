using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Areas.Admin.Controllers
{
    public class FeedbackAdminController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        // GET: Admin/Feedback
        public ActionResult Index()
        {
            client.seenFeedback();
            return View(client.getFeedBack().ToList());
        }
    }
}