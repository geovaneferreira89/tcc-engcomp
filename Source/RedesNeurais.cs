using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using NeuroLoopGainLibrary.Edf;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using BrainNet.NeuralFramework;
using System.Collections;

namespace AmbienteRPB
{
    public class RedesNeurais
    {
        //Controles Chart--------------------------------------------------------------------------
        private Control _Grafico = null;
        private delegate void AtualizaChart(string opcao, double[] dados, int canal, int CanalParaPlotar, RectangleAnnotation selecaoAtual, int [] myArray);
        private System.Windows.Forms.DataVisualization.Charting.Chart prb = null;
        private VerticalLineAnnotation Cursor;        
        private int CanalAtual;
        private RectangleAnnotation selecaoAtual;
        //Controles Progress Bar-------------------------------------------------------------------
        private Control _BarraDeProgresso = null;
        private delegate void AtualizaPloter(int valor, int caso);
        private System.Windows.Forms.ProgressBar prgbar = null;
        //Controles Scroll Bar --------------------------------------------------------------------
        private Control _ScrollBar = null;
        private delegate void ScrollBar_Propriedades(int _canal, EdfFile SinalEEG);
        private System.Windows.Forms.ScrollBar ScrollBar;
        //Saida de dados -------------------------------------------------------------------------
        private Control SMS = null;
        private delegate void SMS_Propriedades(int opcao, string texto, bool AutScroll);
        private System.Windows.Forms.RichTextBox TextBox;
        private string tipoDeRede;
        //Variaveis do kohoney -------------------------------------------------------------------
        private Neuron_KHn[,] outputs_KHn; // Collection of weights.
        private int iteration;             // Current iteration.
        private int length;                // Side length of output grid.
        private int dimensions;            // Number of input dimensions.
        private Random rnd = new Random();

        private List<string> labels = new List<string>();
        private List<double[]> patterns = new List<double[]>();
        private string file;
        private int VetTreinamento;
        private double[] VetorEvento;
        private double[] Sinal;
        //Varivais por backpropagation ------------------------------------------------------------
        private BackPropNeuronStrategy strategy;
        private BrainNet.NeuralFramework.NeuralNetwork network;
        private ArrayList layers;
        private TrainingData td;
        private ArrayList inputs;
        private ArrayList outputs_;

        private ListaPadroesEventos[] ListasPadrEvents;
        private EdfFile SinalEEG;

