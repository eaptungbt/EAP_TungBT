using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookServices.Model
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();
        private int counter = 1;

        public BookRepository()
        {
            AddNewBook(new Book() { Title = "C# Programming", ISBN = "12346845346" });
            AddNewBook(new Book() { Title = "Java Programming", ISBN = "6421305410" });
            AddNewBook(new Book() { Title = "WCF Programming", ISBN = "21654319855" });
        }
        public void AddNewBook(Book item)
        {
            //if (item == null)
            //    throw new ArgumentNullException("newBook");

            item.BookId = counter++;
            books.Add(item);
            //return item;
        }

        public bool DeleteABook(int id)
        {
            int idx = books.FindIndex(b => b.BookId == id);
            if (idx == -1)
            {
                return false;
            }
            books.RemoveAll(b => b.BookId == id);
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.Find(b => b.BookId == id);
        }

        public bool UpdateABook(Book item)
        {
            if (item == null)
                throw new ArgumentNullException("updateBook");

            int idx = books.FindIndex(b => b.BookId == item.BookId);
            if (idx == -1)
                return false;
            books.RemoveAt(idx);
            books.Add(item);
            return true;
        }
    }
}