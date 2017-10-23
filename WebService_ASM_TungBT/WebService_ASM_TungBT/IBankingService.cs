using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService_ASM_TungBT
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankingService" in both code and config file together.
    [ServiceContract]
    public interface IBankingService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Banking/")]
        string ThanhToan(DoiTac doiTac,KhachHang khachHang,decimal soTien, int hthuc);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "History/")]
        List<GiaoDich> LichSuKhachHang(KhachHang khachHang,DateTime fromDate,DateTime todate);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "History/")]
        List<GiaoDich> LichSuDoiTac(DoiTac doiTac);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Sodu/")]
        decimal getSoDuKhachHang(KhachHang khachHang);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Sodu/")]
        decimal getSoDuDoiTac(DoiTac doiTac);
    }
}
