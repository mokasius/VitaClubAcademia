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

        internal Treino(TreinoDO treino) : base(treino)
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

        public void DeletarTreino()
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    DivisaoTreino.DeletarDivisaoTreino(this.Id);
                    db.Treinos.Remove(this.TreinoDO);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update()
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    var entity = db.Treinos.Find(this.Id);
                    if (entity != null)
                    {
                        db.Entry(entity).CurrentValues.SetValues(this.TreinoDO);
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
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
                    if (this.Id == 0)
                    {
                        db.Treinos.Add(this.TreinoDO);
                        db.SaveChanges();
                    }
                    else
                    {
                        this.Update();
                        DivisaoTreino.DeletarDivisaoTreino(this.Id);
                    }

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

        public static List<Treino> GetTreinos()
        {
            var retorno = new List<Treino>();

            try
            {
                using (var db = new VitaClubContext())
                {
                    var treinos = db.Treinos.Where(a => a.Status == (int)enumStatusTreino.Ativo);
                    foreach (var treinoDO in treinos)
                    {
                        var treino = new Treino(treinoDO);
                        treino.Divisoes.Count();
                        /*
                        var divisoesTreino = db.DivisoesTreino.Where(a => a.TreinoId == treino.Id);
                        foreach (var divisaoTreinoDO in divisoesTreino)
                        {
                            var divisaoTreino = new DivisaoTreino(divisaoTreinoDO);

                            var exerciciosTreino = db.ExerciciosTreino.Where(a => a.DivisaoId == divisaoTreino.TreinoId && a.DivisaoSeq == divisaoTreino.Sequencia);
                            foreach (var exerciciosTreinoDO in exerciciosTreino)
                            {
                                var exercicioTreino = new ExercicioTreino(exerciciosTreinoDO);
                                divisaoTreino.Exercicios.Add(exercicioTreino);
                            }

                            treino.Divisoes.Add(divisaoTreino);
                        }
                        */

                        retorno.Add(treino);
                    }
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }

            return retorno;
        }

    }
}


