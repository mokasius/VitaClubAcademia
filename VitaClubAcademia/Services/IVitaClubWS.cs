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
        Stream SalvarAluno(string json);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeletarAluno", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Stream DeletarAluno(string json);

        #endregion

        #region Metodos Exercicio

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SalvarExercicio", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Stream SalvarExercicio(string json);

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
        Stream SalvarTreino(string json);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CarregarTreinos", ResponseFormat = WebMessageFormat.Json)]
        Stream CarregarTreinos();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeletarTreino", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Stream DeletarTreino(string json);

        #endregion

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SalvarAlunoTreino", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Stream SalvarAlunoTreino(string json);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SalvarPagamento", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Stream SalvarPagamento(string json);

        #region Metodos Pagamento

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CarregarUltimosPgtosAluno/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Stream CarregarUltimosPgtosAluno(string codigo);

        #endregion

        #region Metodos Hidro

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SalvarFrequenciasHidro", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Stream SalvarFrequenciasHidro(string json);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CarregarFrequencias/{presentes}", ResponseFormat = WebMessageFormat.Json)]
        Stream CarregarFrequencias(string presentes);

        #endregion

        

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "EnviarEmailPagamento", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void EnviarEmailPagamento(string json);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "EnviarEmailPagamento2")]
        void EnviarEmailPagamento2(Stream json);


    }

    [DataContract]
    public class Status
    {
        public string errorMessage { get; set; }
    }

}
