using ConsumingSOAPServiceCRUD_Client.ServiceReferenceBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsumingSOAPServiceCRUD_Client.Controllers
{
    public class BookController : Controller
    {
      BookServiceSoapClient client = new BookServiceSoapClient();
        // GET: Book
        public ActionResult Index()
        {
            ViewBag.listBooks = client.GetBookList();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            var id = book.ISBN;
            client.AddBook(book);
            return RedirectToAction("Index", "Book");
        }
        public ActionResult Delete(int id)
        {
            client.DeleteBook(Convert.ToString(id));
            return RedirectToAction("Index", "Book");
        }
        public ActionResult Edit(int id)
        {
            var book = client.GetBookList().Where(b => b.BookId == id).FirstOrDefault();
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            client.UpdateBook(book);
            return RedirectToAction("Index", "Book");
        }
    }
}