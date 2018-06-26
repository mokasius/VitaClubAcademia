using Business.Classes;
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
        public void DoWork()
        {
        }

        public string Welcome(string name)
        {
            return "Welcome " + name;
        }


        public void SalvarAluno(string json)
        {
            var aluno = new JavaScriptSerializer().Deserialize<Aluno>(json);

            try
            {
                aluno.ValidaAluno();
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
