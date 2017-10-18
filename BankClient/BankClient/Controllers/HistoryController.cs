using BankClient.Models;
using BankClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankClient.Controllers
{
    public class HistoryController : Controller
    {
        BankingServiceClient client = new BankingServiceClient();
        // GET: History
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DoiTac()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoiTac(SearchModel search)
        {
            var dt = new DoiTac() {maDoiTac=search.ma,matKhau=search.matkhau };
            var giaodich = client.LichSuDoiTac(dt, search.fromDate, search.toDate).ToList();
            ViewBag.GiaoDich = giaodich;
            return View();
        }
        public ActionResult KhachHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KhachHang(SearchModel search)
        {
            var kh = new KhachHang() { maKH = search.ma, pin = search.matkhau };
            var giaodich = client.LichSuKhachHang(kh, search.fromDate, search.toDate).ToList();
            ViewBag.GiaoDich = giaodich;
            return View();
        }
    }
}