using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbienteRPB
{
    class AV_Marcacao
    {
        public double horario;
        public double inicio;
        public double fim;
        public bool detectada;

        public void Tratar(double h)
        {
            horario = h;
            inicio = horario - 2;
            fim = horario + 2;
            detectada = false;
        }
    }
}
