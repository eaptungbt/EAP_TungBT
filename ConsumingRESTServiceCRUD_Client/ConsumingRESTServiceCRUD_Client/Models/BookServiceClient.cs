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

        public List<Book> getAllBook() {
            var syncClient = new WebClient();
            var content = syncClient.DownloadString(BASE_URL+"Books");
            var json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<List<Book>>(content);
        }
    }
}