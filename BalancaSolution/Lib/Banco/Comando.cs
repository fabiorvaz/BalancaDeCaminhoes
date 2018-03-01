using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.Banco
{
    public class Comando
    {
        #region Singleton

        private static readonly Comando instancia = new Comando();
        private Comando() { }

        public static Comando Default
        {
            get
            {
                return instancia;
            }
        }

        #endregion

        #region Variaveis

        /// <summary>
        /// define se esta em modo de homologacao
        /// </summary>
        private bool modoDeHomologacao { get; set; }

        public Conexao conexao { get; set; }

        /// <summary>
        /// objeto de conexao com o banco de dados
        /// </summary>
        public DbConnection conexaoBanco;

        /// <summary>
        /// tipo do banco que está ativo no momento
        /// </summary>
        private string tipoBanco;

        #endregion

        #region Inicio banco

        /// <summary>
        /// monta a conexão com o banco de dados
        /// </summary>
        /// <param name="homologacao">informa se é no ambiente de homologacao ou nao</param>
        public void montarConexaoComBanco(bool homologacao)
        {

            string connection;
            if (homologacao)
            {
                modoDeHomologacao = homologacao;
                tipoBanco = conexao.tipoBancoHomologacao.ToString();
                connection = conexao.connectionStringHomologacao;
            }
            else
            {
                modoDeHomologacao = homologacao;
                tipoBanco = conexao.tipoBancoProducao.ToString();
                connection = conexao.connectionStringProducao;
            }

            switch (tipoBanco.ToLower())
            {
                case "mdb":
                    conexaoBanco = new OleDbConnection(connection);
                    break;
                case "sqlite":
                    conexaoBanco = new SQLiteConnection(connection);
                    break;
                default:
                    throw new Exception("Tipo de banco não implementado");
            }
        }

        /// <summary>
        /// Testa a conexão com o banco de dados
        /// </summary>
        public string testarConexao()
        {
            try
            {
                conexaoBanco.Open();
                conexaoBanco.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString().Contains("connecting"))
                    return ex.Message;
            }

            return "Sucesso!";
        }

        #endregion

        #region Executa comando

        /// <summary>
        /// Executa um comando no banco.
        /// </summary>
        /// <param name="tp">tipo do comando a ser executado</param>
        /// <param name="tabela">tabela no banco</param>
        /// <param name="condicoes">lista de condições</param>
        /// <param name="valores">para os comandos de insert e de update serve como lista de valores, para select serve como lista de campos a serem selecionados (enviar o valor como null nesse caso)</param>
        public DataTable executaComando(TipoDeComando tp, string tabela, List<Parametros> condicoes, List<Parametros> valores, string sql = "")
        {
            if (conexaoBanco == null)
            {
                montarConexaoComBanco(false);
            }

            switch (tp)
            {
                case TipoDeComando.Select:
                    return (executaSelect(tabela, condicoes, valores));
                case TipoDeComando.Insert:
                    return (executaInsert(tabela, valores));
                case TipoDeComando.Delete:
                    return (executaDelete(tabela, condicoes));
                case TipoDeComando.Update:
                    return (executaUpdate(tabela, condicoes, valores));
                case TipoDeComando.Sql:
                    return (executaSql(sql));
                default:
                    throw new Exception("Tipo não implementado, ou parametros invalidos");
            }
        }
        
        /// <summary>
        /// Executa um comando no banco.
        /// </summary>
        /// <param name="tp">tipo do comando a ser executado</param>
        /// <param name="tabela">tabela no banco</param>
        /// <param name="condicoes">lista de condições</param>
        /// <param name="valores">para os comandos de insert e de update serve como lista de valores, para select serve como lista de campos a serem selecionados (enviar o valor como null nesse caso)</param>
        public DbDataReader executaComandoReader(TipoDeComando tp, string tabela, List<Parametros> condicoes, List<Parametros> valores, string sql = "")
        {
            if (conexaoBanco == null)
            {
                montarConexaoComBanco(false);
            }

            switch (tp)
            {
                case TipoDeComando.Select:
                    return (executaSelectReader(tabela, condicoes, valores));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Inicia uma transaction para edições protegidas no banco
        /// </summary>
        public void iniciarTransaction()
        {
            if (conexaoBanco == null)
            {
                montarConexaoComBanco(false);
            }
            switch (tipoBanco.ToLower())
            {
                case "mdb":
                    return;
                case "sqlite":
                    Validador.IniciarTransactionSQLite((SQLiteConnection)conexaoBanco);
                    break;
                default:
                    throw new Exception("Banco não iniciado ou tipo não implementado");
            }
            Validador.isTrasaction = true;
        }

        /// <summary>
        /// Salva as alterações feitas na transaction no banco
        /// </summary>
        public void commitTransaction()
        {
            if (conexaoBanco == null)
            {
                montarConexaoComBanco(false);
            }
            switch (tipoBanco.ToLower())
            {
                case "mdb":
                    return;
                case "sqlite":
                    Validador.FinalizarTransactionCommitSQLite((SQLiteConnection)conexaoBanco);
                    break;
                default:
                    throw new Exception("Banco não iniciado ou tipo não implementado");
            }
            Validador.isTrasaction = false;
        }

        /// <summary>
        /// Descarta as alterações feitas na transaction
        /// </summary>
        public void rollbackTransaction()
        {
            if (conexaoBanco == null)
            {
                montarConexaoComBanco(false);
            }
            switch (tipoBanco.ToLower())
            {
                case "mdb":
                    return;
                case "sqlite":
                    Validador.FinalizarTransactionRollbackSQLite((SQLiteConnection)conexaoBanco);
                    break;
                default:
                    throw new Exception("Banco não iniciado ou tipo não implementado");
            }
            Validador.isTrasaction = false;
        }

        /// <summary>
        /// testa o tipo do banco de dados ativo para executar o comando update corretamente.
        /// </summary>
        private DataTable executaUpdate(string tabela, List<Parametros> condicoes, List<Parametros> valores)
        {
            switch (tipoBanco.ToLower())
            {
                case "mdb":
                    return Validador.executarUpdateMdb(tabela, condicoes, valores, (OleDbConnection)conexaoBanco);
                case "sqlite":
                    return Validador.ExecutarUpdateSQLite(tabela, condicoes, valores, (SQLiteConnection)conexaoBanco);
                default:
                    throw new Exception("Banco não iniciado ou tipo não implementado");
            }
        }

        /// <summary>
        /// testa o tipo do banco de dados ativo para executar o comando delete corretamente.
        /// </summary>
        private DataTable executaDelete(string tabela, List<Parametros> condicoes)
        {
            switch (tipoBanco.ToLower())
            {
                case "mdb":
                    return Validador.executarDeleteMdb(tabela, condicoes, (OleDbConnection)conexaoBanco);
                case "sqlite":
                    return Validador.ExecutarDeleteSQLite(tabela, condicoes, (SQLiteConnection)conexaoBanco);
                default:
                    throw new Exception("Banco não iniciado ou tipo não implementado");
            }
        }

        /// <summary>
        /// testa o tipo do banco de dados ativo para executar o comando insert corretamente.
        /// </summary>
        private DataTable executaInsert(string tabela, List<Parametros> valores)
        {
            switch (tipoBanco.ToLower())
            {
                case "mdb":
                    return Validador.executarInsertMdb(tabela, valores, (OleDbConnection)conexaoBanco);
                case "sqlite":
                    return Validador.ExecutarInsertSQLite(tabela, valores, (SQLiteConnection)conexaoBanco);
                default:
                    throw new Exception("Banco não iniciado ou tipo não implementado");
            }
        }

        /// <summary>
        /// testa o tipo do banco de dados ativo para executar o comando select corretamente.
        /// </summary>
        private DataTable executaSelect(string tabela, List<Parametros> condicoes, List<Parametros> valores)
        {
            switch (tipoBanco.ToLower())
            {
                case "mdb":
                    return Validador.executarSelectMdb(tabela, condicoes, valores, (OleDbConnection)conexaoBanco);
                case "sqlite":
                    return Validador.ExecutarSelectSQLite(tabela, condicoes, valores, (SQLiteConnection)conexaoBanco);
                default:
                    throw new Exception("Banco não iniciado ou tipo não implementado");
            }
        }

        /// <summary>
        /// testa o tipo do banco de dados ativo para executar o comando select corretamente.
        /// </summary>
        private DbDataReader executaSelectReader(string tabela, List<Parametros> condicoes, List<Parametros> valores)
        {
            switch (tipoBanco.ToLower())
            {
                case "mdb":
                    return null; //Validador.ExecutarSelectMdb(tabela, condicoes, valores, (OleDbConnection)ConexaoBanco);
                case "sqlite":
                    return Validador.ExecutarSelectSQLiteReader(tabela, condicoes, valores, (SQLiteConnection)conexaoBanco);
                default:
                    throw new Exception("Banco não iniciado ou tipo não implementado");
            }
        }

        /// <summary>
        /// testa o tipo do banco de dados ativo para executar o comando sql corretamente.
        /// </summary>
        private DataTable executaSql(string sql)
        {
            switch (tipoBanco.ToLower())
            {
                case "mdb":
                    return Validador.executarSqlMdb(sql, (OleDbConnection)conexaoBanco);
                case "sqlite":
                    return Validador.ExecutarSqlSQLite(sql, (SQLiteConnection)conexaoBanco);
                default:
                    throw new Exception("Banco não iniciado ou tipo não implementado");
            }
        }

        #endregion

        #region Extras
        /*
        /// <summary>
        /// Calcula o hash de uma senha
        /// </summary>
        public string Calcular_Hash_Senha(string senha, string usuario)
        {
            int hash_final = (senha + "" + usuario + "").GetHashCode();
            return hash_final.ToString();
        }

        public bool Validar_Login(string usuario, string senha)
        {
            //verifica se o codigo está cadastrado no banco
            throw new NotImplementedException();
        }
        */
        #endregion
    }

    public enum TipoDeComando
    {
        Select,
        Insert,
        Delete,
        Update,
        Sql
    }
}
