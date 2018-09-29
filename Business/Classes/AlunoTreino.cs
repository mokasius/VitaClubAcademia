using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Business.Classes
{
    public class AlunoTreino : AlunoTreinoBase
    {
        public AlunoTreino() : base()
        {
        }

        internal AlunoTreino(AlunoTreinoDO alunoTreino) : base(alunoTreino)
        {
        }

        public void VincularTreino()
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    db.AlunosTreinos.Add(this.AlunoTreinoDO);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}


