using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using Business;

namespace Business.Classes
{
    public class TreinoBase
    {
        private TreinoDO treinoDO = null;

        #region Properties

        internal TreinoDO TreinoDO
        {
            get { return treinoDO; }
            set { this.treinoDO = value; }
        }

        public virtual int Id
        {
            get { return treinoDO.Id; }
            set { this.treinoDO.Id = value; }
        }

        public string Descricao
        {
            get { return treinoDO.Descricao; }
            set { this.treinoDO.Descricao = value; }
        }
        
        /*
        public DateTime? DataInicial
        {
            get { return treinoDO.DataInicial; }
            set { this.treinoDO.DataInicial = value; }
        }
        public DateTime? DataFinal
        {
            get { return treinoDO.DataFinal; }
            set { this.treinoDO.DataFinal = value; }
        }
        public int? Status
        {
            get { return treinoDO.Status; }
            set { this.treinoDO.Status = value; }
        }
        */
        //public int ? AlunoId
        //{
        //    get { return treinoDO.AlunoId; }
        //    set { this.treinoDO.AlunoId = value; }
        //}
        public string Observacao
        {
            get { return treinoDO.Observacao; }
            set { this.treinoDO.Observacao = value; }
        }

        public Aluno Aluno { get; set; }

        #endregion

        #region Construtores

        public TreinoBase()
        {
            treinoDO = new TreinoDO();
        }

        public TreinoBase(int id)
        {
            using (var db = new VitaClubContext())
            {
                treinoDO = db.Treinos.SingleOrDefault(a => a.Id == id);
            }
        }

        internal TreinoBase(TreinoDO treinoDO)
        {
            this.treinoDO = treinoDO;
        }

        #endregion

        #region CRUD




        #endregion

    }
}


