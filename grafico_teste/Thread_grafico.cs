﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using EDF;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace thread_chart
{
    public class atualiza_sinal
    {
        //Controles Chart--------------------------------------------------------------------------------------------------------
        private Control _Grafico = null;
        private delegate void AtualizaChart(int caso, int _VarchartArea_, string Cor, string nomeSerie, double []SINAL);
        private System.Windows.Forms.DataVisualization.Charting.Chart prb = null;
        //Controles Progress Bar-------------------------------------------------------------------------------------------------
        private Control _BarraDeProgresso = null;
        private delegate void AtualizaPloter(int valor, int caso);
        private System.Windows.Forms.ProgressBar prgbar = null;
        private bool chave = true;
        private int cont = 0;
        // Controles Projeto------------------------------------------------------------------------------------------------------
        private Control _ControleProjeto = null;
        private System.Windows.Forms.ToolStrip ControleProjeto = null;
        private delegate void AtualizaControleProjeto(string caso);
        //Status do Projeto-------------------------------------------------------------------------------------------------------
        private Control _StatusProjeto = null;
        private System.Windows.Forms.StatusStrip StatusProjeto = null;
        private delegate void AtualizaStatusProjeto(string SMS, int caso);
        //amostras sinal de teste-------------------------------------------------------------------------------------------------
        private int num_de_voltas = 20;
        private double num_de_amostras = 0.2;
        private int _NumCanais = 0;
        //Controles sobre o sinal a exibir----------------------------------------------------------------------------------------
        private string OpcaoSinal;
        //Controles Scroll Bar ----------------------------------------------------------------------------------------
        private Control _ScrollBar = null;
        private delegate void ScrollBar_Propriedades(int num_volta);
        private System.Windows.Forms.ScrollBar ScrollBar;
        //Arquivos EDF----------------------------------------------------------------------------------------
        private EDFFile edfFileOutput;
        //-----------------------------------------------------------------------------------------------------------------
        public atualiza_sinal(Control Controle, int NumCanais, Control BarraDeProgresso, Control __ControleProjeto, Control __StatusProjeto, string _OpcaoSinal, EDFFile __edfFileOutput, Control __ScrollBar)
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
        //-----------------------------------------------------------------------------------------------------------------
        public void Inicializa()
        {
            switch (OpcaoSinal) //Gerar Sinal Aleatorio
            {
                case ("Projeto_NOVO"):
                {
                    /*   for (int i = 0; i < _NumCanais; i++)
                  {
                 Plotar(0, 0, 2, i, " ", " ");
                      load_progress_bar(0, 2);
                      FuncAtualizaStatusProjeto("...Iniciou", 0);
                      double j = 0;
                      int inc = 0;
                      while (j < num_de_voltas)
                      {
                          if (i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21)
                          {
                              Plotar(j, Math.Sin(j), 1, i, "YellowGreen", "Seno");
                          }
                          if (i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22)
                          {
                              Plotar(j, Math.Cos(j), 1, i, "Blue", "Cosseno");
                          }
                          if (i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23)
                          {
                              Plotar(j, Math.Tan(j), 1, i, "Green", "Tangente");
                          }
                          inc++;
                          j += num_de_amostras;
                          Thread.Sleep(0);
                      }
                      load_progress_bar(inc, 1);

                  }
                  while (chave)
                  {
                      load_progress_bar(0, 3);
                      FuncScrollBar_Propriedades(num_de_voltas);
                      FuncAtualizaStatusProjeto("...terminou", 1);
                      FuncAtualizaControleProjeto("Des_btn_Suspender");
                  }*/
                    break;
                } //Fim Case Gerar sinal
                case ("Projeto_RPB"):
                {
                    break;
                }
                case("Projeto_EDF"):
                {
                    //FuncAtualizaStatusProjeto("...Iniciou", 0);
                    if (edfFileOutput != null)
                    {
                        int i = 0;
                        foreach (EDFSignal signal in edfFileOutput.Header.Signals)
                        {
                            Plotar(2, i, " ", " ", null);
                            //load_progress_bar(signal.NumberOfSamplesPerDataRecord, 2);
                            num_de_voltas = 0;
                            //Thread.Sleep(1);
                            double[] Enviar = new double[edfFileOutput.DataRecords.Capacity * 256];
                            foreach (EDFDataRecord dataRecord in edfFileOutput.DataRecords)
                            {
                                foreach (double sample in dataRecord[signal.IndexNumberWithLabel])
                                {
                                    Enviar[num_de_voltas] = sample;
                                    num_de_voltas++;
                                }
                            }
                            Plotar(1, i, "Blue", signal.Label.ToString().Substring(4), Enviar);
                            //load_progress_bar(num_de_voltas, 1);
                            FuncScrollBar_Propriedades(num_de_voltas);
                            i++;
                        }
                            //load_progress_bar(0, 3);
                     }
                    break;
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
        private void Plotar(int caso, int _NumCanais_, string Cor, string nomeSerie, double []SINAL)
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] {caso, _NumCanais_, Cor, nomeSerie, SINAL});
            }
            else
            {
                if (caso == 1)
                {
                    if (prb != null)
                    {
                        prb.Series["canal" + _NumCanais_].Color = Color.FromName(Cor);
                        for (int i = 0; i < SINAL.Length; i++)
                            prb.Series["canal" + _NumCanais_].Points.AddXY(i,SINAL[i]);
                        prb.Titles[_NumCanais_].Text = nomeSerie;
                    }
                }
                if (caso == 2)
                {
                    prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                    prb.Series.Add("canal" + _NumCanais_);
                    prb.Series["canal" + _NumCanais_].ChartArea = "canal" + _NumCanais_;
                    prb.Series["canal" + _NumCanais_].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    prb.Legends.Clear();
                
                    prb.Titles.Add("canal" + _NumCanais_);
                    
                    prb.Titles[_NumCanais_].DockedToChartArea = "canal" + _NumCanais_;
                    prb.Titles[_NumCanais_].Position.Height = 3;
                    prb.Titles[_NumCanais_].Position.Width = 40;
                    prb.Titles[_NumCanais_].Alignment = ContentAlignment.MiddleLeft;
                    prb.Titles[_NumCanais_].Position.X = 0;
                    prb.Titles[_NumCanais_].Position.Y = prb.ChartAreas[_NumCanais_].Position.Height / 2 + prb.ChartAreas[_NumCanais_].Position.Y;
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
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
                    prgbar.Maximum = valor * _NumCanais * 90;
                }
                if(caso == 3)
                    prgbar.Visible = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------------------------
        private void FuncScrollBar_Propriedades(int num_volta)
        {
            if (_ScrollBar.InvokeRequired)
            {
                _ScrollBar.BeginInvoke(new ScrollBar_Propriedades(FuncScrollBar_Propriedades), new Object[] {num_volta });
            }
            else
            {
                ScrollBar = _ScrollBar as System.Windows.Forms.ScrollBar;
                ScrollBar.Enabled = true;
                for (int i = 0; i < _NumCanais; i++)
                {
                    if (OpcaoSinal == "Projeto_EDF")
                    {
                        prb.ChartAreas[i].AxisX.ScaleView.Size = 3000;//num_de_voltas; // 30; //VERIFICAR VALOR! "Frequencia"
                        ScrollBar.Maximum = num_de_voltas;
                    }
                    else
                    {
                        prb.ChartAreas[i].AxisX.ScaleView.Size = 3;
                        ScrollBar.Maximum = num_de_voltas;
                    }
                }
                chave = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

    }
}