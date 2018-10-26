using Business.Classes;
using Business.Uteis;
using Business.WebServiceModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Web.Http;
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

        public Stream SalvarAluno(string json)
        {
            var retorno = string.Empty;
            var alunoModel = new JavaScriptSerializer().Deserialize<AlunoModel>(json);
            var aluno = alunoModel.ConvertToDTO();

            try
            {
                //aluno.ValidaAluno();
                aluno.Save();
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            return ConverteObjetoParaStream(ser, retorno);
        }

        public Stream DeletarAluno(string codigo)
        {
            try
            {
                int id = int.Parse(codigo);
                Aluno.Deletar(id);

                return null;
            }
            catch (Exception ex)
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
                return ConverteObjetoParaStream(ser, ex.Message);
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

                var alunoModel = AlunoModel.ConvertToModel(aluno);

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(AlunoModel));
                return ConverteObjetoParaStream(ser, alunoModel);
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
                var alunosModel = new List<AlunoModel>();
                var alunos = Aluno.CarregarAlunos();
                foreach (var aluno in alunos)
                {
                    var model = AlunoModel.ConvertToModel(aluno);
                    alunosModel.Add(model);
                }

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<AlunoModel>));
                return ConverteObjetoParaStream(ser, alunosModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region Metodos Exercicio

        public Stream SalvarExercicio(string json)
        {
            var retorno = string.Empty;
            var exercicio = new JavaScriptSerializer().Deserialize<Exercicio>(json);

            try
            {
                exercicio.Save();
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            return ConverteObjetoParaStream(ser, retorno);
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

        public Stream SalvarTreino(string json)
        {
            var retorno = string.Empty;
            try
            {
                var treinoModel = new JavaScriptSerializer().Deserialize<TreinoModel>(json);

                var treino = treinoModel.ConvertToDTO();
                treino.Save();
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            return ConverteObjetoParaStream(ser, retorno);
        }

        public Stream DeletarTreino(string json)
        {
            var retorno = string.Empty;
            try
            {
                int treinoId = 0;
                if(int.TryParse(json, out treinoId))
                {
                    var treino = new Treino(treinoId);
                    treino.DeletarTreino();
                }
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            return ConverteObjetoParaStream(ser, retorno);
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

        public Stream SalvarAlunoTreino(string json)
        {
            var retorno = string.Empty;
            try
            {
                var alunoTreino = new JavaScriptSerializer().Deserialize<AlunoTreino>(json);
                alunoTreino.VincularTreino();
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            return ConverteObjetoParaStream(ser, retorno);
        }

        #endregion

        #region Pagamentos
        
        public Stream SalvarPagamento(string json)
        {
            var retorno = string.Empty;
            try
            {
                var pagamento = new JavaScriptSerializer().Deserialize<Pagamento>(json);
                pagamento.Salvar();

                //var email = new Email();
                //email.Assunto = "Email teste";
                //email.Texto = "texto do email";
                //email.EnviarEmail("thomas.bellaver@gmail.com");
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            return ConverteObjetoParaStream(ser, retorno);
        }

        public Stream CarregarUltimosPgtosAluno(string alunoId)
        {
            try
            {
                int id = Convert.ToInt32(alunoId);
                var pagamentos = Pagamento.CarregarUltimosPgtosAluno(id);
                
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Pagamento>));
                return ConverteObjetoParaStream(ser, pagamentos);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void EnviarEmailPagamento(string json)
        {
            try
            {
                json = json.Substring(1, json.Length - 2);
                string[] arr = json.Split(',');
                byte[] bResult = new byte[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    bResult[i] = byte.Parse(arr[i]);
                }


                //var teste = new JavaScriptSerializer().Deserialize<dynamic>(json);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void EnviarEmailPagamento2(Stream json)
        {
            try
            {
                byte[] arr = null;
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = json.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    arr = ms.ToArray();
                }

                var email = new Email();
                email.Assunto = "Email teste";
                email.Texto = "texto do email";
                var anexoEmail = new AnexoEmail();
                anexoEmail.Nome = "nome.png";
                anexoEmail.Arquivo = json;
                email.EnviarEmail("thomas.bellaver@gmail.com", anexoEmail);

                //var teste = new JavaScriptSerializer().Deserialize<dynamic>(json);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /*
        public string SalvarPagamento(string json)
        {
            throw new NotImplementedException();
        }

        public void EnviarEmailPagamento(Stream json)
        {
            throw new NotImplementedException();
        }
        */

        #endregion


        #region Metodos Hidro

        public Stream SalvarFrequenciasHidro(string json)
        {
            var retorno = string.Empty;
            try
            {
                var listaFrequencias = new JavaScriptSerializer().Deserialize<List<FrequenciaHidroModel>>(json);

                foreach (var item in listaFrequencias)
                {
                    var frequencia = item.ConvertToDTO();
                    frequencia.Salvar();
                }

            }
            catch (Exception ex)
            {
                retorno = ex.Message;

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
                return ConverteObjetoParaStream(ser, retorno);
            }

            return null;
        }

        public Stream CarregarFrequencias(string presentes)
        {
            try
            {
                bool _presentes = Convert.ToBoolean(presentes);
                var frequencias = FrequenciaHidro.CarregarFrequencias(_presentes);

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<FrequenciaHidro>));
                return ConverteObjetoParaStream(ser, frequencias);
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
