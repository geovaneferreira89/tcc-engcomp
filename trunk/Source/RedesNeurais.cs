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
using BrainNet.NeuralFramework;
using System.Runtime.InteropServices;
using System.Collections;

namespace AmbienteRPB
{
    public class RedesNeurais
    {
        //Controles Chart--------------------------------------------------------------------------
        private Control _Grafico = null;
        private delegate void AtualizaChart(string opcao, double[] dados, int canal, int CanalParaPlotar, RectangleAnnotation selecaoAtual, double [] myArray,List<double> X_, List<double> Y_);
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
        private double[,] SaidaFinal; 
        private Random rnd = new Random();
        private List<string> labels = new List<string>();
        private List<double[]> patterns = new List<double[]>();
        private string file;
        private int VetTreinamento;
        private double[] VetorEvento;
        private double[] Sinal;

        List<double> X_Vals;
        List<double> Y_Vals;

        //Varivais por backpropagation ------------------------------------------------------------
        private bool RNImportada;
        private INeuralNetwork network;
        private ArrayList inputs;
        private ArrayList MLP_output;
        private bool treinarnova = true;
        private ListaPadroesEventos[] ListasPadrEvents;
        private EdfFile SinalEEG;
        private int [] PadroesATreinar;
        private int MenorTamanho = 0;
        private int CanalParaPlotar = 2;
        private double[] vetorDeResultados;
        private bool it_is_debug = false;
        private bool UsarReferencia = false;

