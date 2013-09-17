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

        List<Resultado> resultados = new List<Resultado>();
        List<Marcacao> marcacoes = new List<Marcacao>();

        // VP: QRS detectado
        // FP: não QRS detectado
        // VN: não QRS não detectado, entre dois VP/QRS
        // FN: QRS não detectado
        // aumentar o vetor dos eventos marcados para esquerda e para direita

        public void Avaliar(List<double> results, List<double> annotations) //resultados RN e marcações
        {
            // Tratar resultados
            Resultado res;
            for (int i = 0; i < results.Count(); i++)       // percorre o vetor de marcações já que ele é a referência
            {
                res = new Resultado();
                res.Tratar(results[i]);
                resultados.Add(res);
            }

            // Tratar marcações
            Marcacao marc;
            for (int i = 0; i < annotations.Count(); i++)   // percorre o vetor de marcações já que ele é a referência
            {
                marc = new Marcacao();
                marc.Tratar(annotations[i]);
                marcacoes.Add(marc);    
            }

           // Percorrer a lista de marcacoes
            for (int i = 0; i < marcacoes.Count(); i++)     // percorre o vetor de marcações já que ele é a referência
            {
                for(int j = 0; j < resultados.Count(); j++)
                {
                    // marcação e resultado
                    if((resultados[j].horario <= marcacoes[i].inicio) && (resultados[j].horario <= marcacoes[i].fim)) //dentro do intervalo da marcação
                    {
                        resultados[j].correta = true;       // resultado correto
                        marcacoes[i].detectada = true;      // marcacao detectada
                    }
                }
            }

            double aux;
            for (int i = 0; i < marcacoes.Count(); i++)
            {
                if(marcacoes[i].detectada == true)
                {
                    // VP
                    aux = new double();
                    aux = marcacoes[i].horario;
                    VP.Add(aux);
                }
                else
                {
                    // FN
                    aux = new double();
                    aux = marcacoes[i].horario;
                    FN.Add(aux);
                }

            }

            for (int i = 0; i < resultados.Count(); i++)
            {
                if(resultados[i].correta == false)
                {
                    // FP
                    aux = new double();
                    aux = resultados[i].horario;
                    FP.Add(aux);
                }
            }

            // VN: entre duas marcações em que não há FP
            // entre o fim de uma e o início de outra
            for (int i = 0; i < marcacoes.Count(); i++)
            {

                for (int j = 0; j < resultados.Count(); j++)
                {
                    //if(resultados[j].horario >= marcacoes[i].fim) (resultados[j].horario <= marcacoes[i+1].inicio)
                    //{
                    //}
                }
            }

        }




    }
}
