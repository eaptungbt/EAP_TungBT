using ElevationShop.Models;
using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Controllers
{
    public class RegisController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Person person)
        {
            if (checkUser(person.Email))
            {
                var cus = new Customer() { emailCustomer = person.Email, passwordCustomer = person.Password, addressCustomer = person.Address, company = person.Company, nameCustomer = person.Name };
                client.createCustomer(cus);
                return RedirectToAction("Index", "Login");
            }
            else {
                ViewBag.MES = "Email đã được dùng.";
                return View();
            }
            
        }

        private bool checkUser(string email) {
            foreach (string us in client.getAllCustomerID().ToList()) {
                if (us == email) {
                    return false;
                }
            }
            return true;
        }

        public JsonResult CheckUserName(string Email)
        {
            bool rt = false;
            
            if (rt)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

    }
}