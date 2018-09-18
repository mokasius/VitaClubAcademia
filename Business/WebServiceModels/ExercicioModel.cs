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
    }
}