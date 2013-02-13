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
        private float x_Pos, y_Pos;
        private String nomeProject = "Sem nome";
        private string status_projeto = "Projeto_NOVO";
        private EDFFile edfFileOutput = null;
        private HitTestResult var_result;
        private bool MostrarCursorX;
        //Geren Arquivos-----------------------------------------------------------------
        private GerenArquivos Arquivos;
        //Editor de eventos--------------------------------------------------------------
        private int numDeEventosMarcados = 0;
        String Evento;
        ToolTip tooltip = new ToolTip();
        Color Cor;
        Color CorFundo;
        //-----------------------------------------------------------------------------------------
        public FormPrincipal()
        {
            Arquivos = new GerenArquivos();
            InitializeComponent();
            gbxEventos.Visible = false;
            gbxEventos.Enabled = false;

            gbxChart.Location = new System.Drawing.Point(2, 21);
            gbxChart.Size = new System.Drawing.Size(this.Size.Width - 20, 379); 
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
            /*if (ThreadChart.IsAlive == true && ThreadInicializada)
            {
                ThreadChart.Abort();
            }*/
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
                    ChartInicializarThreads(__numeroDeCanais);
                    btn_novoProjeto.Enabled = false;
                    btn_Importar.Enabled = false;
                    btn_novoProjeto.Enabled = false;
                    infoEDF.Enabled = true;
                    marcarEventos.Enabled = true;
                    btn_Importar.Enabled = false;
                    btnTemas.Enabled = true;
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
            //saveToolStripButton.Enabled = true;
            MessageBox.Show("Projeto " + nomeProject + "\nCriado",
                    "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            status_projeto = "Projeto_NOVO";
            ChartInicializarThreads(__numeroDeCanais);
            btn_novoProjeto.Enabled = false;
            //btn_MarcarPadroes.Enabled = true;

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
           /* HitTestResult result = chart1.HitTest(e.X, e.Y);
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
            }*/
            lbl_mouseX.Text = "Mouse X: " + e.Location.X;
            lbl_mouseY.Text = "Mouse Y: " + e.Location.Y;
        }
        //---------------------------------------------------------------------------------------
        //                               ##   Definir Padrões  ##
        //---------------------------------------------------------------------------------------
        private void marcarPadrõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (marcarEventos.Checked == false)
            {
                btn_MarcarPadroes.Enabled = true;
                marcarEventos.Checked = true;
                gbxEventos.Visible = true;
                gbxEventos.Enabled = true;
                gbxChart.Location = new System.Drawing.Point(95, 21);
                chart1.Location = new System.Drawing.Point(2, 8);
                gbxChart.Size = new System.Drawing.Size(this.Size.Width - 115, this.Size.Height - 105);
                chart1.Size = new System.Drawing.Size(this.Size.Width - 119, this.Size.Height - 115);
                check_MostrarCursorX.Checked = false;
                MostrarCursorX = false;
                AtualizaFerramentaAtiva("", 0);
                mostrarCursores = 1;
                AtualizaFerramentaAtiva("Marcar Eventos", 1);
            }
            else
            {
                marcarEventos.Checked = false;
                gbxEventos.Visible = false;
                gbxEventos.Enabled = false;
                gbxChart.Location = new System.Drawing.Point(2, 21);
                chart1.Location = new System.Drawing.Point(2, 8);
                gbxChart.Size = new System.Drawing.Size(this.Size.Width - 20, this.Size.Height - 105);
                chart1.Size = new System.Drawing.Size(this.Size.Width - 24, this.Size.Height - 115);
                AtualizaFerramentaAtiva("", 0);
            }
        }
        //------------------------------------------------------------------------------------------
        //Defini uma seleção afim de ser um padrão. 
        private void MarcarSelecao(MouseEventArgs e)
        {
                    HitTestResult result = chart1.HitTest(e.X, e.Y);
                    if (result.ChartArea != null)
                    {
                        AtualizaFerramentaAtiva("", 2);
                        ExecutaSelecao(result, e);
                    }
                    else
                    {
                        //Caso não encontrado nenhum resultado para onde foi clicado, o sofware 
                        //faz uma varredura de no maximo elemtos acima, evita transtornos... 
                        bool cont = true;
                        int i = 1;
                        while(cont)
                        {
                            result = chart1.HitTest(e.X + i, e.Y);
                            if (result != null)
                                cont = false;
                            if (i == 10)
                                cont = false;
                            i++;
                        }
                        AtualizaFerramentaAtiva("Result null", 2);
                        if(result == null)
                            AtualizaFerramentaAtiva("RESULT NULL 2 - Marque novamente", 2);
                        else
                            ExecutaSelecao(result, e);
                    }
        }
        //------------------------------------------------------------------------------------------
        private void ExecutaSelecao(HitTestResult result, MouseEventArgs e)
        {
            if (numCursor == 0)
            {
                var_result = result;

                chart1.Annotations.Clear();
                Adiciona_linhas_de_tempo();

                result.ChartArea.CursorX.SelectionColor = Color.FromArgb(00, 50, 50, 50);
                result.ChartArea.CursorX.SetCursorPixelPosition(new PointF(0, 0), false);

                x_Pos = (e.X);
                y_Pos = (e.Y);

                //linha fixa
                VerticalLineAnnotation cursor_vertical = new VerticalLineAnnotation();
                cursor_vertical.AnchorDataPoint = chart1.Series[result.ChartArea.Name].Points[1];
                cursor_vertical.Height = result.ChartArea.Position.Height;
                cursor_vertical.LineColor = Color.Green;
                cursor_vertical.LineWidth = 1;
                cursor_vertical.AnchorX = result.ChartArea.AxisX.PixelPositionToValue(e.X);
                cursor_vertical.AnchorY = result.ChartArea.AxisY.Maximum;
                chart1.Annotations.Add(cursor_vertical);
                numCursor++;
            }
            else if (numCursor == 1 && (result.ChartArea == var_result.ChartArea))
            {
                result.ChartArea.CursorX.AxisType = AxisType.Secondary;
                result.ChartArea.CursorX.LineColor = Color.Green;
                result.ChartArea.CursorX.LineWidth = 1;
                result.ChartArea.CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);

                // Set range selection color, specifying transparency of 120
                result.ChartArea.CursorX.SelectionColor = Color.FromArgb(90, 50, 50, 50);
                result.ChartArea.CursorX.IsUserEnabled = true;
                result.ChartArea.CursorX.IsUserSelectionEnabled = true;
                PointF Padrao_Inicio = new PointF(x_Pos, y_Pos);
                PointF Padrao_Fim = new PointF(e.X, e.Y);
                result.ChartArea.CursorX.SetSelectionPixelPosition(Padrao_Inicio, Padrao_Fim, true);

                Padrao_Inicio.X = (float)result.ChartArea.AxisX.PixelPositionToValue(x_Pos);
                Padrao_Fim.X = (float)result.ChartArea.AxisX.PixelPositionToValue(e.X);

                Exportar_Padrao(Padrao_Inicio, Padrao_Fim);
                numCursor = 0;//CLICAR + VEZES SEM EFEITO
                result.ChartArea.CursorX.SetSelectionPixelPosition(new PointF(0, 0), new PointF(0, 0), true);
                result.ChartArea.CursorX.LineColor = Color.LightGray;
                result.ChartArea.CursorX.SetCursorPixelPosition(new PointF(0, 0), true);
                result.ChartArea.CursorX.IsUserEnabled = false;
                result.ChartArea.CursorX.IsUserSelectionEnabled = false;

                chart1.Annotations.Clear();
                Adiciona_linhas_de_tempo();
            }
        }
        //------------------------------------------------------------------------------------------
        private void Exportar_Padrao(PointF Padrao_Inicio, PointF Padrao_Fim)
        {
            if (Evento != null)
            {
                Arquivos.ExportarPadraoArquivo(Evento + "_" + numDeEventosMarcados, chart1, var_result, Padrao_Inicio, Padrao_Fim);
                MessageBox.Show("Padrão '" + Evento + "' salvo.", "Ambiente RPB");
                numDeEventosMarcados++;
            }
            else
                MessageBox.Show("Selecione um tipo de envento antes, Padrão descartado", "Ambiente RPB", MessageBoxButtons.OK);
        }
        //------------------------------------------------------------------------------------------
        private void editorDePadrõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditorDePadroes EditorForm = new FormEditorDePadroes();
            EditorForm.ShowDialog();
        }
        //------------------------------------------------------------------------------------------       
        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditorDeEventos EditorEvenForm = new FormEditorDeEventos();
            EditorEvenForm.ShowDialog();
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
                toolInfo.ForeColor = Color.Red;
                toolInfo.Text = ferramenta;
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
                chart1.ChartAreas[i].Position.X = 4;
                chart1.ChartAreas[i].Position.Y = Divisao * i; 
                chart1.ChartAreas[i].Position.Height = Divisao;
                chart1.ChartAreas[i].Position.Width = 96;
            }
            Adiciona_linhas_de_tempo();
            if (status_projeto == "Projeto_NOVO")
            {
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto, edfFileOutput, ScrollBar);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
                chart1.Enabled = true;
                //ThreadInicializada = true;
                FrequenciaCombo.Enabled = true;
                AmplitudeCombo.Enabled = true;
            }
            if (status_projeto == "Projeto_RPB")
            {
                //  this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto, edfFileOutput, ScrollBar);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
                //ThreadInicializada = true;
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
                //ThreadInicializada = true;
                chart1.Enabled = true;
                FrequenciaCombo.Enabled = true;
                AmplitudeCombo.Enabled = true;
            }
            
        }
        //------------------------------------------------------------------------------------------
        private void Adiciona_linhas_de_tempo()
        {
            //adicionar linhas eixo Y
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1  = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation2  = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation3  = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation4  = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation5  = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation6  = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation7  = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation8  = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation9  = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();

            lineAnnotation1.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation2.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation3.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation4.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation5.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation6.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation7.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation8.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation9.LineColor  = System.Drawing.Color.LightGray;

            lineAnnotation1.ToolTip  = "1";
            lineAnnotation2.ToolTip  = "1";
            lineAnnotation3.ToolTip  = "1";
            lineAnnotation4.ToolTip  = "1";
            lineAnnotation5.ToolTip  = "1";
            lineAnnotation6.ToolTip  = "1";
            lineAnnotation7.ToolTip  = "1";
            lineAnnotation8.ToolTip  = "1";
            lineAnnotation9.ToolTip  = "1";

            lineAnnotation1.X = 4;
            lineAnnotation2.X = 4 + 10.6 * 1;
            lineAnnotation3.X = 4 + 10.6 * 2;
            lineAnnotation4.X = 4 + 10.6 * 3;
            lineAnnotation5.X = 4 + 10.6 * 4;
            lineAnnotation6.X = 4 + 10.6 * 5;
            lineAnnotation7.X = 4 + 10.6 * 6;
            lineAnnotation8.X = 4 + 10.6 * 7;
            lineAnnotation9.X = 4 + 10.6 * 8;

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

            lineAnnotation1.Height  = 200;
            lineAnnotation2.Height  = 200;
            lineAnnotation3.Height  = 200;
            lineAnnotation4.Height  = 200;
            lineAnnotation5.Height  = 200;
            lineAnnotation6.Height  = 200;
            lineAnnotation7.Height  = 200;
            lineAnnotation8.Height  = 200;
            lineAnnotation9.Height  = 200;

            lineAnnotation1.Name = "LineAnnotation1";
            lineAnnotation2.Name = "LineAnnotation2";
            lineAnnotation3.Name = "LineAnnotation3";
            lineAnnotation4.Name = "LineAnnotation4";
            lineAnnotation5.Name = "LineAnnotation5";
            lineAnnotation6.Name = "LineAnnotation6";
            lineAnnotation7.Name = "LineAnnotation7";
            lineAnnotation8.Name = "LineAnnotation8";
            lineAnnotation9.Name = "LineAnnotation9";

            chart1.Annotations.Add(lineAnnotation1);
            chart1.Annotations.Add(lineAnnotation2);
            chart1.Annotations.Add(lineAnnotation3);
            chart1.Annotations.Add(lineAnnotation4);
            chart1.Annotations.Add(lineAnnotation5);
            chart1.Annotations.Add(lineAnnotation6);
            chart1.Annotations.Add(lineAnnotation7);
            chart1.Annotations.Add(lineAnnotation8);
            chart1.Annotations.Add(lineAnnotation9);
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
            progressBar.Enabled = false;
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
                    chart1.ChartAreas[i].AxisX.ScaleView.Size = Convert.ToDouble(FrequenciaCombo.Text)*1000;
            }
        }
        //------------------------------------------------------------------------------------------
        private void informaçõesEDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nome Paciente:\n"+edfFileOutput.Header.PatientIdentification
                +"\nData\n"+edfFileOutput.Header.StartDateEDF
                    + "\nHora\n" + edfFileOutput.Header.StartTimeEDF
                      + "\nDuração\n" + edfFileOutput.Header.DurationOfDataRecordInSeconds
                        + "\nNumberOfBytes\n" + edfFileOutput.Header.NumberOfBytes
                           + "\nNumberOfDataRecords\n" + edfFileOutput.Header.NumberOfDataRecords
                             + "\nNumberOfSignalsInDataRecord\n" + edfFileOutput.Header.NumberOfSignalsInDataRecord
                             + "\nVersion\n" + edfFileOutput.Header.Version


                ,"Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //------------------------------------------------------------------------------------------
        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* tool_ControlesProjeto.BackColor = Color.Black;
            chart1.BackColor = Color.Black;
            gbxChart.BackColor = Color.Black;
            gbxEventos.BackColor = Color.Black;
            FrequenciaCombo.BackColor = Color.Black;
            AmplitudeCombo.BackColor = Color.Black;
            menuStrip1.BackColor = Color.Black;
            FrequenciaCombo.ForeColor = Color.White;
            AmplitudeCombo.ForeColor = Color.White;
            lblFreq.ForeColor = Color.White;
            lblAmpli.ForeColor = Color.White;
            lbl_cm.ForeColor = Color.White;
            lbl_V.ForeColor = Color.White;
            Evento1.ForeColor = Color.White;
            Evento2.ForeColor = Color.White;
            Evento3.ForeColor = Color.White;
            Evento4.ForeColor = Color.White;
            Evento5.ForeColor = Color.White;
            Evento6.ForeColor = Color.White;
            Evento7.ForeColor = Color.White;
            Evento8.ForeColor = Color.White;
            Evento9.ForeColor = Color.White;
            Evento10.ForeColor = Color.White;*/
            if (sender.ToString() == "Preto - Vermelho")
            {
                Cor = Color.Red;
                CorFundo = Color.Black;
            }
            if (sender.ToString() == "Preto - Rosa")
            {
                Cor = Color.LightPink;
                CorFundo = Color.Black;
            }
            if (sender.ToString() == "Preto - Branco")
            {
                Cor = Color.White;
                CorFundo = Color.Black;
            }
            if (sender.ToString() == "Branco - Vermelho")
            {
                Cor = Color.Red;
                CorFundo = Color.White;
            }
            if (sender.ToString() == "Branco - Rosa")
            {
                Cor = Color.LightPink;
                CorFundo = Color.White;
            }
            if (sender.ToString() == "Branco - Preto")
            {
                Cor = Color.Black;
                CorFundo = Color.White;
            }
            for (int i = 0; i < __numeroDeCanais; i++)
            {
                chart1.ChartAreas[i].BackColor = CorFundo;
                chart1.Series[i].BackSecondaryColor = CorFundo;
                chart1.Series[i].BorderColor = CorFundo;
                chart1.Series[i].ShadowColor = CorFundo;
                chart1.Series[i].Color = Cor;
            }
        }
        //Teste!

        private void canal1Canal2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();
            for (int j = 0; j < chart1.Series[0].Points.Count; j++)
            {
                double Y__ = chart1.Series[0].Points[j].YValues[0] - chart1.Series[1].Points[j].YValues[0];
                chart1.Series[2].Points.AddXY(j,Y__);// = "" + chart.Series[i].Points[j];       
            }
            MessageBox.Show("Nome Pac");
        }
        //--------------------------------------------------------------------------
        private void fecharToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if( marcarEventos.Checked == true)
            {
                marcarEventos.Checked = false;

                gbxEventos.Visible = false;
                gbxEventos.Enabled = false;

                gbxChart.Location = new System.Drawing.Point(2, 21);
                gbxChart.Size = new System.Drawing.Size(this.Size.Width - 20, 379); 
            }
        }
        //-------------------------------------------------------------------------
        public void SetNenhumEventoMarcado()
        {
            Evento1.Checked = false;
            Evento2.Checked = false;
            Evento3.Checked = false;
            Evento4.Checked = false;
            Evento5.Checked = false;
            Evento6.Checked = false;
            Evento7.Checked = false;
            Evento8.Checked = false;
            Evento9.Checked = false;
            Evento10.Checked = false;
        }
      
        //-------------------------------------------------------------------------
        private void Evento1_Click(object sender, EventArgs e)
        {
            Evento = Evento1.Text;
            SetNenhumEventoMarcado();
            Evento1.Checked = true;
        }

        private void Evento2_Click(object sender, EventArgs e)
        {
            Evento = Evento2.Text;
            SetNenhumEventoMarcado();
            Evento2.Checked = true;
        }

        private void Evento3_Click(object sender, EventArgs e)
        {
            Evento = Evento3.Text;
            SetNenhumEventoMarcado();
            Evento3.Checked = true;
        }

        private void Evento4_Click(object sender, EventArgs e)
        {
            Evento = Evento4.Text;
            SetNenhumEventoMarcado();
            Evento4.Checked = true;
        }

        private void Evento5_Click(object sender, EventArgs e)
        {
            Evento = Evento5.Text;
            SetNenhumEventoMarcado();
            Evento5.Checked = true;
        }

        private void Evento6_Click(object sender, EventArgs e)
        {
            Evento = Evento6.Text;
            SetNenhumEventoMarcado();
            Evento6.Checked = true;
        }

        private void Evento7_Click(object sender, EventArgs e)
        {
            Evento = Evento7.Text;
            SetNenhumEventoMarcado();
            Evento7.Checked = true;
        }

        private void Evento8_Click(object sender, EventArgs e)
        {
            Evento = Evento8.Text;
            SetNenhumEventoMarcado();
            Evento8.Checked = true;
        }

        private void Evento9_Click(object sender, EventArgs e)
        {
            Evento = Evento9.Text;
            SetNenhumEventoMarcado();
            Evento9.Checked = true;
        }

        private void Evento10_Click(object sender, EventArgs e)
        {
            Evento = Evento10.Text;
            SetNenhumEventoMarcado();
            Evento10.Checked = true;
        }
        //------------------------------------------------------------------
        private void renomearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Evento != null)
            {
                FormEditarNomePadrao NomeEvento = new FormEditarNomePadrao();
                NomeEvento.ShowDialog();

                if (Evento1.Checked)
                    Evento1.Text = NomeEvento.NomePadrao;
                if (Evento2.Checked)
                    Evento2.Text = NomeEvento.NomePadrao;
                if (Evento3.Checked)
                    Evento3.Text = NomeEvento.NomePadrao;
                if (Evento4.Checked)
                    Evento4.Text = NomeEvento.NomePadrao;
                if (Evento5.Checked)
                    Evento5.Text = NomeEvento.NomePadrao;
                if (Evento6.Checked)
                    Evento6.Text = NomeEvento.NomePadrao;
                if (Evento7.Checked)
                    Evento7.Text = NomeEvento.NomePadrao;
                if (Evento8.Checked)
                    Evento8.Text = NomeEvento.NomePadrao;
                if (Evento9.Checked)
                    Evento9.Text = NomeEvento.NomePadrao;
                if (Evento10.Checked)
                    Evento10.Text = NomeEvento.NomePadrao;
                Evento = NomeEvento.NomePadrao;
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

        }

        private void btnEvento1_Click(object sender, EventArgs e)
        {
           
        }
        //-----------------------------------------------------------
       
    }
}