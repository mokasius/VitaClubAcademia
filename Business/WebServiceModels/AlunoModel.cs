using Business.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.WebServiceModels
{
    public class AlunoModel
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual DateTime? DataNascimento { get; set; }

        public virtual int? Idade { get; set; }

        public virtual int? FrequenciaSemanal { get; set; }

        public virtual string Profissao { get; set; }

        public virtual double? Peso { get; set; }

        public virtual double? Altura { get; set; }

        public virtual string Email { get; set; }

        public virtual int? Status { get; set; }

        public virtual string Telefone { get; set; }

        public virtual string Objetivo { get; set; }

        public virtual int? DiaVencimento { get; set; }

        public virtual int? Sexo { get; set; }

        public virtual int? Turno { get; set; }

        public virtual List<int> DiasSemana { get; set; }

        public virtual int? Tipo { get; set; }

        public virtual string Observacao { get; set; }

        public virtual string PlanoSaude { get; set; }

        public virtual string TipoSanguineo { get; set; }


        public Aluno ConvertToDTO()
        {
            var aluno = new Aluno();
            aluno.Id = this.Id;
            aluno.Nome = this.Nome;
            aluno.DataNascimento = this.DataNascimento;
            aluno.Idade = this.Idade;
            aluno.FrequenciaSemanal = this.FrequenciaSemanal;
            aluno.Profissao = this.Profissao;
            aluno.Peso = this.Peso;
            aluno.Altura = this.Altura;
            aluno.Email = this.Email;
            aluno.Status = this.Status;
            aluno.Telefone = this.Telefone;
            aluno.Objetivo = this.Objetivo;
            aluno.DiaVencimento = this.DiaVencimento;
            aluno.Sexo = this.Sexo;
            aluno.Turno = this.Turno;
            aluno.DiasSemana = this.DiasSemana == null ? string.Empty : string.Join(",", this.DiasSemana);
            aluno.Tipo = this.Tipo;
            aluno.Observacao = this.Observacao;
            aluno.PlanoSaude = this.PlanoSaude;
            aluno.TipoSanguineo = this.TipoSanguineo;
            
            return aluno;
        }

        public static AlunoModel ConvertToModel(Aluno aluno)
        {
            var alunoModel = new AlunoModel();
            alunoModel.Id = aluno.Id;
            alunoModel.Nome = aluno.Nome;
            alunoModel.DataNascimento = aluno.DataNascimento;
            alunoModel.Idade = aluno.Idade;
            alunoModel.FrequenciaSemanal = aluno.FrequenciaSemanal;
            alunoModel.Profissao = aluno.Profissao;
            alunoModel.Peso = aluno.Peso;
            alunoModel.Altura = aluno.Altura;
            alunoModel.Email = aluno.Email;
            alunoModel.Status = aluno.Status;
            alunoModel.Telefone = aluno.Telefone;
            alunoModel.Objetivo = aluno.Objetivo;
            alunoModel.DiaVencimento = aluno.DiaVencimento;
            alunoModel.Sexo = aluno.Sexo;
            alunoModel.Turno = aluno.Turno;
            alunoModel.DiasSemana = aluno.DiasSemana != null ? aluno.DiasSemana.Split(',').Select(Int32.Parse).ToList() : new List<int>();
            alunoModel.Tipo = aluno.Tipo;
            alunoModel.Observacao = aluno.Observacao;
            alunoModel.PlanoSaude = aluno.PlanoSaude;
            alunoModel.TipoSanguineo = aluno.TipoSanguineo;

            return alunoModel;
        }

    }
}
