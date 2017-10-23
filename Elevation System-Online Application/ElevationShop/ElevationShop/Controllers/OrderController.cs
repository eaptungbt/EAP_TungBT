using ElevationShop.Models;
using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Controllers
{
    public class OrderController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public bool checkOrderID(string id)
        {
            foreach (Order od in client.getOrder().ToList())
            {
                if (od.idOder.Equals(id))
                {
                    return false;
                }
            }
            return true;
        }

        public ActionResult OrderNow()
        {
            if (Session["user"] != null && Session["cart"] != null)
            {
                Random rd = new Random();
                string orderID = (((Customer)Session["user"]).emailCustomer.Split('@'))[0] + rd.Next().ToString();
                bool x = checkOrderID(orderID);
                while (x == false)
                {
                    orderID = ((Customer)Session["user"]).emailCustomer + rd.Next().ToString();
                    x = checkOrderID(orderID);
                }

                Order od = new Order();
                od.idOder = orderID;
                od.emailCustomer = ((Customer)Session["user"]).emailCustomer;
                od.time = DateTime.Now;
                //0 la chua xac nhan
                od.OrderStatus = 0;

                client.addOrder(od);

                foreach (ItemCart item in (List<ItemCart>)Session["cart"])
                {
                    OrderDetail odDetail = new OrderDetail();
                    odDetail.idOder = orderID;
                    odDetail.idElevator = item.eleva.idElevator;
                    odDetail.price = item.eleva.cost;
                    odDetail.qty = item.qty;

                    client.addOrderDetail(odDetail);
                }
                Session["cart"] = null;
                return View("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult ViewDeatilProduct(string id) {
            return View(client.getProductByID(id));
        }
    }
}