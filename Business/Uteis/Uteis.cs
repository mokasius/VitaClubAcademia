using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Uteis
{
    public class Util
    {
        public static bool Between(int valor, int menorNro, int maiorNro)
        {
            var valido = valor >= menorNro && valor <= maiorNro;
            return valido;
        }

    }
}
