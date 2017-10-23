using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ElevationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IElevatorService" in both code and config file together.
    [ServiceContract]
    public interface IElevatorService
    {
        //account
        [OperationContract]
        [WebInvoke (Method ="GET",
            ResponseFormat =WebMessageFormat.Json,
            RequestFormat =WebMessageFormat.Json,
            UriTemplate ="Login/Customer"
            )]
        Customer loginCustomer(Customer cs);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Customer/Create"
            )]
        bool createCustomer(Customer cs);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Customer/getallid"
            )]
        List<string> getAllCustomerID();


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Login/Employee"
            )]
        Employee loginEmployee(Employee cs);


        //product
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "getProduct"
            )]
        List<Elevator> getProduct();

        [OperationContract]
        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         UriTemplate = "getProductByID"
           )]
        Elevator getProductByID(string ID);

        [OperationContract]
        [WebInvoke(Method = "GET",
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         UriTemplate = "getProductByDesign"
           )]
        List<Elevator> getProductByDesign(string dedign);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "addProduct"
            )]
        bool addProduct(Elevator ele);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "editProduct"
            )]
        bool editProduct(Elevator ele);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "deletePeoduct"
            )]
        bool deleteProduct(string id);

        //order
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Order/getAll"
            )]
        List<Order> getOrder();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Order/getOrderByID"
            )]
        Order getOrderByID(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          UriTemplate = "Order/getAll"
          )]
        int coutNewOrder();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Order/getOrderByEmail"
            )]
        List<Order> getOrderByEmail(string email);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Order/create"
            )]
        bool addOrder(Order od);

        [OperationContract]
        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "OrderDetail/create"
           )]
        bool addOrderDetail(OrderDetail odetail);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Order/getALlDetail"
            )]
        List<OrderDetail> getOrderDetail(string idOD);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Order/updateOrder"
            )]
        bool updateOrder(string id,int status,string emailEmployee);

        //feedback
        [OperationContract]
        [WebInvoke(Method = "Get",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "countFeedback"
           )]
        int countFeedback();

        [OperationContract]
        [WebInvoke(Method = "Get",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "getFeedBack"
           )]
        List<Feedback> getFeedBack();

        [OperationContract]
        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "addFeedback"
           )]
        bool addFeedback(Feedback f);

        [OperationContract]
        [WebInvoke(Method = "PUT",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "seenFeedback"
           )]
        void seenFeedback();


        //Maintenance
        [OperationContract]
        [WebInvoke(Method = "Get",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "countMaintenance"
           )]
        int countMaintenance();

        [OperationContract]
        [WebInvoke(Method = "PUT",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "seenMaintenance"
           )]
        void seenMaintenance();

        [OperationContract]
        [WebInvoke(Method = "Get",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "getMaintenance"
           )]
        List<Maintenance> getMaintenance();

        [OperationContract]
        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "addMaintenance"
           )]
        bool addMaintenance(Maintenance m);
    }
}
