using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Controllers
{
    public class ProductCustomerController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        // GET: ProductCustomer
        public ActionResult Index()
        {
            
            return View(client.getProduct().ToList());
        }
    }
}