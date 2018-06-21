using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;

namespace Business.Classes
{
    public class Treino : TreinoBase
    {
        public Treino() : base()
        {
        }

        public Treino(int id) : base(id)
        {
        }

        public Treino(TreinoDO treino) : base(treino)
        {

        }
    }
}


