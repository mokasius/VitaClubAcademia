using System;
using System.Collections.Generic;

namespace Domain.Classes
{

    public class DivisaoTreinoDO
    {
        public int Id { get; set; }
        public int ? TreinoId { get; set; }
        public int ? Sequencia { get; set; }
        public string Descricao { get; set; }

        public virtual TreinoDO Treino { get; set; }
        //public virtual ICollection<ExercicioDO> Exercicios { get; set; }
    }


}
