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

        public virtual string DiasSemana { get; set; }

        public virtual int? Tipo { get; set; }

        public virtual string Observacao { get; set; }

        public virtual string PlanoSaude { get; set; }

        public virtual string TipoSanguineo { get; set; }
    }
}
