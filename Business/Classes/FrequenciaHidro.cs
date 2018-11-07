using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Business.WebServiceModels;

namespace Business.Classes
{
    public class FrequenciaHidro : FrequenciaHidroBase
    {
        public FrequenciaHidro() : base()
        {
        }

        internal FrequenciaHidro(FrequenciaHidroDO frequenciaHidro) : base(frequenciaHidro)
        {
        }


        public void Salvar()
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    db.FrequenciasHidro.AddOrUpdate(this.FrequenciaHidroDO);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<FrequenciaHidroModel> CarregarFrequencias(bool presentes)
        {
            var retorno = new List<FrequenciaHidroModel>();
            try
            {
                using (var db = new VitaClubContext())
                {
                    var dataBase = DateTime.Today.AddDays(-7);

                    var alunosUltimaSemana = new int[] { };

                    if (!presentes)
                        alunosUltimaSemana = db.FrequenciasHidro.Where(a => a.Data > dataBase && a.Selecionado == 1).Select(a => a.AlunoId).Distinct().ToArray();

                    // Query para carregar as frequencias dos alunos que estao ativos e fazem parte da hidro e que tem a frequencia selecionada
                    // Também valida se é para carregar os presentes na ultima semana ou ultima vez que foi a partir de 1 semana
                    var pesquisa =
                        (from aluno in db.Alunos
                         join freq in db.FrequenciasHidro on aluno.Id equals freq.AlunoId
                         where aluno.Excluido == (int)enumExcluido.Nao
                             && aluno.Status == (int)enumStatusAluno.Ativo
                             && (aluno.Tipo == (int)enumTipoAluno.Hidro || aluno.Tipo == (int)enumTipoAluno.Ambos)
                             && freq.Selecionado == 1 && (presentes ? freq.Data > dataBase : (freq.Data <= dataBase && !alunosUltimaSemana.Contains(freq.AlunoId)))
                         group freq by freq.AlunoId into frequencia
                         select frequencia.OrderByDescending(a => a.Data).FirstOrDefault());

                    foreach (var item in pesquisa)
                    {
                        retorno.Add(new FrequenciaHidroModel(item));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

    }
}


