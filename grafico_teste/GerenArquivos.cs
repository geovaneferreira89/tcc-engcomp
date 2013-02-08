using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EDF;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace AmbienteRPB
{
    class GerenArquivos
    {
        private System.Windows.Forms.DataVisualization.Charting.Chart chart = null;
        private System.IO.StreamWriter fileW;
        private System.IO.StreamReader fileR;
        private EDFFile edfFileInput;
        private EDFFile edfFileOutput;
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
        public int Abrir_Projeto(string diretorio)
        {
            fileR = new System.IO.StreamReader(diretorio);
            string dados;
            dados = fileR.ReadLine();
            dados = dados.Substring(15);
            dados = dados.Substring(0, dados.Length - 1);
            MessageBox.Show("Projeto:\n" + diretorio + "\n\n"+dados,
               "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Convert.ToInt32(dados);
        }
        //Abrir Projeto EDF  -----------------------------------------------------------------
        public EDFFile Abrir_Projeto_EDF(string diretorio)
        {
            FormCarregar_EDF formEDF = new FormCarregar_EDF(diretorio);
            formEDF.ShowDialog();
            edfFileOutput = formEDF.edfFileOutput;
            return edfFileOutput;
        }
        //Exportao Padrao   -----------------------------------------------------------------
        public void ExportarPadraoArquivo(string nomePadrao, Control _Chart, HitTestResult canal, PointF Padrao_Inicio, PointF Padrao_Fim)
        {
            chart = _Chart as System.Windows.Forms.DataVisualization.Charting.Chart;
            fileW = new System.IO.StreamWriter(nomePadrao + ".txt", true);
            fileW.WriteLine("[Numero de Amostras = " +  (Padrao_Fim.X - Padrao_Inicio.X) + "]"); 
            for(int i = 0; (i + Padrao_Inicio.X <= Padrao_Fim.X); i++)
            {
                int J = Convert.ToInt16(Padrao_Inicio.X) + i;
                fileW.WriteLine(chart.Series[canal.ChartArea.Name].Points[J]);
            }
            fileW.Close();
        }
        //Importar Padraoes  -----------------------------------------------------------------
        public void ImportarPadraoArquivo(string nomePadrao, Control _Chart)
        {
            chart = _Chart as System.Windows.Forms.DataVisualization.Charting.Chart;
            fileR = new System.IO.StreamReader(nomePadrao);
            string dados;
            dados = fileR.ReadLine();
            dados = dados.Substring(22);
            dados = dados.Substring(0, dados.Length - 1);
            int NumeroDeAmostras = Convert.ToInt16(dados);
            chart.Series[0].Color = Color.Red;
                      
            for (int i = 0; i <= NumeroDeAmostras; i++)
            {
                dados = fileR.ReadLine();
                string x = dados;
                string y = dados;
                int X_ = x.IndexOf(" ");
                
                x = x.Substring(3);
                x = x.Substring(0, X_);

                y = y.Substring(X_+2);
                y = y.Substring(0, y.Length - 1);



              chart.Series[0].Points.AddXY(Convert.ToDouble(x),Convert.ToDouble(y));
            }
        }
        //----------------------------------------------------------------------------------

    }
}
