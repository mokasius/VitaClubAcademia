using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using Business.Uteis;

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

        public DateTime MesAnoReferencia
        {
            get { return new DateTime(this.Ano, this.Mes, 1); }
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

        public static List<Pagamento> CarregarUltimosPgtosAluno(int alunoId)
        {
            var retorno = new List<Pagamento>();

            try
            {
                using (var db = new VitaClubContext())
                {
                    var query = db.Pagamentos.Where(a => a.AlunoId == alunoId).OrderByDescending(a => a.Ano).ThenByDescending(a => a.Mes).Take(3);
                    foreach (var item in query)
                    {
                        retorno.Add(new Pagamento(item));
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return retorno;
        }

        public static List<RelatorioPagamentos> GetPagamentos()
        {
            var retorno = new List<RelatorioPagamentos>();

            //DateTime dataInicial = DateTime.Today.AddYears(-1);
            //DateTime dataFinal = DateTime.Today;
            int mesInicial = 01;
            int mesFinal = 03;
            int anoInicial = 2018;
            int anoFinal = 2019;

            var dataInicial = new DateTime(anoInicial, mesInicial, 1);
            var dataFinal = new DateTime(anoFinal, mesFinal, 1);

            int[] alunosSelecionados = new int[] { };

            try
            {
                using (var db = new VitaClubContext())
                {
                    // validar os alunos informados
                    var alunos = db.Alunos.Where(a => (a.Tipo == (int)enumTipoAluno.Hidro || a.Tipo == (int)enumTipoAluno.Ambos) 
                                                    && a.Status == (int)enumStatusAluno.Ativo && a.Excluido == (int)enumExcluido.Nao);

                    var alunosValidos = alunos.Select(a => new
                    {
                        a.Id,
                        a.Nome,
                        a.DiaVencimento                        
                    }).ToList();

                    var alunosList = alunosValidos.Select(a => a.Id).ToList();

                    var pagamentosRealizados = db.Pagamentos.Where(a => alunosList.Contains(a.AlunoId)
                        && (a.Mes >= mesInicial && a.Mes <= mesFinal)
                        && (a.Ano >= anoInicial && a.Ano <= anoFinal) 
                    ).ToList();

                    foreach (var aluno in alunosValidos)
                    {
                        var _dataInicial = dataInicial;
                        
                        do
                        {
                            var _mesInicial = _dataInicial.Month;
                            var _anoInicial = _dataInicial.Year;

                            var pgto = new RelatorioPagamentos();
                            pgto.AlunoId = aluno.Id;
                            pgto.Nome = aluno.Nome;
                            pgto.Mes = _mesInicial;
                            pgto.Ano = _anoInicial;

                            var pgtoExistente = pagamentosRealizados.FirstOrDefault(a => a.AlunoId == aluno.Id && a.Mes == _mesInicial && a.Ano == _anoInicial);
                            if (pgtoExistente != null)
                            {
                                pgto.Situacao = "Pago";
                                pgto.DataVcto = null;

                                retorno.Add(pgto);
                            }
                            else
                            {
                                pgto.Situacao = "Aberto";
                                pgto.DataVcto = new DateTime(_anoInicial, _mesInicial, aluno.DiaVencimento == 0 ? 1 : (int)aluno.DiaVencimento);

                                retorno.Add(pgto);
                            }

                            _dataInicial = _dataInicial.AddMonths(1);

                        } while (_dataInicial < dataFinal);
                    }

                    var ordenadosPorData = retorno.OrderBy(a => a.MesAnoReferencia).ToList();
                    return ordenadosPorData;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public class RelatorioPagamentos
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Situacao { get; set; }
        public DateTime? DataVcto { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public DateTime MesAnoReferencia
        {
            get { return new DateTime(this.Ano, this.Mes, 1); }
        }
    }
}


