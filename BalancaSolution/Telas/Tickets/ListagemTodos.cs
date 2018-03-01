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
    public partial class ListagemTodos : Form
    {
        public ListagemTodos()
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

        private void CarregarListView()
        {
            dlvDados.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("Codigo", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Tipo", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Data", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Veiculo_Placa", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Status", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Observacao", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Veiculo_Transportadora", "", TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", null, Valores);

            DlvCStatus.AspectToStringConverter = delegate(object x)
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

        private void TsbBtnRefresh_Click(object sender, EventArgs e)
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

        private void TsbImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlvDados.SelectedItems.Count != 1)
                {
                    Lib.Ferramentas.ShowAlertMessageBox("Selecione o ticket.", "Alerta");
                    return;
                }
                Lib.Relatorio.Ticket rel = new Lib.Relatorio.Ticket();
                rel.Codigo = Int32.Parse(dlvDados.SelectedItems[0].SubItems[0].Text);
                rel.Tipo = dlvDados.SelectedItems[0].SubItems[2].Text;
                rel.ImprimirRelatorio();
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void BtnVisualizarImpressao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlvDados.SelectedItems.Count != 1)
                {
                    Lib.Ferramentas.ShowAlertMessageBox("Selecione o ticket.", "Alerta");
                    return;
                }
                Lib.Relatorio.Ticket rel = new Lib.Relatorio.Ticket();
                rel.Codigo = Int32.Parse(dlvDados.SelectedItems[0].SubItems[0].Text);
                rel.Tipo = dlvDados.SelectedItems[0].SubItems[2].Text;
                rel.MontarRelatorio();
                Telas.Relatorio.Visualizar janela = new Relatorio.Visualizar();

                janela.rel = rel;

                janela.MdiParent = this.MdiParent;
                janela.Show();
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void ListagemTodos_Load(object sender, EventArgs e)
        {

        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void ListagemTodos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Sair();
                    break;
                case Keys.F5:
                    CarregarListView();
                    break;
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

        private void DlvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisualizarTicket();
        }

        private void btnVisualizarTicket_Click(object sender, EventArgs e)
        {
            VisualizarTicket();
        }

        private void VisualizarTicket()
        {
            try
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
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }
    }
}