        //------------------------------------------------------------------------------------------
        public RedesNeurais(EdfFile _SinalEEG, ListaPadroesEventos[] _Listas, bool _UsarReferencia, double _dimensions, double _length, double _VetTreinamento, string _file, Control Grafico, int _CanalAtual, int _CanalParaPlotar, Control BarraDeProgresso, Control _SMS_, double[] _VetorEvento, double[] _Sinal, int[] _PadroesATreinar, string _TipoDeRede, ref INeuralNetwork _network, bool _RNImportada, int _MenorTamanho, bool _modDebug)
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
            RNImportada     = _RNImportada;
            network         = _network;
            MenorTamanho    = _MenorTamanho;
            UsarReferencia = _UsarReferencia;
            it_is_debug = _modDebug;
        }
        //------------------------------------------------------------------------------------------
        public void Init()
        {
            //Kohonenn
            switch(tipoDeRede)
            {
                case("Kohonen"):
                {
                    float min_inicio = DateTime.Now.Minute;
                    send_SmS(2, "Iniciando - " + string.Format("{0:HH:mm:ss tt}", DateTime.Now), false);
                    X_Vals = new List<double>();
                    Y_Vals = new List<double>();
                    double[] offset = new double[2];
                    offset[0] = MenorTamanho;
                    Plotar("CLEAR", null, 1, CanalParaPlotar, selecaoAtual, vetorDeResultados, null, null);
                    Plotar("CLEAR", null, 1, CanalParaPlotar+1, selecaoAtual, vetorDeResultados, null, null);
                    Plotar("Criar Chart de Barras", null, CanalAtual, CanalParaPlotar, selecaoAtual, offset, null, null);
                    send_SmS(1, "Adicionando Entradas e treinando", false);
                    int inicio    = 0;
                    int divisaoKo = 3;
                    if (200000 < VetTreinamento)
                        divisaoKo = 4;
                    else if (VetTreinamento < 4000)
                        divisaoKo = 1;
                    
                    load_progress_bar(1, 3);
                    load_progress_bar(0, 4);
                    load_progress_bar(divisaoKo, 2);

                    Initialise_KHn();
                    send_SmS(1, "Treinando a rede com erro abaixo de 0.00001", false);
                    for (int max = 0; max < divisaoKo; max++)
                    {
                        LoadData_KHn(file, inicio, ((max + 1) * (VetTreinamento / divisaoKo)));
                        NormalisePatterns_KHn();
                        Train_KHn(0.00001);
                        DumpCoordinates_KHn();
                        inicio = inicio + (VetTreinamento / divisaoKo);
                        load_progress_bar(0, 1);
                    }
                    load_progress_bar(1, 3);
                    //Imprime a matriz de resultados
                    send_SmS(1, "Terminado: " + string.Format("{0:HH:mm:ss tt}", DateTime.Now), false);
                    send_SmS(1, "Duração: " + Convert.ToString(DateTime.Now.Minute - min_inicio) + " min.", false);
                    //send_SmS(1, "Matriz do Kohonen", false); 
                    for (int i = 0; i < length; i++)
                    {
                        string saida = "";
                        for (int j = 0; j < length; j++)
                        {
                            double[] dados = new double[3];
                            dados[0] = i;
                            dados[1] = j;
                            dados[2] = SaidaFinal[j, i];
                            Plotar("MapaKohonen", dados, CanalAtual, CanalParaPlotar, selecaoAtual, offset, null, null);
                         //   saida += SaidaFinal[j, i] + "\t";
                        }
                        //send_SmS(1, saida, false);
                    }
                     if(!it_is_debug)
                        Plotar("PlotKohonen", null, CanalAtual, CanalParaPlotar, selecaoAtual, offset, X_Vals, Y_Vals);
                    //Thread.Sleep(50);
                    break;
                }
                case("BackPropagation"):
                {
                        //Utilizando o backPropagation 
                        send_SmS(2, "Inicializando", false);
                        //Define o tamanho do vetor evento
                        MenorTamanho = VetorEvento.Count();
                        if(!RNImportada)
                            TreinodaRede(VetorEvento, 1, "SomenteUm", 0); //null - somente o evento marcado 
                        send_SmS(1, "Treinada", false);
                        vetorDeResultados = new double[Sinal.Count()];
                        Rodar(Sinal, 0);
                        send_SmS(1, "Fim", false);
                        break;
                }
                case("BackPropagation_AllEvnts"):
                {
                    int loopMAX = 3;
                    float inicio = DateTime.Now.Minute;
                    while (treinarnova && loopMAX != 0)
                    {
                        Plotar("CLEAR", null, 1, CanalParaPlotar, selecaoAtual, vetorDeResultados,null,null);
                        //Utilizando o backPropagation 
                        send_SmS(0, "", false);
                        send_SmS(2, "Iniciando - " + string.Format("{0:HH:mm:ss tt}", DateTime.Now), false);
                        //busca pelo menor tamanho do dos eventos deste padrao... 
                        vetorDeResultados = new double[VetTreinamento];
                        if (!RNImportada)
                        {
                            send_SmS(1, "Adicionando entradas na rede com " + ListasPadrEvents[PadroesATreinar[0]].GetNomePadrao(), false);
                            TreinodaRede(VetorEvento, 1, "TodosEventos", 0);
                            send_SmS(1, "Treinada", false);
                        }
                        else
                            MenorTamanho = network.InputLayer.Count;
                        send_SmS(1, "Reconhencendo: " + string.Format("{0:HH:mm:ss tt}", DateTime.Now), false);
                        Rodar(Sinal, 0);
                        if (!treinarnova)
                        {
                            float fim = DateTime.Now.Minute;
                            send_SmS(1, "Terminado: " + string.Format("{0:HH:mm:ss tt}", DateTime.Now), false);
                            send_SmS(1, "Duração: " + Convert.ToString(fim - inicio) + " min.", true);
                            Plotar("CLEAR", null, 1, CanalParaPlotar, selecaoAtual, vetorDeResultados, null, null);
                            Plotar("BKP", null, 0, CanalParaPlotar, selecaoAtual, vetorDeResultados, null, null);
                        }
                        else
                        {
                            send_SmS(1, "Retreinando a Rede.", false);
                            loopMAX--;
                        }
                    }
                    if(loopMAX == 0)
                        send_SmS(5, "Erro!\nNão consiguiu detectar!\nObs.: Verifique o conjunto de treinamento", false);
                    break;
               }
               case("BackPropagationTreinar100x"):
               {
                    //Utilizando o backPropagation 
                    send_SmS(0, "", false);
                    send_SmS(2, "Inicializando.", false);
                    //Busca pelo menor tamanho do dos eventos deste padrao... 
                    vetorDeResultados = new double[Sinal.Count()];
                    for(int i=0; i< PadroesATreinar.Count();i++)
                    {
                            send_SmS(1, "Treinando a rede 1000 + com '" + ListasPadrEvents[PadroesATreinar[i]].GetNomePadrao(), false);
                            TreinodaRede(VetorEvento, 1, "TodosEventos", i);
                            send_SmS(1, "Treinada", false);
                    }
                    break;
               }
            }//Fim switch
        }//Fim MLP NOVA Testes 
        //_________________________________________________________________________________________________
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
                        BrainNet.NeuralFramework.INeuron neuronio = new BrainNet.NeuralFramework.Neuron(strategy);
                        layer.Add(ref neuronio);
                    }
                    network.Layers.Add(layer);
                }
            }
            network.ConnectLayers();
        }
        //-----------------------------------------------------------------------------------------
        public void TreinodaRede(double[] input1, double output,string tipoDeTreinamento, int RedeAtual)
        {
            BrainNet.NeuralFramework.NetworkHelper helper;
            helper = new BrainNet.NeuralFramework.NetworkHelper(network);
            ArrayList entrada = new ArrayList();
            ArrayList saida = new ArrayList();
            List<int> UsadosNoTreino = new List<int>();
            List<int> DescartadosDoTreino = new List<int>();
            bool PadraoDescatardo = false;
            switch (tipoDeTreinamento)
            {
                case ("TodosEventos"):
                {
                    saida = new ArrayList();
                    saida.Add(1);
                    List<float> conjTreinado = new List<float>();
                    load_progress_bar(0, 4);
                    int totalParaTreino = ListasPadrEvents[PadroesATreinar[RedeAtual]].NumeroEventos;
                    if (totalParaTreino > 300)
                        totalParaTreino = 300;
                    load_progress_bar(totalParaTreino, 2);
                    for (int cont = 0; cont < totalParaTreino; cont++)
                    {
                        entrada = new ArrayList();
                        string nome_canal = ListasPadrEvents[PadroesATreinar[RedeAtual]].GetNomesEvento(cont);
                        int X_ = nome_canal.IndexOf("_");
                        nome_canal = nome_canal.Substring(X_ + 1);
                        //Inicio do enveto
                        float x = ListasPadrEvents[PadroesATreinar[RedeAtual]].GetValorInicio(cont).X;
                        float x_fim = ListasPadrEvents[PadroesATreinar[RedeAtual]].GetValorFim(cont).X;
                        float referencia = ListasPadrEvents[PadroesATreinar[RedeAtual]].GetValorMeio(cont).X;
                        int DataRecords_lidos = 0;
                        int tempo_X = 0;
                        ///---------------------------------------------------------
                        ///Seleciona os eventos que foram marcados no form principal
                        ///---------------------------------------------------------
                        if (nome_canal != "Correlacao")
                        {
                            PadraoDescatardo = false;
                            while (tempo_X <= (int)(referencia + MenorTamanho/25))
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
                                            //Pela Referencia
                                            if (UsarReferencia)
                                            {
                                                if ((x_fim - x) >= MenorTamanho && (referencia - x) >= (MenorTamanho / 2) && (x_fim - referencia) >= (MenorTamanho / 2) && tempo_X >= (referencia - (MenorTamanho / 2)) && tempo_X < (referencia + (MenorTamanho / 2)))
                                                {
                                                    entrada.Add(SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
                                                    conjTreinado.Add(SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
                                                }
                                            }
                                            else
                                            {
                                                if (tempo_X >= (int)x && tempo_X < (int)(MenorTamanho + x))
                                                        entrada.Add(SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
                                            }
                                            tempo_X++;
                                        }
                                    }
                                }
                            }
                        }
                        ///-------------------------------------------------------------
                        ///Seleciona os eventos que foram marcados no form de reultados
                        ///-------------------------------------------------------------
                        else
                        {
                            double[] sinal;
                            GerenArquivos Arquivos = new GerenArquivos();
                            sinal = Arquivos.ImportaPadraoCorrelacao(ListasPadrEvents[PadroesATreinar[RedeAtual]].GetNomesEvento(cont));
                            //Pegando pela referencia
                            if (cont == 1420)
                                load_progress_bar(0, 1);
                            if (UsarReferencia)
                            {
                                if (sinal.Count() > MenorTamanho && ((int)(referencia -x)) > (MenorTamanho / 2) && ((int)(x_fim - referencia)) > (MenorTamanho / 2) /* && cont != 48 && cont != 141  && cont != 95 && cont != 221 && cont != 176 && cont != 21 && cont != 81 && cont != 30  && cont != 49 && cont != 134 && cont != 11 8&& cont != 88 && cont != 83 && cont != 36&& cont != 280 && cont != 260 && cont != 355 && cont != 368 && cont != 360 && cont != 310 && cont != 358 && cont != 348*/)
                                {
                                    UsadosNoTreino.Add(cont);
                                    for (int i = (int)(referencia - (MenorTamanho / 2)); i < (int)(referencia + (MenorTamanho / 2)); i++)
                                    {
                                        entrada.Add(sinal[i]);
                                        conjTreinado.Add((float)sinal[i]);
                                    }
                                    PadraoDescatardo = false;
                                }
                                else
                                {
                                    PadraoDescatardo = true;
                                    DescartadosDoTreino.Add(cont);
                                }
                            }
                            //Sem a referencia
                            else
                            {
                                if (sinal.Count() <= MenorTamanho)
                                {
                                    for (int i = 0; i < MenorTamanho; i++)
                                        entrada.Add(sinal[i]);
                                    PadraoDescatardo = false;
                                }

                                else
                                    PadraoDescatardo = true;
                            }
                        }
                        if (!PadraoDescatardo)
                            helper.AddTrainingData(entrada, saida);
                        load_progress_bar(0, 1);
                    }
                    ///---------------------------------------
                    ///Gera a saida dos vetores de treinamento
                    ///---------------------------------------
                    if (UsarReferencia)
                    {
                        GerenArquivos dir = new GerenArquivos();
                        System.IO.StreamWriter fileSalve = new System.IO.StreamWriter(dir.getPathUser() + "ConjTreinado.txt", false);
                        string smss = "";

                        for (int val = 0; val < UsadosNoTreino.Count; val++)
                            smss += Convert.ToString(UsadosNoTreino[val]) + "\t";
                            
                        fileSalve.WriteLine(smss);
                        smss = "";
                        for (int linhas = 0; linhas < MenorTamanho; linhas++)
                        {
                            for (int padrTreinados = 0; padrTreinados < (conjTreinado.Count / MenorTamanho); padrTreinados++)
                            {
                                smss += conjTreinado[(padrTreinados * MenorTamanho) + linhas].ToString() + "\t";
                            }
                            fileSalve.WriteLine(smss);
                            smss = "";
                        }
                        fileSalve.Close();
                        send_SmS(1, "Total Usados : " + Convert.ToString(conjTreinado.Count / MenorTamanho), false);
                        send_SmS(1, "Total Descartados : " + Convert.ToString(DescartadosDoTreino.Count), false);
                    }
                    ///------------------------------------///
                    ///Treina a Rede Neural                               
                    ///------------------------------------///
                    send_SmS(1, "Treinando", false);
                    load_progress_bar(1, 3);
                    helper.Train(1500);
                    //calculo do erro
                    NetworkSerializer erro = new BrainNet.NeuralFramework.NetworkSerializer();
                    send_SmS(1, "Erro em: " + Convert.ToString(erro.GetERROR(network)), false); 
                    break;
            }
            case ("SomenteUm"):
            {
                saida.Add(1);
                for (int i = 0; i < input1.Count(); i++)
                    entrada.Add(input1[i]);
                helper.AddTrainingData(entrada, saida);
                helper.Train(1000);
                break;
            }
            }
        }
        //-----------------------------------------------------------------------------------------
        public void Rodar(double[] input1, int RedeAtual)
        {
            load_progress_bar(0, 4);
            load_progress_bar(VetTreinamento - MenorTamanho, 2);
            double threshold = 0.1;
            char character;
            bool chave = true;
            double[] dados = new double[3];
            dados[0] = 0;
            dados[1] = 0;
            dados[2] = 0;
            int offset = (MenorTamanho / 4);
            //Corrige o problema de deslocamento do sinal para esquerda... 
            for (int i = 0; i < offset; i++)
            {
                vetorDeResultados[i] = 0;
                if (it_is_debug)
                    Plotar("VectorAtual", dados, CanalAtual, CanalParaPlotar, selecaoAtual, vetorDeResultados, null, null);
            }

            for (int i = 0; i < VetTreinamento - offset; i++)
            {
                MLP_output = new ArrayList();                
                inputs     = new ArrayList();
                MLP_output.Add(0.0);
                for (int cont = 0; cont < MenorTamanho; cont++){
                    if ((cont + i) < Sinal.Count())
                        inputs.Add(Sinal[cont + i]);
                    else
                        inputs.Add(0);
                }
                dados[0] = i;
                dados[1] = MenorTamanho + i;
                //RODA A RN
                MLP_output = new ArrayList(network.RunNetwork(inputs));
                if (i <= 26)
                {
                    if (threshold < Convert.ToDouble(MLP_output[0]))
                        threshold = Convert.ToDouble(MLP_output[0]);
                    vetorDeResultados[i + offset] = 0;
                }
                else
                {
                    if (threshold < Convert.ToDouble(MLP_output[0]))
                    {
                        vetorDeResultados[i + offset] = 1;
                        treinarnova = false;
                    }
                    else if (threshold > Convert.ToDouble(MLP_output[0])){
                        vetorDeResultados[i + offset] = 5;
                        treinarnova = false;
                    }
                    else
                        vetorDeResultados[i + offset] = 0;
                }
                //-------------------------------------------------------
                if (it_is_debug)
                {
                    if (vetorDeResultados[i + offset] == 1)
                        character = '~';
                    else
                        character = ' ';
                    if (chave)
                    {
                        dados[2] = vetorDeResultados[i + offset];
                        string saida = i + "\n\n" + Convert.ToString(MLP_output[0]);
                        string saida2 = Convert.ToString(vetorDeResultados[i + offset]) + "\t" + character;
                        Plotar("VectorAtual", dados, CanalAtual, CanalParaPlotar, selecaoAtual, vetorDeResultados, null, null);
                        send_SmS(1, saida2, true);
                        Thread.Sleep(12);
                        DialogResult resposta = MessageBox.Show("Dado: " + saida, "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.OKCancel);
                        if (resposta == DialogResult.Cancel)
                        {
                            chave = false;
                            it_is_debug = false;
                        }
                    }
                }
                load_progress_bar(0, 1);
            }
            //Salva em disco a saida 
            //GerenArquivos dir = new GerenArquivos();
            //System.IO.StreamWriter fileSalve = new System.IO.StreamWriter(dir.getPathUser() + "saida.txt", false);
            //string smss = "";
            //for (int val = 0; val < vetorDeResultados.Count(); val++)
            //    smss += Convert.ToString(vetorDeResultados[val]) + "\t";
            //fileSalve.WriteLine(smss);
            //fileSalve.Close();
            //send_SmS(1, "Salvo em disco a saida.", false);
            //Calculo para o threshold inicial
            //media = media / (VetTreinamento - MenorTamanho);
            //for (int val = 0; val < (VetTreinamento - MenorTamanho); val++)
            //{
            //    if (vetorDeResultados[val] > media)
            //    {
            //        vetorDeResultados[val] = 1;
            //        treinarnova = false;
            //    }
            //    else
            //        vetorDeResultados[val] = 0;
            //}

            load_progress_bar(1, 3);
            if (treinarnova)
                novaRedeMLP();
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
                if (opcao == 2)
                {
                    TextBox.Text = texto;
                }
                if (opcao == 0)
                {
                    TextBox.ForeColor = Color.Black;
                    TextBox.Text = "";
                }
                if (opcao == 5)
                {
                    TextBox.Text = "";
                    TextBox.Text = texto;
                    TextBox.ForeColor = Color.Red;
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
                switch (caso)
                {
                    case (0):
                    {
                        prgbar.Visible = true;
                        prgbar.Value = 0;
                        break;
                    }
                    case (1):
                    {
                        if (prgbar != null)
                            prgbar.Increment(1);
                        break;
                    }
                    case (2):
                    {
                        prgbar.Visible = true;
                        prgbar.Maximum = valor;
                        break;
                    }
                    case (3):
                    {
                        prgbar.Visible = false;
                        break;
                    }
                    case (4):
                    {
                        prgbar.Value = 0;
                        break;
                    }
                    case (5):
                    {
                       prgbar.Value = valor;
                       break;
                    }
                }
            }
        }
        //-------------------------------------------------------------------
        //Saida pelo Grafico 
        private void Plotar(string opcao, double[] dados, int canal, int CanalParaPlotar, RectangleAnnotation selecaoAtual, double[] myArray, List<double> X_, List<double> Y_)
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] { opcao, dados, canal, CanalParaPlotar, selecaoAtual, myArray,X_, Y_ });
            }
            else
            {
                switch (opcao)
                {
                    case ("CLEAR"):
                    {
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                            prb.Series.Remove(prb.Series["canal" + CanalParaPlotar]);
                            prb.Series.Add("canal" + CanalParaPlotar);
                            prb.Series["canal" + CanalParaPlotar].ChartArea = "canal" + CanalParaPlotar;
                            prb.Series["canal" + CanalParaPlotar].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                            prb.Series["canal" + CanalParaPlotar].Color = Color.Red;
                        break;
                    }
                    case ("BKP"):
                    {
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                            //Primeira saida da RN
                            if (canal == 0)
                            {
                                for (int i = 0; i < myArray.Count(); i++)
                                    prb.Series["canal" + (CanalParaPlotar)].Points.AddY(myArray[i]);
                            }
                            //Adiciona Zeros Offset
                            else if(canal == 3)
                                prb.Series["canal" + (CanalParaPlotar)].Points.AddY(0);
                            else
                                prb.Series["canal" + (CanalParaPlotar)].Points.Clear();
                            break;
                     }
                    case ("VectorAtual"):
                    {
                            
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                            PointF zero = new PointF(0, 0);
                            prb.ChartAreas["canal" + canal].CursorX.SetSelectionPixelPosition(zero, zero, true);
                            prb.ChartAreas["canal" + canal].CursorX.SelectionColor = Color.FromArgb(128, Color.Yellow);
                            prb.ChartAreas["canal" + canal].CursorX.IsUserEnabled = true;
                            prb.ChartAreas["canal" + canal].CursorX.IsUserSelectionEnabled = true;
                            PointF Padrao_Inicio = new PointF((float)prb.ChartAreas["canal" + canal].AxisX.ValueToPixelPosition(dados[0]), (float)prb.ChartAreas["canal" + canal].AxisY.ValueToPixelPosition(dados[0]));
                            PointF Padrao_Fim    = new PointF((float)prb.ChartAreas["canal" + canal].AxisX.ValueToPixelPosition(dados[1]), (float)prb.ChartAreas["canal" + canal].AxisY.ValueToPixelPosition(dados[1]));
                            //Colore a região do evento
                            prb.ChartAreas["canal" + canal].CursorX.SetSelectionPixelPosition(Padrao_Inicio, Padrao_Fim, true);

                            prb.Series["canal" + (CanalParaPlotar)].Points.AddY(dados[2]);
                            break;
                    }
                    case ("MapaKohonen"):
                    {
                        prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                        prb.Series["canal" + (CanalParaPlotar + 1)].Points.AddXY(dados[0], dados[1], dados[2]);

                        if (prb.Annotations.FindByName("PontoAtual") != null)
                            prb.Annotations.Remove(prb.Annotations.FindByName("PontoAtual"));
                        break;
                    }
                    case ("AddDadoKohonen"):
                    {
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                            for (int k = 0; k < 5; k++)
                            {
                                if (dados[0] == 0 && dados[1] == 0)
                                    prb.Series["canal" + CanalParaPlotar].Points.AddY(10);
                                else if (dados[0] == 0 && dados[1] == 1)
                                    prb.Series["canal" + CanalParaPlotar].Points.AddY(5);
                                else if (dados[0] == 0 && dados[1] == 2)
                                    prb.Series["canal" + CanalParaPlotar].Points.AddY(3);
                                else if (dados[0] == 0 && dados[1] == 3)
                                    prb.Series["canal" + CanalParaPlotar].Points.AddY(1);
                                //else if (dados[0] == 0 && dados[1] == 4)
                                //    prb.Series["canal" + CanalParaPlotar].Points.AddY(0.5);
                                else
                                    prb.Series["canal" + CanalParaPlotar].Points.AddY(0);
                            }
                            //Mapa
                            prb.Series["canal" + (CanalParaPlotar + 1)].Points.AddXY(dados[0], dados[1], dados[4]);
                           
                            //Colore a região do evento  
                            PointF zero = new PointF(0,0);
                            prb.ChartAreas["canal" + canal].CursorX.SetSelectionPixelPosition(zero, zero, true);
                            prb.ChartAreas["canal" + canal].CursorX.SelectionColor = Color.FromArgb(128, Color.Yellow);
                            prb.ChartAreas["canal" + canal].CursorX.IsUserEnabled = true;
                            prb.ChartAreas["canal" + canal].CursorX.IsUserSelectionEnabled = true;
                            PointF Padrao_Inicio = new PointF((float)prb.ChartAreas["canal" + canal].AxisX.ValueToPixelPosition(dados[2]), (float)prb.ChartAreas["canal" + canal].AxisY.ValueToPixelPosition(dados[2]));
                            PointF Padrao_Fim    = new PointF((float)prb.ChartAreas["canal" + canal].AxisX.ValueToPixelPosition(dados[3]), (float)prb.ChartAreas["canal" + canal].AxisY.ValueToPixelPosition(dados[3]));
                            prb.ChartAreas["canal" + canal].CursorX.SetSelectionPixelPosition(Padrao_Inicio, Padrao_Fim, true);
                            
                            //Mostra onde foi plotado no mapa de kohonen
                            if (prb.Annotations.FindByName("PontoAtual") != null)
                                prb.Annotations.Remove(prb.Annotations.FindByName("PontoAtual"));
                            RectangleAnnotation annotationRectangle = new RectangleAnnotation();
                            annotationRectangle.Name = "PontoAtual";
                            annotationRectangle.BackColor = Color.FromArgb(128, Color.Blue);
                            annotationRectangle.AxisX = prb.ChartAreas["canal" + (CanalParaPlotar + 1)].AxisX;
                            annotationRectangle.AxisY = prb.ChartAreas["canal" + (CanalParaPlotar + 1)].AxisY;
                            annotationRectangle.AnchorX = dados[0];
                            annotationRectangle.Y = dados[1] + 0.05;
                            annotationRectangle.Height = 2;
                            annotationRectangle.Width = 2; 
                            annotationRectangle.LineColor = Color.Blue;
                            annotationRectangle.Font = new Font("Arial", 10, FontStyle.Bold);
                            annotationRectangle.AllowMoving = false;
                            annotationRectangle.AllowAnchorMoving = false;
                            annotationRectangle.AllowSelecting = false;
                            prb.Annotations.Add(annotationRectangle);
                            break;
                     }

                    case ("PlotKohonen"):
                    {
                        double offset = myArray[0];
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                            for (int i = 0; i < (offset/2); i++)
                                prb.Series["canal" + CanalParaPlotar].Points.AddY(0);
                           for (int i = 0;  i < X_.Count; i++)
                            {
                               // for (int k = 0; k < 5; k++)
                               // {
                                prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                                if (X_[i] == 0 && Y_[i] == 0)
                                {
                                    prb.Series["canal" + CanalParaPlotar].Points.AddY(10);
                                  //  prb.Series["canal" + (CanalParaPlotar + 1)].Points.AddXY(X_[i], Y_[i], 10);
                                }
                                else if (X_[i] == 0 && Y_[i] == 1)
                                {
                                    prb.Series["canal" + CanalParaPlotar].Points.AddY(5);
                                    ///prb.Series["canal" + (CanalParaPlotar + 1)].Points.AddXY(X_[i], Y_[i], 8);

                                }
                                else if (X_[i] == 0 && Y_[i] == 2)
                                {
                                    prb.Series["canal" + CanalParaPlotar].Points.AddY(3);
                                    //prb.Series["canal" + (CanalParaPlotar + 1)].Points.AddXY(X_[i], Y_[i], 7);

                                }
                                /*else if (X_[i] == 0 && Y_[i] == 3)
                                {
                                    prb.Series["canal" + CanalParaPlotar].Points.AddY(1);
                                    //prb.Series["canal" + (CanalParaPlotar + 1)].Points.AddXY(X_[i], Y_[i], 5);
                                }*/
                               //  else if (X_[i] == 0 && Y_[i] == 4)
                               //      prb.Series["canal" + CanalParaPlotar].Points.AddY(0.5);
                                else
                                {
                                    prb.Series["canal" + CanalParaPlotar].Points.AddY(0);
                                   // prb.Series["canal" + (CanalParaPlotar + 1)].Points.AddXY(X_[i], Y_[i], 2);
                                }
                                //}
                                //Mapa
                            }
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
                                prb.Titles["canal" + (canal + 2)].Position.Height = 3;
                                prb.Titles["canal" + (canal + 2)].Position.Width = 40;
                                prb.Titles["canal" + (canal + 2)].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles["canal" + (canal + 2)].Position.X = 0;
                                prb.Titles["canal" + (canal + 2)].Position.Y = (25 * (canal + 2)) + ((100 - (25 * (canal + 2))) / 2);
                                //Mapa de Kohonenn
                                prb.Series.Add("canal" + (canal + 3));
                                prb.Series["canal" + (canal + 3)].ChartArea = "canal" + (canal + 3);
                                prb.Titles.Add("canal" + (canal + 3));
                                prb.Titles[(canal + 3)].Position.Height = 3;
                                prb.Titles[(canal + 3)].Position.Width = 40;
                                prb.Titles[(canal + 3)].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[(canal + 3)].Position.X = 0;
                                prb.Titles[(canal + 3)].Position.Y = (25 * 4) + ((100 - (25 * 4)) / 2);
                            }
                            else{
                                prb.Series["canal" + (canal + 2)].Points.Clear();
                                prb.Series["canal" + (canal + 3)].Points.Clear();
                            }
                                prb.Series["canal" + (canal + 2)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                prb.Titles[(canal + 2)].Text = "Kohonen";
                                prb.Series["canal" + (canal + 2)].Color = Color.Orange;
                                prb.Series["canal" + (canal + 3)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                                prb.Titles[(canal + 3)].Text = "Mapa";
                                prb.Series["canal" + (canal + 3)].MarkerStyle = MarkerStyle.Circle;
                                prb.Series["canal" + (canal + 3)].Color = Color.Red;
                            prb.ChartAreas["canal" + (canal + 3)].AxisY.Enabled = AxisEnabled.True;
                            prb.ChartAreas["canal" + (canal + 3)].AxisX.Enabled = AxisEnabled.True;
                            prb.ChartAreas["canal" + (canal + 3)].Axes[1].MajorGrid.LineColor = Color.Gainsboro;
                            prb.ChartAreas["canal" + (canal + 3)].Axes[0].MajorGrid.LineColor = Color.Gainsboro;
                            prb.ChartAreas["canal" + (canal + 3)].AxisX.ScaleView.Size = length;
                            prb.ChartAreas["canal" + (canal + 3)].AxisX.ScaleView.SizeType = DateTimeIntervalType.Auto;
                            prb.ChartAreas["canal" + (canal + 3)].AxisX.ScrollBar.Enabled = true;
                            break;
                        }
                }
            }
        }

        //====================================================================================================
        // *****************************************   KOHONEN   *********************************************
        //====================================================================================================
        //
        private int pulo = 5;
        private void Initialise_KHn()
        {
            SaidaFinal = new double[length, length];
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
        //----------------------------------------------------------------------------------------
        private void LoadData_KHn(string file, int ValAtual, int fim)
        {
            int cont = 0;
            patterns.Clear();
            //VetTreinamento é o numero total de amostras que sera apresentada kohonen e classificada por ele
            for (int i = ValAtual; i < fim; i++)
            {
                double[] inputs = new double[dimensions];
                //VetorEvento é o numero de amostras por evento, recomendase sempre acima de 50 amostras por evento
                int pos = 0;
                cont = 0;
                while (cont < dimensions)
                {
                    if ((cont + i) < Sinal.Count())
                        inputs[pos] = Sinal[cont + i];
                    else
                        inputs[pos] = 0;
                    cont++;
                    pos++;
                }
                patterns.Add(inputs);
               //<<CUIDADO>>
                i = (pulo-1) + i;
            }
        }
        //----------------------------------------------------------------------------------------
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
        //----------------------------------------------------------------------------------------
        private void Train_KHn(double maxError)
        {
            double currentError = double.MaxValue;
            int count = 0;
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
                count++;
            }
        }
        //----------------------------------------------------------------------------------------
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
        //----------------------------------------------------------------------------------------
        private void DumpCoordinates_KHn()
        {
            double[] dados = new double[10];
            for (int i = 0; i < patterns.Count; i++)
            {
                Neuron_KHn n = Winner_KHn(patterns[i]);
                string saida = n.X + " " + n.Y;
                SaidaFinal[n.X, n.Y] = SaidaFinal[n.X, n.Y] + 1;

                if (!it_is_debug)
                {
                    for (int k = 0; k < pulo; k++)
                    {
                        X_Vals.Add(n.X);
                        Y_Vals.Add(n.Y);
                    }
                }
                else
                {
                    dados[0] = n.X;
                    dados[1] = n.Y;
                    dados[2] = i * pulo;
                    dados[3] = VetorEvento.Count() + (i*pulo);
                    dados[4] = SaidaFinal[n.X, n.Y];
                    Plotar("AddDadoKohonen", dados, CanalAtual, CanalParaPlotar, selecaoAtual, null, null, null);
                    send_SmS(1, saida, true);
                    Thread.Sleep(1);
                    DialogResult resposta = MessageBox.Show("Dado: " + i + "\nPlotado\nX: " + n.X + "\nY: " + n.Y, "Reconhecimento Automatizado de Padrões em EEG", MessageBoxButtons.OKCancel);
                    if (resposta == DialogResult.Cancel)
                        it_is_debug = false;
                }
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

 
