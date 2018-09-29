using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using Business;

namespace Business.Classes
{
    public class AlunoTreinoBase
    {
        private AlunoTreinoDO alunoTreinoDO = null;

        #region Properties

        internal AlunoTreinoDO AlunoTreinoDO
        {
            get { return alunoTreinoDO; }
            set { this.alunoTreinoDO = value; }
        }

        public virtual int Id
        {
            get { return alunoTreinoDO.Id; }
            set { this.alunoTreinoDO.Id = value; }
        }
        public virtual int AlunoId
        {
            get { return alunoTreinoDO.AlunoId; }
            set { this.alunoTreinoDO.AlunoId = value; }
        }
        public virtual int TreinoId
        {
            get { return alunoTreinoDO.TreinoId; }
            set { this.alunoTreinoDO.TreinoId = value; }
        }

        public DateTime? DataInicial
        {
            get { return alunoTreinoDO.DataInicial; }
            set { this.alunoTreinoDO.DataInicial = value; }
        }
        public DateTime? DataFinal
        {
            get { return alunoTreinoDO.DataFinal; }
            set { this.alunoTreinoDO.DataFinal = value; }
        }

        #endregion

        #region Construtores

        public AlunoTreinoBase()
        {
            alunoTreinoDO = new AlunoTreinoDO();
        }

        internal AlunoTreinoBase(AlunoTreinoDO alunoTreinoDO)
        {
            this.alunoTreinoDO = alunoTreinoDO;
        }

        #endregion

    }
}


