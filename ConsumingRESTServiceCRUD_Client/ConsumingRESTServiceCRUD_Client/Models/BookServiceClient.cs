﻿using ConsumingRESTServiceCRUD_Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace ConsumingRESTServiceCRUD_Client.Models
{
    public class BookServiceClient
    {
        string BASE_URL = "http://localhost:54529/BookServices.svc";
        BookServicesClient client = new BookServicesClient();

        public List<Book> getAllBook() {
            //var syncClient = new WebClient();
            //var content = syncClient.DownloadString(BASE_URL+"Books");
            //var json_serializer = new JavaScriptSerializer();
            //return json_serializer.Deserialize<List<Book>>(content);

            
            var list =client.GetBookList().ToList();
            var rt = new List<Book>();
            list.ForEach(b => rt.Add(new Book() { BookId = b.BookId, ISBN = b.ISBN, Title = b.Title }));
            return rt;
        }
        public string AddBook(Book newBook)
        {
            var book = new ServiceReference1.Book() {BookId=newBook.BookId,ISBN=newBook.ISBN,Title=newBook.Title};
            return client.AddBook(book); ;
        }
        public string DeleteBook(int id)
        {
            return client.DeleteBook(Convert.ToString(id));
        }
        public string Edit(Book newBook)
        {
            var book = new ServiceReference1.Book() { BookId = newBook.BookId, ISBN = newBook.ISBN, Title = newBook.Title };
            return client.UpdateBook(book);
        }
    }
}