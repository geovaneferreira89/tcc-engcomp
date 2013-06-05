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
        private delegate void AtualizaChart(int caso, int canal, EdfFile SinalEEG, string opcao, double[] vector_evento);
        private System.Windows.Forms.DataVisualization.Charting.Chart prb = null;
        private VerticalLineAnnotation Cursor_vertical_Inicio; 
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
        //correlacao
        private string Opcao;
        private double[] Vector_evento;
        //-----------------------------------------------------------------------------------------
        public Correlacao(Control Grafico, Control BarraDeProgresso, Control ScrollBar, EdfFile _edfFileOutput, int _Canal, string _opcao, double[] _vector_evento)
        {
            _Grafico          = Grafico;
            _BarraDeProgresso = BarraDeProgresso;
            _ScrollBar        = ScrollBar;
            edfFileOutput     = _edfFileOutput;
            Canal             = _Canal;
            Opcao             = _opcao;
            Vector_evento     = _vector_evento;
        }
        //-----------------------------------------------------------------------------------------
        public void Inicializa()
        {
            if (edfFileOutput != null)
            {
                if (Opcao == "PlotaSinalEEG")
                {
                    Plotar(2, Canal, null, Opcao, Vector_evento);
                    Plotar(1, Canal, edfFileOutput, Opcao, Vector_evento);
                    FuncScrollBar_Propriedades(Canal, edfFileOutput);
                }
                if (Opcao == "Correlacao")
                    Plotar(0, Canal, edfFileOutput, Opcao, Vector_evento);

                if (Opcao == "CarregarTodoSinal")
                    Plotar(0, Canal, edfFileOutput, Opcao, Vector_evento);
            }
        }
       
        //------------------------------------------------------------------------------------------
        private void Plotar(int caso, int canal, EdfFile SinalEEG, string opcao, double[] vector_evento) 
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] { caso, canal, SinalEEG, opcao, vector_evento });
            }
            else
            {
                switch(opcao)
                {
                    case("PlotaSinalEEG"):
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
                                                if (j == (canal/3))
                                                    prb.Series["canal" + canal].Points.AddY(SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
                                                else
                                                   excluir = SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]; 
                                            }
                                            tempo = 256 + tempo;
                                            load_progress_bar(0, 1);
                                        }
                                    }
                                }
                                prb.Titles[canal].Text = SinalEEG.SignalInfo[(canal/3)].SignalLabel;
                                prb.Series["canal" + canal].Color = Color.FromName("Black");

                                prb.Titles[(canal + 1)].Text = "CORRL" + ((canal/3) + 1);
                                prb.Series["canal" + (canal + 1)].Color = Color.Green;

                                prb.Titles[(canal + 2)].Text = "CORRL" + ((canal/3) + 2);
                                prb.Series["canal" + (canal + 2)].Color = Color.Red;
                  
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
                                prb.Titles[canal].DockedToChartArea = "canal" + canal;
                                prb.Titles[canal].Position.Height = 3;
                                prb.Titles[canal].Position.Width = 40;
                                prb.Titles[canal].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[canal].Position.X = 0;
                                prb.Titles[canal].Position.Y = prb.ChartAreas[canal].Position.Y;

                                prb.Series.Add("canal" + (canal + 1));
                                prb.Series["canal" + (canal+1)].ChartArea = "canal" + (canal+1);
                                prb.Series["canal" + (canal + 1)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                prb.Titles.Add("canal" + (canal + 1));
                                prb.Titles[(canal + 1)].DockedToChartArea = "canal" + (canal +1);
                                prb.Titles[(canal + 1)].Position.Height = 3;
                                prb.Titles[(canal + 1)].Position.Width = 40;
                                prb.Titles[(canal + 1)].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[(canal + 1)].Position.X = 0;
                                prb.Titles[(canal + 1)].Position.Y = prb.ChartAreas[(canal +1)].Position.Y;

                                prb.Series.Add("canal" + (canal + 2));
                                prb.Series["canal" + (canal + 2)].ChartArea = "canal" + (canal + 2);
                                prb.Series["canal" + (canal + 2)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                prb.Titles.Add("canal" + (canal + 2));
                                prb.Titles[(canal + 2)].DockedToChartArea = "canal" + (canal + 2);
                                prb.Titles[(canal + 2)].Position.Height = 3;
                                prb.Titles[(canal + 2)].Position.Width = 40;
                                prb.Titles[(canal + 2)].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[(canal + 2)].Position.X = 0;
                                prb.Titles[(canal + 2)].Position.Y = prb.ChartAreas[(canal + 2)].Position.Y;
                            }
                            break;
                    }
                    //-----------------------------------------
                    case("Correlacao"):{
                        prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                        load_progress_bar(0, 4);
                        load_progress_bar(vector_evento.Count(), 2);
                        float res = 0;
                        double K = 0;
                        float MaxY = 0;
                        float MaxX = 0;
                        //===================================================================
                        //                  Primeira etapa de correlação
                        //===================================================================     
                        for (int i = 0; i < vector_evento.Count(); i++)
                        {
                            K = (vector_evento[i]*vector_evento[i]) + K; 
                            load_progress_bar(0, 1);
                        }
                        load_progress_bar(0, 4);
                        load_progress_bar(vector_evento.Count() * prb.Series[canal].Points.Count(), 2);
                        //Canal que está sendo amostrado
                        for (int i = 0; i < prb.Series[canal].Points.Count; i++)
                        {
                            //Vetor do Evento
                            for (int j = 0; j < vector_evento.Count(); j++)
                            {
                                //Se j+1 tem que ser menor que o tamanho do canal... 
                                if ((j + i) < prb.Series[canal].Points.Count)
                                {
                                    res = (float)((prb.Series[canal].Points[j + i].YValues[0] * vector_evento[j])) + res;
                                }
                                //Incrementa a barra de progresso
                                load_progress_bar(0, 1);
                            }
                            res = (float)((1/K)*res);
                            if (MaxY < res)
                            {
                                MaxY = res;
                                MaxX = i;
                                //Deleta linha se já tiver, ou cria uma nova
                                if (Cursor_vertical_Inicio == null)
                                    Cursor_vertical_Inicio = new VerticalLineAnnotation();
                                else
                                    prb.Annotations.Remove(Cursor_vertical_Inicio);
                                //Linha no Chart
                                Cursor_vertical_Inicio.AnchorDataPoint = prb.Series[canal].Points[1];
                                Cursor_vertical_Inicio.Height = prb.ChartAreas[canal].Position.Height *3;
                                Cursor_vertical_Inicio.LineColor = Color.Blue;
                                Cursor_vertical_Inicio.LineWidth = 1;
                                Cursor_vertical_Inicio.AnchorX = MaxX;
                                Cursor_vertical_Inicio.AnchorY = prb.ChartAreas[canal].AxisY.Maximum;
                                prb.Annotations.Add(Cursor_vertical_Inicio);
                            }
                            //Vai Plotando o resultado...
                            prb.Series[canal + 1].Points.AddY(res);
                            res = 0;
                        }
                        //desabilita a barra de progresso
                        load_progress_bar(1, 3);
                        //Inicia a segunda tecnica de correlação... 
                        //FAZER  prb.Series[canal + 2].Points.AddY(res);
                        DialogResult resposta = MessageBox.Show("Deseja iniciar a segunda correlação?\n", "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.YesNo);
                        //===================================================================
                        //                  Segunda etapa de correlação
                        //===================================================================                        
                        if (resposta == DialogResult.Yes)
                        {
                            load_progress_bar(0, 4);
                            load_progress_bar(vector_evento.Count(), 2);
                            load_progress_bar(vector_evento.Count() * prb.Series[canal + 1].Points.Count(), 2);
                            //Canal que está sendo amostrado
                            res = 0;
                            for (int i = 0; i < prb.Series[canal +1].Points.Count; i++)
                            {
                                //Vetor do Evento
                                for (int j = 0; j < vector_evento.Count(); j++)
                                {
                                    //Se j+1 tem que ser menor que o tamanho do canal... 
                                    if ((j + i) < prb.Series[canal+1].Points.Count)
                                    {
                                        res = (float)((prb.Series[canal+1].Points[j + i].YValues[0] * vector_evento[j])) + res;
                                    }
                                    //Incrementa a barra de progresso
                                    load_progress_bar(0, 1);
                                }
                                res = (float)((1 / K) * res);
                                if (MaxY < res)
                                {
                                    MaxY = res;
                                    MaxX = i;
                                    //Deleta linha se já tiver, ou cria uma nova
                                    if (Cursor_vertical_Inicio == null)
                                        Cursor_vertical_Inicio = new VerticalLineAnnotation();
                                    else
                                        prb.Annotations.Remove(Cursor_vertical_Inicio);
                                    //Linha no Chart
                                    Cursor_vertical_Inicio.AnchorDataPoint = prb.Series[canal].Points[1];
                                    Cursor_vertical_Inicio.Height = prb.ChartAreas[canal].Position.Height * 3;
                                    Cursor_vertical_Inicio.LineColor = Color.Red;
                                    Cursor_vertical_Inicio.LineWidth = 1;
                                    Cursor_vertical_Inicio.AnchorX = MaxX;
                                    Cursor_vertical_Inicio.AnchorY = prb.ChartAreas[canal].AxisY.Maximum;
                                    prb.Annotations.Add(Cursor_vertical_Inicio);
                                }
                                //Vai Plotando o resultado...
                                prb.Series[canal + 2].Points.AddY(res);
                                res = 0;
                            }
                        }
                        //desabilita a barra de progresso
                        load_progress_bar(1, 3);
                        break;
                    }
                    //-----------------------------------------
                   case("CarregarTodoSinal"):{
                       int DataRecords_lidos = (int)vector_evento[0];

                        prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                        load_progress_bar(0, 4);
                        load_progress_bar(edfFileOutput.FileInfo.NrDataRecords - DataRecords_lidos, 2);
                        while (DataRecords_lidos < edfFileOutput.FileInfo.NrDataRecords)
                        {
                            int excluir;
                            int tempo = DataRecords_lidos * 256;
                            edfFileOutput.ReadDataBlock(DataRecords_lidos);
                            DataRecords_lidos++;
                            //Cada ao fim deste for, é adiciocionado somente 1s em todos os canais
                            for (int j = 0; j < edfFileOutput.SignalInfo.Count; j++)
                            {
                                for (int i = 0; i < 256; i++)
                                {
                                    if (j == (canal/3))
                                        prb.Series["canal" + canal].Points.AddY(SinalEEG.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i]);
                                    else
                                        excluir = edfFileOutput.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i];
                                }
                            }
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

                prb.ChartAreas[_canal].AxisX.ScaleView.Size = 2500;
                prb.ChartAreas[_canal].AxisX.ScrollBar.Enabled = false;

                prb.ChartAreas[_canal + 1].AxisX.ScaleView.Size = 2500;
                prb.ChartAreas[_canal + 1].AxisX.ScrollBar.Enabled = false;

                prb.ChartAreas[_canal + 2].AxisX.ScaleView.Size = 2500;
                prb.ChartAreas[_canal + 2].AxisX.ScrollBar.Enabled = false;
               
                ScrollBar.Maximum =  (SinalEEG.FileInfo.NrDataRecords/10);
                ScrollBar.SmallChange = 10;//segundos
                ScrollBar.LargeChange = 10;//segundos       
                ScrollBar.Value = 0;
            }
        }
        //------------------------------------------------------------------------------------------
    }
}