using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NeuroLoopGainLibrary.Edf;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Runtime.InteropServices;
using NeuroLoopGainLibrary.Edf;

namespace AmbienteRPB
{
    public partial class FormResultados : Form
    {
        //-------------------------------------------
        private ListaPadroesEventos[] ListaDeEventos;
        private int numeroDeCanais;
        private GerenArquivos Arquivos;
        private EdfFile edfFileOutput;
        private int CanalAtual = 0;
        private int CanaisCriados = 1;
        private int DataRecords_lidos = 10;
        private int Scroll_Click_Escala_Seg = 10; //tempo em segundos de tela
        private double[] vector_evento;
        public PointF ValorInicio;
        public PointF ValorFim;
        private Thread Thread_;
        private Thread ThreadKohonen;
        private GerenArquivos GerArquivos;
        private bool SMS_Zoom = false;
        private int ID_PadraoAtual;
        //-------------------------------------------
        public FormResultados(ListaPadroesEventos[] _ListaDeEventos, int _numDeCanais, EdfFile _EDF)
        {
            ListaDeEventos = _ListaDeEventos;
            numeroDeCanais = _numDeCanais;
            edfFileOutput  = _EDF;
            Arquivos       = new GerenArquivos();
            InitializeComponent();
        }
        //------------------------------------------------------------------------------------------
        private void FormResultados_Shown(object sender, EventArgs e)
        {
            gbxChart.Height = gbxChart.Height + SMS_Box.Height;
            AdicionaCanais();
            Adiciona_linhas_de_tempo();
            SMS_Box.SelectionStart = SMS_Box.Text.Length;
            SMS_Box.ScrollToCaret();

            Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar,edfFileOutput, CanalAtual,"PlotaSinalEEG",vector_evento, ValorInicio.X, ValorFim.X,  numeroDeCanais);
            Thread Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
            Thread_.Start();
            chart1.Enabled = true;

        }
        //-----------------------------------------------------------------------------------------
        private void AdicionaCanais()
        {
            double Divisao = 100 / (double)4;
            float _aux;
            _aux = (float)Divisao;
            // Primeira serie é o canal 
            // Segundo serie é para a correlação deste canal
            for (int i = 0; i < 4; i++)
            {   //Propriedades de cada sinal
                int _pos = (CanalAtual + i);
                chart1.ChartAreas.Add("canal" + _pos);
                chart1.ChartAreas[_pos].BackColor = Color.Transparent;
                chart1.ChartAreas[_pos].AxisX.Enabled = AxisEnabled.False;
                chart1.ChartAreas[_pos].AxisY.Enabled = AxisEnabled.False;
                chart1.ChartAreas[_pos].Position.Height = _aux;//+10 os sinais sobreescrevem
                chart1.ChartAreas[_pos].Position.Width = 96;
                chart1.ChartAreas[_pos].Position.X = 4;
                chart1.ChartAreas[_pos].Position.Y = _aux * i;
            }
            AdicionaData(0);
        }
        //------------------------------------------------------------------------------------------
        private void Adiciona_linhas_de_tempo()
        {
            //adicionar linhas eixo Y
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation3 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation4 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation5 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation6 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation7 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation8 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation9 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation10 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();

            lineAnnotation1.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation2.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation3.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation4.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation5.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation6.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation7.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation8.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation9.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation10.LineColor = System.Drawing.Color.LightGray;

            lineAnnotation1.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation2.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation3.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation4.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation5.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation6.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation7.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation8.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation9.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation10.LineDashStyle = ChartDashStyle.Dash;

            lineAnnotation1.ToolTip = "1";
            lineAnnotation2.ToolTip = "1";
            lineAnnotation3.ToolTip = "1";
            lineAnnotation4.ToolTip = "1";
            lineAnnotation5.ToolTip = "1";
            lineAnnotation6.ToolTip = "1";
            lineAnnotation7.ToolTip = "1";
            lineAnnotation8.ToolTip = "1";
            lineAnnotation9.ToolTip = "1";
            lineAnnotation10.ToolTip = "1";

            lineAnnotation1.X = 4;
            lineAnnotation2.X = 4 + 9.6 * 1;
            lineAnnotation3.X = 4 + 9.6 * 2;
            lineAnnotation4.X = 4 + 9.6 * 3;
            lineAnnotation5.X = 4 + 9.6 * 4;
            lineAnnotation6.X = 4 + 9.6 * 5;
            lineAnnotation7.X = 4 + 9.6 * 6;
            lineAnnotation8.X = 4 + 9.6 * 7;
            lineAnnotation9.X = 4 + 9.6 * 8;
            lineAnnotation10.X = 4 + 9.6 * 9;

            lineAnnotation1.Width = 0;
            lineAnnotation1.Y = 0;
            lineAnnotation2.Width = 0;
            lineAnnotation2.Y = 0;
            lineAnnotation3.Width = 0;
            lineAnnotation3.Y = 0;
            lineAnnotation4.Width = 0;
            lineAnnotation4.Y = 0;
            lineAnnotation5.Width = 0;
            lineAnnotation5.Y = 0;
            lineAnnotation6.Width = 0;
            lineAnnotation6.Y = 0;
            lineAnnotation7.Width = 0;
            lineAnnotation7.Y = 0;
            lineAnnotation8.Width = 0;
            lineAnnotation8.Y = 0;
            lineAnnotation9.Width = 0;
            lineAnnotation9.Y = 0;
            lineAnnotation10.Width = 0;
            lineAnnotation10.Y = 0;

            lineAnnotation1.Height = 200;
            lineAnnotation2.Height = 200;
            lineAnnotation3.Height = 200;
            lineAnnotation4.Height = 200;
            lineAnnotation5.Height = 200;
            lineAnnotation6.Height = 200;
            lineAnnotation7.Height = 200;
            lineAnnotation8.Height = 200;
            lineAnnotation9.Height = 200;
            lineAnnotation10.Height = 200;

            lineAnnotation1.Name = "LineAnnotation1";
            lineAnnotation2.Name = "LineAnnotation2";
            lineAnnotation3.Name = "LineAnnotation3";
            lineAnnotation4.Name = "LineAnnotation4";
            lineAnnotation5.Name = "LineAnnotation5";
            lineAnnotation6.Name = "LineAnnotation6";
            lineAnnotation7.Name = "LineAnnotation7";
            lineAnnotation8.Name = "LineAnnotation8";
            lineAnnotation9.Name = "LineAnnotation9";
            lineAnnotation10.Name = "LineAnnotation10";

            chart1.Annotations.Add(lineAnnotation1);
            chart1.Annotations.Add(lineAnnotation2);
            chart1.Annotations.Add(lineAnnotation3);
            chart1.Annotations.Add(lineAnnotation4);
            chart1.Annotations.Add(lineAnnotation5);
            chart1.Annotations.Add(lineAnnotation6);
            chart1.Annotations.Add(lineAnnotation7);
            chart1.Annotations.Add(lineAnnotation8);
            chart1.Annotations.Add(lineAnnotation9);
            chart1.Annotations.Add(lineAnnotation10);
        }
        //------------------------------------------------------------------------------------------
        private void AdicionaData(int aux)
        {
            int _min = 0;
            int _seg = 0;
            int _hora = 0;
            _seg = aux;
            if (_seg >= 60)
            {
                _min = _seg / 60;
                _seg = _seg - _min * 60;
                if (_min >= 60)
                {
                    _hora = _min / 60;
                    _min = _min - _hora * 60;
                }
            }
            DateTime dt_chart = new DateTime(2013, 4, 11, _hora, _min, _seg);
            _seg = edfFileOutput.FileInfo.StartTime.Value.Seconds + aux;
            _min = edfFileOutput.FileInfo.StartTime.Value.Minutes;
            _hora = edfFileOutput.FileInfo.StartTime.Value.Hours;
            if (_seg >= 60)
            {
                aux = _seg / 60;
                _seg = _seg - aux * 60;
                _min = aux + edfFileOutput.FileInfo.StartTime.Value.Minutes;
                if (_min >= 60)
                {
                    aux = _min / 60;
                    _hora = aux + edfFileOutput.FileInfo.StartTime.Value.Hours;
                    _min = _min - aux * 60;
                }
            }
            DateTime dt_EEG = new DateTime(2013, 4, 11, _hora, _min, _seg);

            string tempo = dt_EEG.ToString("H:mm:ss") + " (" + dt_chart.ToString("H:mm:ss") + ")";
            lbl_Tempo.Text = tempo;
        }
        //------------------------------------------------------------------------------------------
        //Mudança de sinal
        private void btn_SinalProximo_Click(object sender, EventArgs e)
        {
            if ((CanalAtual/4) < (numeroDeCanais-1))
            {
                //Desabilita o canal que está sendo exibido... 
                for (int i = 0; i < 4; i++)
                {
                    chart1.ChartAreas[CanalAtual + i].Visible = false;
                    chart1.Titles[CanalAtual + i].Visible = false;
                }
                //Incrementa o canal...
                CanalAtual = CanalAtual + 4;
                //Cria as séries para o novo canal, se ela não existe (incrementa CanaisCriados)
                if (CanaisCriados <= (CanalAtual / 4))
                {
                    AdicionaCanais();
                    Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "PlotaSinalEEG", vector_evento, ValorInicio.X,ValorFim.X,numeroDeCanais);
                    Thread Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
                    Thread_.Start();
                    CanaisCriados++;
                }
                //Se exite exibe o canal
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        chart1.ChartAreas[CanalAtual + i].Visible = true;
                        chart1.Titles[CanalAtual + i].Visible = true;
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------
        private void btn_SinalAnterior_Click(object sender, EventArgs e)
        {
            if (CanalAtual != 0)
            {
                //Desabilita o canal que está sendo exibido... 
                for(int i=0;i<4;i++)
                {
                    chart1.ChartAreas[CanalAtual+i].Visible = false;
                    chart1.Titles[CanalAtual + i].Visible = false;
                }
                //Carrega o canal inferior, o qual já está cirado
                CanalAtual = CanalAtual - 4;
                for (int i = 0; i < 4; i++)
                {
                    chart1.ChartAreas[CanalAtual + i].Visible = true;
                    chart1.Titles[CanalAtual + i].Visible = true;
                }
            }
        }
        
        //------------------------------------------------------------------------------------------
        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            //Atualizar o tempo
            if (e.Type == ScrollEventType.SmallIncrement)
            {
                //"Apaga" 1s Primeiro de sinal, 256 em x
                AdicionaData(e.NewValue + Scroll_Click_Escala_Seg);
                AddSegInChart();
            }
            else if (e.Type == ScrollEventType.SmallDecrement)
            {
                AdicionaData(e.NewValue + Scroll_Click_Escala_Seg);
            }
            //Atualizar o chart
            for (int i = 0; i < chart1.ChartAreas.Count(); i++)
            {
                chart1.ChartAreas[CanalAtual].AxisX.ScaleView.Position = e.NewValue * edfFileOutput.SignalInfo[1].BufferOffset;
                chart1.ChartAreas[CanalAtual + 1].AxisX.ScaleView.Position = e.NewValue * edfFileOutput.SignalInfo[1].BufferOffset;
                chart1.ChartAreas[CanalAtual + 2].AxisX.ScaleView.Position = e.NewValue * edfFileOutput.SignalInfo[1].BufferOffset;
                //chart1.ChartAreas[CanalAtual + 3].AxisX.ScaleView.Position = e.NewValue * edfFileOutput.SignalInfo[1].BufferOffset;
            }
        }
        //------------------------------------------------------------------------------------------
        private void AddSegInChart()
        {
            for (int k = 0; k < Scroll_Click_Escala_Seg; k++)
            {
                if (DataRecords_lidos < edfFileOutput.FileInfo.NrDataRecords)
                {
                    int excluir;
                    int tempo = DataRecords_lidos * edfFileOutput.SignalInfo[1].BufferOffset;
                    edfFileOutput.ReadDataBlock(DataRecords_lidos);
                    DataRecords_lidos++;
                    //Cada ao fim deste for, é adiciocionado somente 1s em todos os canais
                    for (int j = 0; j < numeroDeCanais; j++)
                    {
                        for (int i = 0; i < edfFileOutput.SignalInfo[j].NrSamples; i++)
                        {
                            if (j == (CanalAtual/4))
                                chart1.Series[CanalAtual].Points.AddY(edfFileOutput.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i]);
                            else
                                excluir = edfFileOutput.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i];
                        }
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (SelecionaEventoDasLista())
            {
                DialogResult resposta = MessageBox.Show("Deseja iniciar a correlação?\nSim - Todo o sinal\nNão - Somente 10s de sinal\nCancel - Aborta a operação\n", "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.YesNoCancel);
                if (resposta == DialogResult.No)
                    inicia_correlacao();
                if (resposta == DialogResult.Yes)
                {
                    double[] Parametros;
                    Parametros = new double[3];
                    Parametros[0] = DataRecords_lidos;
                    Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "CarregarTodoSinal", Parametros,ValorInicio.X,ValorFim.X,numeroDeCanais);
                    Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
                    Thread_.Start();
                    inicia_correlacao();
                }
                CorrelAgain.Enabled = true;
            }
        }
        private bool SelecionaEventoDasLista()
        {
            FormEditorDeEventos selecionar_evento = new FormEditorDeEventos(ListaDeEventos, edfFileOutput, numeroDeCanais);
            selecionar_evento.ShowDialog();
            if (selecionar_evento.vector != null)
            {
                vector_evento = new double[selecionar_evento.vector.Count()];
                vector_evento = selecionar_evento.vector;
                ValorInicio = selecionar_evento.ValorInicio;
                ValorFim = selecionar_evento.ValorFim;
                ID_PadraoAtual = selecionar_evento.itemLista;
                return true;
            }
            else
                return false;
        }

        //------------------------------------------------------------------------------------------
        //Passar para thread depois... 
        private void inicia_correlacao()
        {
            chart1.Series[CanalAtual+1].Points.Clear();
            chart1.Series[CanalAtual+2].Points.Clear();
            Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "Correlacao", vector_evento,ValorInicio.X,ValorFim.X,numeroDeCanais);
            Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
            Thread_.Start();
        }

