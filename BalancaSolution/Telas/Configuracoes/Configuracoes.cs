using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Telas.Configuracoes
{
    public partial class Configuracoes : Form
    {
        public Configuracoes()
        {
            InitializeComponent();
        }

        private void Configuracoes_Load(object sender, EventArgs e)
        {
            Carregar_Aba_Balanca();
            Carregar_Aba_Log();
            Carregar_Aba_Comunicacao();
        }

        private void Carregar_Aba_Balanca()
        {
            balanca_txt_atual.Text = Properties.Settings.Default.Balanca.Replace("/", " ");
            balanca_lsb_marca.Items.Add("Toledo");
        }

        private void Carregar_Aba_Log()
        {
            log_chk_ativar.Checked = Properties.Settings.Default.Modo_Log;
        }

        private void Carregar_Aba_Comunicacao()
        {
            comunicacao_cb_porta_serial.DataSource = SerialPort.GetPortNames();
            for (int i = 0; i < comunicacao_cb_porta_serial.Items.Count; i++)
            {
                if (comunicacao_cb_porta_serial.Items[i].ToString().ToLower().Equals(Properties.Settings.Default.Porta_Serial.ToLower()))
                {
                    comunicacao_cb_porta_serial.SelectedIndex = i;
                    break;
                }
            }
        }

        private void balanca_lsb_marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            balanca_lsb_modelo.Items.Clear();
            if (balanca_lsb_marca.SelectedIndex != -1)
            {
                switch (balanca_lsb_marca.Text)
                {
                    case "Toledo":
                        balanca_lsb_modelo.Items.Add("810");
                        break;
                    default:
                        break;
                }
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar_Campos()) return;
                Properties.Settings.Default.Balanca = balanca_txt_atual.Text.Replace(" ", "/");
                Properties.Settings.Default.Modo_Log = log_chk_ativar.Checked;
                Properties.Settings.Default.Porta_Serial = comunicacao_cb_porta_serial.SelectedItem.ToString();
                Properties.Settings.Default.BalancaFake = comunicacao_chk_balanca_fake.Checked;
                Properties.Settings.Default.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private void balanca_btn_usar_selecionada_Click(object sender, EventArgs e)
        {
            try
            {
                if ((balanca_lsb_marca.SelectedIndex == -1) || (balanca_lsb_modelo.SelectedIndex==-1))
                {
                    Lib.Ferramentas.ShowAlertMessageBox("Favor selecionar uma balança.", "Aviso de erro");
                    return;
                }
                balanca_txt_atual.Text = balanca_lsb_marca.SelectedItem + " " + balanca_lsb_modelo.SelectedItem;
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta");
            }
        }

        private void balanca_lsb_marca_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            balanca_lsb_modelo.Items.Clear();
            if (balanca_lsb_marca.SelectedIndex != -1)
            {
                switch (balanca_lsb_marca.Text)
                {
                    case "Toledo":
                        balanca_lsb_modelo.Items.Add("810");
                        break;
                    default:
                        break;
                }
            }
        }

        private void log_btn_ver_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Lib.Log.Log.PASTA))
                    Directory.CreateDirectory(Lib.Log.Log.PASTA);
                Process.Start(Lib.Log.Log.PASTA);
            }
            catch (Exception ex)
            {
                Lib.Ferramentas.ShowAlertMessageBox(ex.Message, "Alerta de erro");
            }
        }

        private bool Validar_Campos()
        {
            if (string.IsNullOrEmpty(balanca_txt_atual.Text))
            {
                return false;
            }
            if (comunicacao_cb_porta_serial.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
