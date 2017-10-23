using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevationShop.Models
{
    public class Person
    {
        [Key]
        [Remote("CheckUserName", "Regis")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        public string Company { get; set; }
    }
}