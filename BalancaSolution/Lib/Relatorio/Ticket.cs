using BalancaSolution.Lib.Banco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BalancaSolution.Lib.Relatorio
{
    class Ticket : Relatorio, IRelatorio
    {
        public int Codigo { get; set; }
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

        public Ticket()
        {
            Codigo = -1;
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

            if (Codigo != -1)
                condicoes.Add(new Parametros("Codigo",Codigo.ToString(), TipoDeDadosBD.numerico, OperadorComparativo.EQUALS));

            if (!string.IsNullOrEmpty(Tipo))
                condicoes.Add(new Parametros("Tipo", Tipo, TipoDeDadosBD.character, OperadorComparativo.EQUALS));

            if (!string.IsNullOrEmpty(Produto.ToString()))
                condicoes.Add(new Parametros("Produto_Nome", Produto, TipoDeDadosBD.character, OperadorComparativo.EQUALS));

            if (!string.IsNullOrEmpty(Procedencia.ToString()))
                condicoes.Add(new Parametros("Procedencia", Procedencia, TipoDeDadosBD.character, OperadorComparativo.EQUALS));

            if (!string.IsNullOrEmpty(Destino.ToString()))
                condicoes.Add(new Parametros("Destino", Destino, TipoDeDadosBD.character, OperadorComparativo.EQUALS));

            if (!string.IsNullOrEmpty(Placa.ToString()))
                condicoes.Add(new Parametros("Veiculo_Placa", Placa, TipoDeDadosBD.character, OperadorComparativo.EQUALS));

            if (DataBrutoIni < DataBrutoFim)
                condicoes.Add(new Parametros("Data_Bruto", DataBrutoIni + "|" + DataBrutoFim, TipoDeDadosBD.data, OperadorComparativo.BETWEEN));

            if (DataTaraIni < DataTaraFim)
                condicoes.Add(new Parametros("Data_Tara", DataTaraIni + "|" + DataTaraFim, TipoDeDadosBD.data, OperadorComparativo.BETWEEN));

            if (DataTicketIni < DataTicketFim)
                condicoes.Add(new Parametros("Data_Ticket", DataTicketIni + "|" + DataTicketFim, TipoDeDadosBD.data, OperadorComparativo.BETWEEN));

            Dados = Comando.Default.executaComando(TipoDeComando.Select, "Ticket", condicoes, null);
        }

        public void  ImprimirRelatorio()
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

        public void  MontarRelatorio()
        {
            PrepararDados();
            StringBuilder stb = new StringBuilder();

            stb.Append(Properties.Resources.TemplateRelatorioTicket);
            stb.Replace("@numero", Dados.Rows[0]["Codigo"].ToString());
            stb.Replace("@tipo", Dados.Rows[0]["Tipo"].ToString());

            stb.Replace("@produto", Dados.Rows[0]["Produto_Nome"].ToString());
            stb.Replace("@procedencia", Dados.Rows[0]["Procedencia"].ToString());
            stb.Replace("@destino", Dados.Rows[0]["Destino"].ToString());
            stb.Replace("@placa", Dados.Rows[0]["Veiculo_Placa"].ToString());

            stb.Replace("@pesobruto", float.Parse(Dados.Rows[0]["Peso_Bruto"].ToString()).ToString("n0"));
            stb.Replace("@datapesobruto", Dados.Rows[0]["Data_Bruto"].ToString());
            stb.Replace("@pesotara", float.Parse(Dados.Rows[0]["Peso_Tara"].ToString()).ToString("n0"));
            stb.Replace("@datapesotara", Dados.Rows[0]["Data_Tara"].ToString());

            stb.Replace("@pesoliquido", float.Parse(Dados.Rows[0]["Peso_Liquido"].ToString()).ToString("n0"));
            stb.Replace("@volumes", Dados.Rows[0]["Quantidade_Cargas"].ToString());
            stb.Replace("@pesovolumes", float.Parse(Dados.Rows[0]["Peso_Liquido_NF"].ToString()).ToString("n0"));
            string tipo = Dados.Rows[0]["Produto_Tipo_Margem"].ToString();
            string textoDif = "";
            switch (tipo)
            {
                case "P":
                    textoDif = float.Parse(Dados.Rows[0]["Diferenca"].ToString()).ToString("n0") + " %";
                    break;
                case "K":
                    textoDif = float.Parse(Dados.Rows[0]["Diferenca"].ToString()).ToString("n0") + " Kg";
                    break;
                default:
                    textoDif = float.Parse(Dados.Rows[0]["Diferenca"].ToString()).ToString("n0");
                    break;
            }
            stb.Replace("@diferenca", textoDif);
            
            stb.Replace("@observacao", Dados.Rows[0]["Observacao"].ToString());

            Html = stb.ToString();
        }
    }
}
