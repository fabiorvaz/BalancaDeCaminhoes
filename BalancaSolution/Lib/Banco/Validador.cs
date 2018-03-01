using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.Banco
{
    public static class Validador
    {
        internal static bool isTrasaction = false;

        #region MDB

        /// <summary>
        /// Cria um comando select para um banco do tipo mdb
        /// </summary>
        /// <param name="tabela">nome da tabela</param>
        /// <param name="condicoes">lista de condições do where</param>
        /// <param name="valores">lista de colunas a serem selecionadas, padrão *</param>
        /// <returns>oledbcommand criado</returns>
        internal static DataTable executarSelectMdb(string tabela, List<Parametros> condicoes, List<Parametros> valores, OleDbConnection conexaoBanco)
        {
            StringBuilder sB = new StringBuilder();
            sB.Append("SELECT ");
            if (valores == null)
            {
                sB.Append("* ");
            }
            else
            {
                for (int i = 0; i < valores.Count; i++)
                {
                    if (i > 0)
                        sB.Append(", ");
                    sB.Append(valores[i].Nome);
                }
            }
            sB.Append(" FROM ");
            sB.Append(tabela);
            if (condicoes != null)
            {
                sB.Append(" WHERE ");
                sB.Append(montarCondicaoWhereMdb(condicoes));
            }
            OleDbCommand command = new OleDbCommand(sB.ToString());
            if (condicoes != null)
            {
                foreach (OleDbParameter p in montarParametersMdb(condicoes))
                {
                    command.Parameters.Add(p);
                }
            }
            command.Connection = conexaoBanco;
            OleDbDataAdapter dA = new OleDbDataAdapter(command);
            DataSet dS = new DataSet();
            conexaoBanco.Open();
            dA.Fill(dS);
            conexaoBanco.Close();
            return dS.Tables[0];
        }

        /// <summary>
        /// Monta a clausula Where, sem o texto where, seguindo as regras do banco mdb
        /// </summary>
        /// <param name="condicoes">condições a serem usadas na clausula where</param>
        /// <returns>string com a clausula montada</returns>
        private static string montarCondicaoWhereMdb(List<Parametros> condicoes)
        {
            StringBuilder sB = new StringBuilder();
            for (int i = 0; i < condicoes.Count; i++)
            {
                if (condicoes[i].listaParametros == null)
                {
                    if (i > 0)
                        sB.Append(" " + condicoes[i].OperadorL + " ");
                    sB.Append(condicoes[i].Nome + "=@c" + condicoes[i].Nome + i);
                }
                else
                {
                    if (i > 0)
                        sB.Append(" " + condicoes[i].OperadorL + " ");
                    sB.Append("(");
                    sB.Append(montarCondicaoWhereMdb(condicoes[i].listaParametros));
                    sB.Append(")");
                }
            }
            return sB.ToString();
        }

        /// <summary>
        /// monta a lista de parametros a serem adicionados nos comandos mdb
        /// </summary>
        /// <param name="lista">lista de parametros</param>
        private static List<OleDbParameter> montarParametersMdb(List<Parametros> lista)
        {
            List<OleDbParameter> parametros = new List<OleDbParameter>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].listaParametros == null)
                {
                    parametros.Add(new OleDbParameter("@c" + lista[i].Nome + i, lista[i].Valor));
                }
                else
                {
                    foreach (OleDbParameter p in montarParametersMdb(lista[i].listaParametros))
                    {
                        parametros.Add(p);
                    }
                }
            }
            return parametros;
        }

        /// <summary>
        /// Ajusta os valores para ficarem compativeis com o banco de dados do tipo mdb
        /// </summary>
        /// <param name="p">parametro a ser arrumado</param>
        /// <returns>valor corrigido</returns>
        private static string normalizarDadoMdb(Parametros p)
        {
            string retorno = "";
            switch (p.Tipo)
            {
                case TipoDeDadosBD.data:
                    retorno = "'" + p.Valor + "'";
                    break;
                case TipoDeDadosBD.numerico:
                    retorno = "'" + p.Valor + "'";
                    break;
                case TipoDeDadosBD.texto:
                    retorno = "'" + p.Valor + "'";
                    break;
                default:
                    retorno = p.Valor;
                    break;
            }
            return retorno;
        }

        internal static DataTable executarInsertMdb(string tabela, List<Parametros> valores, OleDbConnection conexaoBanco)
        {
            StringBuilder sB = new StringBuilder();
            StringBuilder sB2 = new StringBuilder();

            sB.AppendLine("INSERT INTO ");
            sB.AppendLine(tabela);
            sB.AppendLine("(");
            sB2.AppendLine("VALUES (");

            for (int i = 0; i < valores.Count; i++)
            {
                if (i > 0)
                {
                    sB.AppendLine(",");
                    sB2.AppendLine(",");
                }
                sB.AppendLine(valores[i].Nome);
                sB2.AppendLine("@v" + valores[i].Nome);
            }
            sB.AppendLine(")");
            sB2.AppendLine(")");
            sB.AppendLine(sB2.ToString());
            OleDbCommand comando = new OleDbCommand(sB.ToString(), conexaoBanco);
            foreach (OleDbParameter p in montarParametersMdb(valores))
            {
                comando.Parameters.Add(p);
            }
            conexaoBanco.Open();
            comando.ExecuteNonQuery();
            conexaoBanco.Close();
            return null;
        }

        internal static DataTable executarDeleteMdb(string tabela, List<Parametros> condicoes, OleDbConnection conexaoBanco)
        {
            StringBuilder sB = new StringBuilder();
            sB.Append("DELETE FROM " + tabela);
            sB.Append(" WHERE ");
            if (condicoes.Count == 0)
            {
                return null;
            }
            sB.Append(montarCondicaoWhereMdb(condicoes));
            OleDbCommand comando = new OleDbCommand(sB.ToString(), conexaoBanco);
            foreach (OleDbParameter p in montarParametersMdb(condicoes))
            {
                comando.Parameters.Add(p);
            }
            conexaoBanco.Open();
            comando.ExecuteNonQuery();
            conexaoBanco.Close();
            return null;
        }

        internal static DataTable executarUpdateMdb(string tabela, List<Parametros> condicoes, List<Parametros> valores, OleDbConnection conexaoBanco)
        {
            if (condicoes.Count == 0)
                return null;
            if (valores.Count == 0)
                return null;
            StringBuilder sB = new StringBuilder();

            sB.Append("UPDATE " + tabela);
            sB.Append(" SET ");
            for (int i = 0; i < valores.Count; i++)
            {
                if (i > 0)
                    sB.Append(", ");
                sB.Append(valores[i].Nome + "=@v" + valores[i].Nome);
            }
            sB.Append(" WHERE ");
            sB.Append(montarCondicaoWhereMdb(condicoes));
            OleDbCommand comando = new OleDbCommand(sB.ToString(), conexaoBanco);
            foreach (OleDbParameter p in montarParametersMdb(valores))
            {
                comando.Parameters.Add(p);
            }
            foreach (OleDbParameter p in montarParametersMdb(condicoes))
            {
                comando.Parameters.Add(p);
            }

            conexaoBanco.Open();
            comando.ExecuteNonQuery();
            conexaoBanco.Close();
            return null;
        }

        internal static DataTable executarSqlMdb(string sql, OleDbConnection conexaoBanco)
        {
            OleDbCommand comando = new OleDbCommand(sql);
            comando.Connection = conexaoBanco;
            if (sql.ToUpper().StartsWith("SELECT"))
            {
                OleDbDataAdapter DA = new OleDbDataAdapter(comando);
                DataSet dS = new DataSet();
                conexaoBanco.Open();
                DA.Fill(dS);
                conexaoBanco.Close();
                return dS.Tables[0];
            }
            else
            {
                conexaoBanco.Open();
                comando.ExecuteNonQuery();
                conexaoBanco.Close();
                return null;
            }
        }

        #endregion

        #region SQLite

        internal static SQLiteTransaction transactionSqlite;

        /// <summary>
        /// Cria um comando select para um banco do tipo SQLite
        /// </summary>
        /// <param name="tabela">nome da tabela</param>
        /// <param name="condicoes">lista de condições do where</param>
        /// <param name="valores">lista de colunas a serem selecionadas, padrão *</param>
        /// <returns>SQLitecommand criado</returns>
        internal static DataTable ExecutarSelectSQLite(string tabela, List<Parametros> condicoes, List<Parametros> valores, SQLiteConnection ConexaoBanco)
        {
            StringBuilder SB = new StringBuilder();
            SB.Append("SELECT ");
            if (valores == null)
            {
                SB.Append("* ");
            }
            else
            {
                for (int i = 0; i < valores.Count; i++)
                {
                    if (i > 0)
                        SB.Append(", ");
                    SB.Append(valores[i].Nome);
                }
            }
            SB.Append(" FROM ");
            SB.Append(tabela);
            if (condicoes != null)
            {
                SB.Append(" WHERE ");
                SB.Append(MontarCondicaoWhereSQLite(condicoes));
            }
            SQLiteCommand command = new SQLiteCommand(SB.ToString());
            if (condicoes != null)
            {
                foreach (SQLiteParameter p in MontarParametersSQLite(condicoes, 'c'))
                {
                    command.Parameters.Add(p);
                }
            }
            command.Connection = ConexaoBanco;
            SQLiteDataAdapter DA = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            if (ConexaoBanco.State != ConnectionState.Open)
                ConexaoBanco.Open();
            DA.Fill(ds);
            ConexaoBanco.Close();
            return ds.Tables[0];
        }

        /// <summary>
        /// Cria um comando select para um banco do tipo SQLite
        /// </summary>
        /// <param name="tabela">nome da tabela</param>
        /// <param name="condicoes">lista de condições do where</param>
        /// <param name="valores">lista de colunas a serem selecionadas, padrão *</param>
        /// <returns>SQLitecommand criado</returns>
        internal static SQLiteDataReader ExecutarSelectSQLiteReader(string tabela, List<Parametros> condicoes, List<Parametros> valores, SQLiteConnection ConexaoBanco)
        {
            StringBuilder SB = new StringBuilder();
            SB.Append("SELECT ");
            if (valores == null)
            {
                SB.Append("* ");
            }
            else
            {
                for (int i = 0; i < valores.Count; i++)
                {
                    if (i > 0)
                        SB.Append(", ");
                    SB.Append(valores[i].Nome);
                }
            }
            SB.Append(" FROM ");
            SB.Append(tabela);
            if (condicoes != null)
            {
                SB.Append(" WHERE ");
                SB.Append(MontarCondicaoWhereSQLite(condicoes));
            }
            SQLiteCommand command = new SQLiteCommand(SB.ToString());
            if (condicoes != null)
            {
                foreach (SQLiteParameter p in MontarParametersSQLite(condicoes, 'c'))
                {
                    command.Parameters.Add(p);
                }
            }
            command.Connection = ConexaoBanco;
            if (ConexaoBanco.State != ConnectionState.Open)
                ConexaoBanco.Open();
            SQLiteDataReader reader = command.ExecuteReader();
            ConexaoBanco.Close();
            return reader;
        }

        /// <summary>
        /// Monta a clausula Where, sem o texto where, seguindo as regras do banco SQLite
        /// </summary>
        /// <param name="condicoes">condições a serem usadas na clausula where</param>
        /// <returns>string com a clausula montada</returns>
        private static string MontarCondicaoWhereSQLite(List<Parametros> condicoes)
        {
            StringBuilder SB = new StringBuilder();
            for (int i = 0; i < condicoes.Count; i++)
            {
                if (condicoes[i].listaParametros == null)
                {
                    if (i > 0)
                        SB.Append(" " + condicoes[i].OperadorL + " ");
                    switch (condicoes[i].OperadorC)
                    {
                        case OperadorComparativo.EQUALS:
                            SB.Append(condicoes[i].Nome + "=@c" + condicoes[i].Nome + i);
                            break;
                        case OperadorComparativo.LIKE:
                            SB.Append(condicoes[i].Nome + " LIKE @c" + condicoes[i].Nome + i);
                            break;
                        case OperadorComparativo.BETWEEN:
                            SB.Append(condicoes[i].Nome + " BETWEEN @c" + condicoes[i].Nome + i + "A AND " + " @c" + condicoes[i].Nome + i + "B");
                            break;
                        case OperadorComparativo.IN:
                            SB.Append(condicoes[i].Nome + " IN (");
                            int cont = 0;
                            bool teste = false;
                            foreach (string a in condicoes[i].Valor.Split(','))
                            {
                                if (teste)
                                    SB.Append(", ");
                                SB.Append("@c" + condicoes[i].Nome + "IN" + cont);
                                cont++;
                                teste = true;
                            }
                            SB.Append(")");
                            break;
                        default:
                            SB.Append(condicoes[i].Nome + "=@c" + condicoes[i].Nome + i);
                            break;
                    }
                }
                else
                {
                    if (i > 0)
                        SB.Append(" " + condicoes[i].OperadorL + " ");
                    SB.Append("(");
                    SB.Append(montarCondicaoWhereMdb(condicoes[i].listaParametros));
                    SB.Append(")");
                }
            }
            return SB.ToString();
        }

        /// <summary>
        /// monta a lista de parametros a serem adicionados nos comandos SQLite
        /// </summary>
        /// <param name="lista">lista de parametros</param>
        private static List<SQLiteParameter> MontarParametersSQLite(List<Parametros> lista, char letra)
        {
            List<SQLiteParameter> parametros = new List<SQLiteParameter>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].listaParametros == null)
                {
                    string nome = "";
                    if (letra == 'c')
                        nome = "@" + letra + lista[i].Nome + i;
                    else
                        nome = "@" + letra + lista[i].Nome;
                    switch (lista[i].Tipo)
                    {
                        case TipoDeDadosBD.data:
                            if (lista[i].OperadorC != OperadorComparativo.BETWEEN)
                                parametros.Add(new SQLiteParameter(nome, DateTime.Parse(lista[i].Valor)));
                            else if (lista[i].OperadorC == OperadorComparativo.BETWEEN)
                            {
                                string[] div = lista[i].Valor.Split('|');
                                parametros.Add(new SQLiteParameter(nome + "A", DateTime.Parse(div[0])));
                                parametros.Add(new SQLiteParameter(nome + "B", DateTime.Parse(div[1])));
                            }
                            else
                            {
                                string[] div = lista[i].Valor.Split(',');
                                for (int cont = 0; cont < div.Length; cont++)
                                {
                                    parametros.Add(new SQLiteParameter(nome + "IN" + cont, DateTime.Parse(div[cont])));
                                }
                            }
                            break;
                        case TipoDeDadosBD.numerico:
                            if (lista[i].OperadorC == OperadorComparativo.BETWEEN)
                            {
                                string[] div = lista[i].Valor.Split('|');
                                parametros.Add(new SQLiteParameter(nome + "A", int.Parse(div[0])));
                                parametros.Add(new SQLiteParameter(nome + "B", int.Parse(div[1])));
                            }
                            else if (lista[i].OperadorC == OperadorComparativo.IN)
                            {
                                string[] div = lista[i].Valor.Split(',');
                                for (int cont = 0; cont < div.Length; cont++)
                                {
                                    parametros.Add(new SQLiteParameter(nome + "IN" + cont, int.Parse(div[cont])));
                                }
                            }
                            else
                                parametros.Add(new SQLiteParameter(nome, int.Parse(lista[i].Valor)));
                            break;
                        case TipoDeDadosBD.numericoLongo:
                            if (lista[i].OperadorC != OperadorComparativo.BETWEEN)
                                parametros.Add(new SQLiteParameter(nome, long.Parse(lista[i].Valor)));
                            else if (lista[i].OperadorC == OperadorComparativo.BETWEEN)
                            {
                                string[] div = lista[i].Valor.Split('|');
                                parametros.Add(new SQLiteParameter(nome + "A", long.Parse(div[0])));
                                parametros.Add(new SQLiteParameter(nome + "B", long.Parse(div[1])));
                            }
                            else
                            {
                                string[] div = lista[i].Valor.Split(',');
                                for (int cont = 0; cont < div.Length; cont++)
                                {
                                    parametros.Add(new SQLiteParameter(nome + "IN" + cont, long.Parse(div[cont])));
                                }
                            }
                            break;
                        case TipoDeDadosBD.texto:
                            if (lista[i].OperadorC != OperadorComparativo.BETWEEN)
                                parametros.Add(new SQLiteParameter(nome, lista[i].Valor));
                            else if (lista[i].OperadorC == OperadorComparativo.BETWEEN)
                            {
                                string[] div = lista[i].Valor.Split('|');
                                parametros.Add(new SQLiteParameter(nome + "A", div[0]));
                                parametros.Add(new SQLiteParameter(nome + "B", div[1]));
                            }
                            else
                            {
                                string[] div = lista[i].Valor.Split(',');
                                for (int cont = 0; cont < div.Length; cont++)
                                {
                                    parametros.Add(new SQLiteParameter(nome + "IN" + cont, div[cont]));
                                }
                            }
                            break;
                        case TipoDeDadosBD.pontoFlutuante:
                            if (lista[i].OperadorC != OperadorComparativo.BETWEEN)
                                parametros.Add(new SQLiteParameter(nome, float.Parse(lista[i].Valor)));
                            else if (lista[i].OperadorC == OperadorComparativo.BETWEEN)
                            {
                                string[] div = lista[i].Valor.Split('|');
                                parametros.Add(new SQLiteParameter(nome + "A", float.Parse(div[0])));
                                parametros.Add(new SQLiteParameter(nome + "B", float.Parse(div[1])));
                            }
                            else
                            {
                                string[] div = lista[i].Valor.Split(',');
                                for (int cont = 0; cont < div.Length; cont++)
                                {
                                    parametros.Add(new SQLiteParameter(nome + "IN" + cont, float.Parse(div[cont])));
                                }
                            }
                            break;
                        default:
                            if (lista[i].OperadorC != OperadorComparativo.BETWEEN)
                                parametros.Add(new SQLiteParameter(nome, lista[i].Valor));
                            else if (lista[i].OperadorC == OperadorComparativo.BETWEEN)
                            {
                                string[] div = lista[i].Valor.Split('|');
                                parametros.Add(new SQLiteParameter(nome + "A", div[0]));
                                parametros.Add(new SQLiteParameter(nome + "B", div[1]));
                            }
                            else
                            {
                                string[] div = lista[i].Valor.Split(',');
                                for (int cont = 0; cont < div.Length; cont++)
                                {
                                    parametros.Add(new SQLiteParameter(nome + "IN" + cont, div[cont]));
                                }
                            }
                            break;
                    }
                }
                else
                {
                    foreach (SQLiteParameter p in MontarParametersSQLite(lista[i].listaParametros, letra))
                    {
                        parametros.Add(p);
                    }
                }
            }
            return parametros;
        }

        /// <summary>
        /// Ajusta os valores para ficarem compativeis com o banco de dados do tipo SQLite
        /// </summary>
        /// <param name="p">parametro a ser arrumado</param>
        /// <returns>valor corrigido</returns>
        private static string NormalizarDadoSQLite(Parametros p)
        {
            string retorno = "";
            switch (p.Tipo)
            {
                case TipoDeDadosBD.data:
                    retorno = p.Valor;
                    break;
                case TipoDeDadosBD.numerico:
                    retorno = p.Valor;
                    break;
                case TipoDeDadosBD.texto:
                    retorno = p.Valor;
                    break;
                case TipoDeDadosBD.pontoFlutuante:
                    retorno = p.Valor.ToString().Replace(",", ".");
                    break;
                default:
                    retorno = p.Valor;
                    break;
            }
            return retorno;
        }

        internal static DataTable ExecutarInsertSQLite(string tabela, List<Parametros> valores, SQLiteConnection ConexaoBanco)
        {
            StringBuilder SB = new StringBuilder();
            StringBuilder SB2 = new StringBuilder();

            SB.AppendLine("INSERT INTO ");
            SB.AppendLine(tabela);
            SB.AppendLine("(");
            SB2.AppendLine("VALUES (");

            for (int i = 0; i < valores.Count; i++)
            {
                if (i > 0)
                {
                    SB.AppendLine(",");
                    SB2.AppendLine(",");
                }
                SB.AppendLine(valores[i].Nome);
                SB2.AppendLine("@v" + valores[i].Nome);
            }
            SB.AppendLine(")");
            SB2.AppendLine(")");
            SB.AppendLine(SB2.ToString());
            SQLiteCommand comando = new SQLiteCommand(SB.ToString(), ConexaoBanco);
            foreach (SQLiteParameter p in MontarParametersSQLite(valores, 'v'))
            {
                comando.Parameters.Add(p);
            }
            if (!isTrasaction)
            {
                if (ConexaoBanco.State != ConnectionState.Open)
                    ConexaoBanco.Open();
                comando.ExecuteNonQuery();
                ConexaoBanco.Close();
            }
            else
            {
                if (ConexaoBanco.State != ConnectionState.Open)
                    ConexaoBanco.Open();
                comando.ExecuteNonQuery();
            }
            return null;
        }

        internal static DataTable ExecutarDeleteSQLite(string tabela, List<Parametros> condicoes, SQLiteConnection ConexaoBanco)
        {
            StringBuilder SB = new StringBuilder();
            SB.Append("DELETE FROM " + tabela);
            SB.Append(" WHERE ");
            if (condicoes.Count == 0)
            {
                return null;
            }
            SB.Append(MontarCondicaoWhereSQLite(condicoes));
            SQLiteCommand comando = new SQLiteCommand(SB.ToString(), ConexaoBanco);
            foreach (SQLiteParameter p in MontarParametersSQLite(condicoes, 'c'))
            {
                comando.Parameters.Add(p);
            }
            if (!isTrasaction)
            {
                if (ConexaoBanco.State != ConnectionState.Open)
                    ConexaoBanco.Open();
                comando.ExecuteNonQuery();
                ConexaoBanco.Close();
            }
            else
            {
                if (ConexaoBanco.State != ConnectionState.Open)
                    ConexaoBanco.Open();
                comando.ExecuteNonQuery();
            }
            return null;
        }

        internal static DataTable ExecutarUpdateSQLite(string tabela, List<Parametros> condicoes, List<Parametros> valores, SQLiteConnection ConexaoBanco)
        {
            if (condicoes.Count == 0)
                return null;
            if (valores.Count == 0)
                return null;
            StringBuilder SB = new StringBuilder();

            SB.Append("UPDATE " + tabela);
            SB.Append(" SET ");
            for (int i = 0; i < valores.Count; i++)
            {
                if (i > 0)
                    SB.Append(", ");
                SB.Append(valores[i].Nome + "=@v" + valores[i].Nome);
            }
            SB.Append(" WHERE ");
            SB.Append(MontarCondicaoWhereSQLite(condicoes));
            SQLiteCommand comando = new SQLiteCommand(SB.ToString(), ConexaoBanco);
            foreach (SQLiteParameter p in MontarParametersSQLite(valores, 'v'))
            {
                comando.Parameters.Add(p);
            }
            foreach (SQLiteParameter p in MontarParametersSQLite(condicoes, 'c'))
            {
                comando.Parameters.Add(p);
            }

            if (!isTrasaction)
            {
                if (ConexaoBanco.State != ConnectionState.Open)
                    ConexaoBanco.Open();
                comando.ExecuteNonQuery();
                ConexaoBanco.Close();
            }
            else
            {
                if (ConexaoBanco.State != ConnectionState.Open)
                    ConexaoBanco.Open();
                comando.ExecuteNonQuery();
            }
            return null;
        }

        internal static DataTable ExecutarSqlSQLite(string sql, SQLiteConnection ConexaoBanco)
        {
            SQLiteCommand comando = new SQLiteCommand(sql, ConexaoBanco);
            comando.Connection = ConexaoBanco;
            if (sql.ToUpper().StartsWith("SELECT"))
            {
                SQLiteDataAdapter DA = new SQLiteDataAdapter(comando);
                DataSet ds = new DataSet();
                if (ConexaoBanco.State != ConnectionState.Open)
                    ConexaoBanco.Open();
                DA.Fill(ds);
                ConexaoBanco.Close();
                return ds.Tables[0];
            }
            else
            {
                if (!isTrasaction)
                {
                    ConexaoBanco.Open();
                    comando.ExecuteNonQuery();
                    ConexaoBanco.Close();
                }
                else
                {
                    if (ConexaoBanco.State != ConnectionState.Open)
                        ConexaoBanco.Open();
                    comando.ExecuteNonQuery();
                }
                return null;
            }
        }

        internal static SQLiteCommand MontarInsertSQLite(string tabela, List<Parametros> valores)
        {
            StringBuilder SB = new StringBuilder();
            StringBuilder SB2 = new StringBuilder();

            SB.AppendLine("INSERT INTO ");
            SB.AppendLine(tabela);
            SB.AppendLine("(");
            SB2.AppendLine("VALUES (");

            for (int i = 0; i < valores.Count; i++)
            {
                if (i > 0)
                {
                    SB.AppendLine(",");
                    SB2.AppendLine(",");
                }
                SB.AppendLine(valores[i].Nome);
                SB2.AppendLine("@v" + valores[i].Nome);
            }
            SB.AppendLine(")");
            SB2.AppendLine(")");
            SB.AppendLine(SB2.ToString());
            SQLiteCommand comando = new SQLiteCommand(SB.ToString());
            foreach (SQLiteParameter p in MontarParametersSQLite(valores, 'v'))
            {
                comando.Parameters.Add(p);
            }

            return comando;
        }

        internal static SQLiteCommand MontarDeleteSQLite(string tabela, List<Parametros> condicoes)
        {
            StringBuilder SB = new StringBuilder();
            SB.Append("DELETE FROM " + tabela);
            SB.Append(" WHERE ");
            if (condicoes.Count == 0)
            {
                return null;
            }
            SB.Append(MontarCondicaoWhereSQLite(condicoes));
            SQLiteCommand comando = new SQLiteCommand(SB.ToString());
            foreach (SQLiteParameter p in MontarParametersSQLite(condicoes, 'c'))
            {
                comando.Parameters.Add(p);
            }
            return comando;
        }

        internal static SQLiteCommand MontarUpdateSQLite(string tabela, List<Parametros> condicoes, List<Parametros> valores)
        {
            if (condicoes.Count == 0)
                return null;
            if (valores.Count == 0)
                return null;
            StringBuilder SB = new StringBuilder();

            SB.Append("UPDATE " + tabela);
            SB.Append(" SET ");
            for (int i = 0; i < valores.Count; i++)
            {
                if (i > 0)
                    SB.Append(", ");
                SB.Append(valores[i].Nome + "=@v" + valores[i].Nome);
            }
            SB.Append(" WHERE ");
            SB.Append(MontarCondicaoWhereSQLite(condicoes));
            SQLiteCommand comando = new SQLiteCommand(SB.ToString());
            foreach (SQLiteParameter p in MontarParametersSQLite(valores, 'v'))
            {
                comando.Parameters.Add(p);
            }
            foreach (SQLiteParameter p in MontarParametersSQLite(condicoes, 'c'))
            {
                comando.Parameters.Add(p);
            }

            return comando;
        }

        internal static void IniciarTransactionSQLite(SQLiteConnection ConexaoBanco)
        {
            if (ConexaoBanco.State != ConnectionState.Open)
                ConexaoBanco.Open();
            transactionSqlite = ConexaoBanco.BeginTransaction();
        }

        internal static void FinalizarTransactionCommitSQLite(SQLiteConnection ConexaoBanco)
        {
            transactionSqlite.Commit();
            ConexaoBanco.Close();
        }

        internal static void FinalizarTransactionRollbackSQLite(SQLiteConnection ConexaoBanco)
        {
            transactionSqlite.Rollback();
            ConexaoBanco.Close();
        }

        public static void ExecutarTransactionSQLite(List<SQLiteCommand> ListaComandos, SQLiteConnection ConexaoBanco)
        {
            ConexaoBanco.Open();
            using (SQLiteTransaction tr = ConexaoBanco.BeginTransaction())
            {
                try
                {
                    foreach (SQLiteCommand comando in ListaComandos)
                    {
                        comando.Connection = ConexaoBanco;
                        comando.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                }
            }
            ConexaoBanco.Close();
        }

        #endregion
    }
}
