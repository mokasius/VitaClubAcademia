using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;

namespace Business.Classes
{
    public class DivisaoTreino : DivisaoTreinoBase
    {
        public DivisaoTreino() : base()
        {
        }

        public DivisaoTreino(int treinoId, int sequencia) : base(treinoId, sequencia)
        {
        }

        public DivisaoTreino(DivisaoTreinoDO divisaoTreino) : base(divisaoTreino)
        {

        }

        private List<ExercicioTreino> _exerciciosTreinos = null;
        public List<ExercicioTreino> Exercicios
        {
            get
            {
                if (_exerciciosTreinos == null)
                    _exerciciosTreinos = ExercicioTreino.GetExercicioTreinos(this.TreinoId, this.Sequencia);

                return _exerciciosTreinos;
            }
        }

        public static List<DivisaoTreino> GetDivisoesTreino(int? treinoId)
        {
            var retorno = new List<DivisaoTreino>();
            if (treinoId == null || treinoId == 0)
                return retorno;

            try
            {
                using (var db = new VitaClubContext())
                {
                    var lista = db.DivisoesTreino.Where(a => a.TreinoId == treinoId);

                    DivisaoTreino divisao = null;
                    foreach (var item in lista)
                    {
                        divisao = new DivisaoTreino(item);
                        divisao.Exercicios.Count();   // ver se precisa
                        retorno.Add(divisao);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return retorno;
        }

    }
}


