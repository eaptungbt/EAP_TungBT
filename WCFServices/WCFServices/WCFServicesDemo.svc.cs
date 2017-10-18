using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFServicesDemo" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WCFServicesDemo.svc or WCFServicesDemo.svc.cs at the Solution Explorer and start debugging.
    public class WCFServicesDemo : IWCFServicesDemo
    {
        public string getMessage()
        {
            return "Hello";
        }

        public string postMessage(string username)
        {
            return string.Format("Welcome {0}", username);
        }
    }
}
