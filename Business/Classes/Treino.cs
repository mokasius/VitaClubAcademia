using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;

namespace Business.Classes
{
    public class Treino : TreinoBase
    {
        public Treino() : base()
        {
        }

        public Treino(int id) : base(id)
        {
        }

        public Treino(TreinoDO treino) : base(treino)
        {

        }

        //public List<DivisaoTreino> Divisoes { get; set; }
        private List<DivisaoTreino> _divisoes = null;
        public List<DivisaoTreino> Divisoes
        {
            get
            {
                if (_divisoes == null)
                    _divisoes = DivisaoTreino.GetDivisoesTreino(this.Id);

                return _divisoes;
            }
        }

        public void Save()
        {
            //foreach (var divisao in this.Divisoes)
            //{
            //    var id = divisao.Id;
            //}

            try
            {
                using (var db = new VitaClubContext())
                {
                    db.Treinos.Add(this.TreinoDO);
                    db.SaveChanges();

                    var entry = db.Entry(this.TreinoDO).GetDatabaseValues();

                    var treinoId = this.TreinoDO.Id;


                    var divSeq = 1;
                    foreach (var divisao in this.Divisoes)
                    {
                        divisao.TreinoId = treinoId;
                        divisao.Sequencia = divSeq++;
                        db.DivisoesTreino.Add(divisao.DivisaoTreinoDO);
                        db.SaveChanges();

                        var exSec = 1;
                        foreach (var exercicio in divisao.Exercicios)
                        {
                            exercicio.DivisaoId = treinoId;
                            exercicio.DivisaoSeq = (int)divisao.Sequencia;
                            exercicio.Sequencia = exSec++;
                            db.ExerciciosTreino.Add(exercicio.ExercicioTreinoDO);
                            db.SaveChanges();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

    }
}


