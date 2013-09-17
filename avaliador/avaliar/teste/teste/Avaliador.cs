using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste
{
    class Avaliador
    {
        public List<double> VP = new List<double>();
        public List<double> VN = new List<double>();
        public List<double> FP = new List<double>();
        public List<double> FN = new List<double>();

        List<Mark> marcacoes = new List<Mark>();

        //VP: QRS detectado
        //FP: não QRS detectado
        //VN: não QRS não detectado, entre dois VP/QRS
        //FN: QRS não detectado
        //aumentar o vetor dos eventos marcados para esquerda e para direita

        public void Avaliar(List<double> results, List<double> annotations) //resultados RN e marcações
        {

            //tratar marcações: são expandidas
            Mark mark;
            for (int i = 0; i < annotations.Count(); i++)
            {
                mark = new Mark(annotations[i]);
                marcacoes.Add(mark);
            }

            //percorrer marcações tratadas
            for (int i = 0; i < marcacoes.Count(); i++)
            {
                for (int j = 0; j < results.Count(); j++)
                {
                    if( (results[j] >= marcacoes[i]) && (results[j] <= marcacoes[i]) )
                    {
                        if (marcacoes[i].detectada == false)
                        {
                            marcacoes[i].detectada = true;
                        }
                    }
                  
                }
            }


        }




    }
}
