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


