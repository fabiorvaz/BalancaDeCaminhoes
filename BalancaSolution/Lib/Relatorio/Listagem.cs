using BalancaSolution.Lib.Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Lib.Relatorio
{
    class Listagem : Relatorio, IRelatorio
    {
        private float altura_linha = 4.5f;
        private float largura_coluna = 28;
        private float altura_folha = 160;
        private float largura_folha = 270;

        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public string Produto { get; set; }
        public string Procedencia { get; set; }
        public string Destino { get; set; }
        public string Placa { get; set; }
        public DateTime DataBrutoIni { get; set; }
        public DateTime DataBrutoFim { get; set; }
        public DateTime DataTaraIni { get; set; }
        public DateTime DataTaraFim { get; set; }
        public DateTime DataTicketIni { get; set; }
        public DateTime DataTicketFim { get; set; }


        public Listagem()
        {
            Codigo = "";
            Tipo = "";
            Produto = "";
            Procedencia = "";
            Destino = "";
            Placa = "";
            DateTime ini = DateTime.Now.AddYears(-1000);
            DataBrutoIni = ini;
            DataBrutoFim = ini;
            DataTaraIni = ini;
            DataTaraFim = ini;
            DataTicketIni = ini;
            DataTicketFim = ini;
        }

        public string VisualizarRelatorio()
        {
            return Html;
        }

        public void PrepararDados()
        {
            List<Parametros> condicoes = new List<Parametros>();

            if (!string.IsNullOrEmpty(Codigo))
            {
                if (Codigo.Contains(","))
                    condicoes.Add(new Parametros("Codigo", Codigo, TipoDeDadosBD.numerico, OperadorComparativo.IN));
                else
                    condicoes.Add(new Parametros("Codigo", Codigo, TipoDeDadosBD.numerico, OperadorComparativo.EQUALS));
            }

            if (!string.IsNullOrEmpty(Tipo))
                condicoes.Add(new Parametros("Tipo", Tipo, TipoDeDadosBD.character, OperadorComparativo.EQUALS));

            if (!string.IsNullOrEmpty(Produto.ToString()))
            {
                if(Produto.Contains("%"))
                    condicoes.Add(new Parametros("Produto_Nome", Produto, TipoDeDadosBD.character, OperadorComparativo.LIKE));
                else
                    condicoes.Add(new Parametros("Produto_Nome", Produto, TipoDeDadosBD.character, OperadorComparativo.EQUALS));
            }

            if (!string.IsNullOrEmpty(Procedencia.ToString()))
            {
                if (Procedencia.Contains("%"))
                    condicoes.Add(new Parametros("Procedencia", Procedencia, TipoDeDadosBD.character, OperadorComparativo.LIKE));
                else
                    condicoes.Add(new Parametros("Procedencia", Procedencia, TipoDeDadosBD.character, OperadorComparativo.EQUALS));
            }

            if (!string.IsNullOrEmpty(Destino.ToString()))
            {
                if (Destino.Contains("%"))
                    condicoes.Add(new Parametros("Destino", Destino, TipoDeDadosBD.character, OperadorComparativo.LIKE));
                else
                    condicoes.Add(new Parametros("Destino", Destino, TipoDeDadosBD.character, OperadorComparativo.EQUALS));
            }

            if (!string.IsNullOrEmpty(Placa.ToString()))
            {
                if (Placa.Contains("%"))
                    condicoes.Add(new Parametros("Veiculo_Placa", Placa, TipoDeDadosBD.character, OperadorComparativo.LIKE));
                else
                    condicoes.Add(new Parametros("Veiculo_Placa", Placa, TipoDeDadosBD.character, OperadorComparativo.EQUALS));
            }

            if (DataBrutoIni < DataBrutoFim)
                condicoes.Add(new Parametros("Data_Bruto", DataBrutoIni + "|" + DataBrutoFim, TipoDeDadosBD.data, OperadorComparativo.BETWEEN));

            if (DataTaraIni < DataTaraFim)
                condicoes.Add(new Parametros("Data_Tara", DataTaraIni + "|" + DataTaraFim, TipoDeDadosBD.data, OperadorComparativo.BETWEEN));

            if (DataTicketIni < DataTicketFim)
                condicoes.Add(new Parametros("Data_Ticket", DataTicketIni + "|" + DataTicketFim, TipoDeDadosBD.data, OperadorComparativo.BETWEEN));
            if(condicoes.Count>0)
                Dados = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", condicoes, null);
            else
                Dados = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", null, null);
        }

        public void ImprimirRelatorio()
        {
            MontarRelatorio();
            WebBrowser nav = new WebBrowser();
            nav.Navigate("about:blank");
            if (nav.Document != null)
            {
                nav.Document.Write(Html);
            }
            nav.DocumentText = Html;

            nav.ShowPrintDialog();
        }

        public void MontarRelatorio()
        {
            int pagina = 1;
            int linhas = 1;
            PrepararDados();
            StringBuilder stb = new StringBuilder();

            stb.Append(Properties.Resources.TemplateRelatorioListagem);

            StringBuilder corpo = new StringBuilder();
            corpo.AppendLine(Nova_Pagina(pagina));
            foreach (DataRow dr in Dados.Rows)
            {
                if (((linhas + 1) * altura_linha) >= altura_folha)
                {
                    linhas = 1;
                    pagina += 1;
                    corpo.AppendLine(Encerra_Pagina());
                    corpo.AppendLine(Nova_Pagina(pagina));
                }
                corpo.AppendLine(Montar_Linha(dr));
                linhas += 1;
            }
            corpo.AppendLine(Encerra_Pagina());
            stb.Replace("@corpo", corpo.ToString());
            Html = stb.ToString();
        }

        private string Montar_Linha(DataRow DR)
        {
            StringBuilder linha = new StringBuilder();
            linha.AppendLine("<tr>");
            linha.AppendLine("<td class=\"celula\">"+DR["Codigo"].ToString()+"</td>");
            linha.AppendLine("<td class=\"celula\">"+DR["Tipo"].ToString()+"</td>");
            linha.AppendLine("<td class=\"celula\">"+DR["Procedencia"].ToString()+"</td>");
            linha.AppendLine("<td class=\"celula\">"+DR["Destino"].ToString()+"</td>");
            linha.AppendLine("<td class=\"celula\">"+DR["Status"].ToString()+"</td>");
            linha.AppendLine("<td class=\"celula\">"+DateTime.Parse(DR["Data"].ToString()).ToShortDateString()+"</td>");
            linha.AppendLine("<td class=\"celula\" style=\"text-align: right;\">" + float.Parse(DR["Peso_liquido"].ToString()).ToString("0") + "</td>");
            linha.AppendLine("<td class=\"celula\" style=\"text-align: right;\">" + float.Parse(DR["Peso_liquido_nf"].ToString()).ToString("0") + "</td>");
            linha.AppendLine("<td class=\"celula\" style=\"text-align: right;\">" + float.Parse(DR["Diferenca"].ToString()).ToString("0") + "</td>");
            linha.AppendLine("</tr>");
            return (linha.ToString());
        }

        private string Nova_Pagina(int pag)
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("<div id=\"Pagina"+pag+"\" class=\"pagina\">");
            SB.AppendLine("<table>");
            SB.AppendLine("<tr>");
            SB.AppendLine("<th class=\"celula\">C&oacute;digo</th>");
            SB.AppendLine("<th class=\"celula\">Tipo</th>");
            SB.AppendLine("<th class=\"celula\">Procedencia</th>");
            SB.AppendLine("<th class=\"celula\">Destino</th>");
            SB.AppendLine("<th class=\"celula\">Status</th>");
            SB.AppendLine("<th class=\"celula\">Data</th>");
            SB.AppendLine("<th class=\"celula\">Liquido</th>");
            SB.AppendLine("<th class=\"celula\">Liquido NF</th>");
            SB.AppendLine("<th class=\"celula\">Diferen&ccedil;a</th>");
            SB.AppendLine("</tr>");
            return SB.ToString();
        }

        private string Encerra_Pagina()
        {
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("</table>");
            SB.AppendLine("</div>");
            return SB.ToString();
        }
    }
}
