using Business.Classes;

namespace Business.WebServiceModels
{
    public class ExercicioModel
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int GrupoMuscular { get; set; }
        
        public Exercicio ConvertToDTO()
        {
            var exercicio = new Exercicio();
            exercicio.Id = this.Id;
            exercicio.Descricao = this.Descricao;
            exercicio.GrupoMuscular = this.GrupoMuscular;

            return exercicio;
        }

        public static ExercicioModel ConvertToModel(Exercicio exercicio)
        {
            var exercicioModel = new ExercicioModel();
            exercicioModel.Id = exercicio.Id;
            exercicioModel.Descricao = exercicio.Descricao;
            exercicioModel.GrupoMuscular = (int)exercicio.GrupoMuscular;

            return exercicioModel;
        }
    }
}