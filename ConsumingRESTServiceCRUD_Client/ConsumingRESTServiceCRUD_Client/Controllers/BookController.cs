using ConsumingRESTServiceCRUD_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsumingRESTServiceCRUD_Client.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            BookServiceClient bsc = new BookServiceClient();
            ViewBag.listBooks = bsc.getAllBook();
            return View();
        }
    }
}