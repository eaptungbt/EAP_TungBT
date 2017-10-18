
using BankingClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingClient.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edumall()
        {
            var doitac= new DoiTac() { maDoiTac = "DT01", matKhau = "1234" };
            ViewBag.Doitac = doitac;
            return RedirectToAction("Index","ThanhToan");
        }
        public ActionResult LichSu()
        {
            return View();
        }
    }
}