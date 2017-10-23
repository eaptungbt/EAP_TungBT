using ElevationShop.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Areas.Admin.Controllers
{
    public class BankAccountController : Controller
    {
        // GET: Admin/BankAccount
        public ActionResult Index()
        {
            BankingServiceClient bankClient = new BankingServiceClient();
            return View(bankClient.LichSuDoiTac(new DoiTac() { maDoiTac = "Elevation", matKhau = "1234" }).ToList());
        }
    }
}