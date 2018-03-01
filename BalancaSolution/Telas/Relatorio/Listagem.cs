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
    public partial class Listagem : Form
    {
        public Listagem()
        {
            InitializeComponent();
        }

        private void btn_gerar_Click(object sender, EventArgs e)
        {
            Gerar();
        }

        private Lib.Relatorio.Listagem Gerar_Relatorio(Lib.Relatorio.Listagem rel)
        {
            DateTime ini, fim;
            
            if (!Validar_Campos())
                return null;
            rel.Codigo = txt_codigo.Text;
            rel.Destino = txt_destino.Text;
            rel.Procedencia = txt_procedencia.Text;
            rel.Produto = txt_produto.Text;
            rel.Placa = txt_placa.Text;

            if ((txt_data_ini.Text != "  /  /") && (txt_data_fim.Text != "  /  /"))
            {
                ini = DateTime.Parse(txt_data_ini.Text);
                fim = DateTime.Parse(txt_data_fim.Text);
                rel.DataTicketIni = ini;
                rel.DataTicketFim = fim;
            }

            if ((txt_data_bruto_ini.Text != "  /  /") && (txt_data_bruto_fim.Text != "  /  /"))
            {
                ini = DateTime.Parse(txt_data_bruto_ini.Text);
                fim = DateTime.Parse(txt_data_bruto_fim.Text);
                rel.DataBrutoIni = ini;
                rel.DataBrutoFim = fim;
            }

            if ((txt_data_tara_ini.Text != "  /  /") && (txt_data_tara_fim.Text != "  /  /"))
            {
                ini = DateTime.Parse(txt_data_tara_ini.Text);
                fim = DateTime.Parse(txt_data_tara_fim.Text);
                rel.DataTaraIni = ini;
                rel.DataTaraFim = fim;
            }

            if(!rb_tipo_todos.Checked)
            {
                if (rb_tipo_descarga.Checked)
                    rel.Tipo = "D";
                if (rb_tipo_carga.Checked)
                    rel.Tipo = "C";
            }

            rel.MontarRelatorio();
            return rel;
        }

        private bool Validar_Campos()
        {
            #region Codigo

            if (!string.IsNullOrEmpty(txt_codigo.Text))
            {
                if (txt_codigo.Text.Contains(","))
                {
                    foreach (string temp in txt_codigo.Text.Split(','))
                    {
                        int teste = 0;
                        if (!int.TryParse(txt_codigo.Text, out teste))
                        {
                            Lib.Ferramentas.ShowAlertMessageBox("Código está em um formato invalido", "Alerta");
                            return false;
                        }
                    }
                }
                else
                {
                    int teste = 0;
                    if (!int.TryParse(txt_codigo.Text, out teste))
                    {
                        Lib.Ferramentas.ShowAlertMessageBox("Código está em um formato invalido", "Alerta");
                        return false;
                    }
                }
            }

            #endregion

            return true;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Lib.Relatorio.Listagem rel = Gerar_Relatorio(new Lib.Relatorio.Listagem());
                if (rel == null)
                    return;
                rel.ImprimirRelatorio();
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

        private void Listagem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Sair();
                    break;
                case Keys.Enter:
                    Gerar();
                    break;
            }
        }

        private void Gerar()
        {
            try
            {
                Lib.Relatorio.Listagem rel = Gerar_Relatorio(new Lib.Relatorio.Listagem());
                if (rel == null)
                    return;

                Telas.Relatorio.Visualizar janela = new Relatorio.Visualizar();

                janela.rel = rel;
                janela.Show();
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
    }
}
