﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Cria entradas
            List<double> resultados = new List<double> {10, 20, 31, 40, 50, 55, 60, 80, 90};
            List<double> marcacoes = new List<double> {10, 20, 30, 40, 50, 60, 70, 80, 90};


            //Avalia
            Avaliador avaliador = new Avaliador();
            avaliador.Avaliar(resultados, marcacoes);


            //Saída
            Console.WriteLine("vamos testar");
            for (int i = 0; i < avaliador.VP.Count(); i++)
            {
                Console.WriteLine("VP " + i + ": " + avaliador.VP[i]);
            }

            for (int i = 0; i < avaliador.FP.Count(); i++)
            {
                Console.WriteLine("FP " + i + ": " + avaliador.FP[i]);
            }

            for (int i = 0; i < avaliador.FN.Count(); i++)
            {
                Console.WriteLine("FN " + i + ": " + avaliador.FN[i]);
            }

            for (int i = 0; i < avaliador.VN.Count(); i++)
            {
                Console.WriteLine("VN " + i + ": " + avaliador.VN[i]);
            }

            Console.ReadKey();

        }
    }
}
