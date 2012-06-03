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

namespace grafico_teste
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(double x, double y);
        private Thread ThreadChart;
        private int suspender = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * //esse codigo faz limitar o gráfico. 
             * chart1.ChartAreas.Add("area");
            chart1.ChartAreas["area"].AxisX.Minimum = 0;
            chart1.ChartAreas["area"].AxisX.Maximum = 50;
            chart1.ChartAreas["area"].AxisY.Minimum = 0;
            chart1.ChartAreas["area"].AxisX.Maximum = 100;*/

            atualiza_sinal objCliente = new atualiza_sinal(chart1);
            ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
            ThreadChart.Start();
            btn_Suspender.Visible = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ThreadChart.Abort();
        }

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

        private void chart1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point chartLocationOnForm = chart1.FindForm().PointToClient(chart1.Parent.PointToScreen(chart1.Location));
            chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(e.X - chartLocationOnForm.X, e.Y - chartLocationOnForm.Y), true);
            chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(e.X - chartLocationOnForm.X, e.Y - chartLocationOnForm.Y), true);

            double x = chart1.ChartAreas[0].CursorX.Position;
            double y = chart1.ChartAreas[0].CursorY.Position;

            lbl_x.Text = x.ToString();
            lbl_Y.Text = y.ToString();
         
        }
    }
}
