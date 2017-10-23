using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Areas.Admin.Controllers
{
    public class AccountAdminController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        // GET: Admin/AccountAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var ad = client.loginEmployee(new Employee() {emailEmployee=email,passwordEmployee=password });
            if (ad != null) {
                Session["admin"] = ad;
                return RedirectToAction("Index","HomeAdmin");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Login", "AccountAdmin");
        }
    }
}