using System;
using System.Collections.Generic;

namespace Domain.Classes
{

    public class FrequenciaDO
    {
        public int AlunoId { get; set; }
        public int Sequencia { get; set; }
        public DateTime ? DataPresenca { get; set; }
        public int TreinoId { get; set; }
        public int SequenciaDivisao { get; set; }

        public virtual AlunoDO Aluno { get; set; }
        //public virtual DivisaoTreinoDO DivisaoTreino { get; set; }
    }


}
