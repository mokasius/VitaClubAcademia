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
            treino.Observacao = this.Observacao;

            foreach (var divisaoModel in Divisoes)
            {
                var divisao = divisaoModel.ConvertToDTO();
                treino.Divisoes.Add(divisao);
            }
            
            return treino;
        }

        public static TreinoModel ConvertToModel(Treino treino)
        {
            var treinoModel = new TreinoModel();
            treinoModel.Id = treino.Id;
            treinoModel.Descricao = treino.Descricao;
            treinoModel.DataInicial = treino.DataInicial;
            treinoModel.DataFinal = treino.DataFinal;
            treinoModel.Status = treino.Status;
            treinoModel.Observacao = treino.Observacao;

            treinoModel.Divisoes = new List<DivisaoTreinoModel>();
            foreach (var divisao in treino.Divisoes)
            {
                var divisaoModel = DivisaoTreinoModel.ConvertToModel(divisao);
                treinoModel.Divisoes.Add(divisaoModel);
            }

            return treinoModel;
        }


        public static List<TreinoModel> CarregarTodosTreinos()
        {
            var retorno = new List<TreinoModel>();

            var treinos = Treino.GetTreinos();
            foreach (var treino in treinos)
            {
                retorno.Add(TreinoModel.ConvertToModel(treino));
            }

            return retorno;
        }
    }
}
