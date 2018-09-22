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
        public virtual ExercicioModel Exercicio { get; set; }
        public virtual int? ExercicioId { get; set; }

        public ExercicioTreino ConvertToDTO()
        {
            var exercicioTreino = new ExercicioTreino();
            exercicioTreino.DivisaoId = this.DivisaoId;
            exercicioTreino.DivisaoSeq = this.DivisaoSeq;
            exercicioTreino.Sequencia = this.Sequencia;
            exercicioTreino.Serie = this.Serie;
            exercicioTreino.Repeticoes = this.Repeticoes;
            exercicioTreino.Descanso = this.Descanso;
            exercicioTreino.Carga = this.Carga;
            var ex = this.Exercicio.ConvertToDTO();
            exercicioTreino.ExercicioId = ex.Id;

            return exercicioTreino;
        }

        public static ExercicioTreinoModel ConvertToModel(ExercicioTreino exercicioTreino)
        {
            var exercicioTreinoModel = new ExercicioTreinoModel();
            exercicioTreinoModel.DivisaoId = exercicioTreino.DivisaoId;
            exercicioTreinoModel.DivisaoSeq = exercicioTreino.DivisaoSeq;
            exercicioTreinoModel.Sequencia = exercicioTreino.Sequencia;
            exercicioTreinoModel.Serie = exercicioTreino.Serie;
            exercicioTreinoModel.Repeticoes = exercicioTreino.Repeticoes;
            exercicioTreinoModel.Descanso = exercicioTreino.Descanso;
            exercicioTreinoModel.Carga = exercicioTreino.Carga;
            exercicioTreinoModel.ExercicioId = exercicioTreino.ExercicioId;
            exercicioTreinoModel.Exercicio = ExercicioModel.ConvertToModel(exercicioTreino.Exercicio);

            return exercicioTreinoModel;
        }

    }
}