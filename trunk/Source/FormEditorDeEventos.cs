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

namespace AmbienteRPB
{
    public partial class FormEditorDeEventos : Form
    {
        private ListaPadroesEventos[] Listas;
        private GerenArquivos Arquivos;
        private int numCursor = 0;
        private int mostrarCursores = 0;
        private float x_Pos, y_Pos;
        private HitTestResult var_result;
        private string EDF_File;
        PointF Padrao_Inicio;
        PointF Padrao_Fim;
        EdfFile SinalEEG;
        //---------------------------------------------------------------------------
        public FormEditorDeEventos(ListaPadroesEventos[] _Listas, string _EDF_File)
        {
            InitializeComponent();            
            Listas = _Listas;
            EDF_File = _EDF_File;
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
            lbxEventosPorTipo.Items.Clear();
            for (int i = 0; i < Listas[comboTiposDeEventos.SelectedIndex].NumeroEventos; i++)
                lbxEventosPorTipo.Items.Add(Listas[comboTiposDeEventos.SelectedIndex].GetNomesEvento(i));
            if (chart1.Series.Count != 0)
            {
                chart1.Series.Remove(chart1.Series["Serie01"]);
                chart1.ChartAreas.Remove(chart1.ChartAreas[0]);
            }
        }
        //---------------------------------------------------------------------------
        private void lbxEventosPorTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chart1.Series.Count != 0)
            {
                chart1.Series.Remove(chart1.Series["Serie01"]);
                chart1.ChartAreas.Remove(chart1.ChartAreas[0]);
            }
            if (lbxEventosPorTipo.SelectedItem != null)
            {
                chart1.ChartAreas.Add("Padrao");
                chart1.Series.Add("Serie01");
                chart1.Series["Serie01"].ChartArea = "Padrao";
                chart1.Series["Serie01"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                
                edtEvento_Nome.Text = lbxEventosPorTipo.SelectedItem.ToString();
                cbx_Inicio.Text = "Início " +  Listas[comboTiposDeEventos.SelectedIndex].GetValorInicio(lbxEventosPorTipo.SelectedIndex);
                cbx_Referencia.Text = "Referência " + Listas[comboTiposDeEventos.SelectedIndex].GetValorMeio(lbxEventosPorTipo.SelectedIndex);
                cbx_Fim.Text = "Fim: " + Listas[comboTiposDeEventos.SelectedIndex].GetValorFim(lbxEventosPorTipo.SelectedIndex);
                
                //Carrega sinal edf do arquivo.. 
                Arquivos = new GerenArquivos();
                SinalEEG = Arquivos.Abrir_Projeto_EDF(EDF_File, false);

                //Nome do canal
                string nome_canal =  Listas[comboTiposDeEventos.SelectedIndex].GetNomesEvento(lbxEventosPorTipo.SelectedIndex);
                int X_ = nome_canal.IndexOf("_");
                nome_canal = nome_canal.Substring(X_+1);
                //Inicio do enveto
                float x = Listas[comboTiposDeEventos.SelectedIndex].GetValorInicio(lbxEventosPorTipo.SelectedIndex).X - 1;
                float x_max = Listas[comboTiposDeEventos.SelectedIndex].GetValorFim(lbxEventosPorTipo.SelectedIndex).X + 1;
                
                float aux;
                int DataRecords_lidos = 0;
                int tempo_X = DataRecords_lidos * 256;
                while (tempo_X <= (int) x_max)
                {
                    DataRecords_lidos++;
                    SinalEEG.ReadDataBlock(DataRecords_lidos);
                    //Cada ao fim deste for, é adiciocionado somente 1s em todos os canais
                    for (int j = 0; j < SinalEEG.SignalInfo.Count; j++)
                    {
                        for (int i = 0; i < 256; i++)
                        {
                            if (SinalEEG.SignalInfo[j].SignalLabel == nome_canal)
                            {
                                if (tempo_X >= (int) x && tempo_X <= (int) x_max)
                                {
                                    chart1.Series[0].Points.AddY(SinalEEG.DataBuffer[SinalEEG.SignalInfo[j].BufferOffset + i]);
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
            }
        }
        //---------------------------------------------------------------------------
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
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
        //---------------------------------------------------------------------------
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            numCursor = 0;
            Exportar_Padrao(Padrao_Inicio, Padrao_Fim);
            chart1.Annotations.Clear();
        }
        //---------------------------------------------------------------------------
        private void Exportar_Padrao(PointF Padrao_Inicio, PointF Padrao_Fim)
        {
            Arquivos = new GerenArquivos();
            Arquivos.Exportar_Padroes_Eventos(Listas);
            MessageBox.Show("Padrão '" + edtEvento_Nome.Text + "' editado e salvo.", "Ambiente RPB");
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
        //---------------------------------------------------------------------------
    }
}
