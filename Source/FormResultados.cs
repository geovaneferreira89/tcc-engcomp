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
using System.Threading;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Runtime.InteropServices;
using BrainNet.NeuralFramework;
using System.Collections;

namespace AmbienteRPB
{
    public partial class FormResultados : Form
    {
        public string ArquivoDeSaida
        {
            get;
            set;
        }
        public bool OP_Salvar
        {
            get;
            set;
        }
        //-------------------------------------------
        private ListaPadroesEventos[] ListaDeEventos;
        private int numeroDeCanais;
        private GerenArquivos Arquivos;
        private EdfFile edfFileOutput;
        private int CanalAtual = 0;
        private int CanaisCriados = 1;
        private int [] DataRecords_lidos;
        private int Scroll_Click_Escala_Seg = 10; //tempo em segundos de tela
        private double[] vector_evento;
        public PointF ValorInicio;
        public PointF ValorFim;
        private Thread Thread_;
        private Thread Thread_RN;
        private GerenArquivos GerArquivos;
        private bool SMS_Zoom = false;
        private int ID_PadraoAtual;
        private int numCursor = 0;
        private HitTestResult var_result;
        private double x_Pos, y_Pos;
        private int[] PadroesATreinar;
        private bool visivel;
        private Color CorDeFundo;
        private Color CorDaSerie;
        private bool RN_Rodou;
        private string[] eventos;
        private int[] CountMarcacoes_Por_Evento;
        private double[] Marcacoes;
        private bool SetMax = true;
        private float[] ValsMAX_MIN;
        //Rede Neural
        private bool RN_Importada = false;
        //private NeuralNetwork network;
        private INeuralNetwork network;
        private int MenorTamanho;
        //-------------------------------------------
        public FormResultados(ListaPadroesEventos[] _ListaDeEventos, int _numDeCanais, EdfFile _EDF, Color _CorDeFundo, Color _CorDaSerie)
        {
            ListaDeEventos = _ListaDeEventos;
            numeroDeCanais = _numDeCanais;
            edfFileOutput = _EDF;
            CorDeFundo = _CorDeFundo;
            CorDaSerie = _CorDaSerie;
            Arquivos = new GerenArquivos();
            InitializeComponent();
        }
        //------------------------------------------------------------------------------------------
        private void FormResultados_Shown(object sender, EventArgs e)
        {
            gbxChart.Height = gbxChart.Height + SMS_Box.Height;
            visivel = false;
            AdicionaCanais();
            Adiciona_linhas_de_tempo();
            SMS_Box.SelectionStart = SMS_Box.Text.Length;
            SMS_Box.ScrollToCaret();

            Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "PlotaSinalEEG", vector_evento, ValorInicio.X, ValorFim.X, numeroDeCanais, null,null);
            Thread Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
            Thread_.Start();
            chart1.Enabled = true;
            chart1.BackColor = CorDeFundo;
            OP_Salvar = false;
            RN_Rodou = false;
            DataRecords_lidos = new int[numeroDeCanais];
            DataRecords_lidos[0] = 10; //primeiro canal que vem carregado já por default quando abre a tela
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
                chart1.ChartAreas[_pos].AxisY.IsStartedFromZero = false;
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

            lineAnnotation1.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation2.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation3.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation4.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation5.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation6.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation7.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation8.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation9.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation10.LineColor = System.Drawing.Color.LightGray;

