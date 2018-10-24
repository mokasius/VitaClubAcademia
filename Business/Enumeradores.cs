using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Business
{
    [DataContract]
    public enum enumDiaSemana
    {
        [EnumMember]
        Domingo = 1,
        [EnumMember]
        Segunda = 2,
        [EnumMember]
        Terca = 3,
        [EnumMember]
        Quarta = 4,
        [EnumMember]
        Quinta = 5,
        [EnumMember]
        Sexta = 6,
        [EnumMember]
        Sabado = 7
    }

    [DataContract]
    public enum enumExcluido
    {
        [EnumMember]
        Nao = 0,
        [EnumMember]
        Sim = 1
    }

    [DataContract]
    public enum enumTipoAluno
    {
        [EnumMember]
        Academia = 0,
        [EnumMember]
        Hidro = 1,
        [EnumMember]
        Ambos = 2
    }

    [DataContract]
    public enum enumStatusAluno
    {
        [EnumMember]
        Ativo = 0,
        [EnumMember]
        Inativo = 1
    }

    [DataContract]
    public enum enumStatusTreino
    {
        [EnumMember]
        Inativo = 1,
        [EnumMember]
        Ativo = 0
    }

    public static partial class EnumsExtentions
    {
        public static string Descricao(this enumDiaSemana value)
        {
            switch (value)
            {
                case enumDiaSemana.Domingo:
                    return "Domingo";
                case enumDiaSemana.Segunda:
                    return "Segunda-feira";
                case enumDiaSemana.Terca:
                    return "Terça-feira";
                case enumDiaSemana.Quarta:
                    return "Quarta-feira";
                case enumDiaSemana.Quinta:
                    return "Quinta-feira";
                case enumDiaSemana.Sexta:
                    return "Sexta-feira";
                case enumDiaSemana.Sabado:
                    return "Sábado";
                default: return string.Empty;
            }
        }
    }
}