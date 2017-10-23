using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            ElevatorServiceClient client = new ElevatorServiceClient();
            var cus = client.loginCustomer(new Customer() { emailCustomer = email, passwordCustomer = password });
            if (cus!=null) {
                Session["user"] =cus;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["cart"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}