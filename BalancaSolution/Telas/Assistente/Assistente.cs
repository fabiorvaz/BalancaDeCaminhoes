using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Telas.Assistente
{
    public partial class Assistente : Form
    {
        public Assistente()
        {
            InitializeComponent();
        }

        private void btn_nova_pesagem_Click(object sender, EventArgs e)
        {
            Abrir(new Tickets.Pesagem());
        }

        private void Abrir(Form janela)
        {

            foreach (Form frm in this.MdiParent.MdiChildren)
            {
                if (frm.GetType() == janela.GetType())
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;
                    frm.Focus();
                    return;
                }
            }

            janela.MdiParent = this.MdiParent;
            janela.Show();
        }

        private void btn_aberto_Click(object sender, EventArgs e)
        {
            Abrir(new Tickets.ListagemAbertos());
        }

        private void btn_manutencao_ticket_Click(object sender, EventArgs e)
        {
            Abrir(new Tickets.Manutencao());
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.MdiParent.Close();
        }
    }
}
