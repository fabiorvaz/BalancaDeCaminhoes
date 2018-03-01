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
    public partial class Motorista : Form
    {
        bool pesquisa = false;
        string nome_antigo = "";
        string cpf_antigo = "";
        string tabela = "Motorista";

        public Motorista()
        {
            InitializeComponent();
        }

        private void Motorista_Load(object sender, EventArgs e)
        {
            Carregar_ListView();
        }

        private void Carregar_ListView()
        {
            lsv_dados.DataSource = null;
            List<Parametros> Valores = new List<Parametros>();
            Valores.Add(new Parametros("CPF", "", TipoDeDadosBD.character));
            Valores.Add(new Parametros("Nome", "", TipoDeDadosBD.character));
            DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, tabela,null,Valores);
            lsv_dados.DataSource = DT;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar_Registro();
        }

        private void Limpar_Campos()
        {
            txt_cpf.Text = "";
            txt_nome.Text = "";
            nome_antigo = "";
            cpf_antigo = "";
            errorProvider1.Clear();
            lsv_dados.SelectedIndex = -1;
            pesquisa = false;
            btn_excluir.Enabled = false;
        }

        private bool Validar_CPF(TextBox textBox, ErrorProvider errorProvider)
        {
            if (chk_cpf.Checked)
                return true;
            if(!string.IsNullOrWhiteSpace(textBox.Text))
            {
                long temp;
                if (long.TryParse(textBox.Text, out temp))
                {
                    if (IsCpf(textBox.Text))
                    {
                        errorProvider.SetError(textBox, "");
                        return true;
                    }
                    else
                    {
                        errorProvider.SetError(textBox, "CPF invalido, favor digitar somente números.");
                        return false;
                    }
                }
                else
                {
                    errorProvider.SetError(textBox, "CPF invalido, favor digitar somente números.");
                    return false;
                }
            }
            else
            {
                errorProvider.SetError(textBox, "CPF invalido");
                return false;
            }
        }

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
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
                errorProvider.SetError(textBox, "Nome invalido");
                return false;
            }
        }

        private bool Validar_Dados(Button buton, ErrorProvider errorProvider)
        {
            if (chk_cpf.Checked)
                return true;
            if (pesquisa)
            {
                if (txt_cpf.Text == cpf_antigo)
                    return true;
            }
            List<Parametros> Condicoes = new List<Parametros>();
            Condicoes.Add(new Parametros("CPF", txt_cpf.Text, TipoDeDadosBD.character));

            DataTable DT_Valida = Comando.Default.executaComando(TipoDeComando.Select, tabela, Condicoes, null);
            if (DT_Valida.Rows.Count > 0)
            {
                errorProvider.SetError(buton, "CPF já cadastrado.");
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
                if (!string.IsNullOrWhiteSpace(lsv_dados.SelectedItem.GetSubItem(0).Text))
                {
                   Condicoes.Add(new Parametros("CPF", lsv_dados.SelectedItem.GetSubItem(0).Text, TipoDeDadosBD.character));
                   chk_cpf.Checked = false;
                }
                else
                    chk_cpf.Checked = true;
                Condicoes.Add(new Parametros("Nome", lsv_dados.SelectedItem.GetSubItem(1).Text, TipoDeDadosBD.character));
                DataTable DT = Comando.Default.executaComando(TipoDeComando.Select, tabela, Condicoes, null);
                txt_cpf.Text = DT.Rows[0]["CPF"].ToString();
                txt_nome.Text = DT.Rows[0]["Nome"].ToString();
                nome_antigo = txt_nome.Text;
                cpf_antigo = txt_cpf.Text;
                btn_excluir.Enabled = true;
                pesquisa = true;
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Limpar_Campos();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void chk_cpf_CheckedChanged(object sender, EventArgs e)
        {
            txt_cpf.Enabled = !chk_cpf.Checked;
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Deletar_Registro();
        }

        private void Motorista_KeyDown(object sender, KeyEventArgs e)
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
                if (!Validar_CPF(txt_cpf, errorProvider1)) return;
                if (!Validar_Nome(txt_nome, errorProvider1)) return;

                List<Parametros> Valores = new List<Parametros>();
                List<Parametros> Condicoes = new List<Parametros>();

                if (!chk_cpf.Checked)
                    Valores.Add(new Parametros("CPF", txt_cpf.Text, TipoDeDadosBD.numericoLongo));
                Valores.Add(new Parametros("Nome", txt_nome.Text, TipoDeDadosBD.character));

                if (pesquisa)
                {
                    if (txt_cpf.Text != nome_antigo)
                        if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    Condicoes.Add(new Parametros("Nome", nome_antigo, TipoDeDadosBD.character));
                    Comando.Default.executaComando(TipoDeComando.Update, tabela, Condicoes, Valores);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Motorista " + nome_antigo + " foi atualizado.");
                }
                else
                {
                    if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    Comando.Default.executaComando(TipoDeComando.Insert, tabela, null, Valores);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Motorista " + txt_nome.Text + " foi criado.");
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
                if (MessageBox.Show("Tem certeja que deseja EXCLUIR o motorista " + nome_antigo + "? \nEssa ação não pode ser desfeita.", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nome_antigo != txt_cpf.Text)
                        if (!Validar_Dados(btn_salvar, errorProvider1)) return;
                    List<Parametros> Condicoes = new List<Parametros>();
                    Condicoes.Add(new Parametros("Nome", nome_antigo, TipoDeDadosBD.character));
                    Comando.Default.executaComando(TipoDeComando.Delete, tabela, Condicoes, null);
                    if (Properties.Settings.Default.Modo_Log)
                        Lib.Log.Log.gravarMenssagemDataHora("Mototrista " + nome_antigo + " foi deletado.");
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
            else if ((txt_nome.Text != "") || (txt_cpf.Text != ""))
            {
                if (MessageBox.Show("Tem certeja que deseja abandonar a edição?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }
    }
}
