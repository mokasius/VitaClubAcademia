using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;

namespace Business.Classes
{
    public class ExercicioTreino : ExercicioTreinoBase
    {

        public ExercicioTreino() : base()
        {
        }

        public ExercicioTreino(int divisaoId, int divisaoSeq, int sequencia) : base(divisaoId, divisaoSeq, sequencia)
        {
        }

        internal ExercicioTreino(ExercicioTreinoDO exercicioTreino) : base(exercicioTreino)
        {

        }

        private Exercicio _exercicio = null;
        public Exercicio Exercicio
        {
            get
            { 
                if (_exercicio == null && this.ExercicioId != null)
                    _exercicio = new Exercicio((int)this.ExercicioId);

                return _exercicio;
            }
        }

        public static List<ExercicioTreino> GetExercicioTreinos(int? treinoId, int? seq)
        {
            var retorno = new List<ExercicioTreino>();
            if (treinoId == null || treinoId == 0)
                return retorno;

            try
            {
                using (var db = new VitaClubContext())
                {
                    var lista = db.ExerciciosTreino.Where(a => a.DivisaoId == treinoId && a.DivisaoSeq == seq);

                    ExercicioTreino exercicioTreino = null;
                    foreach (var item in lista)
                    {
                        exercicioTreino = new ExercicioTreino(item);
                        retorno.Add(exercicioTreino);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return retorno;
        }

        public static void DeletarExercicioTreino(int divisaoId, int sequencia)
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    var delExercicio = db.ExerciciosTreino.Where(a => a.DivisaoId == divisaoId && a.DivisaoSeq == sequencia).ToList();
                    db.ExerciciosTreino.RemoveRange(delExercicio);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


