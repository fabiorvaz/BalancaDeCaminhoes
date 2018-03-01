using BalancaSolution.Lib.Banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Telas.Tickets
{
    public partial class ListagemAbertos : Form
    {
        public ListagemAbertos()
        {
            InitializeComponent();
            CarregarListView();
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

        private void BtnNovaPesagem_Click(object sender, EventArgs e)
        {
            Abrir(new Pesagem());
        }

        private void BtnPesagem_Click(object sender, EventArgs e)
        {
            try
            {
                ConcluirPesagem();
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void ConcluirPesagem()
        {
            if (dlvDados.SelectedItems.Count != 1)
            {
                Lib.Ferramentas.ShowAlertMessageBox("Selecione o ticket.", "Alerta");
                return;
            }
            Pesagem janela = new Pesagem();
            janela.fechar = true;

            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("Codigo", dlvDados.SelectedItems[0].SubItems[0].Text, OperadorLogico.AND));
            Condicoes.Add(new Parametros("Tipo", dlvDados.SelectedItems[0].SubItems[2].Text, OperadorLogico.AND));
            DataTable DT_Ticket = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, null);

            janela.ID_Ticket = Int32.Parse(DT_Ticket.Rows[0]["ID"].ToString());

            Abrir(janela);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DeletarRegistro();
        }

        private void CarregarListView()
        {
            dlvDados.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("Codigo", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Tipo", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Data", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Veiculo_Placa", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Status", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Veiculo_Transportadora", "", TipoDeDadosBD.character));
            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("Status", "0", TipoDeDadosBD.numerico,OperadorLogico.OR));
            Condicoes.Add(new Parametros("Status", "3", TipoDeDadosBD.numerico, OperadorLogico.OR));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, Valores);

            dlv_c_status.AspectToStringConverter = delegate(object x)
            {
                switch (x.ToString())
                {
                    case "0":
                        return "Aberto";
                    case "1":
                        return "Fechado";
                    case "2":
                        return "Cancelado";
                    case "3":
                        return "Criado";
                    default:
                        return "Erro";
                }
            };
            
            dlvDados.DataSource = DT;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarListView();
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void DlvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ConcluirPesagem();
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void ListagemAbertos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Sair();
                    break;
                case Keys.Delete:
                    if (dlvDados.Focused)
                        DeletarRegistro();
                    break;
                case Keys.F5:
                    CarregarListView();
                    break;
            }
        }

        private void DeletarRegistro()
        {
            try
            {
                if (dlvDados.SelectedItems.Count == 1)
                {
                    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Tem certeza que deseja excluir o registro selecionado?", "Confirmação de exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        List<Parametros> Condicoes = new List<Parametros>();
                        Condicoes.Add(new Parametros("Codigo", dlvDados.SelectedItems[0].SubItems[0].Text, TipoDeDadosBD.numerico));
                        Condicoes.Add(new Parametros("Tipo", dlvDados.SelectedItems[0].SubItems[2].Text, TipoDeDadosBD.character));
                        Comando.Default.executaComando(TipoDeComando.Delete, "Ticket", Condicoes, null);
                        CarregarListView();
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void Sair()
        {
            this.Close();
        }

        private void BtnFecharForm_Click(object sender, EventArgs e)
        {
            Sair();
        }


    }
}
