﻿using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

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

        internal DivisaoTreino(DivisaoTreinoDO divisaoTreino) : base(divisaoTreino)
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

        public static void DeletarDivisaoTreino(int treinoId)
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    var delDivisao = db.DivisoesTreino.Where(a => a.TreinoId == treinoId).ToList();
                    foreach (var item in delDivisao)
                    {
                        ExercicioTreino.DeletarExercicioTreino((int)item.TreinoId, (int)item.Sequencia);

                        db.DivisoesTreino.Attach(item);
                        db.Entry(item).State = EntityState.Deleted;
                    }
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


