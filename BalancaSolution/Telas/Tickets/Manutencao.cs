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
    public partial class Manutencao : Form
    {
        Dictionary<int,string> Manuts = new Dictionary<int,string>{
            {1,"Cancelar ticket"}, 
            {2,"Inverter tipo"},
            {3,"Fechar ticket"}
        };

        public Manutencao()
        {
            InitializeComponent();
        }

        private void Manutencao_Load(object sender, EventArgs e)
        {
            Carregar_Cb_Manut();
        }

        private void Carregar_Cb_Manut()
        {
            cb_manut.DataSource = new BindingSource(Manuts, null);
            cb_manut.DisplayMember = "Value";
            cb_manut.ValueMember = "Key";
            cb_manut.SelectedIndex = -1;
        }

        private void cb_manut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_manut.SelectedIndex != -1)
            {
                switch (cb_manut.SelectedValue.ToString())
                { 
                    case "1":
                        Carregar_Cancelar_Ticket();
                        break;
                    case "2":
                        Carregar_Inverter_Tipo();
                        break;
                    case "3":
                        Carregar_Fechar_Ticket();
                        break;
                }
            }
        }

        private void btn_aplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cb_ticket.SelectedIndex != -1) && (cb_manut.SelectedIndex != -1))
                {
                    switch (cb_manut.SelectedValue.ToString())
                    {
                        case "1":
                            Executar_Cancelar_Ticket();
                            break;
                        case "2":
                            Executar_Inverter_Ticket();
                            break;
                        case "3":
                            Executar_Fechar_Ticket();
                            break;
                    }
                }
                else
                {
                    if (cb_manut.SelectedIndex == -1)
                        Lib.Ferramentas.ShowAlertMessageBox("Selecione uma rotina de manutenção.", "Alerta");
                    if (cb_ticket.SelectedIndex == -1)
                        Lib.Ferramentas.ShowAlertMessageBox("Selecione um ticket.", "Alerta");
                }
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void Executar_Cancelar_Ticket()
        {
            if (MessageBox.Show("Tem certeja que deseja CANCELAR o ticket? \nEssa ação não pode ser desfeita.", "Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<Parametros> Valores = new List<Parametros>();
                List<Parametros> Condicoes = new List<Parametros>();
                Valores.Add(new Parametros("Status", "2", TipoDeDadosBD.numerico));
                Condicoes.Add(new Parametros("ID", cb_ticket.SelectedValue.ToString(), TipoDeDadosBD.numerico));
                Comando.Default.executaComando(TipoDeComando.Update, "Ticket", Condicoes, Valores);
                                
                if (Properties.Settings.Default.Modo_Log)
                {
                    Lib.Log.Log.gravarMenssagemDataHora("Ticket " + cb_ticket.SelectedText.ToString() + " foi cancelado.");
                }

                Carregar_Cancelar_Ticket();
                Lib.Ferramentas.ShowAlertMessageBox("O ticket foi cancelado com sucesso.", "Mensagem");
            }
        }

        private void Executar_Inverter_Ticket()
        {
            List<Parametros> Valores = new List<Parametros>();
            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("ID", cb_ticket.SelectedValue.ToString(), TipoDeDadosBD.numerico));
            DataTable dt = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, null);
            string cod ="";
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Tipo"].ToString().ToLower() == "c")
                {
                    Valores.Add(new Parametros("Tipo", "D", TipoDeDadosBD.character));
                    cod = ticket_gera_numeracao("D");
                }
                else if (dt.Rows[0]["Tipo"].ToString().ToLower() == "d")
                {
                    Valores.Add(new Parametros("Tipo", "C", TipoDeDadosBD.character));
                    cod=ticket_gera_numeracao("C");
                }
                Valores.Add(new Parametros("Codigo", cod, TipoDeDadosBD.numerico));
                Valores.Add(new Parametros("Procedencia", dt.Rows[0]["Destino"].ToString(), TipoDeDadosBD.character));
                Valores.Add(new Parametros("Destino", dt.Rows[0]["Procedencia"].ToString(), TipoDeDadosBD.character));
                Valores.Add(new Parametros("Peso_Tara", dt.Rows[0]["Peso_Bruto"].ToString(), TipoDeDadosBD.character));
                Valores.Add(new Parametros("Peso_Bruto", dt.Rows[0]["Peso_Tara"].ToString(), TipoDeDadosBD.character));
                Valores.Add(new Parametros("Data_Bruto", dt.Rows[0]["Data_Tara"].ToString(), TipoDeDadosBD.data));
                Valores.Add(new Parametros("Data_Tara", dt.Rows[0]["Data_Bruto"].ToString(), TipoDeDadosBD.data));
                Comando.Default.executaComando(TipoDeComando.Update, "Ticket", Condicoes, Valores);
                
                if (Properties.Settings.Default.Modo_Log)
                {
                    Lib.Log.Log.gravarMenssagemDataHora("Ticket " + cb_ticket.SelectedText.ToString() + " teve seu tipo invertido.");
                }

                Carregar_Inverter_Tipo();
                Lib.Ferramentas.ShowAlertMessageBox("O ticket teve seu tipo invertido corretamente. \nSeu novo código é: " + cod, "Mensagem");

            }
        }

        private void Carregar_Cancelar_Ticket()
        {
            cb_ticket.DataSource = null;

            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("ID", ""));
            Valores.Add(new Parametros("Codigo", ""));
            Valores.Add(new Parametros("Tipo", ""));

            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("Status", "1", TipoDeDadosBD.numerico));
            Condicoes.Add(new Parametros("Data_Fechamento", DateTime.Now.AddDays(-1).ToString() + "|" + DateTime.Now.AddDays(1).ToString(), TipoDeDadosBD.data, OperadorComparativo.BETWEEN));

            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, Valores);

            Dictionary<string, string> Tickets = new Dictionary<string, string>();

            foreach (DataRow DR in DT.Rows)
            {
                Tickets.Add(DR["ID"].ToString(), DR["Codigo"].ToString() + DR["Tipo"].ToString());
            }

            if (Tickets.Count == 0)
                return;
            cb_ticket.DataSource = new BindingSource(Tickets, null);
            cb_ticket.DisplayMember = "Value";
            cb_ticket.ValueMember = "Key";
        }

        private void Carregar_Inverter_Tipo()
        {
            cb_ticket.DataSource = null;

            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("ID", ""));
            Valores.Add(new Parametros("Codigo", ""));
            Valores.Add(new Parametros("Tipo", ""));

            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("Status", "0", TipoDeDadosBD.numerico, OperadorLogico.OR));
            Condicoes.Add(new Parametros("Status", "3", TipoDeDadosBD.numerico, OperadorLogico.OR));

            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, Valores);

            Dictionary<string, string> Tickets = new Dictionary<string, string>();

            foreach (DataRow DR in DT.Rows)
            {
                Tickets.Add(DR["ID"].ToString(), Montar_Display_Member(DR["Codigo"].ToString(), DR["Tipo"].ToString()));
            }

            if (Tickets.Count == 0)
                return;

            cb_ticket.DataSource = new BindingSource(Tickets, null);
            cb_ticket.DisplayMember = "Value";
            cb_ticket.ValueMember = "Key";
        }

        private void Carregar_Fechar_Ticket()
        {
            cb_ticket.DataSource = null;

            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("ID", ""));
            Valores.Add(new Parametros("Codigo", ""));
            Valores.Add(new Parametros("Tipo", ""));

            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("Status", "0", TipoDeDadosBD.numerico, OperadorLogico.OR));
            Condicoes.Add(new Parametros("Status", "3", TipoDeDadosBD.numerico, OperadorLogico.OR));

            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, Valores);

            Dictionary<string, string> Tickets = new Dictionary<string, string>();

            foreach (DataRow DR in DT.Rows)
            {
                Tickets.Add(DR["ID"].ToString(), Montar_Display_Member(DR["Codigo"].ToString(), DR["Tipo"].ToString()));
            }

            if (Tickets.Count == 0)
                return;

            cb_ticket.DataSource = new BindingSource(Tickets, null);
            cb_ticket.DisplayMember = "Value";
            cb_ticket.ValueMember = "Key";
        }

        private void Executar_Fechar_Ticket()
        {
            if (MessageBox.Show("Tem certeja que deseja FECHAR o ticket? \nEssa ação não pode ser desfeita.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<Parametros> Valores = new List<Parametros>();
                List<Parametros> Condicoes = new List<Parametros>();
                Valores.Add(new Parametros("Status", "1", TipoDeDadosBD.numerico));
                Condicoes.Add(new Parametros("ID", cb_ticket.SelectedValue.ToString(), TipoDeDadosBD.numerico));
                Comando.Default.executaComando(TipoDeComando.Update, "Ticket", Condicoes, Valores);

                if (Properties.Settings.Default.Modo_Log)
                {
                    Lib.Log.Log.gravarMenssagemDataHora("Ticket " + cb_ticket.SelectedText.ToString() + " foi fechado.");
                }

                Carregar_Cancelar_Ticket();
                Lib.Ferramentas.ShowAlertMessageBox("O ticket foi fechado com sucesso.", "Mensagem");
            }
        }

        private string Montar_Display_Member(string a, string b)
        {
            if (b.ToLower() == "c")
                return a + " - Carga";
            else
                return a + " - Descarga";
        }

        private string ticket_gera_numeracao(string tipo)
        {
            if (tipo.ToLower() == "c")
            {
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("Tipo", "C", TipoDeDadosBD.character));
                List<Parametros> Valores = new List<Parametros>();
                Valores.Add(new Parametros("MAX(Codigo) as Codigo", ""));
                DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, Valores);
                if (DT.Rows.Count == 1)
                {
                    if (DT.Rows[0]["Codigo"].ToString() != "")
                        return (Int32.Parse(DT.Rows[0]["Codigo"].ToString()) + 1).ToString();
                    else
                        return "1";
                }
                else
                {
                    return "1";
                }
            }
            if (tipo.ToLower() == "d")
            {
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("Tipo", "D", TipoDeDadosBD.character));
                List<Parametros> Valores = new List<Parametros>();
                Valores.Add(new Parametros("MAX(Codigo) as Codigo", ""));
                DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", Condicoes, Valores);
                if (DT.Rows.Count == 1)
                {
                    if (DT.Rows[0]["Codigo"].ToString() != "")
                        return (Int32.Parse(DT.Rows[0]["Codigo"].ToString()) + 1).ToString();
                    else
                        return "1";
                }
                else
                {
                    return "1";
                }
            }
            return "";
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void Manutencao_KeyDown(object sender, KeyEventArgs e)
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

    }
}
