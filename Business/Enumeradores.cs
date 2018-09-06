using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    //public static class EnumExtensions
    //{
    //    public static string GetDescription(this T enumerationValue) where T : struct
    //    {
    //        var type = enumerationValue.GetType();
    //        if (!type.IsEnum)
    //        {
    //            throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
    //        }
    //        var memberInfo = type.GetMember(enumerationValue.ToString());
    //        if (memberInfo.Length > 0)
    //        {
    //            var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

    //            if (attrs.Length > 0)
    //            {
    //                return ((DescriptionAttribute)attrs[0]).Description;
    //            }
    //        }
    //        return enumerationValue.ToString();
    //    }
    //}

    public class Enumeradores
    {
        public enum DiaSemana
        {
            [Description("Domingo")]
            Domingo = 1,
            [Description("Segunda-feira")]
            Segunda = 2,
            [Description("Terça-feira")]
            Terca = 3,
            [Description("Quarta-feira")]
            Quarta = 4,
            [Description("Quinta-feira")]
            Quinta = 5,
            [Description("Sexta-feira")]
            Sexta = 6,
            [Description("Sábado")]
            Sabado = 7
        }
    }
}
