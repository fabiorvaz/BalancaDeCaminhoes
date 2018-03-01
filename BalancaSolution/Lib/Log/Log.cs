using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.Log
{
    static class Log
    {
        static public string PASTA = Path.Combine(Environment.GetEnvironmentVariable("temp"),"Balanca");
        static private string ARQUIVO = "Balanca-"+DateTime.Now.ToString("yyyy-MM-dd")+".log";
        static private bool Existe = false;

        /// <summary>
        /// tenta criar um ARQUIVO de log
        /// </summary>
        static public void criarLog()
        {
            if ((!PASTA.Equals("")) && (!ARQUIVO.Equals("")))
            {
                if (!Directory.Exists(PASTA))
                    Directory.CreateDirectory(PASTA);
                if (!File.Exists(Path.Combine(PASTA + ARQUIVO)))
                {
                    FileStream f = File.Create(Path.Combine(PASTA,ARQUIVO));
                    f.Close();
                }
                Existe = true;
            }
        }

        /// <summary>
        /// grava uma mensagem normal no log
        /// </summary>
        /// <param name="mensagem">menssagem a ser gravada</param>
        static public void gravarMenssagem(string mensagem)
        {
            if (!Existe)
                criarLog();
            using (StreamWriter file = new StreamWriter(Path.Combine(PASTA, ARQUIVO), true))
            {
                file.WriteLine(mensagem);
            }
        }

        /// <summary>
        /// grava uma mensagem no log colocando data e hora no formato brasileiro antes da mensagem
        /// </summary>
        /// <param name="mensagem">menssagem a ser gravada</param>
        static public void gravarMenssagemDataHora(string mensagem)
        {
            string msg = "";
            if (!Existe)
                criarLog();
            msg = msg + DateTime.Now.Day.ToString("d2") + "/" + DateTime.Now.Month.ToString("d2") + "/" + DateTime.Now.Year.ToString("d4") + " ";
            msg = msg + DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":" + DateTime.Now.Second.ToString("d2") + " ";
            msg = msg + mensagem;
            using (StreamWriter file = new StreamWriter(Path.Combine(PASTA, ARQUIVO), true))
            {
                file.WriteLine(msg);
            }
        }
    }
}
