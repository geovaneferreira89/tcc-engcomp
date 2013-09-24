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
            inicio = horario - 50;
            fim = horario + 50;
            detectada = false;
        }
    }
}
