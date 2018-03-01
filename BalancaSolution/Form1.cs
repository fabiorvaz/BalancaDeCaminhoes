using BalancaSolution.Lib.Banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalancaSolution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao connection = new Conexao();
            connection.connectionStringProducao = "Data Source=c:\\temp\\balanca.db;Version=3;";
            connection.tipoBancoProducao = TipoDeBancos.sqlite;
            Comando.Default.conexao = connection;
            Comando.Default.montarConexaoComBanco(false);
            MessageBox.Show(Comando.Default.testarConexao());
        }
    }
}
