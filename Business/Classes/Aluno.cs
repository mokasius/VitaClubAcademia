using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;

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
                        var _treinos = db.Treinos.Where(a => a.AlunoId == this.Id);

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
            db.Treinos.RemoveRange(db.Treinos.Where(a => a.AlunoId == this.Id));

            // adiciona os DO's no treino para salvar
            db.Treinos.AddRange(this.Treinos.Select(a => a.TreinoDO));
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
                    db.Alunos.Add(this.AlunoDO);

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

        public static void Teste()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            using (var db = new VitaClubContext())
            {

                var aluno = new Aluno();
                aluno.Id = 1;
                aluno.Nome = "aluno 1";
                //var aluno2 = new Aluno(aluno.AlunoDO);

                //var x = aluno.Nome;


                var treino2 = new Treino();
                treino2.Id = 3;
                treino2.AlunoId = 1;
                treino2.Descricao = "desc 3";

                aluno.Treinos.Add(treino2);

                aluno.Save();
                
            }
        }


    }
}


