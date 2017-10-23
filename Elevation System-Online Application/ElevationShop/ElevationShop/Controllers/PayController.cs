using ElevationShop.Models;
using ElevationShop.ServiceReference1;
using ElevationShop.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Controllers
{
    public class PayController : Controller
    {
        static decimal TIEN = 0;
        static string ID= "";
        // GET: Pay
        ElevatorServiceClient client = new ElevatorServiceClient();
        BankingServiceClient bankClient = new BankingServiceClient();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TienMat(string id)
        {
            var od=client.getOrderByID(id);
            client.updateOrder(id, 4, od.emailEmployee);
            return RedirectToAction("Index","Order");
        }
        public ActionResult Banking(decimal sotien, string id)
        {
            TIEN = sotien;
            ID = id;
            return View();
        }
        [HttpPost]
        public ActionResult Banking(payModel pay)
        {
            DoiTac dt = new DoiTac() {maDoiTac= "Elevation",matKhau="1234" };
            KhachHang kh = new KhachHang() {maKH=pay.maKhachHang,pin=pay.pin };
            var mes=bankClient.ThanhToan(dt, kh, TIEN, 1);

            var od = client.getOrderByID(ID);
            client.updateOrder(ID, 4, od.emailEmployee);

            if (mes == "thanhcong")
            {
                return RedirectToAction("Index", "Order");
            }
            return RedirectToAction("Index", "Order");
        }
    }
}