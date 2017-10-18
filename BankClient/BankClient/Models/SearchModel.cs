using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankClient.Models
{
    public class SearchModel
    {
        [DisplayName("Mã")]
        public string ma { get; set; }
        [DisplayName("Mật khẩu/Pin")]
        public string matkhau { get; set; }
        [DisplayName("Từ ngày")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime fromDate { get; set; }
        [DisplayName("Đến ngày")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime toDate { get; set; }
    }
}