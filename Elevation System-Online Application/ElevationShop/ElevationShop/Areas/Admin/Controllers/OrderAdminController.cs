using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Areas.Admin.Controllers
{
    public class OrderAdminController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        // GET: Admin/OrderAdmin
        public ActionResult Index()
        {
            return View(client.getOrder().ToList());
        }
        public ActionResult ChapNhan(string id)
        {
            Employee em = new Employee();
            em = (Employee)Session["admin"];
            client.updateOrder(id,2,em.emailEmployee);
            return View("Index",client.getOrder().ToList());
        }
        public ActionResult Huy(string id)
        {
            Employee em = new Employee();
            em = (Employee)Session["admin"];
            client.updateOrder(id, 3, em.emailEmployee);
            return View("Index", client.getOrder().ToList());
        }
        public ActionResult GiaoHang(string id)
        {
            Employee em = new Employee();
            em = (Employee)Session["admin"];
            //dang cho thanh toan
            client.updateOrder(id, 1, em.emailEmployee);
            return View("Index", client.getOrder().ToList());
        }
    }
}