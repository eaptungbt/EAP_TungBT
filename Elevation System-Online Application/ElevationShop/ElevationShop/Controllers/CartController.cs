using ElevationShop.Models;
using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Controllers
{
    public class CartController : Controller
    {
        ElevatorServiceClient client = new ElevatorServiceClient();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(string id)
        {
            int index = isExists(id);
            List<ItemCart> cart = (List<ItemCart>)Session["cart"];
            if (index != -1)
            {
                cart.RemoveAt(index);
                Session["cart"] = cart;
            }
            return View("addToCart");
        }

        public ActionResult addToCart(string id)
        {
            if ((Customer)Session["user"] != null)
            {
                if (Session["cart"] == null && id != null)
                {
                    List<ItemCart> cart = new List<ItemCart>();
                    cart.Add(new ItemCart() { eleva = client.getProductByID(id), qty=1});
                    Session["cart"] = cart;
                }
                else if (id != null)
                {
                    List<ItemCart> cart = (List<ItemCart>)Session["cart"];
                    int index = isExists(id);
                    if (index == -1)
                    {
                        cart.Add(new ItemCart() { eleva = client.getProductByID(id), qty = 1 });
                    }
                    else
                    {
                        cart[index].qty++;
                    }
                    Session["cart"] = cart;
                    return View();
                }
            }
            else {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        private int isExists(string id)
        {
            List<ItemCart> cart = (List<ItemCart>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].eleva.idElevator == id)
                    return i;

            return -1;
        }
    }
}