            lineAnnotation1.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation2.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation3.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation4.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation5.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation6.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation7.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation8.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation9.LineDashStyle = ChartDashStyle.Dash;
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
            if ((CanalAtual / 4) < (numeroDeCanais - 1))
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
                    Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "PlotaSinalEEG", vector_evento, ValorInicio.X, ValorFim.X, numeroDeCanais,null,null);
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
                for (int i = 0; i < 4; i++)
                {
                    chart1.ChartAreas[CanalAtual + i].Visible = false;
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
                //"Apaga" 10s ou dependendo da ecala definida em "Scroll_Click_Escala_Seg"
                AdicionaData(e.NewValue + Scroll_Click_Escala_Seg);
                AddSegInChart();
            }
            else if (e.Type == ScrollEventType.SmallDecrement)
            {
                AdicionaData(e.NewValue + Scroll_Click_Escala_Seg);
            }
            //Atualizar o chart
            chart1.ChartAreas[CanalAtual].AxisX.ScaleView.Position = e.NewValue * (edfFileOutput.SignalInfo[1].BufferOffset / (int)edfFileOutput.FileInfo.SampleRecDuration);
            chart1.ChartAreas[CanalAtual + 1].AxisX.ScaleView.Position = e.NewValue * (edfFileOutput.SignalInfo[1].BufferOffset / (int)edfFileOutput.FileInfo.SampleRecDuration);
            chart1.ChartAreas[CanalAtual + 2].AxisX.ScaleView.Position = e.NewValue * (edfFileOutput.SignalInfo[1].BufferOffset / (int)edfFileOutput.FileInfo.SampleRecDuration);
            chart1.ChartAreas[CanalAtual + 3].AxisX.ScaleView.Position = e.NewValue * (edfFileOutput.SignalInfo[1].BufferOffset / (int)edfFileOutput.FileInfo.SampleRecDuration);
        }
        //------------------------------------------------------------------------------------------
        private void AddSegInChart()
        {
            for (int k = 0; k < Scroll_Click_Escala_Seg; k++)
            {
                if (DataRecords_lidos[CanalAtual/4] < edfFileOutput.FileInfo.NrDataRecords)
                {
                    if (SetMax)
                    {
                        SetMax = false;
                        ValsMAX_MIN = new float[2];
                        ValsMAX_MIN[0] = (float)chart1.ChartAreas[CanalAtual].AxisY.Maximum;
                        ValsMAX_MIN[1] = (float)chart1.ChartAreas[CanalAtual].AxisY.Minimum;
                    }
                    int excluir;
                    int tempo = DataRecords_lidos[CanalAtual / 4] * edfFileOutput.SignalInfo[1].BufferOffset;
                    edfFileOutput.ReadDataBlock(DataRecords_lidos[CanalAtual / 4]);
                    DataRecords_lidos[CanalAtual / 4] = DataRecords_lidos[CanalAtual / 4] + 1;
                    //Cada ao fim deste for, é adiciocionado somente 1s em todos os canais
                    for (int j = 0; j < numeroDeCanais; j++)
                    {
                        for (int i = 0; i < edfFileOutput.SignalInfo[j].NrSamples; i++)
                        {
                            if (j == (CanalAtual / 4))
                                chart1.Series[CanalAtual].Points.AddY(edfFileOutput.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i]);
                            else
                                excluir = edfFileOutput.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i];
                        }
                    }
                    chart1.ChartAreas[CanalAtual].AxisY.Maximum = ValsMAX_MIN[0];
                    chart1.ChartAreas[CanalAtual].AxisY.Minimum = ValsMAX_MIN[1];
                }
            }
        }
        //------------------------------------------------------------------------------------------
        //Ajustes de Amplitude 
        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {
            chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum = chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum + 1;
        }
        //------------------------------------------------------------------------------------------

        private void ampliMENOS_Click(object sender, EventArgs e)
        {
            double Max = chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum;
            if ((Max - 10) >= 0)
                chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum = chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum - 10;
            else if ((Max - 1) >= 0)
                chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum = chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum - 1;
        }
        //------------------------------------------------------------------------------------------
        //Ajustes de Offset 
        private void offsetCIMA_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum = chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum - 1;
            chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Minimum = chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Minimum - 1;
        }
        //------------------------------------------------------------------------------------------
        private void offsetBAIXO_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum = chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Maximum + 1;
            chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Minimum = chart1.ChartAreas[(Convert.ToInt16(opcCANAL.Text) - 1) + CanalAtual].AxisY.Minimum + 1;
        }
        //------------------------------------------------------------------------------------------
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (visivel == false)
            {
                gbxChart.Height = gbxChart.Height - SMS_Box.Height;
                visivel = true;
            }
            SMS_Box.Visible = true;
            btn_Aumentar.Visible = true;
            btn_Close.Visible = true;
         
            if (Promediacao())
            {
                if (DataRecords_lidos[CanalAtual / 4] <= edfFileOutput.FileInfo.NrDataRecords)
                {
                    DialogResult resposta = MessageBox.Show("Deseja iniciar a correlação?\nSim - Todo o sinal\nNão - Somente 10s de sinal\nCancel - Aborta a operação\n", "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.YesNoCancel);
                    if (resposta == DialogResult.No)
                        inicia_correlacao();
                    if (resposta == DialogResult.Yes)
                    {
                        double[] Parametros;
                        Parametros = new double[3];
                        Parametros[0] = DataRecords_lidos[CanalAtual / 4];
                        //Escalas Máxima e minima
                        if (SetMax)
                        {
                            SetMax = false;
                            ValsMAX_MIN = new float[2];
                            ValsMAX_MIN[0] = (float)chart1.ChartAreas[CanalAtual].AxisY.Maximum;
                            ValsMAX_MIN[1] = (float)chart1.ChartAreas[CanalAtual].AxisY.Minimum;
                        }
                        Parametros[1] = ValsMAX_MIN[0];//max
                        Parametros[2] = ValsMAX_MIN[1];//min

                        chart1.Series[CanalAtual + 1].Points.Clear();
                        chart1.Series[CanalAtual + 2].Points.Clear();

                        Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "CarregarTodoSinal", vector_evento, ValorInicio.X, ValorFim.X, numeroDeCanais, Parametros, null);
                        Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
                        Thread_.Start();
                        DataRecords_lidos[CanalAtual / 4] = edfFileOutput.FileInfo.NrDataRecords + 10;
                    }
                    segundaCorrelacao.Enabled = true;
                }
                else
                {
                    chart1.Series[CanalAtual + 1].Points.Clear();
                    chart1.Series[CanalAtual + 2].Points.Clear();
                    inicia_correlacao();
                    segundaCorrelacao.Enabled = true;
                }
            }
        }
        //--------------------------------------------------------------------------
        //Promediacão a ser utilizada na correlação
        private bool Promediacao()
        {
            FormEditorDeEventos selecionar_evento = new FormEditorDeEventos(ListaDeEventos, edfFileOutput, numeroDeCanais);
            selecionar_evento.ShowDialog();
            int eventoMenor = 0;
            if (selecionar_evento.vector != null)
            {
                ValorInicio = selecionar_evento.ValorInicio;
                ValorFim    = selecionar_evento.ValorFim;
                ID_PadraoAtual = selecionar_evento.itemLista;

                for (int cont = 0; cont < ListaDeEventos[ID_PadraoAtual].NumeroEventos; cont++)
                {
                    int aux = (int)(ListaDeEventos[ID_PadraoAtual].GetValorFim(cont).X - ListaDeEventos[ID_PadraoAtual].GetValorInicio(cont).X);
                    if (cont == 0 || MenorTamanho > aux){
                        MenorTamanho = aux;
                        eventoMenor = cont;
                    }
                }
                vector_evento = new double[MenorTamanho];
                int ValMinAcimaDaRef = (int)(ListaDeEventos[ID_PadraoAtual].GetValorFim(eventoMenor).X - ListaDeEventos[ID_PadraoAtual].GetValorMeio(eventoMenor).X);
                int ValMinAbaixoDaRef = (int)(ListaDeEventos[ID_PadraoAtual].GetValorMeio(eventoMenor).X - ListaDeEventos[ID_PadraoAtual].GetValorInicio(eventoMenor).X);
                int TotaisUsados = 0;
                for(int i =0; i < ListaDeEventos[ID_PadraoAtual].NumeroEventos; i++)
                {
                    int tamanho = (int)(ListaDeEventos[ID_PadraoAtual].GetValorFim(i).X - ListaDeEventos[ID_PadraoAtual].GetValorInicio(i).X);
                    int Ref_Menos_Inicio = (int)(ListaDeEventos[ID_PadraoAtual].GetValorMeio(i).X - ListaDeEventos[ID_PadraoAtual].GetValorInicio(i).X);
                    int Ref_Menos_Fim = (int)(ListaDeEventos[ID_PadraoAtual].GetValorFim(i).X - ListaDeEventos[ID_PadraoAtual].GetValorMeio(i).X);
                    if (MenorTamanho <= tamanho && ValMinAbaixoDaRef <= Ref_Menos_Inicio &&  ValMinAcimaDaRef <= Ref_Menos_Fim)
                    {
                        int inicio = Ref_Menos_Inicio - ValMinAbaixoDaRef;
                        int fim = Ref_Menos_Inicio + ValMinAcimaDaRef;
                        int auxContVet = 0;
                        List<float> vectorSinal = new List<float>();
                        vectorSinal = obtemSinal(i, ID_PadraoAtual);
                        for (int j = inicio; j < fim; j++)
                        {
                            //Aqui preciso adquirir o sinal... 
                               vector_evento[auxContVet] = vector_evento[auxContVet] + vectorSinal[j];
                               auxContVet++;
                        }
                        TotaisUsados++;
                        //faz a promediação (média)
                        if(TotaisUsados != 0){
                                for(int j=0;j<vector_evento.Count();j++){
                                    vector_evento[j] = vector_evento[j]/TotaisUsados;
                                }
                        }
                    }
                }// ID_PadraoAtual
                SMS_Box.Clear();
                SMS_Box.Text = "Realizada Promediação dos Eventos\nIniciando a correlação\n";
                return true;
            }
            else
                return false;
        }
        private List<float> obtemSinal(int PosicaoDaLista, int PadraoDaLista)
        {
            List<float> vectorSinal = new List<float>();
             
            string nome_canal = ListaDeEventos[PadraoDaLista].GetNomesEvento(PosicaoDaLista);
            int X_ = nome_canal.IndexOf("_");
            nome_canal = nome_canal.Substring(X_ + 1);
            float x = ListaDeEventos[PadraoDaLista].GetValorInicio(PosicaoDaLista).X;
            float x_fim = ListaDeEventos[PadraoDaLista].GetValorFim(PosicaoDaLista).X;
            float referencia = ListaDeEventos[PadraoDaLista].GetValorMeio(PosicaoDaLista).X;          
            int tempo_X = 0;
            if (nome_canal == "Correlacao")
            {
                double[] sinal;
                GerenArquivos Arquivos = new GerenArquivos();
                sinal = Arquivos.ImportaPadraoCorrelacao(ListaDeEventos[PadraoDaLista].GetNomesEvento(PosicaoDaLista));
                for (int j = 0; j < sinal.Count(); j++)
                    vectorSinal.Add((float)sinal[j]);
            }
            else
            {
                int BlocosLidos = 0;
                while (tempo_X <= (int)x_fim)
                {
                    edfFileOutput.ReadDataBlock(BlocosLidos);
                    BlocosLidos++;
                    for (int j = 0; j < edfFileOutput.FileInfo.NrSignals; j++)
                    {
                        for (int i = 0; i < edfFileOutput.SignalInfo[j].NrSamples; i++)
                        {
                            if (edfFileOutput.SignalInfo[j].SignalLabel == nome_canal)
                            {
                                if (tempo_X >= (int)x && tempo_X < (int)x_fim)
                                    vectorSinal.Add(edfFileOutput.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i]);
                                tempo_X++;
                            }
                        }
                    }
                }
            }
            return vectorSinal;
        }
        //--------------------------------------------------------------------------
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
        private void inicia_correlacao()
        {
            chart1.Series[CanalAtual + 1].Points.Clear();
            chart1.Series[CanalAtual + 2].Points.Clear();
            SMS_Box.Clear();
            double[] Parametros;
            Parametros = new double[3];
            Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "Correlacao", vector_evento, ValorInicio.X, ValorFim.X, numeroDeCanais, Parametros, null);
            Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
            Thread_.Start();
        }

        private void btn_Suspender_Click_1(object sender, EventArgs e)
        {
            if (Thread_RN.IsAlive)
            {
                Thread_RN.Abort();
                MessageBox.Show("Operação Abortada!\n", "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.OK);
                progressBar.Value = 0;
                progressBar.Enabled = false;
            }
            else
                MessageBox.Show("Nenhuma operação no momento está sendo executada!\n", "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.OK);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Segunda correlação
            Promediacao();
            double[] Parametros;
            Parametros = new double[3];
            Parametros[1] = ValsMAX_MIN[0];//max
            Parametros[2] = ValsMAX_MIN[1];//min
            Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "Correlacao_AGAIN", vector_evento, ValorInicio.X, ValorFim.X, numeroDeCanais, Parametros, null);
            Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
            Thread_.Start();
        }

        private void BTN_Kohonen_Click(object sender, EventArgs e)
        {
            if (SelecionaEventoDasLista())
            {
                if (visivel == false)
                {
                    gbxChart.Height = gbxChart.Height - SMS_Box.Height;
                    visivel = true;
                }
                SMS_Box.Clear();
                SMS_Box.Visible = true;
                btn_Aumentar.Visible = true;
                btn_Close.Visible = true;

                GerArquivos = new GerenArquivos();
                int CanalKohonen;
                double numeroLinhas = chart1.Series[CanalAtual].Points.Count;//System.IO.File.ReadAllLines(GerArquivos.getPathUser() + "arquivo.txt").Length;
                FormEditarNomePadrao FormDadosInput = new FormEditarNomePadrao();
                FormDadosInput.opcao = 1;
                FormDadosInput.Vetores = numeroLinhas;
                if (vector_evento != null)
                    FormDadosInput.TamVetores = vector_evento.Count();
                FormDadosInput.ShowDialog();

                //Dados sobre os charts, onde plotar
                if (FormDadosInput.UsarCorrelacao == true)
                    CanalKohonen = CanalAtual + 1;
                else
                    CanalKohonen = CanalAtual;
                //Canal de saida de resultados
                int canalParaPlotar = CanalAtual + 2;

                if (FormDadosInput.NumPadroes > 1)
                {
                    PadroesATreinar = new int[FormDadosInput.NumPadroes];
                    PadroesATreinar[0] = ID_PadraoAtual;
                    eventos = new string[FormDadosInput.NumPadroes];
                    eventos[0] = Convert.ToString(ID_PadraoAtual);

                    for (int i = 1; i < FormDadosInput.NumPadroes; i++)
                    {
                        SelecionaEventoDasLista();
                        PadroesATreinar[i] = ID_PadraoAtual;
                        eventos[i] = Convert.ToString(ID_PadraoAtual);
                    }
                }
                else
                {
                    PadroesATreinar = new int[1];
                    PadroesATreinar[0] = ID_PadraoAtual;
                    eventos = new string[FormDadosInput.NumPadroes];
                    eventos[0] = Convert.ToString(ID_PadraoAtual);
                }

                double[] vectorSignal = new double[chart1.Series[CanalKohonen].Points.Count];
                for (int i = 0; i < chart1.Series[CanalKohonen].Points.Count; i++)
                    vectorSignal[i] = chart1.Series[CanalKohonen].Points[i].YValues[0];
                RedesNeurais objRMP = new RedesNeurais(edfFileOutput, ListaDeEventos, FormDadosInput.UsarReferencia, FormDadosInput.TamVetores, FormDadosInput.Vetores, FormDadosInput.TreinamentoCom, GerArquivos.getPathUser() + "arquivo.txt", chart1, CanalKohonen, canalParaPlotar, progressBar, SMS_Box, vector_evento, vectorSignal, PadroesATreinar, "Kohonen", ref network, RN_Importada, MenorTamanho);
                Thread_RN = new Thread(new ThreadStart(objRMP.Init));
                Thread_RN.Start();
                //Habilita a opção de poder exportar para o form principal
                RN_Rodou = true;
            }
        }
        //------------------------------------------------------------------------------
        private void treinar100VezesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if ( SelecionaEventoDasLista())
            {
                if (visivel == false)
                {
                    gbxChart.Height = gbxChart.Height - SMS_Box.Height;
                    visivel = true;
                }
                SMS_Box.Clear();
                SMS_Box.Visible = true;
                btn_Aumentar.Visible = true;
                btn_Close.Visible = true;

                GerArquivos = new GerenArquivos();
                double numeroLinhas = chart1.Series[0].Points.Count;
                FormEditarNomePadrao FormDadosInput = new FormEditarNomePadrao();
                FormDadosInput.opcao = 1;
                FormDadosInput.Vetores = numeroLinhas;
                if (vector_evento != null)
                    FormDadosInput.TamVetores = vector_evento.Count();
                FormDadosInput.ShowDialog();

                //Dados sobre os charts, onde plotar
                int canalDados;
                if (FormDadosInput.UsarCorrelacao == true)
                    canalDados = CanalAtual + 1;
                else
                    canalDados = CanalAtual;

                //Canal de saida de resultados
                int canalParaPlotar = CanalAtual + 2;

                double[] vectorSignal = new double[chart1.Series[canalDados].Points.Count];
                for (int i = 0; i < chart1.Series[canalDados].Points.Count; i++)
                    vectorSignal[i] = chart1.Series[canalDados].Points[i].YValues[0];

                string TipoBkP;
                //Verifica se a RN foi criada
                if (!RN_Importada)
                {
                    PadroesATreinar = new int[1];
                    PadroesATreinar[0] = ID_PadraoAtual;
                    eventos = new string[FormDadosInput.NumPadroes];
                    eventos[0] = Convert.ToString(ID_PadraoAtual);
                    TipoBkP = "BackPropagation";
                    if (FormDadosInput.UsarListaDeTodosEnventos){
                        TipoBkP = "BackPropagation_AllEvnts";
                        if (!FormDadosInput.UsarReferencia){
                            for (int i = 0; i < PadroesATreinar.Count(); i++){
                                for (int cont = 0; cont < ListaDeEventos[PadroesATreinar[i]].NumeroEventos; cont++){
                                    int aux = (int)(ListaDeEventos[PadroesATreinar[i]].GetValorFim(cont).X - ListaDeEventos[PadroesATreinar[i]].GetValorInicio(cont).X);
                                    if ((cont == 0 && i == 0) || MenorTamanho > aux)
                                        MenorTamanho = aux;
                                }
                            }
                        }
                        else
                            MenorTamanho = Convert.ToInt16(FormDadosInput.TamVetores);
                    }
                    else
                        MenorTamanho = vector_evento.Count();
                    novaRedeMLP();
                    salvarRedeToolStripMenuItem.Enabled = true;
                }
                //Pergunta se quer treinar novamente a rede neural... algo assim
                else{
                    //So para nao dar erro na classe RedesNeurais
                    TipoBkP = "BackPropagationTreinar100x";
                    PadroesATreinar = new int[1];
                    PadroesATreinar[0] = 1;
                    eventos = new string[1];
                }

                RedesNeurais objBKP = new RedesNeurais(edfFileOutput, ListaDeEventos, FormDadosInput.UsarReferencia, FormDadosInput.TamVetores, FormDadosInput.Vetores, FormDadosInput.TreinamentoCom, null, chart1, canalDados, canalParaPlotar, progressBar, SMS_Box, vector_evento, vectorSignal, PadroesATreinar, TipoBkP, ref network, RN_Importada, MenorTamanho);
                Thread_RN = new Thread(new ThreadStart(objBKP.Init));
                Thread_RN.Start();
                //Habilita a opção de poder exportar para o form principal
                RN_Rodou = true;

            }
        }

        private void btn_BackPropagation_Click(object sender, EventArgs e)
        {
                    bool verifica = false;
                    if (RN_Importada)
                        verifica = true;
                    else
                        verifica = SelecionaEventoDasLista();

                    if (verifica)
                    {
                        if (visivel == false)
                        {
                            gbxChart.Height = gbxChart.Height - SMS_Box.Height;
                            visivel = true;
                        }
                        SMS_Box.Visible = true;
                        btn_Aumentar.Visible = true;
                        btn_Close.Visible = true;

                        GerArquivos = new GerenArquivos();
                        double numeroLinhas = chart1.Series[0].Points.Count;
                        FormEditarNomePadrao FormDadosInput = new FormEditarNomePadrao();
                        FormDadosInput.opcao = 1;
                        FormDadosInput.Vetores = numeroLinhas;
                        if (vector_evento != null)
                            FormDadosInput.TamVetores = vector_evento.Count();
                        FormDadosInput.ShowDialog();

                        //Dados sobre os charts, onde plotar
                        int canalDados;
                        if (FormDadosInput.UsarCorrelacao == true)
                            canalDados = CanalAtual + 1;
                        else
                            canalDados = CanalAtual;

                        //Canal de saida de resultados
                        int canalParaPlotar = CanalAtual + 2;

                        double[] vectorSignal = new double[chart1.Series[canalDados].Points.Count];
                        for (int i = 0; i < chart1.Series[canalDados].Points.Count; i++)
                            vectorSignal[i] = chart1.Series[canalDados].Points[i].YValues[0];


                        bool state = true;
                        while (state)
                        {
                            DialogResult debug = MessageBox.Show("Iniciar, este é um loop para ficar treinando a RN sempre, vou retirar depois...", "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.YesNo);
                            if (debug == DialogResult.Yes)
                            {
                                SMS_Box.Clear();
                                string TipoBkP;
                                //Verifica se a RN foi criada
                                if (!RN_Importada)
                                {
                                    PadroesATreinar = new int[1];
                                    PadroesATreinar[0] = ID_PadraoAtual;
                                    //Só busca um evento
                                    eventos = new string[1];
                                    eventos[0] = Convert.ToString(ID_PadraoAtual);
                                    TipoBkP = "BackPropagation";
                                    if (FormDadosInput.UsarListaDeTodosEnventos)
                                    {
                                        TipoBkP = "BackPropagation_AllEvnts";
                                        if (!FormDadosInput.UsarReferencia)
                                        {
                                            for (int i = 0; i < PadroesATreinar.Count(); i++)
                                            {
                                                for (int cont = 0; cont < ListaDeEventos[PadroesATreinar[i]].NumeroEventos; cont++)
                                                {
                                                    int aux = (int)(ListaDeEventos[PadroesATreinar[i]].GetValorFim(cont).X - ListaDeEventos[PadroesATreinar[i]].GetValorInicio(cont).X);
                                                    if ((cont == 0 && i == 0) || MenorTamanho > aux)
                                                        MenorTamanho = aux;
                                                }
                                            }
                                        }
                                        else
                                            MenorTamanho = Convert.ToInt16(FormDadosInput.TamVetores);
                                    }
                                    else
                                        MenorTamanho = vector_evento.Count();
                                    novaRedeMLP();
                                    salvarRedeToolStripMenuItem.Enabled = true;
                                }
                                //Pergunta se quer treinar novamente a rede neural... algo assim
                                else
                                {
                                    //So para nao dar erro na classe RedesNeurais
                                    TipoBkP = "BackPropagation_AllEvnts";
                                    PadroesATreinar = new int[1];
                                    PadroesATreinar[0] = 1;
                                    eventos = new string[1];
                                }

                                RedesNeurais objBKP = new RedesNeurais(edfFileOutput, ListaDeEventos, FormDadosInput.UsarReferencia, FormDadosInput.TamVetores, FormDadosInput.Vetores, FormDadosInput.TreinamentoCom, null, chart1, canalDados, canalParaPlotar, progressBar, SMS_Box, vector_evento, vectorSignal, PadroesATreinar, TipoBkP, ref network, RN_Importada, MenorTamanho);
                                Thread_RN = new Thread(new ThreadStart(objBKP.Init));
                                Thread_RN.Start();
                                //Habilita a opção de poder exportar para o form principal
                                RN_Rodou = true;

                            }
                            else
                                state = false;
                        }
                    }
         }
        //---------------------------------------------------------------------------
        //Função responsavel por criar a Rede Neural
        public void novaRedeMLP()
        {
            BackPropNeuronStrategy strategy = new BackPropNeuronStrategy();
            ArrayList layers = new ArrayList();
            
            layers.Add(MenorTamanho);
            int NeuroniosDaCamadaInterm = (int)Math.Sqrt(MenorTamanho);
            if (NeuroniosDaCamadaInterm < 9)
                NeuroniosDaCamadaInterm = 9;
            layers.Add(NeuroniosDaCamadaInterm);
            layers.Add(1);
            
            network = new NeuralNetwork();
            foreach (int neurons in layers)
            {
                NeuronLayer layer;
                for (int i = 0; i <= neurons - 1; i++)
                {
                    layer = new NeuronLayer();
                    for (i = 0; i <= neurons - 1; i++)
                    {
                        INeuron neuronio = new Neuron(strategy);
                        layer.Add(ref neuronio);
                    }
                    network.Layers.Add(layer);
                }
            }
            network.ConnectLayers();
        }
        //---------------------------------------------------------------------------
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
                SMS_Box.Location = new Point(this.SMS_Box.Location.X, gbxChart.Height + 25);
                SMS_Box.Height = SMS_Box.Height + gbxChart.Height;
                btn_Aumentar.Location = new Point(this.btn_Aumentar.Location.X, this.SMS_Box.Location.Y + 4);
                btn_Close.Location = new Point(this.btn_Close.Location.X, this.SMS_Box.Location.Y + 4);
                visivel = false;
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
            visivel = false;
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
        //================================================================================================
        //                                   Marcar padrao pela correlação 
        //================================================================================================
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if (result.Series != null)
                ExecutaSelecao(result, e, 0);
        }
        private void ExecutaSelecao(HitTestResult result, MouseEventArgs e, int offsetX)
        {
            if (numCursor == 0)
            {
                var_result = result;
                x_Pos = (e.X);
                y_Pos = (e.Y);
                PointF Padrao_Inicio = new PointF((float)x_Pos, (float)y_Pos);

                numCursor++;
                result.ChartArea.CursorX.SetCursorPixelPosition(Padrao_Inicio, true);
            }
            else
            {
                PointF Padrao_Inicio = new PointF((float)x_Pos, (float)y_Pos);
                PointF Padrao_Fim = new PointF((e.X + offsetX), e.Y);

                PointF zero = new PointF(0, 0);

                result.ChartArea.CursorX.SetSelectionPixelPosition(zero, zero, true);
                result.ChartArea.CursorX.SelectionColor = Color.FromArgb(128, Color.Green);

                //Colore a região do evento
                result.ChartArea.CursorX.SetSelectionPixelPosition(Padrao_Inicio, Padrao_Fim, true);

                Padrao_Inicio.X = (float)result.ChartArea.AxisX.PixelPositionToValue(x_Pos);
                Padrao_Fim.X = (float)result.ChartArea.AxisX.PixelPositionToValue(e.X + offsetX);

                Padrao_Inicio = new PointF((float)result.ChartArea.AxisX.PixelPositionToValue(x_Pos), (float)result.ChartArea.AxisY.PixelPositionToValue(y_Pos));
                Padrao_Fim = new PointF((float)result.ChartArea.AxisX.PixelPositionToValue(e.X + offsetX), (float)result.ChartArea.AxisY.PixelPositionToValue(e.Y));

                numCursor = 0;
                if (Padrao_Inicio.X < Padrao_Fim.X)
                {
                    vector_evento = new double[(int)(Padrao_Fim.X - Padrao_Inicio.X)];
                    for (int i = 0; i < vector_evento.Count(); i++)
                        vector_evento[i] = result.Series.Points[Convert.ToInt32(Padrao_Inicio.X) + i].YValues[0];
                    Exportar_Padrao_Na_Lista(Padrao_Inicio, Padrao_Fim, result, "", (float)Padrao_Fim.X - Padrao_Inicio.X);
                }
                else
                    result.ChartArea.CursorX.SelectionColor = Color.FromArgb(128, Color.Red);
            }
        }
        //------------------------------------------------------------------------------------------
        private void Exportar_Padrao_Na_Lista(PointF Padrao_Inicio, PointF Padrao_Fim, HitTestResult Canal, string coment, float Comprimento)
        {
            string Resultado = Interaction.InputBox("Em qual padrao deseja salvar?", "Salvar Evento", Convert.ToString(ID_PadraoAtual + 1));
            if (Resultado != "")
            {
                int i = Convert.ToInt32(Resultado);
                i--;
                Padrao_Fim.X = Padrao_Fim.X - Padrao_Inicio.X;
                Padrao_Inicio.X = 0;
                PointF Padrao_Ref = new PointF(Padrao_Fim.X/2, 0);
                ListaDeEventos[i].SetValorInicio(ListaDeEventos[i].GetNumeroEventos(), Padrao_Inicio);
                ListaDeEventos[i].SetValorFim(ListaDeEventos[i].GetNumeroEventos(), Padrao_Fim);
                ListaDeEventos[i].SetValorMeio(ListaDeEventos[i].GetNumeroEventos(), Padrao_Ref);
                ListaDeEventos[i].SetComentario(ListaDeEventos[i].GetNumeroEventos(), coment);
                ListaDeEventos[i].SetWidth(ListaDeEventos[i].GetNumeroEventos(), Comprimento);
                ListaDeEventos[i].SetNomesEvento(ListaDeEventos[i].GetNumeroEventos(), (i + 1) + "-" + ListaDeEventos[i].GetNumeroEventos() + "_" + "Correlacao");
                Arquivos.SalvaPadraoCorrelacao((i + 1) + "-" + ListaDeEventos[i].GetNumeroEventos() + "_" + "Correlacao", vector_evento);
                ListaDeEventos[i].SetCorDeFundo(ListaDeEventos[i].GetNumeroEventos(), Color.Green);
                ListaDeEventos[i].SetNumeroEventos(ListaDeEventos[i].GetNumeroEventos() + 1);
            }
        }
        //================================================================================================
        //                      Fechar o Form E Salvamento de Resultados  Dados Da RN
        //================================================================================================
        //------------------------------------------------------------------------------------------
        private void FormResultados_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        //----------------------------------------------------------------------------------------
        //Função responsavel por analisar os resultados obtidos da RN
        private int SalvarResultados()
        {
            bool iniciou = false;
            int inicio = 0;
            int Fim;
            int count = 0;
            int valMax = 0;
            int valMin = 0;
            int val = 0;
            CountMarcacoes_Por_Evento = new int[eventos.Count()];
            Marcacoes = new double[chart1.Series[2].Points.Count()];
            //Pegar sempre o menor maybe, o menor é o primeiro evento que vc marcou.... 
            for (int CanalX = 0; CanalX < CanaisCriados; CanalX++)
            {
                for (int i = 0; i < chart1.Series[(CanalX * 4) + 2].Points.Count(); i++)
                {
                    val = (int)chart1.Series[(CanalX * 4) + 2].Points[i].YValues[0];
                    if (val != 0)
                    {
                        if (iniciou == false)
                        {
                            valMax = val;
                            valMin = val;
                            inicio = i;
                            iniciou = true;
                        }
                        else if (valMin >= val && iniciou == true)
                        {
                            valMin = val;
                        }
                        else if (valMax <= val && iniciou == true)
                        {
                            valMax = val;
                        }
                    }
                    else if (iniciou == true)
                    {
                        Fim = i;
                        CountMarcacoes_Por_Evento[valMin - 1] = CountMarcacoes_Por_Evento[valMin - 1] + 1;
                        //Salva os dados nos vetores
                        Marcacoes[count] = CanalX;
                        count++;
                        Marcacoes[count] = inicio;
                        count++;
                        Marcacoes[count] = Fim;
                        count++;
                        iniciou = false;
                    }
                }
            }
            return count;
        }

        private void FormResultados_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (RN_Rodou)
            {
                DialogResult resposta = MessageBox.Show("Deseja salvar os resultados?", "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    OP_Salvar = true;
                    ArquivoDeSaida = edfFileOutput.FileName;
                    int count = SalvarResultados();
                    Arquivos = new GerenArquivos();
                    Arquivos.Exportar_RN(ArquivoDeSaida, eventos, CountMarcacoes_Por_Evento, Marcacoes, count);
                    RN_Rodou = false;
                }
            }
        }
        //Carrega o arquivo de marcacoes existente, arquivo este gerado pelo MIT e editado por nós... 
        private void btnMarcacoes_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TXT Files|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 double[] Parametros;
                 Parametros = new double[3];
                 Parametros[0] = DataRecords_lidos[CanalAtual / 4];
                 if (SetMax)
                 {
                     SetMax = false;
                     ValsMAX_MIN = new float[2];
                     ValsMAX_MIN[0] = (float)chart1.ChartAreas[CanalAtual].AxisY.Maximum;
                     ValsMAX_MIN[1] = (float)chart1.ChartAreas[CanalAtual].AxisY.Minimum;
                 }
                 Parametros[1] = ValsMAX_MIN[0];//max
                 Parametros[2] = ValsMAX_MIN[1];//min

                 Correlacao carregarMarcacoes = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "Marcacoes", Parametros, ValorInicio.X, ValorFim.X, numeroDeCanais, Parametros, openFileDialog1.FileName);
                 Thread_ = new Thread(new ThreadStart(carregarMarcacoes.Inicializa));
                 Thread_.Start();
                 DataRecords_lidos[CanalAtual / 4] = edfFileOutput.FileInfo.NrDataRecords + 10;
                 toolAnalise.Enabled = true;
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if (result.ChartArea != null)
            {
                double pointXPixel = result.ChartArea.AxisX.PixelPositionToValue(e.X);
                double pointYPixel = result.ChartArea.AxisY.PixelPositionToValue(e.Y);
                lbl_x.Text = "Valor X: " + pointXPixel.ToString("f4");
                lbl_Y.Text = "Valor Y: " + pointYPixel.ToString("f4");
            }
            lbl_mouseX.Text = "Mouse X: " + e.Location.X;
            lbl_mouseY.Text = "Mouse Y: " + e.Location.Y;
        }

        private void salvarRedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivo = saveFileDialog1.FileName;
                NetworkSerializer ser = new BrainNet.NeuralFramework.NetworkSerializer();
                ser.SaveNetwork(nomeArquivo + ".xml", network);
            }
        }

        private void importarRedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkSerializer ser = new BrainNet.NeuralFramework.NetworkSerializer();
            openFileDialog1.Filter = "XML Files|*.xml";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    network = new BrainNet.NeuralFramework.NeuralNetwork();
                    ser.LoadNetwork(openFileDialog1.FileName, ref network);
                    //MessageBox.Show("Rede Neural " + openFileDialog1.FileName + " carregada com sucesso!", "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.OK);

                    RN_Importada = true;
                    object senders = new object[1];
                    EventArgs a = new EventArgs();
                    btn_BackPropagation_Click( senders,a);
                    salvarRedeToolStripMenuItem.Enabled = true;
                    treinar100VezesToolStripMenuItem.Visible = true;
                }
                catch
                {
                    MessageBox.Show("Erro Arquivo invalido", "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //================================================================================================
        //                                   INICIO DA ANALISE DA MLP
        //================================================================================================
        //------------------------------------------------------------------------------------------
        private void AnaliseMLP_Click(object sender, EventArgs e)
        {
            string threshold = "";
            threshold = Interaction.InputBox("Threshold", "Reconhecimento Automatizado de Padrões em EEG", "", 10, 10);

            MessageBox.Show("QRSs: " + Convert.ToString(ContarQRSs(Convert.ToInt16(threshold))), "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.OK);
            //ContarQRSs();
        }
        private int ContarQRSs(int threshold)
        {
            bool iniciou = false;
            int inicio = 0;
            int Fim;
            int count = 0;
            int val = 0;
            int numMAX = 0;
            CountMarcacoes_Por_Evento = new int[eventos.Count()];
            Marcacoes = new double[chart1.Series[2].Points.Count()];
            //Pegar sempre o menor maybe, o menor é o primeiro evento que vc marcou.... 
            for (int CanalX = 0; CanalX < CanaisCriados; CanalX++)
            {
                for (int i = 0; i < chart1.Series[(CanalX * 4) + 2].Points.Count(); i++)
                {
                    val = (int)chart1.Series[(CanalX * 4) + 2].Points[i].YValues[0];
                    if (val != 0)
                    {
                        if (iniciou == false)
                        {
                            inicio = i;
                            iniciou = true;
                        }
                        numMAX++;
                    }
                    else if (iniciou == true && numMAX >= threshold)
                    {
                        numMAX = 0;
                        Fim = i;
                        //Salva os dados nos vetores
                        Marcacoes[count] = inicio;
                        count++;
                        iniciou = false;
                    }
                    else
                    {
                        iniciou = false;
                        numMAX = 0;
                    }
                }
            }
            Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanaisCriados, "Resultado", Marcacoes, ValorInicio.X, ValorFim.X, numeroDeCanais, null, null);
            Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
            Thread_.Start();


            return count;
        }
    }
}
