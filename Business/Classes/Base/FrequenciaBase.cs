using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using Business;

namespace Business.Classes
{
    public class FrequenciaBase
    {
        private FrequenciaDO frequenciaDO = null;

        #region Properties

        internal FrequenciaDO FrequenciaDO
        {
            get { return frequenciaDO; }
            set { this.frequenciaDO = value; }
        }

        public virtual int AlunoId
        {
            get { return frequenciaDO.AlunoId; }
            set { this.frequenciaDO.AlunoId = value; }
        }
        
        public int Sequencia
        {
            get { return frequenciaDO.AlunoId; }
            set { this.frequenciaDO.AlunoId = value; }
        }
        public DateTime? DataPresenca
        {
            get { return frequenciaDO.DataPresenca; }
            set { this.frequenciaDO.DataPresenca = value; }
        }
        public int TreinoId
        {
            get { return frequenciaDO.TreinoId; }
            set { this.frequenciaDO.TreinoId = value; }
        }
        public int SequenciaDivisao
        {
            get { return frequenciaDO.SequenciaDivisao; }
            set { this.frequenciaDO.SequenciaDivisao = value; }
        }

        #endregion

        #region Construtores

        public FrequenciaBase()
        {
            frequenciaDO = new FrequenciaDO();
        }

        public FrequenciaBase(int alunoId, int sequencia)
        {
            using (var db = new VitaClubContext())
            {
                frequenciaDO = db.Frequencias.SingleOrDefault(a => a.AlunoId == alunoId && a.Sequencia == sequencia);
            }
        }

        internal FrequenciaBase(FrequenciaDO frequenciaDO)
        {
            this.frequenciaDO = frequenciaDO;
        }

        #endregion

        #region CRUD




        #endregion

    }
}


