using ElevationShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElevationShop.Models
{
    public class ItemCart
    {
        public Elevator eleva { get; set; }
        public int qty { get; set; }
    }
}