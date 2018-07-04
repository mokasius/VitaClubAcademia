using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using Business;

namespace Business.Classes
{
    public class ExercicioBase
    {
        private ExercicioDO exercicioDO = null;

        #region Properties

        internal ExercicioDO ExercicioDO
        {
            get { return exercicioDO; }
            set { this.exercicioDO = value; }
        }

        public virtual int Id
        {
            get { return exercicioDO.Id; }
            set { this.exercicioDO.Id = value; }
        }

        public virtual string Descricao
        {
            get { return exercicioDO.Descricao; }
            set { this.exercicioDO.Descricao = value; }
        }

        public virtual int? GrupoMuscular
        {
            get { return exercicioDO.GrupoMuscular; }
            set { this.exercicioDO.GrupoMuscular = value; }
        }

        /*
        public virtual int? Serie
        {
            get { return exercicioDO.Serie; }
            set { this.exercicioDO.Serie = value; }
        }

        public virtual int? Repeticoes
        {
            get { return exercicioDO.Repeticoes; }
            set { this.exercicioDO.Repeticoes = value; }
        }

        public virtual int? Descanso
        {
            get { return exercicioDO.Descanso; }
            set { this.exercicioDO.Descanso = value; }
        }
        public virtual int? Carga
        {
            get { return exercicioDO.Carga; }
            set { this.exercicioDO.Carga = value; }
        }        
        public virtual int? DivisaoTreinoId
        {
            get { return exercicioDO.DivisaoTreinoId; }
            set { this.exercicioDO.DivisaoTreinoId = value; }
        }
        */

        #endregion

        #region Construtores

        public ExercicioBase()
        {
            exercicioDO = new ExercicioDO();
        }

        public ExercicioBase(int id)
        {
            using (var db = new VitaClubContext())
            {
                exercicioDO = db.Exercicios.SingleOrDefault(a => a.Id == id);
            }
        }

        internal ExercicioBase(ExercicioDO exercicioDO)
        {
            this.exercicioDO = exercicioDO;
        }

        #endregion

        #region CRUD




        #endregion

    }
}


