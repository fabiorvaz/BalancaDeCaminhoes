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
    public partial class Tipo_De_Veiculo : Form
    {
        bool pesquisa = false;
        string tabela = "Tipo_de_veiculo";
        string nome_antigo = "";

        public Tipo_De_Veiculo()
        {
            InitializeComponent();
        }


        private void Carregar_ListView()
        {
            lsv_dados.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("ID", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Nome", "", TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, tabela, null, Valores);
            lsv_dados.DataSource = DT;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar_Registro();
        }

        private void Limpar_Campos()
        {
            txt_codigo.Text = "";
            txt_nome.Text = "";
            errorProvider1.Clear();
            lsv_dados.SelectedIndex = -1;
            pesquisa = false;
            btn_excluir.Enabled = false;
        }
        
        private bool Validar_Nome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProvider.SetError(textBox, "Nome invalido.");
                return false;
            }
        }

        private bool Validar_Dados(Button buton, ErrorProvider errorProvider)
        {
            if (pesquisa)
            {
                if (nome_antigo == txt_nome.Text)
                    return true;
            }

            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("Nome", txt_nome.Text, TipoDeDadosBD.character));

            DataTable DT_Valida = Comando.Default.executaComando(TipoDeComando.Select, tabela, Condicoes, null);
            if (DT_Valida.Rows.Count > 0)
            {
                errorProvider.SetError(txt_nome, "Tipo já cadastrado.");
                return false;
            }

            return true;
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
                Condicoes.Add(new Parametros("ID", lsv_dados.SelectedItem.GetSubItem(0).Text, TipoDeDadosBD.character));
                DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, tabela, Condicoes, null);
                txt_codigo.Text = DT.Rows[0]["ID"].ToString();
                txt_nome.Text = DT.Rows[0]["Nome"].ToString();
                nome_antigo = txt_nome.Text;
                pesquisa = true;
                btn_excluir.Enabled = true;
            }
        }

        private void Tipo_De_Veiculo_Load(object sender, EventArgs e)
        {
            Carregar_ListView();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Limpar_Campos();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Deletar_Registro();
        }

        private void Tipo_De_Veiculo_KeyDown(object sender, KeyEventArgs e)
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
                if (!Validar_Nome(txt_nome, errorProvider1)) return;

                List<Parametros> Valores = new List<Parametros>();
                Valores.Add(new Parametros("Nome", txt_nome.Text, TipoDeDadosBD.character));

                if (pesquisa)
                {
                    if (txt_codigo.Text == nome_antigo)
                    {
                        Carregar_ListView();
                        Limpar_Campos();
                    }
                    if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    List<Parametros> Condicoes = new List<Parametros>();
                    Condicoes.Add(new Parametros("ID", txt_codigo.Text, TipoDeDadosBD.character));
                    Comando.Default.executaComando(TipoDeComando.Update, tabela, Condicoes, Valores);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Tipo de veiculo " + nome_antigo + " foi atualizado.");
                }
                else
                {
                    if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    Comando.Default.executaComando(TipoDeComando.Insert, tabela, null, Valores);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Produto " + txt_codigo.Text + " foi criado.");
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
                if (MessageBox.Show("Tem certeja que deseja EXCLUIR o tipo de veiculo " + nome_antigo + "? \nEssa ação não pode ser desfeita.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nome_antigo != txt_nome.Text)
                        if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    List<Parametros> Condicoes = new List<Parametros>();
                    Condicoes.Add(new Parametros("Nome", nome_antigo, TipoDeDadosBD.character));
                    Comando.Default.executaComando(TipoDeComando.Delete, tabela, Condicoes, null);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Tipo de veiculo " + nome_antigo + " foi deletado.");
                    Carregar_ListView();
                    Limpar_Campos();
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
            else if ((txt_nome.Text != "") || (txt_codigo.Text != ""))
            {
                if (MessageBox.Show("Tem certeja que deseja abandonar a edição?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }
    }
}
