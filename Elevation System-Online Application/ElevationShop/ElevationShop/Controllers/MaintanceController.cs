using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Controllers
{
    public class MaintanceController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        static string IDOD = "";
        // GET: Maintance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(string id)
        {
            IDOD = id;
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Maintenance m)
        {
            m.idOder = IDOD;
            m.statusMaintenace = 0;
            client.addMaintenance(m);
            return RedirectToAction("Index", "ProductCustomer");
        }
    }
}