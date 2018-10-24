using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

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

        public static List<FrequenciaHidro> CarregarFrequencias(bool presentes)
        {
            var retorno = new List<FrequenciaHidro>();
            try
            {
                using (var db = new VitaClubContext())
                {
                    var dataBase = DateTime.Today.AddDays(-7);
                    var alunosHidro = db.Alunos.Where(a => a.Excluido == (int)enumExcluido.Nao 
                                                    && a.Status == (int)enumStatusAluno.Ativo 
                                                    && (a.Tipo == (int)enumTipoAluno.Hidro || a.Tipo == (int)enumTipoAluno.Ambos))
                                               .Select(a => a.Id).ToArray();

                    // carrega todas as frequencias dos alunos possiveis, ordenando pela data
                    var query = db.FrequenciasHidro.Where(a => alunosHidro.Contains(a.AlunoId)).OrderByDescending(a => a.Data).ToList();
                    var ultimaDataPorAluno = new HashSet<FrequenciaHidro>();
                    foreach (var alunoId in alunosHidro)
                    {
                        var freq = query.FirstOrDefault(a => a.AlunoId == alunoId);
                        if (freq != null)
                            ultimaDataPorAluno.Add(new FrequenciaHidro(freq));
                    }

                    if (presentes)
                    {
                        retorno = ultimaDataPorAluno.Where(a => a.Data >= dataBase).ToList();
                    }
                    else
                    {
                        retorno = ultimaDataPorAluno.Where(a => a.Data <= dataBase).ToList();
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


