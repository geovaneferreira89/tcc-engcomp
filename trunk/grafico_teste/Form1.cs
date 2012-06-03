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

namespace grafico_teste
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(double x, double y);
        private Thread ThreadChart;

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
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ThreadChart.Abort();
        }
    }
}
