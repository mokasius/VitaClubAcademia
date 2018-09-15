using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using Business;

namespace Business.Classes
{
    public class ExercicioTreinoBase
    {
        private ExercicioTreinoDO exercicioTreinoDO = null;

        #region Properties

        internal ExercicioTreinoDO ExercicioTreinoDO
        {
            get { return exercicioTreinoDO; }
            set { this.exercicioTreinoDO = value; }
        }

        public virtual int DivisaoId
        {
            get { return exercicioTreinoDO.DivisaoId; }
            set { this.exercicioTreinoDO.DivisaoId = value; }
        }
        public virtual int DivisaoSeq
        {
            get { return exercicioTreinoDO.DivisaoSeq; }
            set { this.exercicioTreinoDO.DivisaoSeq = value; }
        }

        public virtual int Sequencia
        {
            get { return exercicioTreinoDO.Sequencia; }
            set { this.exercicioTreinoDO.Sequencia = value; }
        }

        public virtual int? Serie
        {
            get { return exercicioTreinoDO.Serie; }
            set { this.exercicioTreinoDO.Serie = value; }
        }

        public virtual int? Repeticoes
        {
            get { return exercicioTreinoDO.Repeticoes; }
            set { this.exercicioTreinoDO.Repeticoes = value; }
        }

        public virtual int? Descanso
        {
            get { return exercicioTreinoDO.Descanso; }
            set { this.exercicioTreinoDO.Descanso = value; }
        }
        public virtual int? Carga
        {
            get { return exercicioTreinoDO.Carga; }
            set { this.exercicioTreinoDO.Carga = value; }
        }        
        public virtual int? ExercicioId
        {
            get { return exercicioTreinoDO.ExercicioId; }
            set { this.exercicioTreinoDO.ExercicioId = value; }
        }

        #endregion

        #region Construtores

        public ExercicioTreinoBase()
        {
            exercicioTreinoDO = new ExercicioTreinoDO();
        }

        public ExercicioTreinoBase(int divisaoId, int divisaoSeq, int sequencia)
        {
            using (var db = new VitaClubContext())
            {
                exercicioTreinoDO = db.ExerciciosTreino.SingleOrDefault(a => a.DivisaoId == divisaoId && a.DivisaoSeq == divisaoSeq && a.Sequencia == sequencia);
            }
        }

        internal ExercicioTreinoBase(ExercicioTreinoDO exercicioTreinoDO)
        {
            this.exercicioTreinoDO = exercicioTreinoDO;
        }

        #endregion

        #region CRUD




        #endregion

    }
}


