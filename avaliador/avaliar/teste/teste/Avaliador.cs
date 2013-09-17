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

        //VP: QRS detectado
        //FP: não QRS detectado
        //VN: não QRS não detectado, entre dois VP/QRS
        //FN: QRS não detectado
        //aumentar o vetor dos eventos marcados para esquerda e para direita

        public void Avaliar(List<double> results, List<double> annotations) //resultados RN e marcações
        {
            //int aumento = 1; //aumento da marcação
            //double[] aumentado = new double[1 + aumento * 2]; //aumento pra direita e pra esquerda
            double aux;

            for (int i = 0; i < annotations.Count(); i++)//percorre o vetor de marcações já que ele é a referência
            {
                //vai fazer um E lógico, só que com o vetor expandido


                //primeiro expandir o vetor
                //if (annotations[i] == 1)
                //{
                //    for (int j = 0; j < (1 + aumento * 2); j++)
                //    {
                //        aumentado[j] = annotations[i] - aumento + j;
                //    }
                //}


                //com o vetor novo percorremos a list de resultados
                for (int j = 0; j < results.Count(); j++)
                {
                    //for (int k = 0; k < aumentado.Count(); k++)
                    //{
                    //    if (aumentado[k] == results[j]) //VP
                    //    {
                    //        aux = new double();
                    //        aux = aumentado[k];
                    //        VP.Add(aux);
                    //    }
                    //}

                    if ((annotations[i] == 1) && (results[j] == 1))
                    {
                        aux = new double();
                        aux = i;                //salva a posição ou horário do evento
                        VP.Add(aux);
                    }
                }


            }

        }




    }
}