        private int [] PadroesATreinar;
        private int MenorTamanho = 0;
        private int CanalParaPlotar = 2;
        //------------------------------------------------------------------------------------------
        public RedesNeurais(EdfFile _SinalEEG, ListaPadroesEventos[] _Listas, double _dimensions, double _length, double _VetTreinamento, string _file, Control Grafico, int _CanalAtual,int _CanalParaPlotar, Control BarraDeProgresso, Control _SMS_, double[] _VetorEvento, double[] _Sinal, int[] _PadroesATreinar, string _TipoDeRede)
        {
            SinalEEG        =  _SinalEEG;
            ListasPadrEvents = _Listas;
            PadroesATreinar = _PadroesATreinar;
            _Grafico        = Grafico;
            CanalAtual      = _CanalAtual;
            _BarraDeProgresso = BarraDeProgresso;
            _ScrollBar     = ScrollBar;
            tipoDeRede     = _TipoDeRede;
            length         = (int)_VetTreinamento;
            dimensions     = (int)_dimensions;
            file           = _file;
            SMS            = _SMS_;
            VetTreinamento = (int)_length;
            VetorEvento    = _VetorEvento;
            Sinal          = _Sinal;
            CanalParaPlotar = _CanalParaPlotar;
        }
        //------------------------------------------------------------------------------------------
        public void Init()
        {
            //Kohonen
            if (tipoDeRede == "Kohonen")
            {
                Plotar("Criar Chart de Barras", null, CanalAtual, CanalParaPlotar, selecaoAtual,null);
                send_SmS(1, "Inicializando...",false);
                Initialise_KHn();
                send_SmS(1, "Carregando Arquivo de Vetores", false);
                LoadData_KHn(file);
                send_SmS(1, "Init NormalisePatterns", false);
                NormalisePatterns_KHn();
                send_SmS(1, "Treinando a rede com 0.0000001", false);
                Train_KHn(0.0000001);
                send_SmS(1, "Resultados:", false);
                DumpCoordinates_KHn();
                send_SmS(1, "Fim...", false);
            }
            else if (tipoDeRede == "BackPropagation")
            {
                //Utilizando o backPropagation 
                send_SmS(1, "Inicializando...", false);
                //Define o tamanho do vetor evento
                MenorTamanho = VetorEvento.Count();
                newRede();
                TreinodaRede(VetorEvento, 1, "SomenteUm"); //null - somente o evento marcado 
                send_SmS(1, "Treinada", false);
                Rodar(Sinal);
                send_SmS(1, "Fim", false);
            }
            else if (tipoDeRede == "BackPropagation_AllEvnts")
            {
                //Utilizando o backPropagation 
                send_SmS(1, "Inicializando...", false);
                //busca pelo menor tamanho do dos eventos deste padrao... 
                for (int i = 0; i < PadroesATreinar.Count(); i++)
                {
                    for (int cont = 0; cont < ListasPadrEvents[PadroesATreinar[i]].NumeroEventos; cont++)
                    {
                        int aux = (int)(ListasPadrEvents[PadroesATreinar[i]].GetValorFim(cont).X - ListasPadrEvents[PadroesATreinar[i]].GetValorInicio(cont).X);
                        if ((cont == 0 && i ==0) || MenorTamanho > aux)
                            MenorTamanho = aux;
                    }
                }
                newRede();
                TreinodaRede(VetorEvento, 1, "TodosEventos"); //null - somente o evento marcado 
                send_SmS(1, "Treinada", false);
                Rodar(Sinal);

                send_SmS(1, "Fim", false);
            }
        }
        
