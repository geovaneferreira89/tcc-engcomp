using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Runtime.InteropServices;
using NeuroLoopGainLibrary.Edf;
using System.Threading;
using System.Drawing;


namespace AmbienteRPB
{
    public class Annotations_Chart
    {
        private Control _Grafico = null;
        private delegate void Anotation(float PosX, float PosY, Color CorDeFundo, string nomeEvento, DataPoint _Canal_, bool _comentOn_, string _coment_, float _Altura_, float _Comprimento_, bool _opcao_, ListaPadroesEventos[] _Lista_);
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1 = null;
        private float ValX;
        private float ValY;
        private Color Cor;
        private string Evento;
        private DataPoint Canal;
        private bool comentOn;
        private string coment;
        private float Altura; 
        private float Comprimento;
        private ListaPadroesEventos[] ListaPadroes;
        private bool opcao;
        //Controles Progress Bar--------------------------------------------------------------------
        private Control _BarraDeProgresso = null;
        private delegate void AtualizaPloter(int valor, int caso);
        private System.Windows.Forms.ProgressBar prgbar = null;
        //-----------------------------------------------------------------------------------------
        // This method that will be called when the thread is started
        public Annotations_Chart(Control Chart, Control BarraDeProgresso, float _ValX, float _ValY, Color _Cor, string _Evento, DataPoint _Canal, bool _comentOn, string _coment, float _Altura, float _Comprimento, bool _Opcao, ListaPadroesEventos[] _ListaPadroes)
        {
            _Grafico     = Chart;
            ValX         = _ValX;
            ValY         = _ValY;
            Cor          = _Cor;
            Evento       = _Evento;
            Canal        = _Canal;
            comentOn     = _comentOn;
            coment       = _coment;
            Altura       = _Altura;
            Comprimento  = _Comprimento;
            ListaPadroes = _ListaPadroes;
            opcao        = _Opcao;
            _BarraDeProgresso = BarraDeProgresso;
        }
        //----------------------------------------------
        public void Init()
        {
            Thread.Sleep(20);
            Add_Comentario(ValX, ValY, Cor, Evento, Canal,comentOn,coment,Altura,Comprimento,opcao,ListaPadroes);
        }
        //----------------------------------------------
        private void Add_Comentario(float PosX, float PosY, Color CorDeFundo, string nomeEvento, DataPoint _Canal_, bool _comentOn_, string _coment_, float _Altura_, float _Comprimento_, bool _opcao_, ListaPadroesEventos[] _Lista_)
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new Anotation(Add_Comentario), new Object[] { PosX, PosY, CorDeFundo, nomeEvento, _Canal_, _comentOn_, _coment_, _Altura_, _Comprimento_, _opcao_ , _Lista_});
            }
            else
            {
                chart1 = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                if (opcao)
                {
                    // Create a rectangle annotation
                    RectangleAnnotation annotationRectangle = new RectangleAnnotation();
                    // Setup visual attributes
                    if (_comentOn_)
                        annotationRectangle.Text = _coment_;
                    else
                        annotationRectangle.Text = "";
                    annotationRectangle.BackColor = Color.FromArgb(128, CorDeFundo);
                    annotationRectangle.AnchorX = PosX;
                    annotationRectangle.AnchorY = PosY;
                    annotationRectangle.AnchorDataPoint = _Canal_;
                    annotationRectangle.LineColor = CorDeFundo;
                    annotationRectangle.Font = new Font("Arial", 14, FontStyle.Bold);
                    //Altura
                    annotationRectangle.Height = _Altura_;
                    //Comprimento
                    annotationRectangle.Width = _Comprimento_ / 10;
                    // Prevent moving or selecting
                    annotationRectangle.AllowMoving = false;
                    annotationRectangle.AllowAnchorMoving = false;
                    annotationRectangle.AllowSelecting = false;
                    // Add the annotation to the collection
                    chart1.Annotations.Add(annotationRectangle);
                }
                else
                {//Carrega do arquivo... 
                    load_progress_bar(_Lista_.Count(), 2);
                    for (int i = 0; i < _Lista_.Count(); i++)
                    {
                        for (int j = 0; j < _Lista_[i].GetNumeroEventos(); j++)
                        {
                            RectangleAnnotation annotationRectangle = new RectangleAnnotation();
                            annotationRectangle.Text = _Lista_[i].GetComentario(j);
                            annotationRectangle.BackColor = Color.FromArgb(128, _Lista_[i].GetCorDeFundo(j));

                            annotationRectangle.AxisX = chart1.ChartAreas[_Lista_[i].GetChartDataPoint(j)].AxisX;
                            annotationRectangle.AxisY = chart1.ChartAreas[_Lista_[i].GetChartDataPoint(j)].AxisY;

                            annotationRectangle.X = (int)_Lista_[i].GetValorInicio(j).X;
                            annotationRectangle.Y = chart1.ChartAreas[_Lista_[i].GetChartDataPoint(j)].AxisY.Maximum;

                            annotationRectangle.LineColor = _Lista_[i].GetCorDeFundo(j);
                            annotationRectangle.Font = new Font("Arial", 14, FontStyle.Bold);
                            //Altura
                            annotationRectangle.Height = chart1.ChartAreas[_Lista_[i].GetChartDataPoint(j)].Position.Height;
                            //Comprimento
                            annotationRectangle.Width = _Lista_[i].GetWidth(j) / 10;
                            // Prevent moving or selecting
                            annotationRectangle.AllowMoving = false;
                            annotationRectangle.AllowAnchorMoving = false;
                            annotationRectangle.AllowSelecting = false;
                            // Add the annotation to the collection
                            chart1.Annotations.Add(annotationRectangle);
                        }
                        load_progress_bar(0, 1);
                    }
                    load_progress_bar(0, 3);
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
                    prgbar.BackColor = Color.Yellow;
                    prgbar.Maximum = valor;
                }
                if (caso == 3)
                    prgbar.Visible = false;
            }
        }
        //---------------------------------------------------------------------------------------
    }
    
}
