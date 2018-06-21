using System;
using System.Collections.Generic;

namespace Domain.Classes
{

    public class AlunoDO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime ? DataNascimento { get; set; }
        public int ? Idade { get; set; }
        public string Profissao { get; set; }
        public int ? FrequenciaSemanal { get; set; }
        public double ? Peso { get; set; }
        public double ? Altura { get; set; }
        public string Email { get; set; }
        public int ? Status { get; set; }

        public virtual ICollection<TreinoDO> Treinos { get; set; }
        //public virtual ICollection<FrequenciaDO> Frequencias { get; set; }
    }


}
