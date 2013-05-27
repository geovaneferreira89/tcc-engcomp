using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using NeuroLoopGainLibrary.Edf;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;

namespace AmbienteRPB
{
    public class Correlacao
    {
        //Controles Chart--------------------------------------------------------------------------
        private Control _Grafico = null;
        private delegate void AtualizaChart(int caso, int canal, EdfFile SinalEEG);
        private System.Windows.Forms.DataVisualization.Charting.Chart prb = null;
        //Controles Progress Bar-------------------------------------------------------------------
        private Control _BarraDeProgresso = null;
        private delegate void AtualizaPloter(int valor, int caso);
        private System.Windows.Forms.ProgressBar prgbar = null;
        //Controles Scroll Bar --------------------------------------------------------------------
        private Control _ScrollBar = null;
        private delegate void ScrollBar_Propriedades(int num_volta, EdfFile SinalEEG);
        private System.Windows.Forms.ScrollBar ScrollBar;
        //Arquivos EDF-----------------------------------------------------------------------------
        private EdfFile edfFileOutput;
        private int Canal;
        //-----------------------------------------------------------------------------------------
        public Correlacao(Control Grafico, Control BarraDeProgresso, Control ScrollBar, EdfFile _edfFileOutput, int _Canal)
        {
            _Grafico          = Grafico;
            _BarraDeProgresso = BarraDeProgresso;
            _ScrollBar        = ScrollBar;
            edfFileOutput     = _edfFileOutput;
            Canal             = _Canal;
        }
        //-----------------------------------------------------------------------------------------
        public void Inicializa()
        {
            if (edfFileOutput != null)
            {
                Plotar(2, Canal, null);
                Plotar(1, Canal, edfFileOutput);
              //  FuncScrollBar_Propriedades(1, edfFileOutput);
            }
        }
     //------------------------------------------------------------------------------------------
        private void Plotar(int caso, int canal, EdfFile SinalEEG) 
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] { caso, canal, SinalEEG });
            }
            else
            {
                float excluir;
                int tempo = 0;
                if (caso == 1)
                {
                    if (prb != null)
                    {
                        load_progress_bar(10, 2);
                        for (int k = 0; k < 10; k++)
                        {
                            edfFileOutput.ReadDataBlock(k);
                            for (int j = 0; j < SinalEEG.SignalInfo.Count; j++)
                            {
                                for (int i = 0; i < 256; i++)
                                {
                                    if (j == canal)
                                        prb.Series["canal" + canal].Points.AddY(SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
                                    else
                                       excluir = SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]; 
                                }
                                tempo = 256 + tempo;
                                load_progress_bar(0, 1);
                            }
                        }
                    }  
                    prb.Titles[0].Text = SinalEEG.SignalInfo[canal].SignalLabel;
                    prb.Series["canal" + canal].Color = Color.FromName("Black");
                  
                    load_progress_bar(1, 3);
                }
                //---------------------------               
                if (caso == 2)
                {
                    prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                    prb.Series.Add("canal" + canal);
                    prb.Series["canal" + canal].ChartArea = "canal" + canal;
                    prb.Series["canal" + canal].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    prb.Legends.Clear();
                    prb.Titles.Add("canal" + canal);
                    prb.Titles[canal].DockedToChartArea = "canal" + canal;
                    prb.Titles[canal].Position.Height = 3;
                    prb.Titles[canal].Position.Width = 40;
                    prb.Titles[canal].Alignment = ContentAlignment.MiddleLeft;
                    prb.Titles[canal].Position.X = 0;
                    prb.Titles[canal].Position.Y = prb.ChartAreas[canal].Position.Y;
                }
            }
        }
        //------------------------------------------------------------------------------------------
        private void load_progress_bar(int valor, int caso)
        {

            if (_BarraDeProgresso.InvokeRequired)
            {
                _BarraDeProgresso.BeginInvoke(new AtualizaPloter(load_progress_bar), new Object[] { valor, caso });
            }
            else
            {
                if (caso == 1)
                {
                    if (prgbar != null)
                    {
                        prgbar.Increment(1);
                    }
                }
                if (caso == 2)  
                {
                    prgbar = _BarraDeProgresso as System.Windows.Forms.ProgressBar;
                    prgbar.Visible = true;
                    prgbar.Maximum = valor;
                }
                if(caso == 3)
                    prgbar.Visible = false;
            }
        }
        //------------------------------------------------------------------------------------------
        private void FuncScrollBar_Propriedades(int num_volta, EdfFile SinalEEG)
        {
            if (_ScrollBar.InvokeRequired)
            {
                _ScrollBar.BeginInvoke(new ScrollBar_Propriedades(FuncScrollBar_Propriedades), new Object[] {num_volta,  SinalEEG});
            }
            else
            {
                ScrollBar = _ScrollBar as System.Windows.Forms.ScrollBar;
                ScrollBar.Enabled = true;
                for (int i = 0; i < 3; i++)
                {
                    prb.ChartAreas[i].AxisX.ScaleView.Size = 2500;
                    prb.ChartAreas[i].AxisX.ScrollBar.Enabled = false;
                }
                ScrollBar.Maximum =  (SinalEEG.FileInfo.NrDataRecords/10);
                ScrollBar.SmallChange = 10;//segundos
                ScrollBar.LargeChange = 10;//segundos            
            }
        }
        //------------------------------------------------------------------------------------------

    }

}