﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbienteRPB
{
    class AV_Resultado
    {
        public double horario;
        public bool correta;

        public void Tratar(double h)
        {
            horario = h;
            correta = false;
        }
    }
}
