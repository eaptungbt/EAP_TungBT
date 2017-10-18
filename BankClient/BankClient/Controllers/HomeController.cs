using BankClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankClient.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["DoiTac"] = null;
            return View();
        }
        public ActionResult Edumall()
        {
            DoiTac dt = new DoiTac() { maDoiTac = "DT01", matKhau = "1234" };
            Session["DoiTac"] = dt;
            return RedirectToAction("Index","ThanhToan");
        }
        public ActionResult VTCGame()
        {
            DoiTac dt = new DoiTac() { maDoiTac = "DT02", matKhau = "1234" };
            Session["DoiTac"] = dt;
            return RedirectToAction("Index", "ThanhToan");
        }
        public ActionResult Garena()
        {
            DoiTac dt = new DoiTac() { maDoiTac = "DT03", matKhau = "1234" };
            Session["DoiTac"] = dt;
            return RedirectToAction("Index", "ThanhToan");
        }
        public ActionResult LichSu()
        {
            return View();
        }
    }
}