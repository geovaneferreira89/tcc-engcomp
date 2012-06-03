using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace thread_chart
{
    public class atualiza_sinal
    {
        private Control _Grafico = null;
        private delegate void AtualizaChart(double x, double y, int caso);
        private System.Windows.Forms.DataVisualization.Charting.Chart prb = null;
        //-------------------------------------------------------------
        public atualiza_sinal(Control Controle)
        {
            _Grafico = Controle;
        }
        //-------------------------------------------------------------
        public void Inicializa()
        {
                Plotar(0, 0, 0);
                double i =  0;
                while(i < 100)
                {
                    Plotar(i, Math.Sin(i),1);
                    i = (i + 0.3);
                    Thread.Sleep(50);
                }
        }
        //-------------------------------------------------------------
        private void Plotar(double x, double y, int caso)
        {
            // Verificamos se estamos na thread da UI.
            if (_Grafico.InvokeRequired)
            {
                // Não estamos na thread da UI. Invocamos a thread da UI através da delegada AtualizaRichTextBox
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] { x, y, caso});
            }
            else
            {
                if (caso == 1)
                {
                    if (prb != null)
                    {
                        prb.Series["sinal_1"].Points.AddXY(x, y);
                    }
                }
                else
                {
                    prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                    prb.Series.Clear();
                    prb.Series.Add("sinal_1");
                    prb.Series["sinal_1"].Color = Color.Red;
                    prb.Series["sinal_1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }

            }
        }
        //-------------------------------------------------------------
    }
}