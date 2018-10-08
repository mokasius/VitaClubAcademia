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

        #region Metodos Aluno

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CarregarAluno/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Stream CarregarAluno(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CarregarAlunos", ResponseFormat = WebMessageFormat.Json)]
        Stream CarregarAlunos();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SalvarAluno", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SalvarAluno(string json);

        #endregion

        #region Metodos Exercicio

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SalvarExercicio", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SalvarExercicio(string json);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CarregarExercicio/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Stream CarregarExercicio(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CarregarExercicios", ResponseFormat = WebMessageFormat.Json)]
        Stream CarregarExercicios();

        #endregion

        #region Metodos Treino

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SalvarTreino", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SalvarTreino(string json);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CarregarTreinos", ResponseFormat = WebMessageFormat.Json)]
        Stream CarregarTreinos();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeletarTreino", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void DeletarTreino(string json);

        #endregion

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SalvarAlunoTreino", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SalvarAlunoTreino(string json);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SalvarPagamento", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //ErrorResponse SalvarPagamento(string json);
        string SalvarPagamento(string json);


    }

    [DataContract]
    public class ErrorResponse
    {
        [DataMember(Name = "errorMessage")]
        public string Mensagem { get; set; }
    }

}
