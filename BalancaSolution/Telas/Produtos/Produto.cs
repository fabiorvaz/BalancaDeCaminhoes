using BalancaSolution.Lib.Banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Telas.Produtos
{
    public partial class Produto : Form
    {
        bool pesquisa = false;
        string tabela = "Produto";
        string nome_antigo = "";

        public Produto()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Limpar_Campos();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Limpar_Campos();
        }

        private void Limpar_Campos()
        {
            txt_produto.Text = "";
            nup_margem.Value = 0;
            rb_porcentagem.Checked = true;
            lsv_dados.SelectedIndex = -1;
            pesquisa = false;
            btn_cancelar.Enabled = false;
            errorProvider1.Clear();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar_Registro();
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
                errorProvider.SetError(textBox, "Produto invalido.");
                return false;
            }
        }

        private bool Validar_Margem()
        {
            if (nup_margem.Value < 0)
            {
                errorProvider1.SetError(nup_margem, "Valor não pode ser inferior a 0.");
                return false;
            }

            if (rb_kilos.Checked)
            {
                if (nup_margem.Value > 500)
                {
                    errorProvider1.SetError(nup_margem, "Valor não pode ultrapassar 500 Kg.");
                    return false;
                }
            }
            if (rb_porcentagem.Checked)
            {
                if (nup_margem.Value > 30)
                {
                    errorProvider1.SetError(nup_margem, "Valor não pode ultrapassar 30%.");
                    return false;
                }
            }
            errorProvider1.SetError(nup_margem, "");
            return true;
        }

        private bool Validar_Dados(Button buton, ErrorProvider errorProvider)
        {
            if(pesquisa)
            {
                if (nome_antigo == txt_produto.Text)
                    return true;
            }

            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("Nome", txt_produto.Text, TipoDeDadosBD.character));

            DataTable DT_Valida = Comando.Default.executaComando(TipoDeComando.Select, tabela, Condicoes, null);
            if (DT_Valida.Rows.Count > 0)
            {
                errorProvider.SetError(txt_produto, "Produto já cadastrado.");
                return false;
            }

            return true;
        }

        private void Carregar_ListView()
        {
            lsv_dados.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("Nome", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Margem", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Tipo_Margem", "", TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, tabela, null, Valores);
            olv_tipo.AspectGetter = delegate(object x)
            {
                DataRowView dr = (DataRowView) x;
                return (string)Simbolizar_Tipo_De_Margem(dr["Tipo_Margem"].ToString());
            };
            lsv_dados.DataSource = DT;
        }

        private void Produto_Load(object sender, EventArgs e)
        {
            Carregar_ListView();
        }

        private string Simbolizar_Tipo_De_Margem(string tipo)
        {
            if (tipo.ToUpper() == "K")
            {
                return "Kg";
            }
            if (tipo.ToUpper() == "P")
            {
                return "%";
            }
            return "";
        }

        private void lsv_dados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsv_dados.SelectedIndex != -1)
            {
                List<Parametros> Condicoes = new List<Parametros>();
                Condicoes.Add(new Parametros("Nome", lsv_dados.SelectedItem.GetSubItem(0).Text, TipoDeDadosBD.character));
                DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, tabela, Condicoes, null);
                txt_produto.Text = DT.Rows[0]["Nome"].ToString();
                nup_margem.Value = decimal.Parse(DT.Rows[0]["Margem"].ToString());
                if (DT.Rows[0]["Tipo_Margem"].ToString() == "P")
                    rb_porcentagem.Checked = true;
                else
                    rb_kilos.Checked = true;
                nome_antigo = txt_produto.Text;
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

        private void Produto_KeyDown(object sender, KeyEventArgs e)
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
                if (!Validar_Nome(txt_produto, errorProvider1)) return;
                if (!Validar_Margem()) return;

                List<Parametros> Valores = new List<Parametros>();
                Valores.Add(new Parametros("Nome", txt_produto.Text, TipoDeDadosBD.character));
                Valores.Add(new Parametros("Margem", nup_margem.Value.ToString(), TipoDeDadosBD.pontoFlutuante));
                if (rb_kilos.Checked)
                    Valores.Add(new Parametros("Tipo_Margem", "K", TipoDeDadosBD.character));
                else if (rb_porcentagem.Checked)
                    Valores.Add(new Parametros("Tipo_Margem", "P", TipoDeDadosBD.character));

                if (pesquisa)
                {
                    if (nome_antigo != txt_produto.Text)
                        if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    List<Parametros> Condicoes = new List<Parametros>();
                    Condicoes.Add(new Parametros("Nome", nome_antigo, TipoDeDadosBD.character));
                    Comando.Default.executaComando(TipoDeComando.Update, tabela, Condicoes, Valores);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Produto " + nome_antigo + " foi atualizado.");
                }
                else
                {
                    if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    Comando.Default.executaComando(TipoDeComando.Insert, tabela, null, Valores);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Produto " + txt_produto.Text + " foi criado.");
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
                if (MessageBox.Show("Tem certeja que deseja EXCLUIR o produto " + nome_antigo + "? \nEssa ação não pode ser desfeita.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nome_antigo != txt_produto.Text)
                        if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    List<Parametros> Condicoes = new List<Parametros>();
                    Condicoes.Add(new Parametros("Nome", nome_antigo, TipoDeDadosBD.character));
                    Comando.Default.executaComando(TipoDeComando.Delete, tabela, Condicoes, null);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Produto " + nome_antigo + " foi deletado.");
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
            else if ((txt_produto.Text != "") || (nup_margem.Value != 0))
            {
                if (MessageBox.Show("Tem certeja que deseja abandonar a edição?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }

    }
}
