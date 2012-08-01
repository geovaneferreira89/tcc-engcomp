using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace grafico_teste
{
    class GerenArquivos
    {
        private System.Windows.Forms.DataVisualization.Charting.Chart chart = null;
        private System.IO.StreamWriter fileW;
        private System.IO.StreamReader fileR;
        //Salvar Projeto Como ----------------------------------------------------------------
        public void Salva_Projeto(string diretorio, int __numeroDeCanais, Control _Chart)
        {
             
            chart = _Chart as System.Windows.Forms.DataVisualization.Charting.Chart;
            string Dados_Saida; //= {"[NumDeCanais = X]","[Canal 1 = XXXXXXXX]","[Canal 2 = YYYYYY]"};
            Dados_Saida = "[NumDeCanais = " + __numeroDeCanais + "]";
            fileW = new System.IO.StreamWriter(diretorio,true);
            fileW.WriteLine(Dados_Saida);
            for (int i = 0; i < __numeroDeCanais; i++)
            {
                Dados_Saida = " ";
                fileW.WriteLine(Dados_Saida);
                Dados_Saida = "[Canal " + i + "]";
                fileW.WriteLine(Dados_Saida);
                Dados_Saida = "[Num de Pontos = " + chart.Series[i].Points.Count + "]";
                fileW.WriteLine(Dados_Saida);
                for (int j = 0; j < chart.Series[i].Points.Count; j++)
                {
                    Dados_Saida = "" + chart.Series[i].Points[j];
                    fileW.WriteLine(Dados_Saida);
                }
            }
            fileW.Close();
            MessageBox.Show("Projeto:\n" + diretorio + "\n\nSalvado com sucesso!",
               "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Abrir Projeto  --------------------------------------------------------------------
        public void Abrir_Projeto(string diretorio)
        {
            fileR = new System.IO.StreamReader(diretorio);
        }
        //Abrir Projeto EDF  -----------------------------------------------------------------
        public void Abrir_Projeto_EDF(string diretorio)
        {

        }
    }
}
