using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.Banco
{
    public class Conexao
    {
        #region Exemplos Connections Strings
        /*
         * MDB:
         * Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Banco\\bd.mdb;User Id=admin;Password=;
         * SQLite:
         * Data Source=c:\mydb.db;Version=3;
        */
        #endregion

        #region Homologação

        /// <summary>
        /// Connection string do banco de dados de homologação
        /// </summary>
        public string connectionStringHomologacao { get; set; }

        /// <summary>
        /// Connection string do banco de dados de homologação
        /// Sempre escrever o tipo em minusculo
        /// </summary>
        public TipoDeBancos tipoBancoHomologacao { get; set; }

        #endregion

        #region Produção

        /// <summary>
        /// Connection string do banco de dados de homologação
        /// </summary>
        public string connectionStringProducao { get; set; }

        /// <summary>
        /// Connection string do banco de dados de homologação
        /// </summary>
        public TipoDeBancos tipoBancoProducao { get; set; }

        #endregion
    }

    public enum TipoDeBancos
    {
        sqlite,
        mdb
    }
}
