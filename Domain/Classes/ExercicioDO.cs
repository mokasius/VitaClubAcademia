using System;
using System.Collections.Generic;

namespace Domain.Classes
{

    public class ExercicioDO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int ? Serie { get; set; }
        public int ? Repeticoes { get; set; }
        public int ? Descanso { get; set; }
        public int ? Carga { get; set; }
        public int ? GrupoMuscular { get; set; }
        public int ? DivisaoTreinoId { get; set; }

        //public virtual DivisaoTreinoDO DivisaoTreino { get; set; }
    }


}
