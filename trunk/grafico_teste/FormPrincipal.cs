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
using System.IO;
using System.Runtime.InteropServices;

namespace grafico_teste
{
    public partial class FormPrincipal : Form
    {
        //verifação de status das threads do sistema---------------------------------------
        private Thread StatusThreads;
        private int ThreadChart_status = 0; // 0 - Desabilitada, 1 - Rodando, 2 - Pausada
        //Plotar sinais na tela------------------------------------------------------------
        private Thread ThreadChart;
        private int __numeroDeCanais = 2;
        //---------------------------------------------------------------------------------
        private int numCursor = 0;
        private int mostrarCursores = 0;
        private double x_Pos, y_Pos;
        private int _ZOOM_ = 0; // 0 -desativado, 1 +ZOOm, 2 -ZOMM 
        private String nomeProject = "Sem nome";
        private string status_projeto = "Projeto_NOVO";
        //Geren Arquivos------------------------------------------
        private GerenArquivos Arquivos;
        //-----------------------------------------------------------------------------------------
        public FormPrincipal()
        {
            Arquivos = new GerenArquivos();
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            encerrar_sistema( );
        }
        //#########################################################################################
        //-----------------------------------------------------------------------------------------
        //                                 Gerencia de Projetos
        //-----------------------------------------------------------------------------------------
        //#########################################################################################
        /*
         *Verifica estado do sistema, caso esteja em execução aborta as operações. 
         */
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
        //------------------------------------------------------------------------------------------
        // Ferramenta de importar sinais EEG de outro programa
        private void btn_Importar_Click(object sender, EventArgs e)
        {
            AtualizaFerramentaAtiva("Importar sinais não implentado!", 2);
            //status_projeto = "Projeto_EDF";
        }
        //------------------------------------------------------------------------------------------
        //Salva Projeto em que está sendo executado
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveFileExplorer.ShowDialog();
            nomeProject = saveFileExplorer.FileName;
            if (nomeProject != null)
            {
                Arquivos.Salva_Projeto(nomeProject + ".rpb", __numeroDeCanais, chart1);
            }   
        }
        //------------------------------------------------------------------------------------------
        //Abre projeto.
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileExplorer.ShowDialog( );
            nomeProject = openFileExplorer.FileName;
            if (nomeProject != null)
            {
                Arquivos.Abrir_Projeto(nomeProject + ".rpb");
            }
            status_projeto = "Projeto_RPB";
            AtualizaFerramentaAtiva("Abrir projeto não implentado!", 2); 
        }
        //##########################################################################################
        //------------------------------------------------------------------------------------------
        //                             Ferramentas ao Tratamento do sinal EEG
        //------------------------------------------------------------------------------------------
        //##########################################################################################
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
        //------------------------------------------------------------------------------------------
        private void btn_Resume_Click(object sender, EventArgs e)
        {
            if (ThreadChart_status == 0)
            {
                chart1.Enabled = true; 
                ChartInicializarThreads(__numeroDeCanais);
                FuncStatusThreads();
                btn_Suspender.Enabled = true;
                btn_novoProjeto.Enabled = false;
                btn_Resume.Enabled = false;
                btn_MarcarPadrões.Enabled = true;
                ThreadChart_status = 1;
                btnZoomMais.Enabled = true;
                btnZoomMenos.Enabled = true;
            }

            if (ThreadChart_status == 2)
            {
                ThreadChart.Resume();
                ThreadChart_status = 1;
                btn_Suspender.Enabled = true;
                btn_Resume.Enabled = false;
            }
        }
        //------------------------------------------------------------------------------------------
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
            if (_ZOOM_ != 0)
            {
                if (_ZOOM_ == 1)
                {//ZOOM +
                    chart1.ChartAreas[0].AxisX.ScaleView.Position = 2;
                    chart1.ChartAreas[0].CursorX.AutoScroll = true;
                    chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                    double x = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(x, 10);
                    chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

                    // set scrollbar small change to blockSize (e.g. 100)
                    chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 10;

                }
                else
                {//ZOOM -
                    chart1.ChartAreas[0].AxisX.ScaleView.Position = 2;
                    chart1.ChartAreas[0].CursorX.AutoScroll = true;
                    chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                    chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                }
              }
         
        }
        //------------------------------------------------------------------------------------------
        private void mouse_Mover(object sender, MouseEventArgs e)
        {
            for(int i = 0; i < chart1.ChartAreas.Count; i++)
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
        }
        //------------------------------------------------------------------------------------------
        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encerrar_sistema();
        }
        //------------------------------------------------------------------------------------------
        private void btn_novoProjeto_Click(object sender, EventArgs e)
        {
            btn_Resume.Enabled = true;
            btn_help.Enabled = true;
            saveToolStripButton.Enabled = true;
            MessageBox.Show("Projeto " + nomeProject + "\nCriado", 
                    "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            status_projeto = "Projeto_NOVO";
                
        }
        //------------------------------------------------------------------------------------------
        //                               ##   Definir Padrões ##
        //------------------------------------------------------------------------------------------
        private void btn_MarcarPadrões_Click(object sender, EventArgs e)
        {
            if (mostrarCursores == 0)
            {
                AtualizaFerramentaAtiva("", 0);
                mostrarCursores = 1;
                AtualizaFerramentaAtiva("Marcar Padrões", 1);
            }
            else
            {
                AtualizaFerramentaAtiva("", 0);
            }
        }
        //------------------------------------------------------------------------------------------
        //                                    ##  ZOOM ##
        //------------------------------------------------------------------------------------------
        private void btnZoomMais_Click(object sender, EventArgs e)
        {
            if (_ZOOM_ == 0 || _ZOOM_ == 2)
            {
                AtualizaFerramentaAtiva("", 0);
                AtualizaFerramentaAtiva("ZOOM +", 1);
                Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorZoomMais.cur");
                _ZOOM_ = 1;
            }
            else
            {
                AtualizaFerramentaAtiva("", 0);
            }

        }
        //------------------------------------------------------------------------------------------
        private void btnZoomMenos_Click(object sender, EventArgs e)
        {
            if (_ZOOM_ == 1)
            {
                AtualizaFerramentaAtiva("", 0);
                AtualizaFerramentaAtiva("ZOOM -", 1);
                Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorZoomMenos.cur");
                _ZOOM_ = 2;
            }
            else
            {
                AtualizaFerramentaAtiva("", 0);
            }
        }
        //------------------------------------------------------------------------------------------
        //                              ->   Ferramenta ativa <-
        //------------------------------------------------------------------------------------------
        private void AtualizaFerramentaAtiva(string ferramenta, int opcao)
        {
            if (opcao == 0)
            {
                lbl_ferramentaAtiva.ForeColor = Color.Brown;
                lbl_ferramentaAtiva.Text = "Ferramenta ativa: Nenhuma";
                Cursor = Cursors.Default;
                _ZOOM_ = 0;
                mostrarCursores = 0;
            }
            if (opcao == 1)
            {
                lbl_ferramentaAtiva.ForeColor = Color.MediumSeaGreen;
                lbl_ferramentaAtiva.Text = "Ferramenta ativa: " + ferramenta;
            }
            if (opcao == 2)
            {
                lbl_ferramentaAtiva.ForeColor = Color.Red;
                lbl_ferramentaAtiva.Text = ferramenta;
            }

        }
        //------------------------------------------------------------------------------------------
        //           -> Inicializa Thread responsalvel pela aquisição do sinal. <-
        //------------------------------------------------------------------------------------------
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
                chart1.ChartAreas[i].Position.Y = i * (4) + 3;
                chart1.ChartAreas[i].Position.Height = 3;
                chart1.ChartAreas[i].Position.Width = 100;
            }
            if (status_projeto == "Projeto_NOVO")
            {
                //  this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
            }
            if (status_projeto == "Projeto_RPB")
            {
                //  this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
            }
            if (status_projeto == "Projeto_EDF")
            {
                //  this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
            }
            
        }
        //------------------------------------------------------------------------------------------
        //            ################################################################
        //                           .VERIFICA ESTADO DAS THREAD EXISTENTES.
        //            ################################################################
        //------------------------------------------------------------------------------------------
        private void FuncStatusThreads()
        {
            StatusThreads = new Thread(new ThreadStart(VerificaStatusThreads));
            StatusThreads.Start();
        }
        //------------------------------------------------------------------------------------------
        private void VerificaStatusThreads( )
        {
            while (true)
            {
                if (ThreadChart.IsAlive == false)
                {
                    //btn_Suspender.Enabled = false;
                    ThreadChart.Abort();
                    StatusThreads.Abort();
                }
                Thread.Sleep(1000);
            }
        }
        //------------------------------------------------------------------------------------------
       
    }
}
