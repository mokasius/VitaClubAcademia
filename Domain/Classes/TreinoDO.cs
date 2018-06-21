using System;
using System.Collections.Generic;

namespace Domain.Classes
{

    public class TreinoDO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime ? DataInicial { get; set; }
        public DateTime ? DataFinal { get; set; }
        public int ? Status { get; set; }
        public int ? AlunoId { get; set; }

        public virtual AlunoDO Aluno { get; set; }
        public virtual ICollection<DivisaoTreinoDO> DivisoesTreino { get; set; }
    }


}
