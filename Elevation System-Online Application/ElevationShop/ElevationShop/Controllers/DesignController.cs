using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Controllers
{
    public class DesignController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        // GET: Design
        public ActionResult Index()
        {
            return View(client.getProductByDesign(((Customer)Session["user"]).emailCustomer));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Elevator e)
        {
            e.design = ((Customer)Session["user"]).emailCustomer;
            client.addProduct(e);
            return RedirectToAction("Index","Design");
        }

    }
}