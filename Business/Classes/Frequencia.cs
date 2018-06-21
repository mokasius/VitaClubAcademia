using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;

namespace Business.Classes
{
    public class Frequencia : FrequenciaBase
    {
        public Frequencia() : base()
        {
        }

        public Frequencia(int alunoId, int sequencia) : base(alunoId, sequencia)
        {
        }

        public Frequencia(FrequenciaDO frequencia) : base(frequencia)
        {

        }
    }
}


