using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.BalancasDummy.Toledo
{
    static class _810
    {
        static public string lerPesagem()
        {
            string retorno = "";
            retorno += new Random().Next(9999);
            retorno += ",";
            retorno += new Random().Next(99);
            return retorno;
        }

        static public string lerPesagemFixa()
        {
            string retorno = "?????900????";
            return retorno;
        }
    }
}
