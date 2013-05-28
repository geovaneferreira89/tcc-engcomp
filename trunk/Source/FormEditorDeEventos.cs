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
using NeuroLoopGainLibrary.Edf;
using System.Threading;

namespace AmbienteRPB
{
    public partial class FormEditorDeEventos : Form
    {
      
        private ListaPadroesEventos[] Listas;
        private GerenArquivos Arquivos;
        private string EDF_File;
        EdfFile SinalEEG;

        public PointF ValorInicio;
        public PointF ValorFim;
        public PointF ValorReferencia;

        public double[] Vector;

        VerticalLineAnnotation Cursor_vertical_Inicio; 
        VerticalLineAnnotation Cursor_vertical_Fim;
        VerticalLineAnnotation Cursor_vertical_Referencia;
        //---------------------------------------------------------------------------
        public FormEditorDeEventos(ListaPadroesEventos[] _Listas, string _EDF_File)
        {
            InitializeComponent();            
            Listas = _Listas;
            EDF_File = _EDF_File;
        }
        //---------------------------------------------------------------------------
        public double[] vector
        {
            get;
            set;
        }
        //---------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //---------------------------------------------------------------------------
        private void FormEditorDeEventos_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
                comboTiposDeEventos.Items.Add(Listas[i].NomePadrao);
        }
        //---------------------------------------------------------------------------
        private void comboTiposDeEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chart1.Series.Count != 0)
            {
                chart1.Annotations.Clear();
                chart1.Series.Remove(chart1.Series["Serie01"]);
                chart1.ChartAreas.Remove(chart1.ChartAreas[0]);
            }
            lbxEventosPorTipo.Items.Clear();
            for (int i = 0; i < Listas[comboTiposDeEventos.SelectedIndex].NumeroEventos; i++)
                lbxEventosPorTipo.Items.Add(Listas[comboTiposDeEventos.SelectedIndex].GetNomesEvento(i));
        }
        //---------------------------------------------------------------------------
        private void lbxEventosPorTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chart1.Series.Count != 0)
            {
                chart1.Annotations.Clear();
                chart1.Series.Remove(chart1.Series["Serie01"]);
                chart1.ChartAreas.Remove(chart1.ChartAreas[0]);
            }
            if (lbxEventosPorTipo.SelectedItem != null)
            {
                chart1.ChartAreas.Add("Padrao");
                chart1.Series.Add("Serie01");
                chart1.Series["Serie01"].ChartArea = "Padrao";
                chart1.Series["Serie01"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                
                chart1.Series["Serie01"].IsVisibleInLegend = false;
                chart1.Legends.Clear();
                chart1.ChartAreas["Padrao"].BackColor = Color.Transparent;
                chart1.ChartAreas["Padrao"].AxisX.Enabled = AxisEnabled.False;
                chart1.ChartAreas["Padrao"].AxisY.Enabled = AxisEnabled.False;
                
                edtEvento_Nome.Text = lbxEventosPorTipo.SelectedItem.ToString();
                //Mostra valores ao lado dos labels
                //cbx_Inicio.Text = "Início " +  Listas[comboTiposDeEventos.SelectedIndex].GetValorInicio(lbxEventosPorTipo.SelectedIndex);
                //cbx_Referencia.Text = "Referência " + Listas[comboTiposDeEventos.SelectedIndex].GetValorMeio(lbxEventosPorTipo.SelectedIndex);
                //cbx_Fim.Text = "Fim: " + Listas[comboTiposDeEventos.SelectedIndex].GetValorFim(lbxEventosPorTipo.SelectedIndex);

                ValorInicio = new PointF(); 
                ValorInicio =  Listas[comboTiposDeEventos.SelectedIndex].GetValorInicio(lbxEventosPorTipo.SelectedIndex);
                ValorFim = new PointF();
                ValorFim = Listas[comboTiposDeEventos.SelectedIndex].GetValorFim(lbxEventosPorTipo.SelectedIndex);
                ValorReferencia = new PointF();
                ValorReferencia = Listas[comboTiposDeEventos.SelectedIndex].GetValorMeio(lbxEventosPorTipo.SelectedIndex);
                
                //Carrega sinal edf do arquivo.. 
                Arquivos = new GerenArquivos();
                SinalEEG = Arquivos.Abrir_Projeto_EDF(EDF_File, false);

                //Nome do canal
                string nome_canal =  Listas[comboTiposDeEventos.SelectedIndex].GetNomesEvento(lbxEventosPorTipo.SelectedIndex);
                int X_ = nome_canal.IndexOf("_");
                nome_canal = nome_canal.Substring(X_+1);
                //Inicio do enveto
                float x = Listas[comboTiposDeEventos.SelectedIndex].GetValorInicio(lbxEventosPorTipo.SelectedIndex).X;
                float x_max = Listas[comboTiposDeEventos.SelectedIndex].GetValorFim(lbxEventosPorTipo.SelectedIndex).X;
                //Carrega comentários
                txtComents.Text = Listas[comboTiposDeEventos.SelectedIndex].GetComentario(lbxEventosPorTipo.SelectedIndex);
                float aux;
                int DataRecords_lidos = 0;
                int tempo_X = 0;
                while (tempo_X <= (int) x_max)
                {
                    
                    SinalEEG.ReadDataBlock(DataRecords_lidos);
                    DataRecords_lidos++;
                    //Cada ao fim deste for, é adiciocionado somente 1s em todos os canais
                    for (int j = 0; j < SinalEEG.SignalInfo.Count; j++)
                    {
                        for (int i = 0; i < 256; i++)
                        {
                            if (SinalEEG.SignalInfo[j].SignalLabel == nome_canal)
                            {
                                if (tempo_X >= (int)x && tempo_X <= (int)x_max)
                                {
                                    chart1.Series[0].Points.AddXY(tempo_X, SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
                                }
                                else
                                    aux = SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i];
                                tempo_X++;
                            }
                            else
                               aux = SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i];
                        }
                    }
                }
                AtualizarRefInChart oAlpha = new AtualizarRefInChart(chart1, Listas[comboTiposDeEventos.SelectedIndex].GetValorMeio(lbxEventosPorTipo.SelectedIndex).X);
                Thread oThread = new Thread(new ThreadStart(oAlpha.Init));
                oThread.Start();
             }
        }
        private void add_Ref()
        {
            if (Cursor_vertical_Referencia == null)
                Cursor_vertical_Referencia = new VerticalLineAnnotation();
            else
                chart1.Annotations.Remove(Cursor_vertical_Referencia);
            //Linha de referencia
            Cursor_vertical_Referencia.AnchorDataPoint = chart1.Series[0].Points[1];
            Cursor_vertical_Referencia.Height = chart1.ChartAreas[0].Position.Height;
            Cursor_vertical_Referencia.LineColor = Color.Orange;
            Cursor_vertical_Referencia.LineWidth = 1;
            Cursor_vertical_Referencia.AnchorX = Listas[comboTiposDeEventos.SelectedIndex].GetValorMeio(lbxEventosPorTipo.SelectedIndex).X;
            Cursor_vertical_Referencia.AnchorY = chart1.ChartAreas[0].AxisY.Maximum;
            chart1.Annotations.Add(Cursor_vertical_Referencia);
            Cursor_vertical_Referencia.Visible = true;
        }
        //---------------------------------------------------------------------------
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            if (chart1.ChartAreas.Count != 0)
            {
                if (cbx_Inicio.Checked == true)
                {
                    chart1.ChartAreas[0].CursorX.SelectionColor = Color.FromArgb(00, 50, 50, 50);
                    chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(0, 0), false);
                    //Valores
                    ValorInicio.X =  (float)chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                    ValorInicio.Y = (float)chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                    //Deleta linha se já tiver, ou cria uma nova
                    if (Cursor_vertical_Inicio == null)
                        Cursor_vertical_Inicio = new VerticalLineAnnotation();
                    else
                        chart1.Annotations.Remove(Cursor_vertical_Inicio);
                    //Linha no Chart
                    Cursor_vertical_Inicio.AnchorDataPoint = chart1.Series[0].Points[1];
                    Cursor_vertical_Inicio.Height = chart1.ChartAreas[0].Position.Height;
                    Cursor_vertical_Inicio.LineColor = Color.Blue;
                    Cursor_vertical_Inicio.LineWidth = 1;
                    Cursor_vertical_Inicio.AnchorX = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                    Cursor_vertical_Inicio.AnchorY = chart1.ChartAreas[0].AxisY.Maximum;
                    chart1.Annotations.Add(Cursor_vertical_Inicio);
                    btnSalvar.Enabled = true;
                }
               if (cbx_Fim.Checked == true)
                {
                    chart1.ChartAreas[0].CursorX.SelectionColor = Color.FromArgb(00, 50, 50, 50);
                    chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(0, 0), false);
                    //Valores
                    ValorFim.X =  (float)chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                    ValorFim.Y =  (float)chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                    //Deleta linha se já tiver, ou cria uma nova
                    if (Cursor_vertical_Fim == null)
                        Cursor_vertical_Fim = new VerticalLineAnnotation();
                    else
                        chart1.Annotations.Remove(Cursor_vertical_Fim);
                    //Linha no Chart
                    Cursor_vertical_Fim.AnchorDataPoint = chart1.Series[0].Points[1];
                    Cursor_vertical_Fim.Height = chart1.ChartAreas[0].Position.Height;
                    Cursor_vertical_Fim.LineColor = Color.Green;
                    Cursor_vertical_Fim.LineWidth = 1;
                    Cursor_vertical_Fim.AnchorX = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                    Cursor_vertical_Fim.AnchorY = chart1.ChartAreas[0].AxisY.Maximum;
                    chart1.Annotations.Add(Cursor_vertical_Fim);
                    btnSalvar.Enabled = true;
                }
                if (cbx_Referencia.Checked == true)
                {
                    chart1.ChartAreas[0].CursorX.SelectionColor = Color.FromArgb(00, 50, 50, 50);
                    chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(0, 0), false);
                    //Valores
                    ValorReferencia.X = (float)chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                    ValorReferencia.Y = (float)chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                    //Deleta linha se já tiver, ou cria uma nova
                    if (Cursor_vertical_Referencia == null)
                        Cursor_vertical_Referencia = new VerticalLineAnnotation();
                    else
                        chart1.Annotations.Remove(Cursor_vertical_Referencia);
                    //Linha no Chart
                    Cursor_vertical_Referencia.AnchorDataPoint = chart1.Series[0].Points[1];
                    Cursor_vertical_Referencia.Height = chart1.ChartAreas[0].Position.Height;
                    Cursor_vertical_Referencia.LineColor = Color.Orange;
                    Cursor_vertical_Referencia.LineWidth = 1;
                    Cursor_vertical_Referencia.AnchorX = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                    Cursor_vertical_Referencia.AnchorY = chart1.ChartAreas[0].AxisY.Maximum;
                    chart1.Annotations.Add(Cursor_vertical_Referencia);
                    //Habilita opção de salvar
                    btnSalvar.Enabled = true;
                }
            }
        }
        //---------------------------------------------------------------------------
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(ValorInicio.X > ValorFim.X)
                MessageBox.Show("Marcação errada.\n A posição de inicio está maior que a posição de fim.\n\nNão salvo.", "Reconhecimento Automatizado de Padrões EEG");
            else
            {
                btnSalvar.Enabled = false;
                Arquivos = new GerenArquivos();
                Listas[comboTiposDeEventos.SelectedIndex].SetValorInicio(lbxEventosPorTipo.SelectedIndex, ValorInicio);
                Listas[comboTiposDeEventos.SelectedIndex].SetValorFim(lbxEventosPorTipo.SelectedIndex, ValorFim);
                Listas[comboTiposDeEventos.SelectedIndex].SetValorMeio(lbxEventosPorTipo.SelectedIndex, ValorReferencia);
                Listas[comboTiposDeEventos.SelectedIndex].SetComentario(lbxEventosPorTipo.SelectedIndex, txtComents.Text.ToString());

                Arquivos.Exportar_Padroes_Eventos(Listas);

                MessageBox.Show("Padrão '" + edtEvento_Nome.Text + "' editado e salvo.", "Reconhecimento Automatizado de Padrões EEG");
                txtComents.Text = "";
                chart1.Annotations.Clear();
                chart1.Series.Remove(chart1.Series["Serie01"]);
                chart1.ChartAreas.Remove(chart1.ChartAreas[0]);
            }
        }
        //---------------------------------------------------------------------------
        private void cbx_Inicio_Click(object sender, EventArgs e)
        {
            cbx_Referencia.Checked = false;
            cbx_Fim.Checked = false;
        }
        //---------------------------------------------------------------------------        
        private void cbx_Fim_Click(object sender, EventArgs e)
        {
            cbx_Inicio.Checked = false;
            cbx_Referencia.Checked = false;
        }
        //---------------------------------------------------------------------------        
        private void cbx_Referencia_Click(object sender, EventArgs e)
        {
            cbx_Inicio.Checked = false;
            cbx_Fim.Checked = false;
        }

        private void checkCorrela_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCorrela.Checked)
            {
                if (chart1.ChartAreas.Count != 0)
                {
                    vector = new double[chart1.Series[0].Points.Count];
                    for (int i = 0; i < chart1.Series[0].Points.Count; i++)
                        vector[i] = chart1.Series[0].Points[i].YValues[0];
                    this.Close();
                }
                else
                    checkCorrela.Checked = false;
            }
            else
            {
                vector = null;
            }
        }
    }
    //--------------------------------
    public class AtualizarRefInChart
    {
        private Control _Grafico = null;
        private delegate void AtualizaChart(float posX);
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1 = null;
        private float _ValX;

        // This method that will be called when the thread is started
        public AtualizarRefInChart(Control Chart, float ValX)
        {
            _Grafico = Chart;
            _ValX = ValX;
        }
        public void Init()
        {
            Thread.Sleep(20);
            Referencia_Init(_ValX);
        }
        private void Referencia_Init(float PosicaoX)
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new AtualizaChart(Referencia_Init), new Object[] { PosicaoX });
            }
            else
            {
                chart1 = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;

                VerticalLineAnnotation Cursor_vertical_Ref = new VerticalLineAnnotation();
                //Linha de referencia
                Cursor_vertical_Ref.AnchorDataPoint = chart1.Series[0].Points[1];
                Cursor_vertical_Ref.Height = chart1.ChartAreas[0].Position.Height;
                Cursor_vertical_Ref.LineColor = Color.Wheat;
                Cursor_vertical_Ref.LineWidth = 1;
                Cursor_vertical_Ref.AnchorX = PosicaoX;
                Cursor_vertical_Ref.AnchorY = chart1.ChartAreas[0].AxisY.Maximum;
                chart1.Annotations.Add(Cursor_vertical_Ref);
                Cursor_vertical_Ref.Visible = true;
            }
        }
    };
}
