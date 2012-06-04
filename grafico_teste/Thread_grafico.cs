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
        private int _NumCanais = 1;
        private delegate void AtualizaChart(double x, double y, int caso, int _VarchartArea_);
        private System.Windows.Forms.DataVisualization.Charting.Chart prb = null;
        //-------------------------------------------------------------
        public atualiza_sinal(Control Controle, int NumCanais)
        {
            _Grafico = Controle;
            _NumCanais = NumCanais;
        }
        //-------------------------------------------------------------
        public void Inicializa()
        {
                    for (int i = 0; i < _NumCanais; i++)
                    {
                        Plotar(0, 0, 2, i);
                        double j = 0;
                        while (j < 10)
                        {
                            Plotar(j, Math.Sin(j), 1, i);
                            j += 0.3;
                             Thread.Sleep(50);
                        }
                }
        }
        //-------------------------------------------------------------
        private void Plotar(double x, double y, int caso, int _NumCanais_)
        {
            // Verificamos se estamos na thread da UI.
            if (_Grafico.InvokeRequired)
            {
                // Não estamos na thread da UI. Invocamos a thread da UI através da delegada AtualizaRichTextBox
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] { x, y, caso, _NumCanais_ });
            }
            else
            {
                if (caso == 1)
                {
                    if (prb != null)
                    {
                        prb.Series["canal" + _NumCanais_].Points.AddXY(x, y);
                    }
                }
                if (caso == 2)
                {
                    prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                    prb.Series.Add("canal" + _NumCanais_);
                    prb.Series["canal" + _NumCanais_].Color = Color.Red;
                    prb.Series["canal" + _NumCanais_].ChartArea = "canal" + _NumCanais_;
                    prb.Series["canal" + _NumCanais_].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    prb.Legends.Clear();
                }

            }
        }
        //-------------------------------------------------------------
    }
}