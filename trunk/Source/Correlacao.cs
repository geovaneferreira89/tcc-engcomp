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
        private delegate void AtualizaChart(int caso, int canal, EdfFile SinalEEG, string opcao, double[] vector_evento, float inicio_, float fim_, int numeroDeCanais_);
        private System.Windows.Forms.DataVisualization.Charting.Chart prb = null;
        private VerticalLineAnnotation Cursor_vertical_Inicio;
        private VerticalLineAnnotation Cursor_vertical_Corr2;
        //Controles Progress Bar-------------------------------------------------------------------
        private Control _BarraDeProgresso = null;
        private delegate void AtualizaPloter(int valor, int caso);
        private System.Windows.Forms.ProgressBar prgbar = null;
        //Controles Scroll Bar --------------------------------------------------------------------
        private Control _ScrollBar = null;
        private delegate void ScrollBar_Propriedades(int _canal, EdfFile SinalEEG);
        private System.Windows.Forms.ScrollBar ScrollBar;
        //Arquivos EDF-----------------------------------------------------------------------------
        private EdfFile edfFileOutput;
        private int Canal;
        private int NumeroDeCanais;
        //correlacao
        private string Opcao;
        private double[] Vector_evento;
        private float inicio;
        private float fim;
        private GerenArquivos GerArquivos;
        private double[] Escala;
        private string auxString;
        //-----------------------------------------------------------------------------------------
        public Correlacao(Control Grafico, Control BarraDeProgresso, Control ScrollBar, EdfFile _edfFileOutput, int _Canal, string _opcao, double[] _vector_evento, float _inicio, float _fim, int _NumeroDeCanais, double[] _Escala, string _auxString)
        {
            _Grafico          = Grafico;
            _BarraDeProgresso = BarraDeProgresso;
            _ScrollBar        = ScrollBar;
            edfFileOutput     = _edfFileOutput;
            Canal             = _Canal;
            Opcao             = _opcao;
            Vector_evento     = _vector_evento;
            NumeroDeCanais    = _NumeroDeCanais;
            inicio            = _inicio;
            fim               = _fim;
            Escala            = _Escala;
            auxString = _auxString;
        }
        //-----------------------------------------------------------------------------------------
        public void Inicializa()
        {
            GerArquivos = new GerenArquivos();
            if (edfFileOutput != null)
            {
                if (Opcao == "PlotaSinalEEG")
                {
                    Plotar(2, Canal, null, Opcao, Vector_evento,inicio,fim, NumeroDeCanais);
                    Plotar(1, Canal, edfFileOutput, Opcao, Vector_evento,inicio,fim, NumeroDeCanais);
                    FuncScrollBar_Propriedades(Canal, edfFileOutput);
                }
                if (Opcao == "Correlacao")
                    Plotar(0, Canal, edfFileOutput, Opcao, Vector_evento, inicio,fim, NumeroDeCanais);

                if (Opcao == "CarregarTodoSinal")
                {
                    Plotar(0, Canal, edfFileOutput, Opcao, Escala, inicio, fim, NumeroDeCanais);
                    Plotar(0, Canal, edfFileOutput, "Correlacao", Vector_evento, inicio, fim, NumeroDeCanais);    
                    Plotar(0, Canal, edfFileOutput, "CorrigirAmplitude", Vector_evento, inicio, fim, NumeroDeCanais);
                }
                if (Opcao == "Correlacao_AGAIN")
                {
                    Plotar(0, Canal, edfFileOutput, Opcao, Vector_evento, inicio, fim, NumeroDeCanais);
                }
                if (Opcao == "Marcacoes")
                {
                    Plotar(0, Canal, edfFileOutput, "CarregarTodoSinal", Vector_evento, inicio, fim, NumeroDeCanais);
                    Plotar(0, Canal, edfFileOutput, Opcao, Escala, inicio, fim, NumeroDeCanais);                    
                }
                
                if (Opcao == "Resultado")
                {
                    Plotar(0, Canal, edfFileOutput, "Resultado", Vector_evento, inicio, fim, NumeroDeCanais);
                }
            }
        }
       
        //------------------------------------------------------------------------------------------
        private void Plotar(int caso, int canal, EdfFile SinalEEG, string opcao, double[] vector_evento, float inicio_, float fim_, int numeroDeCanais_) 
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] { caso, canal, SinalEEG, opcao, vector_evento, inicio_, fim_, numeroDeCanais_ });
            }
            else
            {
                switch(opcao)
                {
                    case ("Resultado"):
                        {
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                            load_progress_bar(0, 4);
                            load_progress_bar(canal, 2);
                            for (int CanalX = 0; CanalX < canal; CanalX++)
                            {
                                int tam = prb.Series[(CanalX * 4) + 2].Points.Count();
                                int ponto = 0;
                                prb.Series[(CanalX * 4) + 3].Color = Color.Blue;
                                for (int i = 0; i < tam; i++)
                                {
                                    if (vector_evento[ponto] == i)
                                    {
                                        prb.Series[(CanalX * 4) + 3].Points.AddY(1);
                                        ponto++;
                                    }
                                    else
                                        prb.Series[(CanalX * 4) + 3].Points.AddY(0);
                                }
                                load_progress_bar(0, 1);
                            }
                            load_progress_bar(1, 3);
                            break;
                        }
                    case("PlotaSinalEEG"):
                        {
                            float excluir;
                            if (caso == 1)
                            {
                                if (prb != null)
                                {
                                    load_progress_bar(10, 2);
                                    for (int k = 0; k < 10; k++)
                                    {
                                        edfFileOutput.ReadDataBlock(k);
                                        for (int j = 0; j < numeroDeCanais_; j++)
                                        {
                                            for (int i = 0; i < SinalEEG.SignalInfo[j].NrSamples; i++)
                                            {
                                                if (j == (canal / 4))
                                                    prb.Series["canal" + canal].Points.AddY(SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
                                                else
                                                    excluir = SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]; 
                                            }
                                            load_progress_bar(0, 1);
                                        }
                                    }
                                }
                                prb.Titles[canal].Text = SinalEEG.SignalInfo[(canal/4)].SignalLabel;
                                prb.Series["canal" + canal].Color = Color.FromName("Black");

                                prb.Titles[(canal + 1)].Text = "CORRL" + ((canal/4) + 1);
                                prb.Series["canal" + (canal + 1)].Color = Color.Green;

                                prb.Titles[(canal + 2)].Text = "RN" + ((canal/4) + 1);
                                prb.Series["canal" + (canal + 2)].Color = Color.Red;

                                prb.Titles[(canal + 3)].Text = "RN" + ((canal / 4) + 2);
                                prb.Series["canal" + (canal + 3)].Color = Color.Red;

                                load_progress_bar(1, 3);
                            }
                            if (caso == 2)
                            {
                                prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                                prb.Series.Add("canal" + canal);
                                prb.Series["canal" + canal].ChartArea = "canal" + canal;
                                prb.Series["canal" + canal].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                prb.Legends.Clear();
                                prb.Titles.Add("canal" + canal);
                                prb.Titles[canal].Position.Height = 3;
                                prb.Titles[canal].Position.Width = 40;
                                prb.Titles[canal].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[canal].Position.X = 0;
                                prb.Titles[canal].Position.Y = prb.ChartAreas[canal].Position.Y;
                                prb.ChartAreas[canal].AxisX.ScrollBar.Enabled = false;

                                prb.Series.Add("canal" + (canal + 1));
                                prb.Series["canal" + (canal+1)].ChartArea = "canal" + (canal+1);
                                prb.Series["canal" + (canal + 1)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                prb.Titles.Add("canal" + (canal + 1));
                                prb.Titles[(canal + 1)].Position.Height = 3;
                                prb.Titles[(canal + 1)].Position.Width = 40;
                                prb.Titles[(canal + 1)].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[(canal + 1)].Position.X = 0;
                                prb.Titles[(canal + 1)].Position.Y = prb.ChartAreas[canal+1].Position.Y;
                                prb.ChartAreas[canal+1].AxisX.ScrollBar.Enabled = false;


                                prb.Series.Add("canal" + (canal + 2));
                                prb.Series["canal" + (canal + 2)].ChartArea = "canal" + (canal + 2);
                                prb.Series["canal" + (canal + 2)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                prb.Titles.Add("canal" + (canal + 2));
                                prb.Titles[(canal + 2)].Position.Height = 3;
                                prb.Titles[(canal + 2)].Position.Width = 40;
                                prb.Titles[(canal + 2)].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[(canal + 2)].Position.X = 0;
                                prb.Titles[(canal + 2)].Position.Y = prb.ChartAreas[canal+2].Position.Y;
                                prb.ChartAreas[canal+2].AxisX.ScrollBar.Enabled = false;


                                prb.Series.Add("canal" + (canal + 3));
                                prb.Series["canal" + (canal + 3)].ChartArea = "canal" + (canal + 3);
                                prb.Series["canal" + (canal + 3)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                prb.Titles.Add("canal" + (canal + 3));
                                prb.Titles[(canal + 3)].Position.Height = 3;
                                prb.Titles[(canal + 3)].Position.Width = 40;
                                prb.Titles[(canal + 3)].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[(canal + 3)].Position.X = 0;
                                prb.Titles[(canal + 3)].Position.Y = prb.ChartAreas[canal+3].Position.Y;
                                prb.ChartAreas[canal+3].AxisX.ScrollBar.Enabled = false;

                            }
                            break;
                    }
                    //-----------------------------------------
                    case("Correlacao"):{
                        prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                        load_progress_bar(0, 4);
                        load_progress_bar(vector_evento.Count(), 2);
                        float res = 0;
                        float MaxY = 0;
                        float MinY = 0;
                        float Media = 0;
                        double[] Amplitude = new double[2];
                        //===================================================================
                        //                  Primeira etapa de correlação
                        //===================================================================
                        bool first = true;
                        //Calculo do fator de normalização (K)
                        //Igual à soma dos quadrados dos valores da réplica armazenada.
                        double K = 0;
                        for (int i = 0; i < vector_evento.Count(); i++)
                        {
                            K = (vector_evento[i]*vector_evento[i]) + K; 
                            load_progress_bar(0, 1);
                        }
                        //Prepara a barra de progresso
                        load_progress_bar(0, 4);
                        load_progress_bar(vector_evento.Count() * prb.Series[canal].Points.Count(), 2);
                        //Canal que está sendo amostrado
                        for (int i = 0; i < (prb.Series[canal].Points.Count - vector_evento.Count()); i++)
                        {
                            //Vetor do Evento
                            for (int j = 0; j < vector_evento.Count(); j++)
                            {
                                //Se j+1 tem que ser menor que o tamanho do canal... 
                                if ((j + i) < prb.Series[canal].Points.Count)
                                    res = (float)((prb.Series[canal].Points[j + i].YValues[0] * vector_evento[j])) + res;
                                //Incrementa a barra de progresso
                                load_progress_bar(0, 1);
                            }
                            res = (float)((1/K)*res);
                            //Vai Plotando o resultado...
                            if (first)
                            {
                                //Corrige o problema do sinal ficar estar defasado
                                for (int kk = 0; kk < (vector_evento.Count()/2); kk++)
                                    prb.Series[canal + 1].Points.AddY(res);
                                first = false;
                            }
                            //Vai Plotando o resultado...
                            prb.Series[canal + 1].Points.AddY(res);
                            Media = Media + res;
                            res = 0;
                        }
                        //Adiciona linha vertical em zero
                        HorizontalLineAnnotation Zero_correla = new HorizontalLineAnnotation();
                        Zero_correla.AnchorDataPoint = prb.Series[canal+1].Points[1];
                        Zero_correla.Width = prb.ChartAreas[canal + 1].Position.Width;
                        Zero_correla.Height = 2;
                        Zero_correla.LineDashStyle = ChartDashStyle.Dot;
                        Zero_correla.LineColor = System.Drawing.Color.SkyBlue;
                        Zero_correla.LineWidth = 1;
                        Zero_correla.AnchorX = prb.ChartAreas[canal].AxisX.Minimum;
                        Zero_correla.AnchorY = 0;
                        prb.Annotations.Add(Zero_correla);
                        //Adiciona linha vertical Maximo em Y
                        HorizontalLineAnnotation Max_correla = new HorizontalLineAnnotation();
                        Max_correla.AnchorDataPoint = prb.Series[canal + 1].Points[1];
                        Max_correla.Width = prb.ChartAreas[canal + 1].Position.Width;
                        Max_correla.Height = 2;
                        Max_correla.LineDashStyle = ChartDashStyle.Dot;
                        Max_correla.LineColor = System.Drawing.Color.SkyBlue;
                        Max_correla.LineWidth = 1;
                        Max_correla.AnchorX = prb.ChartAreas[canal].AxisX.Minimum;
                        Max_correla.AnchorY = MaxY;
                        prb.Annotations.Add(Max_correla);
                        
                        //Adiciona linha vertical Minimo em Y
                        HorizontalLineAnnotation Min_correla = new HorizontalLineAnnotation();
                        Min_correla.AnchorDataPoint = prb.Series[canal + 1].Points[1];
                        Min_correla.Width = prb.ChartAreas[canal + 1].Position.Width;
                        Min_correla.Height = 2;
                        Min_correla.LineDashStyle = ChartDashStyle.Dot;
                        Min_correla.LineColor = System.Drawing.Color.SkyBlue;
                        Min_correla.LineWidth = 1;
                        Min_correla.AnchorX = prb.ChartAreas[canal].AxisX.Minimum;
                        Min_correla.AnchorY = MinY;
                        prb.Annotations.Add(Min_correla);

                        //Adiciona linha vertical Média em Y
                        HorizontalLineAnnotation Med_correla = new HorizontalLineAnnotation();
                        Med_correla.AnchorDataPoint = prb.Series[canal + 1].Points[1];
                        Med_correla.Width = prb.ChartAreas[canal + 1].Position.Width;
                        Med_correla.Height = 2;
                        Med_correla.LineDashStyle = ChartDashStyle.Dash;
                        Med_correla.LineColor = System.Drawing.Color.Blue;
                        Med_correla.LineWidth = 1;
                        Med_correla.AnchorX = prb.ChartAreas[canal].AxisX.Minimum;
                        Med_correla.AnchorY = Media/prb.Series[canal+1].Points.Count;
                        prb.Annotations.Add(Med_correla);

                        //desabilita a barra de progresso
                        load_progress_bar(1, 3);
                        break;
                    }
                    case ("Correlacao_AGAIN"):
                    {
                        prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                        load_progress_bar(vector_evento.Count(), 2);
                        float res = 0;
                        float Media = 0;
                        double[] SaidaDeDados = new double[prb.Series["canal" + (canal + 1)].Points.Count];
                        //===================================================================
                        //                     nova correlação
                        //===================================================================   
                        //Calculo do fator de normalização (K)
                        //Igual à soma dos quadrados dos valores da réplica armazenada.
                        double K = 0;
                        load_progress_bar(0, 4);
                        load_progress_bar(vector_evento.Count() * prb.Series["canal" + (canal + 1)].Points.Count(), 2);
                        //Canal que está sendo amostrado
                        res = 0;
                        for (int i = 0; i < vector_evento.Count(); i++)
                        {
                            double valor = prb.Series["canal" + (canal + 1)].Points[Convert.ToInt16(inicio) + i].YValues[0];
                            K = (valor * valor) + K;
                        }
                        //Este vetor evento tem que ser referente a correlação...
                        for (int i = 0; i < prb.Series["canal" + (canal + 1)].Points.Count - vector_evento.Count(); i++)
                        {
                            //Vetor do Evento
                            for (int j = 0; j < vector_evento.Count(); j++)
                            {
                                double valor;
                                //Se j+1 tem que ser menor que o tamanho do canal... 
                                if ((j + i) < prb.Series["canal" + (canal + 1)].Points.Count)
                                {
                                    valor = prb.Series["canal" + (canal + 1)].Points[Convert.ToInt16(inicio) + j].YValues[0];
                                    res = (float)((prb.Series["canal" + (canal + 1)].Points[i+j].YValues[0] * valor) + res);
                                }
                                //Incrementa a barra de progresso
                                load_progress_bar(0, 1);
                            }
                            res = (float)((1 / K) * res);
                            //Vai Plotando o resultado...
                            SaidaDeDados[i] = res;
                            Media = Media + res;
                            res = 0;
                        }
       
                        //Saida dos Resultados da correlação pela correlação!
                        //Limpa o canal da correlação e ajuste o offset
                        prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                        prb.Series.Remove(prb.Series["canal" + (canal + 1)]);
                        prb.Series.Add("canal" + (canal + 1));
                        prb.Series["canal" + (canal + 1)].ChartArea = "canal" + (canal + 1);
                        prb.Series["canal" + (canal + 1)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                        prb.Series["canal" + (canal + 1)].Color = Color.Green;

                        for (int i = 0; i < (vector_evento.Count() / 2); i++)
                            prb.Series["canal" + (canal + 1)].Points.AddY(SaidaDeDados[0]);

                        load_progress_bar(1, 3);
                        load_progress_bar(0, 4);
                        load_progress_bar((SaidaDeDados.Count() - vector_evento.Count()), 2);
                        //Imprime o resultado fina;             
                        for (int i = 0; i < (SaidaDeDados.Count() -vector_evento.Count()); i++)
                        {
                            prb.Series["canal" + (canal + 1)].Points.AddY(SaidaDeDados[i]);
                            load_progress_bar(0, 1);
                        }
                        
                        double MaxY = 0, MinY = 0;
                        if (prb.Series["canal" + (canal + 1)].Points.Count >= 6000)
                        {

                            for (int i = 0; i < 6000; i++)
                            {
                                if (i <= 6000)
                                {
                                    if (MaxY < prb.Series["canal" + (canal + 1)].Points[i].YValues[0] || i == 0)
                                        MaxY = prb.Series["canal" + (canal + 1)].Points[i].YValues[0];
                                    if (MinY > prb.Series["canal" + (canal + 1)].Points[i].YValues[0] || i == 0)
                                        MinY = prb.Series["canal" + (canal + 1)].Points[i].YValues[0];
                                }
                                prb.ChartAreas["canal" + (canal + 1)].AxisY.Maximum = MaxY;
                                prb.ChartAreas["canal" + (canal + 1)].AxisY.Minimum = MinY;
                            }
                        }

                        load_progress_bar(1, 3);
                        break;
                    }
                    //-----------------------------------------
                   case("CarregarTodoSinal"):{
                       int DataRecords_lidos = (int)vector_evento[0];

                        prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                        load_progress_bar(0, 4);
                        if (DataRecords_lidos < edfFileOutput.FileInfo.NrDataRecords)
                        {
                            load_progress_bar(edfFileOutput.FileInfo.NrDataRecords - DataRecords_lidos, 2);
                            while (DataRecords_lidos < edfFileOutput.FileInfo.NrDataRecords)
                            {
                                int excluir;
                                edfFileOutput.ReadDataBlock(DataRecords_lidos);
                                DataRecords_lidos++;
                                //Cada ao fim deste for, é adiciocionado somente 1s em todos os canais
                                for (int j = 0; j < numeroDeCanais_; j++)
                                {
                                    for (int i = 0; i < SinalEEG.SignalInfo[j].NrSamples; i++)
                                    {
                                        if (j == (canal / 3))
                                            prb.Series["canal" + canal].Points.AddY(SinalEEG.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i]);
                                        else
                                            excluir = edfFileOutput.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i];
                                    }
                                }
                                //Incrementa a barra de progresso
                                load_progress_bar(0, 1);
                            }
                            prb.ChartAreas[canal].AxisY.Maximum = vector_evento[1];
                            prb.ChartAreas[canal].AxisY.Minimum = vector_evento[2];
                        }
                        load_progress_bar(1, 3);
                       break;
                    }
                   //-----------------------------------------
                   //Corrige a amplitude
                  case("CorrigirAmplitude"):{
                      prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                      if (prb.Series[Canal + 1].Points.Count >= 6000)
                      {
                          double MaxY=0, MinY=0;
                          for (int i = 0; i < 6000; i++)
                          {
                              if (i <= 6000)
                              {
                                  if (MaxY < prb.Series[Canal + 1].Points[i].YValues[0] || i == 0)
                                      MaxY = prb.Series[Canal + 1].Points[i].YValues[0];
                                  if (MinY > prb.Series[Canal + 1].Points[i].YValues[0] || i == 0)
                                      MinY = prb.Series[Canal + 1].Points[i].YValues[0];
                              }
                              prb.ChartAreas[canal + 1].AxisY.Maximum = MaxY;
                              prb.ChartAreas[canal + 1].AxisY.Minimum = MinY;
                          }
                      }
                      break;  
                  }
                  //-----------------------------------------
                  case ("Marcacoes"):
                  {
                       prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                        GerenArquivos Arquivos = new GerenArquivos();
                        Arquivos.LerMarcacao(auxString);
                        load_progress_bar(0, 4);
                        load_progress_bar(Arquivos.Samples.Count(), 2);
                        for (long i = 0; i <Arquivos.Samples.Count(); i++)
                        {
                            LineAnnotation annotationRectangle = new LineAnnotation();
                            annotationRectangle.BackColor = Color.FromArgb(128, Color.Green);
                            annotationRectangle.AxisX = prb.ChartAreas[Canal].AxisX;
                            annotationRectangle.AxisY = prb.ChartAreas[Canal].AxisY;
                            annotationRectangle.X = Arquivos.Samples[i];
                            annotationRectangle.Y = prb.ChartAreas[Canal].AxisY.Maximum;
                            annotationRectangle.LineColor = Color.FromArgb(128, Color.Green);
                            annotationRectangle.ToolTip = "1";
                            annotationRectangle.Height = prb.ChartAreas[Canal].Position.Height * 4;
                            annotationRectangle.Width = 0;
                            annotationRectangle.AllowMoving = false;
                            annotationRectangle.AllowAnchorMoving = false;
                            annotationRectangle.AllowSelecting = false;
                            prb.Annotations.Add(annotationRectangle);
                            //Incrementa a barra de progresso
                            load_progress_bar(0, 1);
                        }
                        load_progress_bar(1, 3);
                        break;
                    }
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
                prgbar = _BarraDeProgresso as System.Windows.Forms.ProgressBar;
                if (caso == 1)
                {
                    if (prgbar != null)
                    {
                        prgbar.Increment(1);
                    }
                }
                if (caso == 2)  
                {
                    prgbar.Visible = true;
                    prgbar.Maximum = valor;
                }
                if(caso == 3)
                    prgbar.Visible = false;
                if (caso == 4)
                    prgbar.Value = 0;
            }
        }
        //------------------------------------------------------------------------------------------
        private void FuncScrollBar_Propriedades(int _canal, EdfFile SinalEEG)
        {
            if (_ScrollBar.InvokeRequired)
            {
                _ScrollBar.BeginInvoke(new ScrollBar_Propriedades(FuncScrollBar_Propriedades), new Object[] { _canal, SinalEEG });
            }
            else
            {
                ScrollBar = _ScrollBar as System.Windows.Forms.ScrollBar;
                ScrollBar.Enabled = true;

                int valor = (SinalEEG.SignalInfo[0].NrSamples * 10)/ (int)SinalEEG.FileInfo.SampleRecDuration;
                prb.ChartAreas[_canal].AxisX.ScaleView.Size = valor;
                prb.ChartAreas[_canal].AxisX.ScrollBar.Enabled = false;

                prb.ChartAreas[_canal + 1].AxisX.ScaleView.Size = valor;
                prb.ChartAreas[_canal + 1].AxisX.ScrollBar.Enabled = false;

                prb.ChartAreas[_canal + 2].AxisX.ScaleView.Size = valor;
                prb.ChartAreas[_canal + 2].AxisX.ScrollBar.Enabled = false;

                 prb.ChartAreas[_canal + 3].AxisX.ScaleView.Size = valor;
                 prb.ChartAreas[_canal + 3].AxisX.ScrollBar.Enabled = false;

                ScrollBar.Maximum = (SinalEEG.FileInfo.NrDataRecords) * (int)SinalEEG.FileInfo.SampleRecDuration;
                ScrollBar.SmallChange = 10;//segundos
                ScrollBar.LargeChange = 10;//segundos       
                ScrollBar.Value = 0;
            }
        }
        //------------------------------------------------------------------------------------------
    }
}