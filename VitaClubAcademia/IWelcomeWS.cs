using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VitaClubAcademia
{
    [ServiceContract]
    public interface IWelcomeWS
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Welcome/{name}", ResponseFormat = WebMessageFormat.Json)]
        string Welcome(string name);
    }
}
