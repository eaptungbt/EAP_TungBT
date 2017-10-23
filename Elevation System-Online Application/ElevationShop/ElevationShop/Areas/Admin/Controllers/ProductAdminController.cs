using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        // GET: Admin/ProductAdmin
        public ActionResult Index()
        {
            return View(client.getProduct().ToList());
        }
        public ActionResult Edit(string id)
        {
            return View(client.getProductByID(id));
        }
        [HttpPost]
        public ActionResult Edit(Elevator e)
        {
            client.editProduct(e);
            return View("Index", client.getProduct().ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Elevator e)
        {
            e.design = "0";
            client.addProduct(e);
            return View("Index", client.getProduct().ToList());
        }
    }
}