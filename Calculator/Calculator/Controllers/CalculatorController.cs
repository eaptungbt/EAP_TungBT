using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cong(string a,string b)
        {
            var client = new ServiceReference1.WebService1SoapClient();
            string ketqua = Convert.ToString(client.Cong(float.Parse(a), float.Parse(b)));
            ViewBag.ketqua = ketqua;
            return View("Index");
        }
        public ActionResult Tru(string a, string b)
        {
            var client = new ServiceReference1.WebService1SoapClient();
            string ketqua = Convert.ToString(client.Tru(float.Parse(a), float.Parse(b)));
            ViewBag.ketqua = ketqua;
            return View("Index");
        }
    }
}