using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Controls;
using AForge.Neuro;
using AForge.Neuro.Learning;
using AForge;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kohonen Teste");

            //Exemplo que agrupa cor RGB

            // set neurons weights randomization range
            Neuron.RandRange = new DoubleRange( 0, 255 );

            // create network
            DistanceNetwork network = new DistanceNetwork( 3, 100 * 100 );

            // create learning algorithm
            SOMLearning trainer = new SOMLearning( network );

            // input
            double[] input = new double[3];

            int i = 0;
            int iterations = 3;

            while ( i < iterations )
            {
                // update learning rate and radius
                // prepare network input
                input[0] = 3;
                input[1] = 5;
                input[2] = 7;

                // run learning iteration
                trainer.Run( input );
                i++;
            }

            double[] vetor = network.Output; //isso deve ser a saída

            int j = 0;
            for (j = 0; j < vetor.Length; j++)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Ge\Desktop\koho\arq.txt", true))
                {
                    file.WriteLine(vetor[j]);
                }
            }

           


        }
    }
}
