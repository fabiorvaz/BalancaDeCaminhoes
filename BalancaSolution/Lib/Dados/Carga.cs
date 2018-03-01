using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancaSolution.Lib.Dados
{
    class Carga
    {
        public int Numero {get; set;}
        public float Volumes { get; set; }
        public float Peso { get; set; }

        public Carga()
        { }

        public Carga(int n, float v, float p)
        {
            Numero = n;
            Volumes = v;
            Peso = p;
        }
    }
}
