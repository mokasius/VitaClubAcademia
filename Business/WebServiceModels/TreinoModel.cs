using Business.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.WebServiceModels
{
    public class TreinoModel
    {
        public virtual int Id { get; set; }

        public string Descricao { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public int? Status { get; set; }
        public int? AlunoId { get; set; }
        public string Observacao { get; set; }
        public AlunoModel Aluno { get; set; }
        public List<DivisaoTreinoModel> Divisoes { get; set; }

        public Treino ConvertToDTO()
        {
            var treino = new Treino();
            treino.Id = this.Id;
            treino.Descricao = this.Descricao;
            treino.DataInicial = this.DataInicial;
            treino.DataFinal = this.DataFinal;
            treino.Status = this.Status;
            //treino.AlunoId = this.AlunoId;
            treino.Observacao = this.Observacao;

            foreach (var divisaoModel in Divisoes)
            {
                var divisao = divisaoModel.ConvertToDTO();
                treino.Divisoes.Add(divisao);
            }
            
            return treino;
        }

    }
}