        //------------------------------------------------------------------------------------------
        //#Funçao responsavel por criar a rede
        public void newRede()
        {
            strategy = new BrainNet.NeuralFramework.BackPropNeuronStrategy();

            layers = new ArrayList();
            layers.Add(MenorTamanho);
            layers.Add((int)Math.Sqrt(MenorTamanho));
            layers.Add(8);
            //long neurons = 0;
            network = new BrainNet.NeuralFramework.NeuralNetwork();
            foreach (int neurons in layers)
            {
                BrainNet.NeuralFramework.NeuronLayer layer;
                for (int i = 0; i <= neurons - 1; i++)
                {
                    layer = new BrainNet.NeuralFramework.NeuronLayer();
                    for (i = 0; i <= neurons - 1; i++)
                    {
                        BrainNet.NeuralFramework.INeuron ass = new BrainNet.NeuralFramework.Neuron(strategy);
                        layer.Add(ref ass);
                    }
                    network.Layers.Add(layer);
                }
            }
            network.ConnectLayers();
        }
        //-----------------------------------------------------------------------------------------
        public int [] ConvertToBinary(int n)
        {
            int[] bits = new int[8];
            if (n == 0)
            {
                //a
                bits[0] = 0;
                bits[1] = 1;
                bits[2] = 1;
                bits[3] = 0; 
                bits[4] = 0;
                bits[5] = 0;
                bits[6] = 0;
                bits[7] = 1;
            }
            if (n == 1)
            {//0111 0000 - p
                bits[0] = 0;
                bits[1] = 1;
                bits[2] = 1;
                bits[3] = 1;
                bits[4] = 0;
                bits[5] = 0;
                bits[6] = 0;
                bits[7] = 0;
            }
            if (n == 2)
            {//0111 0111 w
                bits[0] = 0;
                bits[1] = 1;
                bits[2] = 1;
                bits[3] = 1;
                bits[4] = 0;
                bits[5] = 1;
                bits[6] = 1;
                bits[7] = 1;
            }
            return bits;
        }
        //-----------------------------------------------------------------------------------------
        public void TreinodaRede(double[] input1, double output,string tipoDeTreinamento)
        {
            BrainNet.NeuralFramework.NetworkHelper helper;
            helper = new BrainNet.NeuralFramework.NetworkHelper(network);
            ArrayList entrada = new ArrayList();
            ArrayList saida = new ArrayList();
            switch (tipoDeTreinamento)
            {
                case ("TodosEventos"):
                    {
                        for (int PadraoAtual = 0; PadraoAtual < PadroesATreinar.Count(); PadraoAtual++)
                        {
                            int [] saidaB = ConvertToBinary(PadraoAtual);
                            saida = new ArrayList();
                            for (int addSaida = 0; addSaida < 8; addSaida++)
                                saida.Add(saidaB[addSaida]);

                            for (int cont = 0; cont < ListasPadrEvents[PadroesATreinar[PadraoAtual]].NumeroEventos; cont++)
                            {
                                entrada = new ArrayList();
                                string nome_canal = ListasPadrEvents[PadroesATreinar[PadraoAtual]].GetNomesEvento(cont);
                                int X_ = nome_canal.IndexOf("_");
                                nome_canal = nome_canal.Substring(X_ + 1);
                                //Inicio do enveto
                                float x = ListasPadrEvents[PadroesATreinar[PadraoAtual]].GetValorInicio(cont).X;
                                float aux;
                                int DataRecords_lidos = 0;
                                int tempo_X = 0;
                                if (nome_canal != "Correlacao")
                                {
                                    while (tempo_X <= (int)x + MenorTamanho)
                                    {

                                        SinalEEG.ReadDataBlock(DataRecords_lidos);
                                        DataRecords_lidos++;
                                        //Cada ao fim deste for, é adiciocionado somente 1s em todos os canais
                                        for (int j = 0; j < SinalEEG.FileInfo.NrSignals; j++)
                                        {
                                            for (int i = 0; i < SinalEEG.SignalInfo[j].NrSamples; i++)
                                            {
                                                if (SinalEEG.SignalInfo[j].SignalLabel == nome_canal)
                                                {
                                                    if (tempo_X >= (int)x && tempo_X < (int)(MenorTamanho + x))
                                                    {
                                                        entrada.Add(SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
                                                    }
                                                    else
                                                        aux = SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i];
                                                    tempo_X++;
                                                }
                                                else
                                                    aux = SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i];
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    double[] sinal;
                                    GerenArquivos Arquivos = new GerenArquivos();
                                    sinal = Arquivos.ImportaPadraoCorrelacao(ListasPadrEvents[PadroesATreinar[PadraoAtual]].GetNomesEvento(cont));
                                    for (int i = 0; i < MenorTamanho; i++)
                                        entrada.Add(sinal[i]);
                                }
                                helper.AddTrainingData(entrada, saida);
                            }
                        }
                        helper.Train(1000);
                        break;
                    }
                case ("SomenteUm"):
                    {
                        //a
                        saida.Add(0);//0
                        saida.Add(1);//1
                        saida.Add(1);//2
                        saida.Add(0);//3
                        saida.Add(0);//4
                        saida.Add(0);//5
                        saida.Add(0);//6
                        saida.Add(1);//7
                        for (int i = 0; i < input1.Count(); i++)
                            entrada.Add(input1[i]);
                        helper.AddTrainingData(entrada, saida);
                        helper.Train(1000);
                        break;
                    }
            }
         
        }
        //-----------------------------------------------------------------------------------------
        public void Rodar(double[] input1)
        {
            load_progress_bar(0, 4);
            load_progress_bar(VetorEvento.Count(), 2);

            int cont = 0;
            bool chave = true;
            double[] dados = new double[2];
            //Corrige o problema de deslocamento do sinal para esquerda... 
            dados[1] = 0;
            dados[0] = 0;
            outputs_ = new ArrayList();
            int[] saidaInt = new int[8];
            outputs_.Add(0.0);
            for (int i = 0; i < (MenorTamanho/ 2); i++)
                Plotar("AddDadoBKP", dados, CanalAtual, CanalParaPlotar, selecaoAtual, saidaInt);
            for (int i = 0; i < VetTreinamento; i++)
            {
                inputs = new ArrayList();
                while (cont < MenorTamanho)
                {
                    if ((cont + i) < Sinal.Count())
                        inputs.Add(Sinal[cont + i]);
                    else
                        inputs.Add(0.0);
                    cont++;

                }
            
                dados[0] = i;
                dados[1] = MenorTamanho + i;

                cont = 0;
                outputs_ = new ArrayList(network.RunNetwork(inputs));
                
                BrainNet.NeuralFramework.PatternProcessingHelper patternHelper = new PatternProcessingHelper();
                char character = (char)(patternHelper.NumberFromArraylist(outputs_));

                for (int kk = 0; kk < 8; kk++)
                {
                    if(0.99 < Convert.ToDouble(outputs_[kk]))
                        saidaInt[kk] = 1;
                    else
                        saidaInt[kk] = 0;
                }
                if (saidaInt[7] == 1 && saidaInt[6] == 0 && saidaInt[5] == 0 && saidaInt[4] == 0 && saidaInt[3] == 0 && saidaInt[2] == 1 && saidaInt[1] == 1 && saidaInt[0] == 0)
                    character = 'a';
                else
                    character = 'E';
                
                string saida = i + "\n\n" + Convert.ToString(outputs_[0]) + "\n" + Convert.ToString(outputs_[1]) + "\n" + Convert.ToString(outputs_[2]) + "\n" + Convert.ToString(outputs_[3]) + "\n" + Convert.ToString(outputs_[4]) + "\n" + Convert.ToString(outputs_[5]) + "\n" + Convert.ToString(outputs_[6]) + "\n" + Convert.ToString(outputs_[7]) + "\n ------ \n" + character;
                string saida2 = Convert.ToString(saidaInt[7]) + "\t" + Convert.ToString(saidaInt[6]) + "\t" + Convert.ToString(saidaInt[5]) + "\t" + Convert.ToString(saidaInt[4]) + "\t" + Convert.ToString(saidaInt[3]) + "\t" + Convert.ToString(saidaInt[2]) + "\t" + Convert.ToString(saidaInt[1]) + "\t" + Convert.ToString(saidaInt[0]) + "\t||   " + character;

                
                if(!chave)
                    send_SmS(1, saida2, false);

                Plotar("AddDadoBKP", dados, CanalAtual, CanalParaPlotar, selecaoAtual, saidaInt);
                load_progress_bar(0, 1);
                Thread.Sleep(10);
                if (chave)
                {
                    send_SmS(1, saida2, true);
                    Thread.Sleep(2);
                    DialogResult resposta = MessageBox.Show("Dado: " + saida, "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.OKCancel);
                    if (resposta == DialogResult.Cancel)
                        chave = false;
                }
                if (i == 600)//540
                    chave = true;
                if (i == 1300)//1150
                    chave = true;
                if (i == 1940)//1700
                    chave = true;
                if (i == 2600)
                    chave = true;
            }
            load_progress_bar(1, 3);
        }
        //====================================================================================================
        //                                        KOHONEN
        //====================================================================================================
        private void Initialise_KHn()
        {
            outputs_KHn = new Neuron_KHn[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    outputs_KHn[i, j] = new Neuron_KHn(i, j, length);
                    outputs_KHn[i, j].Weights = new double[dimensions];
                    for (int k = 0; k < dimensions; k++)
                    {
                        outputs_KHn[i, j].Weights[k] = rnd.NextDouble();
                    }
                }
            }
        }
        //----------------------------------
        private void LoadData_KHn(string file)
        {
            load_progress_bar(1, 3);
            load_progress_bar(0, 4);
            load_progress_bar(VetTreinamento, 2);

            int cont = 0;
            string resultado;
            int canal = 0;
            string line = null;
            int vetores = 0;
            for (int i = 0; i < VetTreinamento; i++)
            {
                while (cont < VetorEvento.Count())
                {
                    if ((cont + i) < Sinal.Count())
                        resultado = Convert.ToString(Sinal[cont + i]);
                    else
                        resultado = "0.0";
                    resultado = resultado.Replace(",", ".");
                    line = line + ", " + resultado;
                    cont++;
                }
                string[] _line = line.Split(',');
                labels.Add(_line[0]);
                double[] inputs = new double[dimensions];
                for (int j = 0; j < dimensions; j++)
                {
                    inputs[j] = double.Parse(_line[j + 1]);
                }
                patterns.Add(inputs);
                line = null;
                cont = 0;
                vetores++;
                line = "vetor" + vetores;
                load_progress_bar(0, 1);
            }
            load_progress_bar(1, 3);
        }
        //----------------------------------
        private void NormalisePatterns_KHn()
        {
            for (int j = 0; j < dimensions; j++)
            {
                double sum = 0;
                for (int i = 0; i < patterns.Count; i++)
                {
                    sum += patterns[i][j];
                }
                double average = sum / patterns.Count;
                for (int i = 0; i < patterns.Count; i++)
                {
                    patterns[i][j] = patterns[i][j] / average;
                }
            }
        }
        //----------------------------------
        private void Train_KHn(double maxError)
        {
            double currentError = double.MaxValue;
            int count = 0 ;
            while (currentError > maxError)
            {
                currentError = 0;
                List<double[]> TrainingSet = new List<double[]>();
                foreach (double[] pattern in patterns)
                {
                    TrainingSet.Add(pattern);
                }
                for (int i = 0; i < patterns.Count; i++)
                {
                    double[] pattern = TrainingSet[rnd.Next(patterns.Count - i)];
                    currentError += TrainPattern_KHn(pattern);
                    TrainingSet.Remove(pattern);
                }
                // Console.WriteLine(currentError.ToString("0.0000000"));
                send_SmS(1, Convert.ToString(count),true);
                count++;
            }
        }
        //----------------------------------
        private double TrainPattern_KHn(double[] pattern)
        {
            double error = 0;
            Neuron_KHn winner = Winner_KHn(pattern);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    error += outputs_KHn[i, j].UpdateWeights_KHn(pattern, winner, iteration);
                }
            }
            iteration++;
            return Math.Abs(error / (length * length));
        }
        //----------------------------------
        private void DumpCoordinates_KHn()
        {
            bool chave = true;
            double[] dados = new double[10];
            for (int i = 0; i < patterns.Count; i++)
            {
                Neuron_KHn n = Winner_KHn(patterns[i]);
                string saida = labels[i] + " " + n.X + " " + n.Y;
                dados[0] = n.X;
                dados[1] = n.Y;
                dados[2] = i;
                dados[3] = VetorEvento.Count() + i;
                Plotar("AddDadoKohonen", dados, CanalAtual, CanalParaPlotar, selecaoAtual, null); // tem o n.x tbm para no caso o Mapa mesmo... 
                if(!chave)
                    send_SmS(1, saida,false);
                if (chave)
                {
                    send_SmS(1, saida, true);
                    Thread.Sleep(1);
                    DialogResult resposta = MessageBox.Show("Dado: " + i + "\nPlotado\nX: " + n.X + "\nY: " + n.Y, "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.OKCancel);
                    if (resposta == DialogResult.Cancel)
                        chave = false;
                }
                if (i == 520)
                    chave = true;
                if (i == 1300)
                    chave = true;
                if (i == 2000)
                    chave = true;
                if (i == 2200)
                    chave = true;
            }
        }
        //----------------------------------
        private Neuron_KHn Winner_KHn(double[] pattern)
        {
            Neuron_KHn winner = null;
            double min = double.MaxValue;
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                {
                    double d = Distance_KHn(pattern, outputs_KHn[i, j].Weights);
                    if (d < min)
                    {
                        min = d;
                        winner = outputs_KHn[i, j];
                    }
                }
            return winner;
        }
        //----------------------------------
        private double Distance_KHn(double[] vector1, double[] vector2)
        {
            double value = 0;
            for (int i = 0; i < vector1.Length; i++)
            {
                value += Math.Pow((vector1[i] - vector2[i]), 2);
            }
            return Math.Sqrt(value);
        }

        //====================================================================================================
        //                                ...Funções de saida do sistema... 
        // (Gráficos, Mensagem pelo RichText..)
        //====================================================================================================
        //Saida de Dados
        private void send_SmS(int opcao, string texto, bool AutScrool)
        {

            if (SMS.InvokeRequired)
            {
                SMS.BeginInvoke(new SMS_Propriedades(send_SmS), new Object[] { opcao, texto, AutScrool });
            }
            else
            {
                TextBox = SMS as System.Windows.Forms.RichTextBox;
                if (opcao == 1)
                {
                    TextBox.Text = TextBox.Text + "\n" + texto;
                    if (AutScrool)
                    {
                        TextBox.SelectionStart = TextBox.Text.Length;
                        TextBox.ScrollToCaret();
                    }
                }

            }
        }
        //-------------------------------------------------------------------------------
        //Barra de progresso
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
                if (caso == 3)
                    prgbar.Visible = false;
                if (caso == 4)
                    prgbar.Value = 0;
            }
        }

