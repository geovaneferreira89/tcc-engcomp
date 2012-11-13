using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbienteRPB
{
    public partial class FormEditorDePadroes : Form
    {
        private GerenArquivos Arquivos;
        public FormEditorDePadroes()
        {
            InitializeComponent();
        }

        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                chart1.ChartAreas.Add("Padrao");
                chart1.Series.Add("Serie01");
                chart1.Series["Serie01"].ChartArea = "Padrao";
                chart1.Series["Serie01"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                // Arquivos.ImportarPadraoArquivo(openFile.FileName, chart1);
                // chart = _Chart as System.Windows.Forms.DataVisualization.Charting.Chart;
                System.IO.StreamReader fileR = new System.IO.StreamReader(openFile.FileName);
                string dados;
                dados = fileR.ReadLine();
                dados = dados.Substring(22);
                dados = dados.Substring(0, dados.Length - 1);
                int NumeroDeAmostras = Convert.ToInt16(dados);
                chart1.Series[0].Color = Color.Red;

                for (int i = 0; i <= NumeroDeAmostras; i++)
                {
                    dados = fileR.ReadLine();
                    string x = dados;
                    string y = dados;
                    int X_ = x.IndexOf(" ");

                    x = x.Substring(3);
                    x = x.Substring(0, X_-4);

                    y = y.Substring(X_ + 3);
                    y = y.Substring(0, y.Length - 1);



                    chart1.Series[0].Points.AddXY(Convert.ToDouble(x), Convert.ToDouble(y));
                }
            }
        }
    }
}
