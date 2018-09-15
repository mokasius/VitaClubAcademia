using Business.Classes;

namespace Business.WebServiceModels
{
    public class ExercicioTreinoModel
    {
        public virtual int DivisaoId { get; set; }
        public virtual int DivisaoSeq { get; set; }
        public virtual int Sequencia { get; set; }

        public virtual int? Serie { get; set; }
        public virtual int? Repeticoes { get; set; }
        public virtual int? Descanso { get; set; }
        public virtual int? Carga { get; set; }
        public virtual int? ExercicioId { get; set; }

        public ExercicioTreino ConvertToDTO()
        {
            var exercicio = new ExercicioTreino();
            exercicio.DivisaoId = this.DivisaoId;
            exercicio.DivisaoSeq = this.DivisaoSeq;
            exercicio.Sequencia = this.Sequencia;
            exercicio.Serie = this.Serie;
            exercicio.Repeticoes = this.Repeticoes;
            exercicio.Descanso = this.Descanso;
            exercicio.Carga = this.Carga;
            exercicio.ExercicioId = this.ExercicioId;

            return exercicio;
        }

    }
}