using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;

namespace Business.Classes
{
    public class ExercicioTreino : ExercicioTreinoBase
    {

        public ExercicioTreino() : base()
        {
        }

        public ExercicioTreino(int treino, int sequencia) : base(treino, sequencia)
        {
        }

        public ExercicioTreino(ExercicioTreinoDO exercicioTreino) : base(exercicioTreino)
        {

        }



    }
}


