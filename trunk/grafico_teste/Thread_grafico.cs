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
        private Control _BarraDeProgresso = null;
        private int _NumCanais = 0;
        private delegate void AtualizaChart(double x, double y, int caso, int _VarchartArea_);
        private System.Windows.Forms.DataVisualization.Charting.Chart prb = null;
        private System.Windows.Forms.ProgressBar prgbar = null;

        //-------------------------------------------------------------
        public atualiza_sinal(Control Controle,int NumCanais)
        {
            _Grafico = Controle;
            _NumCanais = NumCanais;
          //  _BarraDeProgresso = BarraDeProgresso;
        }
        //-------------------------------------------------------------
        public void Inicializa()
        {
                    for (int i = 0; i < _NumCanais; i++)
                    {
                        Plotar(0, 0, 2, i);
                        double j = 0;
                        while (j < 20)
                        {
                            if(i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21)
                                Plotar(j, Math.Sin(j), 1, i);
                            if(i == 1 || i == 4 || i == 7 || i == 10|| i == 13 || i == 16 || i == 19|| i == 22)
                                Plotar(j, Math.Cos(j), 1, i);
                            if(i == 2 || i == 5 || i == 8|| i == 11 || i == 14 || i == 17 || i == 20|| i == 23)
                                Plotar(j, Math.Tan(j), 1, i);
                        

                            j += 0.3;
                            Thread.Sleep(1);
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