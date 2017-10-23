using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Areas.Admin.Controllers
{
    public class MaintenaceAdminController : Controller
    {
        // GET: Admin/MaintenaceAdmin
        public ActionResult Index()
        {
            ElevatorServiceClient client = new ElevatorServiceClient();
            client.seenMaintenance();
            return View(client.getMaintenance().ToList());
        }
    }
}