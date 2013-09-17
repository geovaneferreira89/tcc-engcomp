using System;
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
            List<double> resultados = new List<double> {0, 0, 0, 1, 0, 0, 0, 1};
            List<double> marcacoes = new List<double> {0, 0, 0, 1, 0, 0, 0, 1};


            //Avalia
            Avaliador avaliador = new Avaliador();
            avaliador.Avaliar(resultados, marcacoes);


            //Saída
            Console.WriteLine("vamos testar");
            for (int i = 0; i < avaliador.VP.Count(); i++)
            {
                Console.WriteLine("VP " + i + ": " + avaliador.VP[i]);
            }
            Console.ReadKey();

        }
    }
}
