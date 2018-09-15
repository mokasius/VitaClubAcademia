using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Business.Classes
{
    public class Aluno : AlunoBase
    {
        #region Construtores

        public Aluno() : base()
        {
            //Treinos = new Treino();
            //Frequencias = new Frequencia();
        }

        public Aluno(int id) : base(id)
        {

        }

        public Aluno(AlunoDO aluno) : base(aluno)
        {

        }

        #endregion

        /*
        public new enumTipoAluno EnumTipo
        {
            get
            {
                return (enumTipoAluno)base.Tipo;
            }
            set
            {
                base.Tipo = (int)value;
            }
        }
        */

        private List<Treino> treinos = null;
        public List<Treino> Treinos
        {
            get
            {
                if (treinos == null)
                {
                    treinos = new List<Treino>();

                    using (var db = new VitaClubContext())
                    {
                        //var _treinos = db.Treinos.Where(a => a.AlunoId == this.Id);

                        var _treinos = db.Treinos.ToList();
                        foreach (var item in _treinos)
                        {
                            treinos.Add(new Treino(item));
                        }
                    }
                }
                return treinos;
            }
        }

        private void SaveTreinos(VitaClubContext db)
        {
            // remove os treinos
            //db.Treinos.RemoveRange(db.Treinos.Where(a => a.AlunoId == this.Id));

            // adiciona os DO's no treino para salvar
            //db.Treinos.AddRange(this.Treinos.Select(a => a.TreinoDO));
        }

        public void ValidaAluno()
        {
            if (this.Id != 0)
            {
                try
                {
                    using (var db = new VitaClubContext())
                    {
                        if (db.Alunos.Count(a => a.Id == this.Id) > 0)
                            throw new Exception("Aluno já existe.");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Save()
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    db.Alunos.AddOrUpdate(this.AlunoDO);
                    this.SaveTreinos(db);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }

            return true;
        }

        public static Aluno CarregarAluno(int id)
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    var alunoDO = db.Alunos.SingleOrDefault(a => a.Id == id);

                    if (alunoDO != null)
                    {
                        var aluno = new Aluno(alunoDO);

                        return aluno;
                        //return new Aluno(alunoDO);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }

            return new Aluno();
        }

        public static List<Aluno> CarregarAlunos()
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    var retorno = new List<Aluno>();
                    var alunos = db.Alunos.ToList();

                    foreach (var aluno in alunos)
                    {
                        var a = new Aluno(aluno);
                        a.Treinos.Count();
                        //a.Treinos.Clear();  //limpa os treinos para nao ficar pesado na hora de passar pro mobile
                        //retorno.Add(new Aluno(aluno));
                        retorno.Add(a);
                    }

                    return retorno;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

    }
}


