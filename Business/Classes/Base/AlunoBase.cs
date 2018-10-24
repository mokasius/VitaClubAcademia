using System;
using Domain.Classes;
using System.Linq;
using System.Collections.Generic;
using Business;

namespace Business.Classes
{
    public class AlunoBase
    {
        private AlunoDO alunoDO = null;
        
        #region Properties

        internal AlunoDO AlunoDO
        {
            get { return alunoDO; }
            set { this.alunoDO = value; }
        }

        public virtual int Id
        {
            get { return alunoDO.Id; }
            set { this.alunoDO.Id = value; }
        }

        public virtual string Nome
        {
            get { return alunoDO.Nome; }
            set { this.alunoDO.Nome = value; }
        }

        public virtual DateTime? DataNascimento
        {
            get { return alunoDO.DataNascimento; }
            set { this.alunoDO.DataNascimento = value; }
        }
        
        public virtual int? Idade
        {
            get { return alunoDO.Idade; }
            set { this.alunoDO.Idade = value; }
        }

        public virtual int? FrequenciaSemanal
        {
            get { return alunoDO.FrequenciaSemanal; }
            set { this.alunoDO.FrequenciaSemanal = value; }
        }

        public virtual string Profissao
        {
            get { return alunoDO.Profissao; }
            set { this.alunoDO.Profissao = value; }
        }

        public virtual double? Peso
        {
            get { return alunoDO.Peso; }
            set { this.alunoDO.Peso = value; }
        }

        public virtual double? Altura
        {
            get { return alunoDO.Altura; }
            set { this.alunoDO.Altura = value; }
        }

        public virtual string Email
        {
            get { return alunoDO.Email; }
            set { this.alunoDO.Email = value; }
        }

        public virtual int? Status
        {
            get { return alunoDO.Status; }
            set { this.alunoDO.Status = value; }
        }

        public virtual string Telefone
        {
            get { return alunoDO.Telefone; }
            set { this.alunoDO.Telefone = value; }
        }

        public virtual string Objetivo
        {
            get { return alunoDO.Objetivo; }
            set { this.alunoDO.Objetivo = value; }
        }

        public virtual int? DiaVencimento
        {
            get { return alunoDO.DiaVencimento; }
            set { this.alunoDO.DiaVencimento = value; }
        }

        public virtual int? Sexo
        {
            get { return alunoDO.Sexo; }
            set { this.alunoDO.Sexo = value; }
        }

        public virtual int? Turno
        {
            get { return alunoDO.Turno; }
            set { this.alunoDO.Turno = value; }
        }

        public virtual string DiasSemana
        {
            get { return alunoDO.DiasSemana; }
            set { this.alunoDO.DiasSemana = value; }
        }

        public virtual int? Tipo
        {
            get { return alunoDO.Tipo; }
            set { this.alunoDO.Tipo = value; }
        }

        public virtual string Observacao
        {
            get { return alunoDO.Observacao; }
            set { this.alunoDO.Observacao = value; }
        }

        public virtual string PlanoSaude
        {
            get { return alunoDO.PlanoSaude; }
            set { this.alunoDO.PlanoSaude = value; }
        }

        public virtual string TipoSanguineo
        {
            get { return alunoDO.TipoSanguineo; }
            set { this.alunoDO.TipoSanguineo = value; }
        }

        public virtual int HorarioHidro
        {
            get { return alunoDO.HorarioHidro; }
            set { this.alunoDO.HorarioHidro = value; }
        }

        public virtual int Excluido
        {
            get { return alunoDO.Excluido; }
            set { this.alunoDO.Excluido = value; }
        }

        #endregion

        #region Construtores

        public AlunoBase()
        {
            alunoDO = new AlunoDO();
        }

        public AlunoBase(int id)
        {
            using (var db = new VitaClubContext())
            {
                alunoDO = db.Alunos.SingleOrDefault(a => a.Id == id);   
            }
        }

        internal AlunoBase(AlunoDO alunoDO)
        {
            //this.State = enumBusinessState.Persisted;
            this.alunoDO = alunoDO;
        }


        #endregion

        #region CRUD




        #endregion

    }
}


