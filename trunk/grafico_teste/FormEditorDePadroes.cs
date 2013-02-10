using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Runtime.InteropServices;

namespace AmbienteRPB
{
    public partial class FormEditorDePadroes : Form
    {
        private int numCursor = 0;
        private int mostrarCursores = 0;
        private float x_Pos, y_Pos;
        private HitTestResult var_result;
        PointF Padrao_Inicio;
        PointF Padrao_Fim;
        private GerenArquivos Arquivos;
        //-----------------------------------------------------
        public FormEditorDePadroes()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------
        private void btn_Abrir_Click(object sender, EventArgs e)
        {
           
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    chart1.ChartAreas.Add("Padrao");
                    chart1.Series.Add("Serie01");
                    chart1.Series["Serie01"].ChartArea = "Padrao";
                    chart1.Series["Serie01"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    // Arquivos.ImportarPadraoArquivo(openFile.FileName, chart1);
                    // chart = _Chart as System.Windows.Forms.DataVisualization.Charting.Chart;
                    System.IO.StreamReader fileR = new System.IO.StreamReader(openFile.FileName);
                    edtEvento_Nome.Text = openFile.SafeFileName; //Tirar o resto... 
                    string dados;
                    dados = fileR.ReadLine();
                    dados = dados.Substring(22);
                    dados = dados.Substring(0, dados.Length - 1);
                    int NumeroDeAmostras = Convert.ToInt16(dados);
                    chart1.Series[0].Color = Color.Red;

                    for (int i = 0; i <= NumeroDeAmostras; i++)
                    {
                        dados = fileR.ReadLine();
                        string x = dados;
                        string y = dados;
                        int X_ = x.IndexOf(" ");

                        x = x.Substring(3);
                        x = x.Substring(0, X_ - 4);

                        y = y.Substring(X_ + 3);
                        y = y.Substring(0, y.Length - 1);



                        chart1.Series[0].Points.AddXY(Convert.ToDouble(x), Convert.ToDouble(y));
                    }

                }
        }
        //-----------------------------------------------------
        //Frequencia
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != null)
            chart1.ChartAreas[0].AxisX.ScaleView.Size = Convert.ToDouble(textBox1.Text) ;
        }
        //-----------------------------------------------------
        //Amplitude
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
            chart1.ChartAreas[0].AxisY.ScaleView.Size = Convert.ToDouble(textBox2.Text);
        }
        //-----------------------------------------------------
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //-----------------------------------------------------
        private void btnMarcar_Click(object sender, EventArgs e)
        {
            //limpa seleção
        }
        //-----------------------------------------------------
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            //HitTestResult result = chart1.HitTest(e.X, e.Y);
            if (chart1.ChartAreas[0] != null)
            {
                if (numCursor == 0)
                {
                    
                    chart1.Annotations.Clear();
                    chart1.ChartAreas[0].CursorX.SelectionColor = Color.FromArgb(00, 50, 50, 50);
                    chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(0, 0), false);
                    x_Pos = (e.X);
                    y_Pos = (e.Y);
                    //linha fixa
                    VerticalLineAnnotation cursor_vertical = new VerticalLineAnnotation();
                    cursor_vertical.AnchorDataPoint = chart1.Series[0].Points[1];
                    cursor_vertical.Height = chart1.ChartAreas[0].Position.Height;
                    cursor_vertical.LineColor = Color.Green;
                    cursor_vertical.LineWidth = 1;
                    cursor_vertical.AnchorX = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                    cursor_vertical.AnchorY = chart1.ChartAreas[0].AxisY.Maximum;
                    chart1.Annotations.Add(cursor_vertical);
                    numCursor++;
                }
                else if (numCursor == 1)
                {
                    chart1.ChartAreas[0].CursorX.AxisType = AxisType.Secondary;
                    chart1.ChartAreas[0].CursorX.LineColor = Color.Green;
                    chart1.ChartAreas[0].CursorX.LineWidth = 1;
                    chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
                    // Set range selection color, specifying transparency of 120
                    chart1.ChartAreas[0].CursorX.SelectionColor = Color.FromArgb(90, 50, 50, 50);
                    chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                    chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                    Padrao_Inicio = new PointF(x_Pos, y_Pos);
                    Padrao_Fim = new PointF(e.X, e.Y);
                    chart1.ChartAreas[0].CursorX.SetSelectionPixelPosition(Padrao_Inicio, Padrao_Fim, true);
                    numCursor = 0;//CLICAR + VEZES SEM EFEITO
                    btnSalvar.Enabled = true;
                    Padrao_Inicio.X = (float)chart1.ChartAreas[0].AxisX.PixelPositionToValue(x_Pos);
                    Padrao_Fim.X = (float)chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                }
            }
        }
        //-----------------------------------------------------
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            numCursor = 0;
            Exportar_Padrao(Padrao_Inicio, Padrao_Fim);
            chart1.Annotations.Clear();
        }
        //-----------------------------------------------------
        private void Exportar_Padrao(PointF Padrao_Inicio, PointF Padrao_Fim)
        {
            Arquivos = new GerenArquivos();
            Arquivos.ExportarPadraoEditado(edtEvento_Nome.Text, chart1, Padrao_Inicio, Padrao_Fim);
            MessageBox.Show("Padrão '" + edtEvento_Nome.Text + "' editado e salvo.", "Ambiente RPB");
        }
        //-----------------------------------------------------
    }
}
