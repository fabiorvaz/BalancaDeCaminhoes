//#define Teste

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.Balancas
{
    static class Comando
    {
        static public decimal lerPesagem()
        {
#if Teste
            return Pesar_Teste();
#endif

            string[] balancaSelecionada = Properties.Settings.Default.Balanca.Split('/');
            string marca = balancaSelecionada[0];
            string modelo = balancaSelecionada[1];

            switch (marca)
            {
                case ("Toledo"):
                    switch (modelo)
                    {
                        case ("810"):
                            {
                                if(Properties.Settings.Default.BalancaFake)
                                    return Toledo._810.lerPesagemTeste();
                                else
                                    return Toledo._810.lerPesagem();
                            }
                    }
                    break;
            }


            return -1;
        }

        static private decimal pesarTeste()
        {
            return Toledo._810.lerPesagemTeste();
        }
    }
}
