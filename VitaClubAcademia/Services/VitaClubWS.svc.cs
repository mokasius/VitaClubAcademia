using Business.Classes;
using Business.WebServiceModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;

namespace VitaClubAcademia.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VitaClubWS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select VitaClubWS.svc or VitaClubWS.svc.cs at the Solution Explorer and start debugging.
    public class VitaClubWS : IVitaClubWS
    {
        public VitaClubWS()
        {
            Business.EFManager.LoadDLL();
        }

        public void DoWork()
        {
        }

        public string Welcome(string name)
        {
            return "Welcome " + name;
        }

        #region Metodos Aluno

        public void SalvarAluno(string json)
        {
            var aluno = new JavaScriptSerializer().Deserialize<Aluno>(json);

            try
            {
                //aluno.ValidaAluno();
                aluno.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Stream CarregarAluno(string codigo)
        {
            try
            {
                int id = int.Parse(codigo);

                var aluno = Aluno.CarregarAluno(id);
                //var json = new JavaScriptSerializer().Serialize(aluno);
                //return json;

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Aluno));
                return ConverteObjetoParaStream(ser, aluno);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Stream CarregarAlunos()
        {
            try
            {
                var alunos = Aluno.CarregarAlunos();

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Aluno>));
                return ConverteObjetoParaStream(ser, alunos);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region Metodos Exercicio

        public void SalvarExercicio(string json)
        {
            var exercicio = new JavaScriptSerializer().Deserialize<Exercicio>(json);

            try
            {
                exercicio.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Stream CarregarExercicio(string codigo)
        {
            try
            {
                int id = int.Parse(codigo);

                var exercicio = new Exercicio();
                exercicio.Carregar(id);
                
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Exercicio));
                return ConverteObjetoParaStream(ser, exercicio);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Stream CarregarExercicios()
        {
            try
            {
                var listaExercicios = Exercicio.CarregarTodosExercicios();

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Exercicio>));
                return ConverteObjetoParaStream(ser, listaExercicios);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Metodos Treino

        public void SalvarTreino(string json)
        {
            try
            {
                var treinoModel = new JavaScriptSerializer().Deserialize<TreinoModel>(json);

                var treino = treinoModel.ConvertToDTO();
                treino.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Stream CarregarTreinos()
        {
            try
            {
                var listaTreinos = TreinoModel.CarregarTodosTreinos();

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<TreinoModel>));
                return ConverteObjetoParaStream(ser, listaTreinos);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        private Stream ConverteObjetoParaStream(DataContractJsonSerializer serializer, object retorno)
        {
            MemoryStream stream1 = new MemoryStream();
            serializer.WriteObject(stream1, retorno);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);

            return sr.BaseStream;
        }
    }
}
