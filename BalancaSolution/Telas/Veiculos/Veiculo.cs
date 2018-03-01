using BalancaSolution.Lib.Banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Telas.Veiculos
{
    public partial class Veiculo : Form
    {
        bool pesquisa = false;
        string placa_antiga = "";

        public Veiculo()
        {
            InitializeComponent();
        }

        private void Veiculo_Load(object sender, EventArgs e)
        {
            Carregar_Cb_Motorista_Padrao();
            Carregar_Cb_Tipo_De_Veiculo();
            Carregar_Cb_Transportadora();
            Carregar_ListView();
            Limpar_Campos();
        }

        private void Carregar_Cb_Motorista_Padrao()
        {
            cb_motorista_padrao.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("ID", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Nome", "", TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Motorista", null, Valores);
            cb_motorista_padrao.DataSource = DT;
            cb_motorista_padrao.DisplayMember = "Nome";
            cb_motorista_padrao.ValueMember = "ID";
        }

        private void Carregar_Cb_Tipo_De_Veiculo()
        {
            cb_tipo_de_veiculo.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("ID", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Nome", "", TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Tipo_De_Veiculo", null, Valores);
            cb_tipo_de_veiculo.DataSource = DT;
            cb_tipo_de_veiculo.DisplayMember = "Nome";
            cb_tipo_de_veiculo.ValueMember = "ID";
        }

        private void Carregar_Cb_Transportadora()
        {
            cb_transportadora.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("ID", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Nome", "", TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Transportadora", null, Valores);
            cb_transportadora.DataSource = DT;
            cb_transportadora.DisplayMember = "Nome";
            cb_transportadora.ValueMember = "ID";
        }

        private void Carregar_ListView()
        {
            lsv_dados.DataSource = null;
            string comando = @"SELECT v.Placa 'Placa', t.Nome 'Transportadora', tv.Nome 'Tipo'
FROM Veiculo 'v', Transportadora 't', Tipo_De_Veiculo 'tv'
Where v.ID_Tipo=tv.ID
AND v.ID_Transportadora=t.ID";
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Sql, "Transportadora", null, null, comando);
            lsv_dados.DataSource = DT;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar_Registro();
        }

        private void Limpar_Campos()
        {
            txt_placa.Text = "";
            cb_motorista_padrao.SelectedIndex = -1;
            cb_tipo_de_veiculo.SelectedIndex = -1;
            cb_transportadora.SelectedIndex = -1;
            pesquisa = false;
            lsv_dados.SelectedIndex = -1;
            errorProvider1.Clear();
            btn_excluir.Enabled = false;
        }

        private bool Validar_ComboBox(ComboBox cb, ErrorProvider errorProvider)
        {
            if (cb.SelectedIndex != -1)
            {
                errorProvider.SetError(cb, "");
                return true;
            }
            else
            {
                errorProvider.SetError(cb, "Selecione uma opção.");
                return false;
            }
        }

        private bool Validar_Placa(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProvider.SetError(textBox, "Placa invalida.");
                return false;
            }
        }

        private bool Validar_Dados(Button buton, ErrorProvider errorProvider)
        {
            if (pesquisa)
            {
                if (placa_antiga == txt_placa.Text)
                    return true;
            }

            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("Placa", txt_placa.Text, TipoDeDadosBD.character));

            DataTable DT_Valida = Comando.Default.executaComando(TipoDeComando.Select, "Veiculo", Condicoes, null);
            if (DT_Valida.Rows.Count > 0)
            {
                errorProvider.SetError(txt_placa, "Veiculo já cadastrado.");
                return false;
            }

            return true;
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Limpar_Campos();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Limpar_Campos();
        }

        private void lsv_dados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsv_dados.SelectedIndex != -1)
            {
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("Placa", lsv_dados.SelectedItem.GetSubItem(0).Text, TipoDeDadosBD.character));
                DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, "Veiculo", Condicoes, null);
                txt_placa.Text = DT.Rows[0]["Placa"].ToString();
                cb_transportadora.SelectedValue = DT.Rows[0]["ID_Transportadora"].ToString();
                cb_tipo_de_veiculo.SelectedValue = DT.Rows[0]["ID_Tipo"].ToString();
                cb_motorista_padrao.SelectedValue = DT.Rows[0]["ID_Motorista_Padrao"].ToString();
                placa_antiga = txt_placa.Text;
                pesquisa = true;
                btn_excluir.Enabled = true;
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Deletar_Registro();
        }

        private void Veiculo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Sair();
                    break;
                case Keys.Delete:
                    if (lsv_dados.Focused)
                        Deletar_Registro();
                    break;
                case Keys.Enter:
                    Salvar_Registro();
                    break;
            }
        }

        private void Salvar_Registro()
        {
            try
            {
                if (!Validar_Placa(txt_placa, errorProvider1)) return;

                if (!Validar_ComboBox(cb_transportadora, errorProvider1)) return;
                if (!Validar_ComboBox(cb_tipo_de_veiculo, errorProvider1)) return;
                if (!Validar_ComboBox(cb_motorista_padrao, errorProvider1)) return;

                List<Parametros> Valores = new List<Parametros>();
                Valores.Add(new Parametros("Placa", txt_placa.Text, TipoDeDadosBD.character));
                Valores.Add(new Parametros("ID_Tipo", cb_tipo_de_veiculo.SelectedValue.ToString(), TipoDeDadosBD.numerico));
                Valores.Add(new Parametros("ID_Transportadora", cb_transportadora.SelectedValue.ToString(), TipoDeDadosBD.numerico));
                Valores.Add(new Parametros("ID_Motorista_Padrao", cb_motorista_padrao.SelectedValue.ToString(), TipoDeDadosBD.numerico));

                if (pesquisa)
                {
                    if (placa_antiga != txt_placa.Text)
                        if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    List<Parametros> Condicoes = new List<Parametros>();
                    Condicoes.Add(new Parametros("Placa", placa_antiga, TipoDeDadosBD.character));
                    Comando.Default.executaComando(TipoDeComando.Update, "Veiculo", Condicoes, Valores);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Veiculo " + placa_antiga + " foi atualizado.");
                }
                else
                {
                    if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    Comando.Default.executaComando(TipoDeComando.Insert, "Veiculo", null, Valores);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Produto " + txt_placa.Text + " foi criado.");
                }
                Carregar_ListView();
                Limpar_Campos();
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void Deletar_Registro()
        {
            if (pesquisa)
            {
                if (MessageBox.Show("Tem certeja que deseja EXCLUIR o tipo de veiculo " + placa_antiga + "? \nEssa ação não pode ser desfeita.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (placa_antiga != txt_placa.Text)
                        if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    List<Parametros> Condicoes = new List<Parametros>();
                    Condicoes.Add(new Parametros("Placa", placa_antiga, TipoDeDadosBD.character));

                    DataTable DT_Valida = Comando.Default.executaComando(TipoDeComando.Select, "Veiculo", Condicoes, null);

                    if (DT_Valida.Rows.Count > 0)
                    {
                        Condicoes = new List<Parametros>();
                        Condicoes.Add(new Parametros("ID", DT_Valida.Rows[0]["ID"].ToString(), TipoDeDadosBD.numerico));
                        Comando.Default.executaComando(TipoDeComando.Delete, "Veiculo", Condicoes, null);
                        if (Properties.Settings.Default.Modo_Log)
                            Lib.Log.Log.gravarMenssagemDataHora("Tipo de veiculo " + placa_antiga + " foi deletado.");
                        Carregar_ListView();
                        Limpar_Campos();
                    }
                }
            }
        }

        private void Sair()
        {
            if (pesquisa)
            {
                if (MessageBox.Show("Tem certeja que deseja abandonar a edição?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.Close();
            }
            else if ((cb_motorista_padrao.SelectedIndex != -1) || (txt_placa.Text != "") || (cb_transportadora.SelectedIndex != -1) || (cb_tipo_de_veiculo.SelectedIndex != -1))
            {
                if (MessageBox.Show("Tem certeja que deseja abandonar a edição?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }
    }
}
