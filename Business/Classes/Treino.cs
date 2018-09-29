using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

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

                    db.Treinos.Attach(this.TreinoDO);
                    db.Entry(this.TreinoDO).State = EntityState.Deleted;
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
                        DivisaoTreino.DeletarDivisaoTreino(this.Id);
                        this.Update();
                    }

                    var treinoId = this.TreinoDO.Id;
                    var divSeq = 1;
                    foreach (var divisao in this.Divisoes)
                    {
                        divisao.TreinoId = treinoId;
                        divisao.Sequencia = divSeq++;
                        db.DivisoesTreino.Add(divisao.DivisaoTreinoDO);

                        var exSec = 1;
                        foreach (var exercicio in divisao.Exercicios)
                        {
                            exercicio.DivisaoId = treinoId;
                            exercicio.DivisaoSeq = (int)divisao.Sequencia;
                            exercicio.Sequencia = exSec++;
                            db.ExerciciosTreino.Add(exercicio.ExercicioTreinoDO);
                        }
                    }
                    db.SaveChanges();
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
                    // validar as datas validas ?
                    //var treinos = db.Treinos.Where(a => a.Status == (int)enumStatusTreino.Ativo);
                    var treinos = db.Treinos;
                    foreach (var treinoDO in treinos)
                    {
                        var treino = new Treino(treinoDO);
                        //treino.Divisoes = DivisaoTreino.GetDivisoesTreino(treino.Id);
                        treino.Divisoes.Count();
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


