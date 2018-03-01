using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Telas.Relatorio
{
    public partial class Visualizar : Form
    {
        public Lib.Relatorio.Relatorio rel;
        
        public Visualizar()
        {
            InitializeComponent();
        }

        private void Carregar_Relatorio()
        {
            wb_relatorio.Navigate(" ");

            if (wb_relatorio.Document != null)
            {

                wb_relatorio.Document.Write(rel.Html);

            }

            wb_relatorio.DocumentText = rel.Html;
        }

        private void Visualizar_Shown(object sender, EventArgs e)
        {
            Carregar_Relatorio();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (wb_relatorio.Document != null)
                {
                    if (wb_relatorio.DocumentText != "")
                    {
                        wb_relatorio.ShowPrintDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void Visualizar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Sair();
                    break;
            }
        }

        private void Sair()
        {
            this.Close();
        }

        private void btn_fechar_form_Click(object sender, EventArgs e)
        {
            Sair();
        }
        
    }
}
