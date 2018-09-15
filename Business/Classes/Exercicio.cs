using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;

namespace Business.Classes
{
    public class Exercicio : ExercicioBase
    {
        #region Construtores

        public Exercicio() : base()
        {
        }

        public Exercicio(int id) : base(id)
        {
            Carregar(id);
        }

        public Exercicio(ExercicioDO exercicio) : base(exercicio)
        {

        }

        #endregion

        public bool Save()
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    db.Exercicios.Add(this.ExercicioDO);

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

        public void Carregar(int id)
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    var exercicioDO = db.Exercicios.SingleOrDefault(a => a.Id == id);

                    if (exercicioDO != null)
                    {
                        this.ExercicioDO = exercicioDO;

                        //return new Aluno(alunoDO);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public static List<Exercicio> CarregarTodosExercicios()
        {
            var retorno = new List<Exercicio>();
            try
            {
                using (var db = new VitaClubContext())
                {
                    var exercicios = db.Exercicios.ToList();

                    Exercicio exercicio = null;
                    foreach (var item in exercicios)
                    {
                        exercicio = new Exercicio(item);
                        retorno.Add(exercicio);
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


