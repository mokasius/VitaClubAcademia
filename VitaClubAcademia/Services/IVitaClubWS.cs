using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VitaClubAcademia.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVitaClubWS" in both code and config file together.
    [ServiceContract]
    public interface IVitaClubWS
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Welcome/{name}", ResponseFormat = WebMessageFormat.Json)]
        string Welcome(string name);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CarregarAluno/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Stream CarregarAluno(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CarregarAlunos", ResponseFormat = WebMessageFormat.Json)]
        Stream CarregarAlunos();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SalvarAluno", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SalvarAluno(string json);

    }
}
