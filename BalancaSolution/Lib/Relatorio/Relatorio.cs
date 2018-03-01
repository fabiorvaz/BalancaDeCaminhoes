using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.Relatorio
{
    public class Relatorio 
    {
        public string Html { get; set; }
        protected DataTable Dados { get; set; }
    }
}
