using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Business.Classes
{
    public class Pagamento : PagamentoBase
    {
        public Pagamento() : base()
        {
        }

        internal Pagamento(PagamentoDO pagamentoDO) : base(pagamentoDO)
        {
        }

        private void ValidaPagamento()
        {
            try
            {
                using (var db = new VitaClubContext())
                {
                    if (this.Valor <= 0)
                        throw new Exception("Valor informado deve ser maior que zero.");

                    var existe = db.Pagamentos.Count(a => a.AlunoId == this.AlunoId && a.Mes == this.Mes && a.Ano == this.Ano) > 0;
                    if (existe)
                        throw new Exception("Aluno já possui pagamento para o mês e ano informados.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Salvar()
        {
            try
            {
                ValidaPagamento();
                using (var db = new VitaClubContext())
                {
                    db.Pagamentos.Add(this.PagamentoDO);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarEmailPDF()
        {

        }

    }
}


