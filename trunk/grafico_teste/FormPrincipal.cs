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
    public partial class FormPrincipal : Form
    {
        delegate void SetTextCallback(double x, double y);
        private Thread ThreadChart;
        private int ThreadChart_status = 0; // 0 - Desabilitada, 1 - Rodando, 2 - Pausada
        private int numCursor = 0;
        private int mostrarCursores = 0;
        private double x_Pos, y_Pos;
        private int __numeroDeCanais = 22;
        public FormPrincipal()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            encerrar_sistema( );
        }
        //-----------------------------------------------------------------
        private void encerrar_sistema()
        {
            if (ThreadChart_status == 1)
            {
                ThreadChart.Abort();
            }
            if (ThreadChart_status == 2)
            {
                ThreadChart.Resume();
                ThreadChart.Abort();
            }
        }
        //-----------------------------------------------------------------
        private void btn_Suspender_Click(object sender, EventArgs e)
        {
            if (ThreadChart_status == 1)
            {
                ThreadChart.Suspend();
                ThreadChart_status = 1;
                btn_Suspender.Enabled = false;
                btn_Resume.Enabled = true;
                ThreadChart_status = 2;
            }
        }
        //-----------------------------------------------------------------
        private void btn_Resume_Click(object sender, EventArgs e)
        {
            if (ThreadChart_status == 0)
            {
                chart1.Enabled = true; 
                ChartInicializarThreads(__numeroDeCanais);
                btn_Suspender.Enabled = true;
                btn_novoProjeto.Enabled = false;
                btn_Resume.Enabled = false;
                btn_MarcarPadrões.Enabled = true;
                ThreadChart_status = 1;
            }

            if (ThreadChart_status == 2)
            {
                ThreadChart.Resume();
                ThreadChart_status = 1;
                btn_Suspender.Enabled = true;
                btn_Resume.Enabled = false;
            }
        }
        //-----------------------------------------------------------------
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if(mostrarCursores != 0)
            {

                    if (numCursor == 0)
                    {
                        x_Pos = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                        y_Pos = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

                        //linha fixa
                        VerticalLineAnnotation cursor_vertical = new VerticalLineAnnotation();
                        cursor_vertical.AnchorDataPoint = chart1.Series[0].Points[1];

                        cursor_vertical.Height = 3;
                        cursor_vertical.LineColor = Color.Chocolate;
                        cursor_vertical.LineWidth = 2;
                        cursor_vertical.AnchorX = x_Pos;
                        cursor_vertical.AnchorY = chart1.ChartAreas[0].AxisY.Maximum;
                        chart1.Annotations.Add(cursor_vertical);
                
                        numCursor++;
                    }
                    else if (numCursor == 1)
                    {
                        chart1.ChartAreas[0].CursorX.AxisType = AxisType.Secondary;
                        chart1.ChartAreas[0].CursorX.LineColor = Color.Chocolate;
                        chart1.ChartAreas[0].CursorX.LineWidth = 2;
                        chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);

                        chart1.Annotations.Clear();

                        // Set range selection color, specifying transparency of 120
                        chart1.ChartAreas[0].CursorX.SelectionColor = Color.FromArgb(120, 50, 50, 50);
                        chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                        chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                        chart1.ChartAreas[0].CursorX.SetSelectionPosition(x_Pos, chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X));
                 
                        numCursor++;//CLICAR + VEZES SEM EFEITO
                    }
            }
         
        }
        //-----------------------------------------------------------------
        private void mouse_Mover(object sender, MouseEventArgs e)
        {
                double x = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                double y = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                lbl_x.Text = "Valor X: " + Math.Round(x,4).ToString();
                lbl_Y.Text = "Valor Y: " + Math.Round(y,4).ToString();
                lbl_mouseX.Text = "Mouse X: " + e.X;
                lbl_mouseY.Text = "Mouse Y: " + e.Y;

                if(numCursor < 2)
                    chart1.ChartAreas[0].CursorX.SetCursorPosition(x);
        }
       //-------------------------------------------------------
        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encerrar_sistema();
        }
        //-----------------------------------------------------------------
        private void btn_novoProjeto_Click(object sender, EventArgs e)
        {
            btn_Resume.Enabled = true;
            btn_help.Enabled = true;
           // MessageBox.Show("Projeto EXEMPLO \nCriado com sucesso!", "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",MessageBoxButtons.OK, MessageBoxIcon.Information);
                
        }
        //-----------------------------------------------------------------
        private void btn_MarcarPadrões_Click(object sender, EventArgs e)
        {
            if (mostrarCursores == 0)
            {
                mostrarCursores = 1;
                lbl_ferramentaAtiva.ForeColor = Color.Green;
                lbl_ferramentaAtiva.Text = "Ferramenta ativa: Marcar Padrões";
            }
            else
            {
                mostrarCursores = 0;
                lbl_ferramentaAtiva.ForeColor = Color.Red;
                lbl_ferramentaAtiva.Text = "Nenhuma ferramenta ativa.";
            }
        }
        //-----------------------------------------------------------------
        private void ChartInicializarThreads(int numeroDeCanais)
        {
                for (int i = 0; i < numeroDeCanais; i++)
                {
                    //propriedades de cada sinal
                  chart1.ChartAreas.Add("canal" + i);
                  chart1.ChartAreas[i].AxisX.Enabled = AxisEnabled.False;
                  chart1.ChartAreas[i].AxisY.Enabled = AxisEnabled.False;
                  chart1.ChartAreas[i].BackColor = Color.WhiteSmoke;
                  chart1.ChartAreas[i].Position.X = 1;
                  chart1.ChartAreas[i].Position.Y = i*(4)+3;
                  chart1.ChartAreas[i].Position.Height = 3;
                  chart1.ChartAreas[i].Position.Width = 100;
                }

                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
        }

      

    }
}
