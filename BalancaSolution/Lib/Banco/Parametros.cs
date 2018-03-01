using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.Banco
{
    public class Parametros
    {
        #region variaveis

        /// <summary>
        /// nome do campo no banco
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// valor a ser usado
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// tipo do dado para formatação
        /// </summary>
        public TipoDeDadosBD Tipo { get; set; }

        /// <summary>
        /// Operador logico a ser usado.
        /// Só será valido quando o operador não for o primeiro da lista e quando a operação permitir
        /// </summary>
        public OperadorLogico OperadorL { get; set; }

        /// <summary>
        /// Operador comparativo a ser usado.
        /// </summary>
        public OperadorComparativo OperadorC { get; set; }

        /// <summary>
        /// lista de parametros quando for ajuntamento
        /// </summary>
        public List<Parametros> listaParametros { get; set; }

        #endregion

        /// <param name="n">Nome da coluna</param>
        /// <param name="v">Valor esperado ou a ser incluido</param>
        public Parametros(string n, string v)
        {
            Nome = n;
            Valor = v;
            Tipo = TipoDeDadosBD.auto;
            OperadorL = OperadorLogico.AND;
            OperadorC = OperadorComparativo.EQUALS;
            listaParametros = null;
        }

        /// <param name="n">Nome da coluna</param>
        /// <param name="v">Valor esperado ou a ser incluido</param>
        /// <param name="c">Valor do operador comparativo</param>
        public Parametros(string n, string v, OperadorComparativo c)
        {
            Nome = n;
            Valor = v;
            Tipo = TipoDeDadosBD.auto;
            OperadorL = OperadorLogico.AND;
            OperadorC = c;
            listaParametros = null;
        }

        /// <param name="n">Nome da coluna</param>
        /// <param name="v">Valor esperado ou a ser incluido</param>
        /// <param name="t">Tipo do dado</param>
        public Parametros(string n, string v, TipoDeDadosBD t)
        {
            Nome = n;
            Valor = v;
            Tipo = t;
            OperadorL = OperadorLogico.AND;
            OperadorC = OperadorComparativo.EQUALS;
            listaParametros = null;
        }

        /// <param name="n">Nome da coluna</param>
        /// <param name="v">Valor esperado ou a ser incluido</param>
        /// <param name="t">Tipo do dado</param>
        /// <param name="c">Valor do operador comparativo</param>
        public Parametros(string n, string v, TipoDeDadosBD t, OperadorComparativo c)
        {
            Nome = n;
            Valor = v;
            Tipo = t;
            OperadorL = OperadorLogico.AND;
            OperadorC = c;
            listaParametros = null;
        }

        /// <param name="n">Nome da coluna</param>
        /// <param name="v">Valor esperado ou a ser incluido</param>
        /// <param name="o">Valor do operador logico</param>
        public Parametros(string n, string v, OperadorLogico o)
        {
            Nome = n;
            Valor = v;
            Tipo = TipoDeDadosBD.auto;
            OperadorC = OperadorComparativo.EQUALS;
            OperadorL = o;
            listaParametros = null;
        }

        /// <param name="n">Nome da coluna</param>
        /// <param name="v">Valor esperado ou a ser incluido</param>
        /// <param name="o">Valor do operador logico</param>
        /// <param name="c">Valor do operador comparativo</param>
        public Parametros(string n, string v, OperadorLogico o, OperadorComparativo c)
        {
            Nome = n;
            Valor = v;
            Tipo = TipoDeDadosBD.auto;
            OperadorL = o;
            OperadorC = c;
            listaParametros = null;
        }

        /// <param name="n">Nome da coluna</param>
        /// <param name="v">Valor esperado ou a ser incluido</param>
        /// <param name="t">Tipo do dado</param>
        /// <param name="o">Valor do operador logico</param>
        public Parametros(string n, string v, TipoDeDadosBD t, OperadorLogico o)
        {
            Nome = n;
            Valor = v;
            Tipo = t;
            OperadorL = o;
            OperadorC = OperadorComparativo.EQUALS;
            listaParametros = null;
        }

        /// <param name="n">Nome da coluna</param>
        /// <param name="v">Valor esperado ou a ser incluido</param>
        /// <param name="t">Tipo do dado</param>
        /// <param name="o">Valor do operador logico</param>
        /// <param name="c">Valor do operador comparativo</param>
        public Parametros(string n, string v, TipoDeDadosBD t, OperadorLogico o, OperadorComparativo c)
        {
            Nome = n;
            Valor = v;
            Tipo = t;
            OperadorL = o;
            OperadorC = c;
            listaParametros = null;
        }

        /// <param name="lp">Lista de parametros do ajuntamento</param>
        public Parametros(List<Parametros> lp)
        {
            listaParametros = lp;
            OperadorL = OperadorLogico.AND;
            OperadorC = OperadorComparativo.EQUALS;
            Tipo = TipoDeDadosBD.auto;
            Valor = "";
            Nome = "";
        }

        /// <param name="lp">Lista de parametros do ajuntamento</param>
        /// <param name="o">Valor do operador logicoo</param>
        public Parametros(List<Parametros> lp, OperadorLogico o)
        {
            listaParametros = lp;
            OperadorL = o;
            Tipo = TipoDeDadosBD.auto;
            OperadorC = OperadorComparativo.EQUALS;
            Valor = "";
            Nome = "";
        }
    }

    public enum TipoDeDadosBD
    {
        numerico,
        numericoLongo,
        character,
        texto,
        data,
        pontoFlutuante,
        auto
    }

    public enum OperadorLogico
    {
        AND,
        OR
    }

    public enum OperadorComparativo
    {
        LIKE,
        EQUALS,
        BETWEEN,
        IN
    }
}
