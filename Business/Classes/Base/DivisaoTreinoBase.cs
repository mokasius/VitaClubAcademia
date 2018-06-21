using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using Business;

namespace Business.Classes
{
    public class DivisaoTreinoBase
    {
        private DivisaoTreinoDO divisaoTreinoDO = null;

        #region Properties

        internal DivisaoTreinoDO DivisaoTreinoDO
        {
            get { return divisaoTreinoDO; }
            set { this.divisaoTreinoDO = value; }
        }

        public int Id
        {
            get { return divisaoTreinoDO.Id; }
            set { this.divisaoTreinoDO.Id = value; }
        }

        public int ? TreinoId
        {
            get { return divisaoTreinoDO.TreinoId; }
            set { this.divisaoTreinoDO.TreinoId = value; }
        }

        public int ? Sequencia
        {
            get { return divisaoTreinoDO.TreinoId; }
            set { this.divisaoTreinoDO.TreinoId = value; }
        }

        public string Descricao
        {
            get { return divisaoTreinoDO.Descricao; }
            set { this.divisaoTreinoDO.Descricao = value; }
        }

        #endregion

        #region Construtores

        public DivisaoTreinoBase()
        {
            divisaoTreinoDO = new DivisaoTreinoDO();
        }

        public DivisaoTreinoBase(int treinoId, int sequencia)
        {
            using (var db = new VitaClubContext())
            {
                divisaoTreinoDO = db.DivisoesTreino.SingleOrDefault(a => a.TreinoId == treinoId && a.Sequencia == sequencia);
            }
        }

        internal DivisaoTreinoBase(DivisaoTreinoDO divisaoTreinoDO)
        {
            this.divisaoTreinoDO = divisaoTreinoDO;
        }

        #endregion

        #region CRUD




        #endregion

    }
}


