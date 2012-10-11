﻿using System;
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
using EDF;


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
        private bool MostrarCursorX = true;

        private string dirArquivo;
        private EDFFile edfFileInput = null;
        private EDFFile edfFileOutput = null;
        //Geren Arquivos------------------------------------------
        private GerenArquivos Arquivos;

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
      
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
        // Ferramenta de importar sinais EEG de arquivo .EDF
        private void btn_Importar_Click(object sender, EventArgs e)
        {
                       
            if (openFileEDF.ShowDialog() == DialogResult.OK)
            {
                nomeProject = openFileEDF.FileName;
                edfFileOutput = Arquivos.Abrir_Projeto_EDF(nomeProject);
                if (edfFileOutput != null)
                {
                    status_projeto = "Projeto_EDF";
                    AtualizaFerramentaAtiva("Abrir arquivo .edf em implementação!", 2);
                    __numeroDeCanais = edfFileOutput.Header.Signals.Count;
                    btn_Resume.Enabled = true;
                    btn_help.Enabled = true;
                    saveToolStripButton.Enabled = true;
                    //edfFileOutput.
                }
                else
                    AtualizaFerramentaAtiva("Nenhum sinal selecionado!", 2);
            }
            openFileEDF.Dispose();
         }
        //------------------------------------------------------------------------------------------
        //Salva Projeto em que está sendo executado
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveFileExplorer.ShowDialog() == DialogResult.OK)
            {
                nomeProject = saveFileExplorer.FileName;
                Arquivos.Salva_Projeto(nomeProject + ".rpb", __numeroDeCanais, chart1);
            }   
        }
        //------------------------------------------------------------------------------------------
        //Abre projeto.
        private void openToolStripButton_Click(object sender, EventArgs e)
        { 
            if (openFileExplorer.ShowDialog() == DialogResult.OK)
            {
                nomeProject = openFileExplorer.FileName;
                __numeroDeCanais = Arquivos.Abrir_Projeto(nomeProject);
                if (__numeroDeCanais != 0)
                {
                    //fazer
                }
                status_projeto = "Projeto_RPB";
                AtualizaFerramentaAtiva("Abrir projeto não implentado!", 2); 
            }
           
        }
        //##########################################################################################
        //------------------------------------------------------------------------------------------
        //                             Ferramentas ao Tratamento do sinal EEG
        //------------------------------------------------------------------------------------------
        //##########################################################################################
        //Encerrar o sitema
        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encerrar_sistema();
        }
        //------------------------------------------------------------------------------------------
        //Criar novo projeto
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
        //Supende o sistema
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
        //retorna o sistema
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
        //-----------------------------------------------------------------------------------------
        //Função responsavel por verificar qual ferramenta usar quando o mouse é clicado em cima dos sinais
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {         
            if(mostrarCursores != 0)
            {
                MarcarSelecao(e);
            }    
            if (_ZOOM_ != 0)
            {
                ZOOM(e); 
            }
         
        }
        //-----------------------------------------------------------------------------------------
        //Check box responsavel por Mostra o cursor no eixo X dos gráficos
        private void check_MostrarCursorX_CheckedChanged(object sender, EventArgs e)
        {
            if (check_MostrarCursorX.Checked == true)
            {
                MostrarCursorX = true;
            }
            else
                MostrarCursorX = false;
        }
        //------------------------------------------------------------------------------------------
        // Mostra o cursor no eixo X dos gráficos
        private void mouse_Mover(object sender, MouseEventArgs e)
        {
            if (MostrarCursorX == true)
            {
                var pos = e.Location;
                if (prevPosition.HasValue && pos == prevPosition.Value)
                    return;
                tooltip.RemoveAll();
                prevPosition = pos;
                var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
                foreach (var result in results)
                {
                    if (result.ChartElementType == ChartElementType.DataPoint)
                    {
                        var prop = result.Object as DataPoint;
                        if (prop != null)
                        {
                            var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                            var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                            lbl_x.Text = "Valor X: " + prop.XValue;
                            lbl_Y.Text = "Valor Y: " + prop.YValues[0];
                            //Verificar isto!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! está marcando somente no numero inteiro
                            result.ChartArea.CursorX.SetCursorPosition(prop.XValue);


                            // check if the cursor is really close to the point (2 pixels around the point)
                            if (Math.Abs(pos.X - pointXPixel) < 2 && Math.Abs(pos.Y - pointYPixel) < 2)
                            {
                                tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.chart1, pos.X, pos.Y - 15);


                            }
                        }
                    }
                }
            }
            lbl_mouseX.Text = "Mouse X: " + e.Location.X;
            lbl_mouseY.Text = "Mouse Y: " + e.Location.Y;
        }
        
        //---------------------------------------------------------------------------------------
        //                               ##   Definir Padrões  ##
        //------------------------------------------------------------------------------------------
        //Botão Clicado
        private void btn_MarcarPadrões_Click(object sender, EventArgs e)
        {
            if (mostrarCursores == 0)
            {
                check_MostrarCursorX.Checked = false;
                MostrarCursorX = false;
                AtualizaFerramentaAtiva("", 0);
                mostrarCursores = 1;
                Cursor = new System.Windows.Forms.Cursor(GetType(), "CursorY.cur");
                AtualizaFerramentaAtiva("Marcar Padrões", 1);
            }
            else
            {
                AtualizaFerramentaAtiva("", 0);
            }
        }
        //------------------------------------------------------------------------------------------
        //Defini uma seleção afim de ser um padrão. 
        private void MarcarSelecao(MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        if (numCursor == 0)
                        {

                            x_Pos = prop.XValue;
                            y_Pos = prop.YValues[0];

                            //linha fixa
                            VerticalLineAnnotation cursor_vertical = new VerticalLineAnnotation();
                            cursor_vertical.AnchorDataPoint = chart1.Series[0].Points[1];

                            cursor_vertical.Height = 3;
                            cursor_vertical.LineColor = Color.Chocolate;
                            cursor_vertical.LineWidth = 2;
                            cursor_vertical.AnchorX = x_Pos;
                            cursor_vertical.AnchorY = result.ChartArea.AxisY.Maximum;
                            chart1.Annotations.Add(cursor_vertical);

                            numCursor++;
                        }
                        //APOS O ELSE IF PERGUNTAR SE DESEJA REALMENTE MARCAR UM PADrÃO E TRATAR ISSO!!!

                        else if (numCursor == 1)
                        {
                            result.ChartArea.CursorX.AxisType = AxisType.Secondary;
                            result.ChartArea.CursorX.LineColor = Color.Chocolate;
                            result.ChartArea.CursorX.LineWidth = 2;
                            result.ChartArea.CursorX.SetCursorPixelPosition(new PointF(pos.X, pos.Y), true);

                            chart1.Annotations.Clear();

                            // Set range selection color, specifying transparency of 120
                            result.ChartArea.CursorX.SelectionColor = Color.FromArgb(120, 50, 50, 50);
                            result.ChartArea.CursorX.IsUserEnabled = true;
                            result.ChartArea.CursorX.IsUserSelectionEnabled = true;
                            result.ChartArea.CursorX.SetSelectionPosition(x_Pos, prop.XValue);

                            numCursor = 0;//CLICAR + VEZES SEM EFEITO
                            //PADrões(); !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        }
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------
        //                                    ##  ZOOM ##
        //------------------------------------------------------------------------------------------
        //Botão ZOOM +
        private void btnZoomMais_Click(object sender, EventArgs e)
        {
            if (_ZOOM_ == 0 || _ZOOM_ == 2)
            {
                check_MostrarCursorX.Checked = false;
                MostrarCursorX = false;
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
        //Botão ZOOM -
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
        //Realiza o ZOOM
        private void ZOOM(MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y);
            if (result.ChartArea != null)
            {
                if (_ZOOM_ == 1)
                {//ZOOM +
                    result.ChartArea.AxisX.ScaleView.Position = 2;
                   // result.ChartArea.CursorX.AutoScroll = true;
                    result.ChartArea.AxisX.ScaleView.Zoomable = true;
                    double x = result.ChartArea.AxisX.PixelPositionToValue(e.X);
                    result.ChartArea.AxisX.ScaleView.Zoom(x, x+10);
                   // result.ChartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                    result.ChartArea.AxisX.ScrollBar.Enabled = true;
                    result.ChartArea.AxisX.ScrollBar.IsPositionedInside = true;
                    result.ChartArea.AxisX.ScrollBar.Size = 15;
                   //ver isso!!!     
                    result.ChartArea.CursorX.IsUserEnabled = true;
                    result.ChartArea.CursorX.Interval = 1;
                    result.ChartArea.CursorX.IsUserSelectionEnabled = true;
                    result.ChartArea.AxisX.ScrollBar.IsPositionedInside = true;

                    
                    result.ChartArea.CursorX.IsUserEnabled = true;

                    // set scrollbar small change to blockSize (e.g. 100)
                    //result.ChartArea.AxisX.ScaleView.SmallScrollSize = 1;
                }
                else
                {//ZOOM -
                    result.ChartArea.AxisX.ScaleView.Position = 2;
                    result.ChartArea.CursorX.AutoScroll = true;
                    result.ChartArea.AxisX.ScaleView.Zoomable = true;
                    result.ChartArea.AxisX.ScaleView.ZoomReset();
                }
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
                chart1.ChartAreas[i].Position.X = 4;
                chart1.ChartAreas[i].Position.Y = i * (4) + 3;
                chart1.ChartAreas[i].Position.Height = 3;
                chart1.ChartAreas[i].Position.Width = 95;
               
               
            }
            if (status_projeto == "Projeto_NOVO")
            {
                //  this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto, edfFileOutput);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
            }
            if (status_projeto == "Projeto_RPB")
            {
                //  this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto, edfFileOutput);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
            }
            if (status_projeto == "Projeto_EDF")
            {
                //  this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto, edfFileOutput);
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
