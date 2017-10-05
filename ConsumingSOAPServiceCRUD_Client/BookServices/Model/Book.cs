using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookServices.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
    }
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddNewBook(Book item);
        bool DeleteABook(int id);
        bool UpdateABook(Book item);
    }
}