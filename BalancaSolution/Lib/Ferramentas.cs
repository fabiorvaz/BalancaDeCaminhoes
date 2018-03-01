using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Lib
{
    static class Ferramentas
    {
        static public void ShowAlertMessageBox(string Texto, string Titulo)
        {
            MessageBox.Show(Texto, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        static public bool TestarPortasSeriais()
        {
            string[] portas = SerialPort.GetPortNames();
            if (portas.Length <= 0)
            {
                ShowAlertMessageBox("NENHUMA PORTA SERIAL DETECTADA.", "Aviso");
                return false;
            }
            if (!portas.Contains(Properties.Settings.Default.Porta_Serial))
            {
                Properties.Settings.Default.Porta_Serial = portas[0];
            }
            return true;
        }
    }
}
