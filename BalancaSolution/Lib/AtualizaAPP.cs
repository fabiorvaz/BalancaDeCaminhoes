using Olvebra.AtualizadorVersao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Lib
{
    class AtualizaAPP
    {
        public const string APP_SETUP = "BalancaSolutionSetup.xml";

        static public bool tentarAtualizarBackground()
        {
            OpcaoAtualizacao o = new OpcaoAtualizacao();
            o.ArquivoVersaoBase = APP_SETUP;
            o.UI = false;
            o.ComandoPosAtualizacao = "";

            try
            {
                InformacaoVersao nova = Atualizador.AtualizacaoDisponivel(APP_SETUP);
                if (nova == null) return false;
                Atualizador.AtualizarVersaoAsync(o);
                return true;
            }

            catch (Exception)
            {
            }
            return false;
        }

        static public bool tentarAtualizarUI()
        {
            OpcaoAtualizacao o = new OpcaoAtualizacao();
            o.ArquivoVersaoBase = APP_SETUP;
            o.UI = true;
            o.ComandoPosAtualizacao = "'" + Application.ExecutablePath + "'";

            try
            {
                InformacaoVersao nova = Atualizador.AtualizacaoDisponivel(APP_SETUP);
                if (nova == null)
                {
                    MessageBox.Show("Nenhuma atualização nova disponível.", "Sistema");
                    return false;
                }
                else
                {
                    if (MessageBox.Show("Nova versão " + nova.Versao.ToString() +
                        " encontrada. Deseja atualizar?", "Nova versão encontrada", MessageBoxButtons.YesNo) == DialogResult.No)
                        return false;
                }
                Application.Exit();
                Atualizador.AtualizarVersaoAsync(o);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            return false;
        }
    }
}
