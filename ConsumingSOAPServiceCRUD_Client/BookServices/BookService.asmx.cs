using BookServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BookServices
{
    /// <summary>
    /// Summary description for BookService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BookService : System.Web.Services.WebService
    {
        //bien static chi duoc khoi tao 1 lan duy nhat khi ct bien dich.
        //cac lan sau ko khoi tao nua ma dung co san tu lan tao truoc
        //--------------------
        //O day dung static la de khong phai khoi tao BookRepository co contructor chi add 3 Book ban dau.
        static BookRepository repository = new BookRepository();

        [WebMethod]
        public string AddBook(Book book)
        {
            repository.AddNewBook(book);
            return "id=" + book.BookId;
        }
        [WebMethod]
        public string DeleteBook(string id)
        {
            bool deleted = repository.DeleteABook(int.Parse(id));
            if (deleted)
                return "Delete success";
            else
                return "Delete false";

        }
        [WebMethod]
        public Book GetBookById(string id)
        {
            return repository.GetBookById(int.Parse(id));
        }
        [WebMethod]
        public List<Book> GetBookList()
        {
            return repository.GetAllBooks();
        }
        [WebMethod]
        public string UpdateBook(Book book)
        {
            bool deleted = repository.UpdateABook(book);
            if (deleted)
            {
                return "Book with id= " + book.BookId + " update sucessfully";
            }
            else
            {
                return "Unable to update book with id = " + book.BookId;
            }
        }
    }
}
