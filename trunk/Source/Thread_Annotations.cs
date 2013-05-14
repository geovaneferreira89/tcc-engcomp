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


namespace Thread_Annotations
{
    public class Annotations_Chart
    {

        private Control _Grafico = null;
        private delegate void Anotation(float PosX, float PosY, Color CorDeFundo, string nomeEvento, DataPoint _Canal_,bool _comentOn_, string _coment_,float _Altura_,float _Comprimento_);
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
        // This method that will be called when the thread is started
        public Annotations_Chart(Control Chart, float _ValX, float _ValY, Color _Cor, string _Evento, DataPoint _Canal, bool _comentOn, string _coment, float _Altura, float _Comprimento)
        {
            _Grafico    = Chart;
            ValX        = _ValX;
            ValY        = _ValY;
            Cor         = _Cor;
            Evento      = _Evento;
            Canal       = _Canal;
            comentOn    = _comentOn;
            coment      = _coment;
            Altura       = _Altura;
            Comprimento = _Comprimento;
        }
        public void Init()
        {
            Thread.Sleep(20);
            Add_Comentario(ValX, ValY, Cor, Evento, Canal,comentOn,coment,Altura,Comprimento);
        }
        private void Add_Comentario(float PosX, float PosY, Color CorDeFundo, string nomeEvento, DataPoint _Canal_, bool _comentOn_, string _coment_, float _Altura_, float _Comprimento_)
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new Anotation(Add_Comentario), new Object[] { PosX, PosY, CorDeFundo, nomeEvento, _Canal_, _comentOn_, _coment_,_Altura_,_Comprimento_ });
            }
            else
            {
                chart1 = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
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
                /*
                if (_comentOn_)
                {
                    Thread.Sleep(20);
                    // Create a callout annotation
                    CalloutAnnotation annotationCallout = new CalloutAnnotation();
                    // Setup visual attributes
                    annotationCallout.AnchorX = PosX;
                    annotationCallout.AnchorY = PosY;
                    annotationCallout.AnchorDataPoint = _Canal_;
                    annotationCallout.Text = _coment_;
                    annotationCallout.BackColor = CorDeFundo;
                    annotationCallout.ClipToChartArea = _coment_;
                    // Prevent moving or selecting
                    annotationCallout.AllowMoving = true;
                    annotationCallout.AllowAnchorMoving = true;
                    annotationCallout.AllowSelecting = true;
                    annotationCallout.Visible = true;
                    // Add the annotation to the collection
                    chart1.Annotations.Add(annotationCallout);
                }*/
            }
        }
    }
    
}