        //-------------------------------------------------------------------
        //Saida pelo Grafico 
        private void Plotar(string opcao, double[] dados, int canal, int CanalParaPlotar, RectangleAnnotation selecaoAtual, int[] myArray)
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] { opcao, dados, canal, CanalParaPlotar, selecaoAtual, myArray });
            }
            else
            {
                switch (opcao)
                {
                    case ("AddDadoBKP"):
                        {
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                            //w
                            if (myArray[7] == 1 && myArray[6] == 1 && myArray[5] == 1 && myArray[4] == 0 && myArray[3] == 1 && myArray[2] == 1 && myArray[1] == 1 && myArray[0] == 0)
                                 prb.Series["canal" + (CanalParaPlotar)].Points.AddY(0.30);
                            //p
                            else if (myArray[7] == 0 && myArray[6] == 0 && myArray[5] == 0 && myArray[4] == 0 && myArray[3] == 1 && myArray[2] == 1 && myArray[1] == 1 && myArray[0] == 0)
                                prb.Series["canal" + (CanalParaPlotar)].Points.AddY(0.60);
                            //a
                            else if (myArray[7] == 1 && myArray[6] == 0 && myArray[5] == 0 && myArray[4] == 0 && myArray[3] == 0 && myArray[2] == 1 && myArray[1] == 1 && myArray[0] == 0)
                                prb.Series["canal" + (CanalParaPlotar)].Points.AddY(1);
                            else
                                prb.Series["canal" + (CanalParaPlotar)].Points.AddY(0);

                            PointF zero = new PointF(0, 0);
                            prb.ChartAreas[canal].CursorX.SetSelectionPixelPosition(zero, zero, true);
                            prb.ChartAreas[canal].CursorX.SelectionColor = Color.FromArgb(128, Color.Yellow);
                            prb.ChartAreas[canal].CursorX.IsUserEnabled = true;
                            prb.ChartAreas[canal].CursorX.IsUserSelectionEnabled = true;

                            PointF Padrao_Inicio = new PointF((float)prb.ChartAreas[canal].AxisX.ValueToPixelPosition(dados[0]), (float)prb.ChartAreas[canal].AxisY.ValueToPixelPosition(dados[0]));
                            PointF Padrao_Fim = new PointF((float)prb.ChartAreas[canal].AxisX.ValueToPixelPosition(dados[1]), (float)prb.ChartAreas[canal].AxisY.ValueToPixelPosition(dados[1]));
                            //Colore a região do evento
                            prb.ChartAreas[canal].CursorX.SetSelectionPixelPosition(Padrao_Inicio, Padrao_Fim, true);
                            break;
                        }
                    case ("AddDadoKohonen"):
                        {
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                            
                            prb.Series["canal" + (canal+2)].Points.AddY(dados[1]);
                            //Mapa
                            prb.Series["canal" + (canal+3)].Points.AddXY(dados[0], dados[1]);

                            PointF zero = new PointF(0,0);

                            prb.ChartAreas[canal].CursorX.SetSelectionPixelPosition(zero, zero, true);
                            prb.ChartAreas[canal].CursorX.SelectionColor = Color.FromArgb(128, Color.Yellow); 
                            prb.ChartAreas[canal].CursorX.IsUserEnabled = true;
                            prb.ChartAreas[canal].CursorX.IsUserSelectionEnabled = true;

                            PointF Padrao_Inicio = new PointF((float)prb.ChartAreas[canal].AxisX.ValueToPixelPosition(dados[2]), (float)prb.ChartAreas[canal].AxisY.ValueToPixelPosition(dados[2]));
                            PointF Padrao_Fim = new PointF((float)prb.ChartAreas[canal].AxisX.ValueToPixelPosition(dados[3]), (float)prb.ChartAreas[canal].AxisY.ValueToPixelPosition(dados[3]));
                            //Colore a região do evento
                            prb.ChartAreas[canal].CursorX.SetSelectionPixelPosition(Padrao_Inicio, Padrao_Fim, true);

                            break;
                        }
                    case ("Criar Chart de Barras"):
                        {
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;

                            if (prb.Series.Count != (canal + 4))
                            {
                                prb.Series.Add("canal" + (canal + 2));
                                prb.Series["canal" + (canal + 2)].ChartArea = "canal" + (canal + 2);
                                prb.Titles.Add("canal" + (canal + 2));

                                prb.Titles[canal + 2].Position.Height = 3;
                                prb.Titles[canal + 2].Position.Width = 40;
                                prb.Titles[canal + 2].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[canal + 2].Position.X = 0;
                                prb.Titles[canal + 2].Position.Y = (25 * (canal + 2)) + ((100 - (25 * (canal + 2))) / 2);

                                //mapa de kohonei
                                prb.Series.Add("canal" + (canal + 3));
                                prb.Series["canal" + (canal + 3)].ChartArea = "canal" + (canal + 3);
                                prb.Titles.Add("canal" + (canal + 3));

                                prb.Titles[canal + 3].Position.Height = 3;
                                prb.Titles[canal + 3].Position.Width = 40;
                                prb.Titles[canal + 3].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[canal + 3].Position.X = 0;
                                prb.Titles[canal + 3].Position.Y = (25 * 4) + ((100 - (25 * 4)) / 2);

                            }
                            else
                            {
                                prb.Series["canal" + (canal + 2)].Points.Clear();
                                prb.Series["canal" + (canal + 3)].Points.Clear();
                            }
                            prb.Series["canal" + (canal + 2)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                            prb.Titles[canal + 2].Text = "Kohonen";
                            prb.Series["canal" + (canal + 2)].Color = Color.LightBlue;

                            prb.Series["canal" + (canal + 3)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                            prb.Titles[(canal + 3)].Text = "Mapa";
                            prb.Series["canal" + (canal + 3)].Color = Color.Red;
                            prb.ChartAreas["canal" + (canal + 3)].AxisY.Enabled = AxisEnabled.True;
                            prb.ChartAreas["canal" + (canal + 3)].AxisX.Enabled = AxisEnabled.True;
                            prb.ChartAreas["canal" + (canal + 3)].Axes[1].MajorGrid.LineColor = Color.Gainsboro;
                            prb.ChartAreas["canal" + (canal + 3)].Axes[0].MajorGrid.LineColor = Color.Gainsboro;

                            break;
                        }
                }
            }
        }
    }
    //========================================================================================================
    //                                             Classe Neuron
    //========================================================================================================
   public class Neuron_KHn
     {
        public double[] Weights;
        public int X;
        public int Y;
        private int length;
        private double nf;

        public Neuron_KHn(int x, int y, int length)
        {
            X = x;
            Y = y;
            this.length = length;
            nf = 1000 / Math.Log(length);
        }

        private double Gauss_KHn(Neuron_KHn win, int it)
        {
            double distance = Math.Sqrt(Math.Pow(win.X - X, 2) + Math.Pow(win.Y - Y, 2));
            return Math.Exp(-Math.Pow(distance, 2) / (Math.Pow(Strength_KHn(it), 2)));
        }

        private double LearningRate_KHn(int it)
        {
            return Math.Exp(-it / 1000) * 0.1;
        }

        private double Strength_KHn(int it)
        {
            return Math.Exp(-it / nf) * length;
        }

        public double UpdateWeights_KHn(double[] pattern, Neuron_KHn winner, int it)
        {
            double sum = 0;
            for (int i = 0; i < Weights.Length; i++)
            {
                double delta = LearningRate_KHn(it) * Gauss_KHn(winner, it) * (pattern[i] - Weights[i]);
                Weights[i] += delta;
                sum += delta;
            }
            return sum / Weights.Length;
        }
    }
    //------------------------------------------------------------------------------------------
}

 