        private void btn_Suspender_Click(object sender, EventArgs e)
        {
            Thread_.Suspend();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "Correlacao_AGAIN", vector_evento, ValorInicio.X, ValorFim.X, numeroDeCanais);
            Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
            Thread_.Start();
        }

        private void BTN_Kohonen_Click(object sender, EventArgs e)
        {
            if (SelecionaEventoDasLista())
            {
                gbxChart.Height = gbxChart.Height - SMS_Box.Height;
                btn_Aumentar.Visible = true;
                btn_Close.Visible = true;
                SMS_Box.Visible = true;

                GerArquivos = new GerenArquivos();
                int CanalKohonen;
                double numeroLinhas = chart1.Series[CanalAtual].Points.Count;//System.IO.File.ReadAllLines(GerArquivos.getPathUser() + "arquivo.txt").Length;
                FormEditarNomePadrao FormDadosInput = new FormEditarNomePadrao();
                FormDadosInput.opcao = 1;
                FormDadosInput.Vetores = numeroLinhas;
                if (vector_evento != null)
                    FormDadosInput.TamVetores = vector_evento.Count();

                if (FormDadosInput.UsarCorrelacao == true)
                    CanalKohonen = CanalAtual + 1;
                else
                    CanalKohonen = CanalAtual;

                FormDadosInput.ShowDialog();
                double[] vectorSignal = new double[chart1.Series[CanalKohonen].Points.Count];
                for (int i = 0; i < chart1.Series[CanalKohonen].Points.Count; i++)
                    vectorSignal[i] = chart1.Series[CanalKohonen].Points[i].YValues[0];
                RedesNeurais objKohonen = new RedesNeurais(edfFileOutput,ListaDeEventos, FormDadosInput.TamVetores, FormDadosInput.Vetores, FormDadosInput.TreinamentoCom, GerArquivos.getPathUser() + "arquivo.txt", chart1, CanalAtual, progressBar, SMS_Box, vector_evento, vectorSignal, ID_PadraoAtual, "Kohonen");
                ThreadKohonen = new Thread(new ThreadStart(objKohonen.Init));
                ThreadKohonen.Start();
            }
        }
        //------------------------------------------------------------------------------
        private void btn_BackPropagation_Click(object sender, EventArgs e)
        {
            if (SelecionaEventoDasLista())
            {
                gbxChart.Height = gbxChart.Height - SMS_Box.Height;
                btn_Aumentar.Visible = true;
                btn_Close.Visible = true;
                SMS_Box.Visible = true;

                GerArquivos = new GerenArquivos();
                double numeroLinhas = chart1.Series[0].Points.Count;
                FormEditarNomePadrao FormDadosInput = new FormEditarNomePadrao();
                FormDadosInput.opcao = 1;
                FormDadosInput.Vetores = numeroLinhas;
                if (vector_evento != null)
                    FormDadosInput.TamVetores = vector_evento.Count();


                int canalDados;
                if (FormDadosInput.UsarCorrelacao == true)
                    canalDados = CanalAtual + 1;
                else
                    canalDados = CanalAtual;

                FormDadosInput.ShowDialog();
                double[] vectorSignal = new double[chart1.Series[canalDados].Points.Count];
                for (int i = 0; i < chart1.Series[canalDados].Points.Count; i++)
                    vectorSignal[i] = chart1.Series[canalDados].Points[i].YValues[0];

                string TipoBkP = "BackPropagation";
                if (FormDadosInput.UsarListaDeTodosEnventos)
                    TipoBkP = "BackPropagation_AllEvnts";

                RedesNeurais objBKP = new RedesNeurais(edfFileOutput, ListaDeEventos,FormDadosInput.TamVetores, FormDadosInput.Vetores, FormDadosInput.TreinamentoCom, null, chart1, CanalAtual, progressBar, SMS_Box, vector_evento, vectorSignal, ID_PadraoAtual, TipoBkP);
                ThreadKohonen = new Thread(new ThreadStart(objBKP.Init));
                ThreadKohonen.Start();
            }
        }

        private void comboAmplitude_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void comboFrequencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (comboFrequencia.Text != "")
            {
                for (int i = 0; i < 4; i++)
                    chart1.ChartAreas[i].AxisX.ScaleView.Size = Convert.ToDouble(comboFrequencia.Text) * 1000;
                chart1.ChartAreas[3].AxisX.ScaleView.Size = Convert.ToDouble(comboFrequencia.Text);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (!SMS_Zoom)
            {
                gbxChart.Height = gbxChart.Height + SMS_Box.Height;
                btn_Close.Visible = false;
                SMS_Box.Visible = false;
                btn_Aumentar.Visible = false;
            }
            else
            {
                SMS_Zoom = false;
                gbxChart.Visible = true;
                SMS_Box.Location = new Point(this.SMS_Box.Location.X, gbxChart.Height+25);
                SMS_Box.Height = SMS_Box.Height + gbxChart.Height;
                btn_Aumentar.Location = new Point(this.btn_Aumentar.Location.X, this.SMS_Box.Location.Y + 4);
                btn_Close.Location = new Point(this.btn_Close.Location.X, this.SMS_Box.Location.Y + 4);
            }
        }

        private void btn_Aumentar_Click(object sender, EventArgs e)
        {
            SMS_Zoom = true;
            gbxChart.Visible = false;
            SMS_Box.Location = new Point(this.SMS_Box.Location.X, gbxChart.Location.Y);
            SMS_Box.Height = SMS_Box.Height + gbxChart.Height;
            btn_Aumentar.Location = new Point(this.btn_Aumentar.Location.X, 30);
            btn_Close.Location = new Point(this.btn_Close.Location.X, 30);

        }

        private void comboFrequencia_KeyPress(object sender, KeyPressEventArgs e)
        {
             char ch = e.KeyChar;
              if (!Char.IsDigit(ch) && ch != 8)
                 e.Handled = true;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
        }
        //------------------------------------------------------------------------------------------
     }
}
