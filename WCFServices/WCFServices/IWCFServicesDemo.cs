using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFServicesDemo" in both code and config file together.
    [ServiceContract]
    public interface IWCFServicesDemo
    {
        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string getMessage();

        [OperationContract]
        [WebInvoke(
            Method ="POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string postMessage(string username);
    }
}
