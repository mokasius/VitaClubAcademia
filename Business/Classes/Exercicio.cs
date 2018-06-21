using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;

namespace Business.Classes
{
    public class Exercicio : ExercicioBase
    {

        public Exercicio() : base()
        {
        }

        public Exercicio(int id) : base(id)
        {
        }

        public Exercicio(ExercicioDO exercicio) : base(exercicio)
        {

        }



    }
}


