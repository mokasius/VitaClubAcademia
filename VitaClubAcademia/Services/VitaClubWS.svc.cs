using Business.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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


    }
}
