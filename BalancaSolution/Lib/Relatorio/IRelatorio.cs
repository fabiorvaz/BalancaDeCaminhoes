using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.Relatorio
{
    interface IRelatorio
    {
        string VisualizarRelatorio();
        void PrepararDados();
        void ImprimirRelatorio();
        void MontarRelatorio();
    }
}
