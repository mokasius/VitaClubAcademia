using System;
using System.Collections.Generic;

namespace Domain.Classes
{

    public class ExercicioTreinoDO
    {
        public int Treino { get; set; }
        public int Sequencia { get; set; }
        public int ? Serie { get; set; }
        public int ? Repeticoes { get; set; }
        public int ? Descanso { get; set; }
        public int ? Carga { get; set; }
        //public int ? GrupoMuscular { get; set; }
        public int ? ExercicioId { get; set; }
    }


}
