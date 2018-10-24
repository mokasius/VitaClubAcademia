using System;
using System.Collections.Generic;

namespace Domain.Classes
{

    public class PagamentoDO
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public double Valor { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public DateTime DataPagamento { get; set; }
    }


}
