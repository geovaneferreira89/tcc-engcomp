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


namespace AmbienteRPB
{
    public class Kohonen
    {
        //Controles Chart--------------------------------------------------------------------------
        private Control _Grafico = null;
        private delegate void AtualizaChart(string opcao, double dadoX,double dadoY, int canal);
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
        //Saida de dados -------------------------------------------------------------------------
        private Control SMS = null;
        private delegate void SMS_Propriedades(int opcao, string texto);
        private System.Windows.Forms.RichTextBox TextBox;
        //Variaveis do kohoney -------------------------------------------------------------------
        private Neuron[,] outputs;  // Collection of weights.
        private int iteration;      // Current iteration.
        private int length;        // Side length of output grid.
        private int dimensions;    // Number of input dimensions.
        private Random rnd = new Random();
 
        private List<string> labels = new List<string>();
        private List<double[]> patterns = new List<double[]>();
        string file;

        //Ok: cria um kohonen, mandar sinal no lugar do arquivo
        public Kohonen(int _dimensions, int _length, string _file,Control Grafico, Control BarraDeProgresso, Control _SMS_)
        {
            _Grafico          = Grafico;
            _BarraDeProgresso = BarraDeProgresso;
            _ScrollBar        = ScrollBar;  
            length = _length;
            dimensions = _dimensions;
            file = _file;
            SMS = _SMS_;
        }
        //------------------------------------------------------------------------------------------
        public void Init()
        {
            Plotar("Criar Chart de Barras", 0,0, 2);
            send_SmS(1, "Inicializando...");
            Initialise();
            send_SmS(1, "Carregando Arquivo de Vetores");
            LoadData(file);
            send_SmS(1, "Init NormalisePatterns");
            NormalisePatterns();
            send_SmS(1, "Treinando a rede com 0.0000001");
            Train(0.0000001);
            send_SmS(1, "Resultados:");
            DumpCoordinates();
            //load_progress_bar(10, 2);
            send_SmS(1, "Fim...");
        }
        //------------------------------------------------------------------------------------------
        private void Initialise()
        {
            outputs = new Neuron[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    outputs[i, j] = new Neuron(i, j, length);
                    outputs[i, j].Weights = new double[dimensions];
                    for (int k = 0; k < dimensions; k++)
                    {
                        outputs[i, j].Weights[k] = rnd.NextDouble();
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------
        private void LoadData(string file)
        {
            StreamReader reader = File.OpenText(file);
            reader.ReadLine(); // Ignore first line.
            int count = 0;
            while (count != length)///!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(',');
                labels.Add(line[0]);
                double[] inputs = new double[dimensions];
                for (int i = 0; i < dimensions; i++)
                {
                    inputs[i] = double.Parse(line[i+1]);
                }
                patterns.Add(inputs);
                count++;
            }
            reader.Close();
        }
 
        private void NormalisePatterns()
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
 
        private void Train(double maxError)
        {
            double currentError = double.MaxValue;
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
                    currentError += TrainPattern(pattern);
                    TrainingSet.Remove(pattern);
                }
               // Console.WriteLine(currentError.ToString("0.0000000"));
                send_SmS(1, "0.0000000");
            }
        }
 
