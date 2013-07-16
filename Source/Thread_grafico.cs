/**
 * @file Thread_grafico.cd
 * 
 *
 * \brief   Implementação dos métodos de plotagem
 * \details Este arquivo apresenta a implementação dos métodos de plotagem do sinal EEG na tela 
 * 
 * @version 1.0
 * @date    05/2012
 * @author  Geovane Vinicius Ferreira (email: geovanevinicius89@gmail.com)
 */
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

namespace thread_chart
{
    public class atualiza_sinal
    {
        //Controles Chart--------------------------------------------------------------------------
        private Control _Grafico = null;
        private delegate void AtualizaChart(int caso, int canal, EdfFile SinalEEG,int NumeroDeCanais);
        private System.Windows.Forms.DataVisualization.Charting.Chart prb = null;
        //Controles Progress Bar--------------------------------------------------------------------
        private Control _BarraDeProgresso = null;
        private delegate void AtualizaPloter(int valor, int caso);
        private System.Windows.Forms.ProgressBar prgbar = null;
        // Controles Projeto-----------------------------------------------------------------------
        private Control _ControleProjeto = null;
        private System.Windows.Forms.ToolStrip ControleProjeto = null;
        private delegate void AtualizaControleProjeto(string caso);
        //Status do Projeto------------------------------------------------------------------------
        private Control _StatusProjeto = null;
        private System.Windows.Forms.StatusStrip StatusProjeto = null;
        private delegate void AtualizaStatusProjeto(string SMS, int caso);
        //amostras sinal de teste-------------------------------------------------------------------
        private int _NumCanais = 0;
        //Controles sobre o sinal a exibir----------------------------------------------------------
        private string OpcaoSinal;
        //Controles Scroll Bar ---------------------------------------------------------------------
        private Control _ScrollBar = null;
        private delegate void ScrollBar_Propriedades(int num_volta, EdfFile SinalEEG);
        private System.Windows.Forms.ScrollBar ScrollBar;
        //Arquivos EDF-----------------------------------------------------------------------------
        private EdfFile edfFileOutput;
        //-----------------------------------------------------------------------------------------
        public atualiza_sinal(Control Controle, int NumCanais, Control BarraDeProgresso, Control __ControleProjeto, Control __StatusProjeto, string _OpcaoSinal, EdfFile __edfFileOutput, Control __ScrollBar)
        {
            edfFileOutput     = __edfFileOutput;
            _Grafico          = Controle;
            _NumCanais        = NumCanais;
            _BarraDeProgresso = BarraDeProgresso;
            _ControleProjeto  = __ControleProjeto;
            _StatusProjeto    = __StatusProjeto;
            OpcaoSinal        = _OpcaoSinal;
            _ScrollBar        = __ScrollBar;
        }
        //------------------------------------------------------------------------------------------
        public void Inicializa()
        {
            switch (OpcaoSinal) 
            {
                case("Projeto_EDF"):
                {
                    if (edfFileOutput != null)
                    {
                        for (int k = 0; k < _NumCanais; k++) 
                        {
                            Plotar(2, k, null, _NumCanais);
                        }
                        Plotar(1, 0, edfFileOutput,_NumCanais);
                        FuncScrollBar_Propriedades(1, edfFileOutput);
                     }
                    break;
                }
            }
        }
        //------------------------------------------------------------------------------------------
        private void Plotar(int caso, int canal, EdfFile SinalEEG, int NumeroDeCanais) 
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] { caso, canal, SinalEEG, NumeroDeCanais });
            }
            else
            {
                if (caso == 1)
                {
                    if (prb != null)
                    {
                        load_progress_bar(10, 2);
                        int NumeroDeBlocosLer = 10;
                        if (NumeroDeCanais == 1)
                            NumeroDeBlocosLer = edfFileOutput.DataBuffer.Count();
                        for (int k = 0; k < 10; k++)
                        {
                            edfFileOutput.ReadDataBlock(k);
                            for (int j = 0; j < NumeroDeCanais; j++)
                            {
                                for (int i = 0; i < SinalEEG.SignalInfo[j].NrSamples; i++)
                                {
                                    if (SinalEEG.SignalInfo[j].NrSamples != SinalEEG.SignalInfo[0].NrSamples)
                                    { //hypnograma
                                       for (int Histo = 0; Histo < (SinalEEG.SignalInfo[0].NrSamples / SinalEEG.SignalInfo[j].NrSamples); Histo++)
                                            prb.Series["canal" + j].Points.AddY(SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
                                      // i = SinalEEG.SignalInfo[j].NrSamples;
                                    }
                                    else
                                        prb.Series["canal" + j].Points.AddY(SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
                                }
                            }
                        }
                    }
                    for (int i = 0; i < NumeroDeCanais; i++)
                    {
                        prb.Titles[i].Text = SinalEEG.SignalInfo[i].SignalLabel;
                        prb.Series["canal" + i].Color = Color.FromName("Black");
                    }
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
        //----------------------------------------------------------------------------------------  
        private void FuncAtualizaControleProjeto(string caso)
        {
            if (_ControleProjeto.InvokeRequired)
            {
                _ControleProjeto.BeginInvoke(new AtualizaControleProjeto(FuncAtualizaControleProjeto), new Object[] { caso });
            }
            else
            {
                if (caso == "Des_btn_Suspender")
                {
                    ControleProjeto = _ControleProjeto as System.Windows.Forms.ToolStrip;
                    ControleProjeto.Items["btn_Suspender"].Enabled = false;
                }
           }
        }
        //------------------------------------------------------------------------------------------
        private void FuncAtualizaStatusProjeto(string SMS, int caso)
        {
            if (_StatusProjeto.InvokeRequired)
            {
                _StatusProjeto.BeginInvoke(new AtualizaStatusProjeto(FuncAtualizaStatusProjeto), new Object[] { SMS, caso });
            }
            else
            {
                if (caso == 0)
                {
                    StatusProjeto = _StatusProjeto as System.Windows.Forms.StatusStrip;
                    StatusProjeto.Items["lbl_ferramentaAtiva"].ForeColor = Color.MediumSeaGreen;
                    StatusProjeto.Items["lbl_ferramentaAtiva"].Text = "Ferramenta ativa: Imporando sinais";
                }
                if (caso == 1)
                {
                    StatusProjeto.Items["lbl_ferramentaAtiva"].ForeColor = Color.Green;
                    StatusProjeto.Items["lbl_ferramentaAtiva"].Text = "Sinais Importados.";
                }
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

                int valor = SinalEEG.SignalInfo[0].NrSamples * 10;
                if (7 <= _NumCanais)
                {
                    if (SinalEEG.SignalInfo[4].NrSamples != SinalEEG.SignalInfo[0].NrSamples)
                        valor = 1000;
                }
                
                for (int i = 0; i < _NumCanais; i++)
                {
                     prb.ChartAreas[i].AxisX.ScaleView.Size = valor;
                     prb.ChartAreas[i].AxisX.ScrollBar.Enabled = false;
                }
             
                ScrollBar.Maximum =  (SinalEEG.FileInfo.NrDataRecords);
                ScrollBar.SmallChange = 10;//segundos
                ScrollBar.LargeChange = 10;//segundos            
            }
        }
        //------------------------------------------------------------------------------------------

    }

}