using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.Serial
{
    class Comando
    {
        /// <summary>
        /// objeto para controlar a porta serial
        /// </summary>
        private SerialPort comPort = new SerialPort();
        public string Porta = "Com2";
        public int BitRate = 4800;
        public int Bits = 7;
        public Parity Paridade = Parity.Space;
        public StopBits Stop = StopBits.One;
        public int TimeOut = 5000;
        public string NewLine = "\n";

        public string Ler()
        {
            if (SerialPort.GetPortNames().Length > 0)
            {
                string FiString = "";
                comPort.PortName = Porta;
                comPort.BaudRate = BitRate;
                comPort.DataBits = Bits;
                comPort.Parity = Paridade;
                comPort.StopBits = Stop;
                comPort.NewLine = NewLine;
                comPort.ReadTimeout = TimeOut;
                //TODO: try catch do timeout
                try
                {
                    comPort.Open();
                    comPort.DiscardInBuffer();
                    FiString = comPort.ReadLine();
                    comPort.Close();
                }
                catch (TimeoutException)
                {
                    FiString = "";
                    comPort.Close();
                }
                return FiString;
            }
            else
            {
                return "-1";
            }
        }

        /// <summary>
        /// Le varias linhas
        /// </summary>
        /// <param name="linhas">numero de linhas</param>
        /// <param name="todas">retorna todas</param>
        public string Ler(int linhas, bool todas = false)
        {
            if (SerialPort.GetPortNames().Length > 0)
            {
                StringBuilder FiString = new StringBuilder();
                comPort.PortName = Porta;
                comPort.BaudRate = BitRate;
                comPort.DataBits = Bits;
                comPort.Parity = Paridade;
                comPort.StopBits = Stop;
                comPort.NewLine = NewLine;
                comPort.ReadTimeout = TimeOut;
                try
                {
                    comPort.Open();
                    comPort.DiscardInBuffer();
                    for (int i = 1; i <= linhas; i++)
                    {
                        if(todas)
                            FiString.AppendLine(comPort.ReadLine());
                        else
                        {
                            FiString.Clear();
                            FiString.Append(comPort.ReadLine());
                            if (Properties.Settings.Default.Modo_Log)
                                Lib.Log.Log.gravarMenssagemDataHora("Foi lido da balança:" + FiString.ToString());
                        }
                    }
                    comPort.Close();
                }
                catch (TimeoutException)
                {
                    FiString.Append("");
                    comPort.Close();
                }
                return FiString.ToString();
            }
            else
            {
                return "-1";
            }
        }

        public void Escrever(string Texto)
        {
            comPort.PortName = Porta;
            comPort.BaudRate = BitRate;
            comPort.DataBits = Bits;
            comPort.Parity = Paridade;
            comPort.StopBits = Stop;
            comPort.Open();
            comPort.WriteLine(Texto);
            comPort.Close();
        }
    }
}
