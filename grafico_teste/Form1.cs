using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using thread_chart;
using System.Threading;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;

namespace grafico_teste
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(double x, double y);
        private Thread ThreadChart;
        private int suspender = 0;
        private int numCursor = 0;
        private double x_Pos, y_Pos;

        public Form1()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * //esse codigo faz limitar o gráfico. 
             * chart1.ChartAreas.Add("area");
            chart1.ChartAreas["area"].AxisX.Minimum = 0;
            chart1.ChartAreas["area"].AxisX.Maximum = 50;
            chart1.ChartAreas["area"].AxisY.Minimum = 0;
            chart1.ChartAreas["area"].AxisX.Maximum = 100;*/
            
            chart1.Enabled = true;
            atualiza_sinal objCliente = new atualiza_sinal(chart1);
            ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
            ThreadChart.Start();
            btn_Suspender.Visible = true;
            btnLigar.Visible = false;
        }
        //-----------------------------------------------------------------
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (suspender != 0)
            {
                ThreadChart.Resume();
            }
            ThreadChart.Abort();
        }
        //-----------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (suspender == 0)
            {
                ThreadChart.Suspend();
                suspender = 1;
                btn_Suspender.Text = "Retormar";
            }
            else
            {
                ThreadChart.Resume();
                suspender = 0;
                btn_Suspender.Text = "Suspender";
            }
        }
        //-----------------------------------------------------------------
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (numCursor == 0)
            {

                x_Pos = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                y_Pos = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

                //linha fixa
                VerticalLineAnnotation cursor_vertical = new VerticalLineAnnotation();
                cursor_vertical.AnchorDataPoint = chart1.Series[0].Points[2];
                cursor_vertical.Height = 81;
               
                cursor_vertical.LineColor = Color.Blue;
                cursor_vertical.LineWidth = 2;
                cursor_vertical.AnchorX = x_Pos;
                chart1.Annotations.Add(cursor_vertical);
	            
                //Anotação "flag"
                
                TextAnnotation annotation = new TextAnnotation();
                annotation.AnchorDataPoint = chart1.Series[0].Points[2];
                annotation.AnchorX =  x_Pos ;
                annotation.AnchorY = y_Pos; 
            
                annotation.Text = "Flag 1";
                annotation.ForeColor = Color.DarkBlue;
                annotation.Font = new Font("Arial", 9);
                chart1.Annotations.Add(annotation);
                
                numCursor++;
            }
            else if (numCursor == 1)
            {
                chart1.ChartAreas[0].CursorX.LineColor = Color.Chocolate;
                chart1.ChartAreas[0].CursorX.LineWidth = 2;
                chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);

                double x = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                double y = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

                //// Set range selection color, specifying transparency of 120
                //chart1.ChartAreas[0].CursorX.SelectionColor = Color.FromArgb(120, 50, 50, 50);
                //chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                //chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                //chart1.ChartAreas[0].CursorX.SetSelectionPosition(x_Pos, chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X));

                TextAnnotation annotation = new TextAnnotation();
                annotation.AnchorDataPoint = chart1.Series[0].Points[2];
                annotation.AnchorX = x;
                annotation.AnchorY = y;

                annotation.Text = "Flag 2";
                annotation.ForeColor = Color.Green;
                annotation.Font = new Font("Arial", 9);

                chart1.Annotations.Add(annotation);
                numCursor++;//CLICAR + VEZES SEM EFEITO
            }
         
        }
        //-----------------------------------------------------------------
        private void mouse_Mover(object sender, MouseEventArgs e)
        {
                double x = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                double y = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                lbl_x.Text = x.ToString();
                lbl_Y.Text = y.ToString();
                if(numCursor < 2)
                    chart1.ChartAreas[0].CursorX.SetCursorPosition(x);
        }
    }
}
