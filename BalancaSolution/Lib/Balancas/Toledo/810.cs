using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BalancaSolution.Lib.Balancas.Toledo
{
    class _810
    {
        static private int BitRate = 4800;
        static private int Bits = 7;
        static private Parity Paridade = Parity.Space;
        static private StopBits Stop = StopBits.One;
        static Lib.Serial.Comando portaSerial = new Lib.Serial.Comando();

        static public decimal lerPesagemTeste()
        {
            string dados = Lib.BalancasDummy.Toledo._810.lerPesagem();
            
            Regex reg = new Regex("[0-9]+");
            MatchCollection matches = reg.Matches(dados);
            if (matches.Count <= 0)
                return -1;
            else
            {
                return decimal.Parse(matches[0].Value);
            }    
        }

        static public decimal lerPesagem()
        {
            portaSerial.BitRate = BitRate;
            portaSerial.Bits = Bits;
            portaSerial.Paridade = Paridade;
            portaSerial.Stop = Stop;
            portaSerial.Porta = Properties.Settings.Default.Porta_Serial;

            string dados = portaSerial.Ler(2);
            if (dados == "-1")
                return -1;

            Regex reg = new Regex("[0-9]+");
            MatchCollection matches = reg.Matches(dados);
            if (matches.Count <= 0)
                return -1;
            else
            {
                return decimal.Parse(matches[0].Value);
            }    

        }
    }
}
