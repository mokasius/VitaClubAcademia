using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;

namespace Business.Classes
{
    public class DivisaoTreino : DivisaoTreinoBase
    {
        public DivisaoTreino() : base()
        {
        }

        public DivisaoTreino(int treinoId, int sequencia) : base(treinoId, sequencia)
        {
        }

        public DivisaoTreino(DivisaoTreinoDO divisaoTreino) : base(divisaoTreino)
        {

        }
    }
}


