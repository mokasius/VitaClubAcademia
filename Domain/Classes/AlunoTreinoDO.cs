using System;
using System.Collections.Generic;

namespace Domain.Classes
{
    public class AlunoTreinoDO
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int TreinoId { get; set; }
        public DateTime ? DataInicial { get; set; }
        public DateTime ? DataFinal { get; set; }
    }
}
