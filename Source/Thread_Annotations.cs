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
        private delegate void Anotation(float PosX, float PosY, Color CorDeFundo, string nomeEvento, DataPoint _Canal_);
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1 = null;
        private float ValX;
        private float ValY;
        private Color Cor;
        private string Evento;
        private DataPoint Canal;
        // This method that will be called when the thread is started
        public Annotations_Chart(Control Chart, float _ValX, float _ValY, Color _Cor, string _Evento, DataPoint _Canal)
        {
            _Grafico = Chart;
            ValX = _ValX;
            ValY = _ValY;
            Cor = _Cor;
            Evento = _Evento;
           Canal = _Canal;
        }
        public void Init()
        {
            Thread.Sleep(20);
            Add_Init(ValX, ValY, Cor, Evento, Canal);
        }
        private void Add_Init(float PosX, float PosY, Color CorDeFundo, string nomeEvento, DataPoint _Canal_)
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new Anotation(Add_Init), new Object[] { PosX, PosY, CorDeFundo, nomeEvento, _Canal_ });
            }
            else
            {
                chart1 = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;

                 // Create a callout annotation
                 CalloutAnnotation annotationCallout = new CalloutAnnotation();

                // Setup visual attributes
                 annotationCallout.AnchorX = PosX;
                 annotationCallout.AnchorY = PosY;
                 annotationCallout.AnchorDataPoint = _Canal_;
                annotationCallout.Text = Evento;
                annotationCallout.BackColor = CorDeFundo;
                annotationCallout.ClipToChartArea = nomeEvento;

                // Prevent moving or selecting
                annotationCallout.AllowMoving = true;
                annotationCallout.AllowAnchorMoving = true;
                annotationCallout.AllowSelecting = true;
                annotationCallout.Visible = true;

                // Add the annotation to the collection
                chart1.Annotations.Add(annotationCallout);
                // Create a callout annotation
                //TreadAnnotations oAlpha = new AtualizarRefInChart(chart1, Listas[comboTiposDeEventos.SelectedIndex].GetValorMeio(lbxEventosPorTipo.SelectedIndex).X);


                // Create a rectangle annotation
                /*RectangleAnnotation annotationRectangle = new RectangleAnnotation();

                // Setup visual attributes
                annotationRectangle.Text = "Attached to\nChart Picture";
                annotationRectangle.BackColor = Color.FromArgb(255, 255, 192);
                annotationRectangle.AnchorX = 30;
                annotationRectangle.AnchorY = 25;

                // Prevent moving or selecting
                annotationRectangle.AllowMoving = false;
                annotationRectangle.AllowAnchorMoving = false;
                annotationRectangle.AllowSelecting = false;

                // Add the annotation to the collection
                chart1.Annotations.Add(annotationRectangle);

                // Create a line annotation
                LineAnnotation annotationLine = new LineAnnotation();

                // Setup visual attributes
                annotationLine.StartCap = LineAnchorCapStyle.Arrow;
                annotationLine.EndCap = LineAnchorCapStyle.Arrow;
                annotationLine.LineWidth = 3;
                annotationLine.LineColor = Color.OrangeRed;
                annotationLine.ClipToChartArea = "Default";

                // Prevent moving or selecting
                annotationLine.AllowMoving = false;
                annotationLine.AllowAnchorMoving = false;
                annotationLine.AllowSelecting = false;

                if (chart1.Series[0].Points.Count > 10)
                {
                    // Use the Anchor Method to anchor to points 8 and 10...
                    annotationLine.SetAnchor(chart1.Series[0].Points[8], chart1.Series[0].Points[10]);
                }

                // Add the annotation to the collection
                chart1.Annotations.Add(annotationLine);     
                */
                       
            }
        }
    }
    
}
