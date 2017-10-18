using BankingClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingClient.Controllers
{
    public class ThanhToanController : Controller
    {
        BankingServiceClient client = new BankingServiceClient();
        // GET: ThanhToan
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(KhachHang kh)
        {
            DoiTac dt =(DoiTac)ViewBag.Doitac;
            ViewBag.Message = client.ThanhToan(dt, kh, kh.soDu, 1);
            return View();
        }
    }
}