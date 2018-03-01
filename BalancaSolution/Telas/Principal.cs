using BalancaSolution.Lib.Banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Telas
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            if (!Lib.Ferramentas.TestarPortasSeriais())
                this.Close();
        }

        private void Abrir(Form janela)
        {

            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == janela.GetType())
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;
                    frm.Focus();
                    return;
                }
            }

            janela.MdiParent = this;
            janela.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Montar_Conexao_Banco();
            Abrir(new Assistente.Assistente());
            this.WindowState = FormWindowState.Maximized;
        }

        private void Montar_Conexao_Banco()
        {
            Conexao connection = new Conexao();
            connection.connectionStringProducao = "Data Source="+Path.Combine(Application.StartupPath,"balanca.db")+";Version=3;";
            connection.tipoBancoProducao = TipoDeBancos.sqlite;
            Comando.Default.conexao = connection;
            Comando.Default.montarConexaoComBanco(false);
        }

        private void motoristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Veiculos.Motorista());
        }

        private void tipoDeVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Veiculos.Tipo_De_Veiculo());
        }

        private void transportadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Veiculos.Transportadora());
        }

        private void veiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Veiculos.Veiculo());
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Abrir(new Produtos.Produto());
        }

        private void novaPesagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Tickets.Pesagem());
        }

        private void ticketsAbertosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Tickets.ListagemAbertos());
        }

        private void ticketsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Abrir(new Tickets.ListagemTodos());
        }

        private void manutençãoDeTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Tickets.Manutencao());
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Configuracoes.Configuracoes());
        }

        private void listagemDeTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Relatorio.Listagem());
        }

        private void assistenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir(new Assistente.Assistente());
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lib.AtualizaAPP.tentarAtualizarUI();
        }
    }
}
