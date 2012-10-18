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
using EDF;


namespace AmbienteRPB
{
    public partial class FormPrincipal : Form
    {
       
        //Plotar sinais na tela------------------------------------------------------------
        private Thread ThreadChart;
        private int __numeroDeCanais = 23;
        //---------------------------------------------------------------------------------
        private int numCursor = 0;
        private int mostrarCursores = 0;
        private double x_Pos, y_Pos;
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
            if (ThreadChart.IsAlive == true)
            {
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
                    AtualizaFerramentaAtiva("Abrir arquivo .EDF", 1);
                    __numeroDeCanais = edfFileOutput.Header.Signals.Count;
                    saveToolStripButton.Enabled = true;
                    ChartInicializarThreads(__numeroDeCanais);

                    btn_novoProjeto.Enabled = false;
                    btn_MarcarPadrões.Enabled = true;

                    btn_Importar.Enabled = false;
                    btn_novoProjeto.Enabled = false;
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
                    btn_Importar.Enabled = false;
                    btn_novoProjeto.Enabled = false;
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
            btn_Importar.Enabled = false;
            btn_novoProjeto.Enabled = false;
            //btn_help.Enabled = true;
            saveToolStripButton.Enabled = true;
            MessageBox.Show("Projeto " + nomeProject + "\nCriado",
                    "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            status_projeto = "Projeto_NOVO";

            ChartInicializarThreads(__numeroDeCanais);
           
            btn_novoProjeto.Enabled = false;
            btn_MarcarPadrões.Enabled = true;

        }
        //------------------------------------------------------------------------------------------
        //Supende o sistema
        private void btn_Suspender_Click(object sender, EventArgs e)
        {
       
        }
        //------------------------------------------------------------------------------------------
        //retorna o sistema
        private void btn_Resume_Click(object sender, EventArgs e)
        {
         
        }
        //-----------------------------------------------------------------------------------------
        //Função responsavel por verificar qual ferramenta usar quando o mouse é clicado em cima dos sinais
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mostrarCursores != 0)
            {
                MarcarSelecao(e);
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
           
            HitTestResult result = chart1.HitTest(e.X, e.Y);
            if (result.ChartArea != null)
            {
                var pointXPixel = result.ChartArea.AxisX.PixelPositionToValue(e.X);
                var pointYPixel = result.ChartArea.AxisY.PixelPositionToValue(e.Y);
                lbl_x.Text = "Valor X: " + pointXPixel;
                lbl_Y.Text = "Valor Y: " + pointYPixel;
                if (MostrarCursorX == true)
                {
                //Mostra cursor X
                result.ChartArea.CursorX.SetCursorPosition(pointXPixel);
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
                    HitTestResult result = chart1.HitTest(e.X, e.Y);
                    if (result != null)
                    {
                        if (numCursor == 0)
                        {

                            x_Pos = result.ChartArea.AxisX.PixelPositionToValue(e.X);
                            y_Pos = result.ChartArea.AxisY.PixelPositionToValue(e.Y);

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
                            result.ChartArea.CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);

                            chart1.Annotations.Clear();

                            // Set range selection color, specifying transparency of 120
                            result.ChartArea.CursorX.SelectionColor = Color.FromArgb(120, 50, 50, 50);
                            result.ChartArea.CursorX.IsUserEnabled = true;
                            result.ChartArea.CursorX.IsUserSelectionEnabled = true;
                            result.ChartArea.CursorX.SetSelectionPosition(x_Pos, e.X);

                            numCursor = 0;//CLICAR + VEZES SEM EFEITO
                            //PADrões(); !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
            int Divisao = 100 / numeroDeCanais;
            for (int i = 0; i < numeroDeCanais; i++)
            {
                //propriedades de cada sinal
                chart1.ChartAreas.Add("canal" + i);
                chart1.ChartAreas[i].AxisX.Enabled = AxisEnabled.False;
                chart1.ChartAreas[i].AxisY.Enabled = AxisEnabled.False;
                chart1.ChartAreas[i].BackColor = Color.Linen; //Cor de fundo nos canais... 
                chart1.ChartAreas[i].Position.X = 4;
                chart1.ChartAreas[i].Position.Y = Divisao * i + 1;
                chart1.ChartAreas[i].Position.Height = Divisao;
                chart1.ChartAreas[i].Position.Width = 95;  
            }
            //adicionar linhas eixo Y
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation3 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation4 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation5 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation6 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation7 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation8 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation9 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation10 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
          

            lineAnnotation1.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation2.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation3.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation4.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation5.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation6.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation7.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation8.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation9.LineColor = System.Drawing.Color.LightGray;
            lineAnnotation10.LineColor = System.Drawing.Color.LightGray;
      
            lineAnnotation1.ToolTip = "1";
            lineAnnotation2.ToolTip = "1";
            lineAnnotation3.ToolTip = "1";
            lineAnnotation4.ToolTip = "1";
            lineAnnotation5.ToolTip = "1";
            lineAnnotation6.ToolTip = "1";
            lineAnnotation7.ToolTip = "1";
            lineAnnotation8.ToolTip = "1";
            lineAnnotation9.ToolTip = "1";
            lineAnnotation10.ToolTip = "1";

            lineAnnotation1.X = 4;
            //=]
            lineAnnotation2.X = 14.3;
            lineAnnotation3.X = 24.6;
            lineAnnotation4.X = 34.9;
            lineAnnotation5.X = 45.2;
            lineAnnotation6.X = 55.5;
            lineAnnotation7.X = 65.8;
            lineAnnotation8.X = 76.1;
            lineAnnotation9.X = 87.4;
            lineAnnotation10.X = 99;

            lineAnnotation1.Width = 0;
            lineAnnotation1.Y = 0;
            lineAnnotation2.Width = 0;
            lineAnnotation2.Y = 0;
            lineAnnotation3.Width = 0;
            lineAnnotation3.Y = 0;
            lineAnnotation4.Width = 0;
            lineAnnotation4.Y = 0;
            lineAnnotation5.Width = 0;
            lineAnnotation5.Y = 0;
            lineAnnotation6.Width = 0;
            lineAnnotation6.Y = 0;
            lineAnnotation7.Width = 0;
            lineAnnotation7.Y = 0;
            lineAnnotation8.Width = 0;
            lineAnnotation8.Y = 0;
            lineAnnotation9.Width = 0;
            lineAnnotation9.Y = 0;
            lineAnnotation10.Width = 0;
            lineAnnotation10.Y = 0;

            lineAnnotation1.Height = 200;
            lineAnnotation2.Height = 200;
            lineAnnotation3.Height = 200;
            lineAnnotation4.Height = 200;
            lineAnnotation5.Height = 200;
            lineAnnotation6.Height = 200;
            lineAnnotation7.Height = 200;
            lineAnnotation8.Height = 200;
            lineAnnotation9.Height = 200;
            lineAnnotation10.Height = 200;

            lineAnnotation1.Name = "LineAnnotation1";
            lineAnnotation2.Name = "LineAnnotation2";
            lineAnnotation3.Name = "LineAnnotation3";
            lineAnnotation4.Name = "LineAnnotation4";
            lineAnnotation5.Name = "LineAnnotation5";
            lineAnnotation6.Name = "LineAnnotation6";
            lineAnnotation7.Name = "LineAnnotation7";
            lineAnnotation8.Name = "LineAnnotation8";
            lineAnnotation9.Name = "LineAnnotation9";
            lineAnnotation10.Name = "LineAnnotation10";

            chart1.Annotations.Add(lineAnnotation1);
            chart1.Annotations.Add(lineAnnotation2);
            chart1.Annotations.Add(lineAnnotation3);
            chart1.Annotations.Add(lineAnnotation4);
            chart1.Annotations.Add(lineAnnotation5);
            chart1.Annotations.Add(lineAnnotation6);
            chart1.Annotations.Add(lineAnnotation7);
            chart1.Annotations.Add(lineAnnotation8);
            chart1.Annotations.Add(lineAnnotation9);
            chart1.Annotations.Add(lineAnnotation10);
        
            if (status_projeto == "Projeto_NOVO")
            {
                //  this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto, edfFileOutput, ScrollBar);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
                chart1.Enabled = true;
                FrequenciaCombo.Enabled = true;
                AmplitudeCombo.Enabled = true;
            }
            if (status_projeto == "Projeto_RPB")
            {
                //  this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto, edfFileOutput, ScrollBar);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
                chart1.Enabled = true;
                FrequenciaCombo.Enabled = true;
                AmplitudeCombo.Enabled = true;
            }
            if (status_projeto == "Projeto_EDF")
            {
                //  this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto, edfFileOutput, ScrollBar);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
                chart1.Enabled = true;
                FrequenciaCombo.Enabled = true;
                AmplitudeCombo.Enabled = true;
            }
            
        }
        //------------------------------------------------------------------------------------------
        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
        //------------------------------------------------------------------------------------------
        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            for (int i = 0; i < __numeroDeCanais; i++)
            {
                chart1.ChartAreas[i].AxisX.ScaleView.Position = e.NewValue;
            }
        }
        //------------------------------------------------------------------------------------------
        private void AmplitudeCombo_TextChanged(object sender, EventArgs e)
        {
            if (AmplitudeCombo.Text != "")
            {
                for (int i = 0; i < __numeroDeCanais; i++)
                    chart1.ChartAreas[i].AxisY.ScaleView.Size = Convert.ToDouble(AmplitudeCombo.Text);
            }
        }
        //------------------------------------------------------------------------------------------

        private void FrequenciaCombo_TextChanged(object sender, EventArgs e)
        {
            if (FrequenciaCombo.Text != "")
            {
                for (int i = 0; i < __numeroDeCanais; i++)
                    chart1.ChartAreas[i].AxisX.ScaleView.Size = Convert.ToDouble(FrequenciaCombo.Text);
            }
        }
        //------------------------------------------------------------------------------------------
       
    }
}
