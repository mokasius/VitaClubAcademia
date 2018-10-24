using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using Business;

namespace Business.Classes
{
    public class PagamentoBase
    {
        private PagamentoDO pagamentoDO = null;

        #region Properties

        internal PagamentoDO PagamentoDO
        {
            get { return pagamentoDO; }
            set { this.pagamentoDO = value; }
        }

        public virtual int Id
        {
            get { return pagamentoDO.Id; }
            set { this.pagamentoDO.Id = value; }
        }

        public virtual int AlunoId
        {
            get { return pagamentoDO.AlunoId; }
            set { this.pagamentoDO.AlunoId = value; }
        }

        public virtual int Mes
        {
            get { return pagamentoDO.Mes; }
            set { this.pagamentoDO.Mes = value; }
        }

        public virtual int Ano
        {
            get { return pagamentoDO.Ano; }
            set { this.pagamentoDO.Ano = value; }
        }

        public virtual double Valor
        {
            get { return pagamentoDO.Valor; }
            set { this.pagamentoDO.Valor = value; }
        }

        public virtual DateTime DataPagamento
        {
            get { return pagamentoDO.DataPagamento; }
            set { this.pagamentoDO.DataPagamento = value; }
        }
        

        #endregion

        #region Construtores

        public PagamentoBase()
        {
            pagamentoDO = new PagamentoDO();
        }

        internal PagamentoBase(PagamentoDO pagamentoDO)
        {
            this.pagamentoDO = pagamentoDO;
        }

        #endregion

    }
}