        private double TrainPattern(double[] pattern)
        {
            double error = 0;
            Neuron winner = Winner(pattern);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    error += outputs[i, j].UpdateWeights(pattern, winner, iteration);
                }
            }
            iteration++;
            return Math.Abs(error / (length * length));
        }
 
        private void DumpCoordinates()
        {
            for (int i = 0; i < patterns.Count; i++)
            {
                Neuron n = Winner(patterns[i]);
              //  Console.WriteLine("{0},{1},{2}", labels[i], n.X, n.Y);
                string saida = labels[i] + " " + n.X + " " + n.Y;
                Plotar("AddDado", n.X,n.Y,2); // tem o n.x tbm para no caso o Mapa mesmo... 
                send_SmS(1, saida);
            }
        }
 
        private Neuron Winner(double[] pattern)
        {
            Neuron winner = null;
            double min = double.MaxValue;
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                {
                    double d = Distance(pattern, outputs[i, j].Weights);
                    if (d < min)
                    {
                        min = d;
                        winner = outputs[i, j];
                    }
                }
            return winner;
        }
 
        private double Distance(double[] vector1, double[] vector2)
        {
            double value = 0;
            for (int i = 0; i < vector1.Length; i++)
            {
                value += Math.Pow((vector1[i] - vector2[i]), 2);
            }
            return Math.Sqrt(value);
        }
        //Usar canal 2
        private void Plotar(string opcao, double dadoX, double dadoY, int canal)
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] { opcao, dadoX, dadoY, canal });
            }
            else
            {
                switch (opcao)
                {
                    case ("AddDado"):
                        {
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                            prb.Series["canal" + canal].Points.AddY(dadoY);

                            prb.Series["canal" + 4].Points.AddXY(dadoX,dadoY);
                            break;
                        }
                    case ("Criar Chart de Barras"):
                        {
                            prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                            if (prb.Series.Count != 3)
                            {
                                prb.Series.Add("canal" + canal);
                                prb.Series["canal" + canal].ChartArea = "canal" + canal;
                                prb.Titles.Add("canal" + canal);

                                prb.Titles[canal].Position.Height = 3;
                                prb.Titles[canal].Position.Width = 40;
                                prb.Titles[canal].Alignment = ContentAlignment.MiddleLeft;
                                prb.Titles[canal].Position.X = 0;
                                prb.Titles[canal].Position.Y = (33 * canal) + ((100 - (33 * canal)) / 2);
                            }
                            prb.Series["canal" + canal].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                            prb.Titles[canal].Text = "Kohonen" + ((canal / 3) + 2);
                            prb.Series["canal" + canal].Color = Color.LightBlue;

                            //mapa de kohonei
                            prb.Series.Add("canal" + 4);
                            prb.Series["canal" + 4].ChartArea = "canal" + 3;
                            prb.Titles.Add("canal" +4);

                            prb.Titles[3].Position.Height = 3;
                            prb.Titles[3].Position.Width = 40;
                            prb.Titles[3].Alignment = ContentAlignment.MiddleLeft;
                            prb.Titles[3].Position.X = 0;
                            prb.Titles[3].Position.Y = (33 * 3) + ((100 - (33 * 3)) / 2);

                            prb.Series["canal" + 4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                            prb.Titles[3].Text = "Mapa" + ((4 / 3) + 2);
                            prb.Series["canal" + 4].Color = Color.Red;
                            break;
                        }
                }
            }
        }
        //-------------------------------------------------------------------------------
        //Saida de Dados
        private void send_SmS(int opcao, string texto)
        {

            if (SMS.InvokeRequired)
            {
                SMS.BeginInvoke(new SMS_Propriedades(send_SmS), new Object[] { opcao, texto });
            }
            else
            {
                TextBox = SMS as System.Windows.Forms.RichTextBox;
                if (opcao == 1)
                {
                    TextBox.Text = TextBox.Text + "\n" + texto;
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
     }
    //========================================================================================================
    //                                             Classe Neuron
    //========================================================================================================
    public class Neuron
     {
        public double[] Weights;
        public int X;
        public int Y;
        private int length;
        private double nf;

        public Neuron(int x, int y, int length)
        {
            X = x;
            Y = y;
            this.length = length;
            nf = 1000 / Math.Log(length);
        }

        private double Gauss(Neuron win, int it)
        {
            double distance = Math.Sqrt(Math.Pow(win.X - X, 2) + Math.Pow(win.Y - Y, 2));
            return Math.Exp(-Math.Pow(distance, 2) / (Math.Pow(Strength(it), 2)));
        }

        private double LearningRate(int it)
        {
            return Math.Exp(-it / 1000) * 0.1;
        }

        private double Strength(int it)
        {
            return Math.Exp(-it / nf) * length;
        }

        public double UpdateWeights(double[] pattern, Neuron winner, int it)
        {
            double sum = 0;
            for (int i = 0; i < Weights.Length; i++)
            {
                double delta = LearningRate(it) * Gauss(winner, it) * (pattern[i] - Weights[i]);
                Weights[i] += delta;
                sum += delta;
            }
            return sum / Weights.Length;
        }
    }
    //------------------------------------------------------------------------------------------
}

 
