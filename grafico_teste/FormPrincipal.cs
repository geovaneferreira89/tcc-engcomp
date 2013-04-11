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
using NeuroLoopGainLibrary.Edf;


namespace AmbienteRPB
{
    public partial class FormPrincipal : Form
    {
        //Plotar sinais na tela------------------------------------------------------------
        private Thread ThreadChart;
        private int __numeroDeCanais = 23;
        private int DataRecords_lidos = 10;
        //---------------------------------------------------------------------------------
        private int numCursor = 0;
        private int mostrarCursores = 0;
        private float x_Pos, y_Pos;
        private String nomeProject = "Sem nome";
        private string status_projeto = "Projeto_NOVO";
        private EdfFile edfFileOutput = null;
        private HitTestResult var_result;
        private bool MostrarCursorX;
        //Geren Arquivos-----------------------------------------------------------------
        private GerenArquivos Arquivos;
        //Marção de Padrões e seus Eventos-----------------------------------------------
        private int EventoAtual;
        private ListaPadroesEventos[] ListaPadroes;
        String Evento;
        Color highlightColor;
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
            //SALVAR
            if(ListaPadroes != null)
            {
               DialogResult resposta = MessageBox.Show("Deseja salvar a lista de pradrões e eventos?", "Ambiente RPB", MessageBoxButtons.YesNo);
               if (resposta == DialogResult.Yes)
               {
                   Arquivos.Exportar_Padroes_Eventos(ListaPadroes);
                   MessageBox.Show("Salvo com sucesso!", "Ambiente RPB");
               }
            }
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
                    __numeroDeCanais = edfFileOutput.SignalInfo.Count;
                    ChartInicializarThreads(__numeroDeCanais);
                    btn_novoProjeto.Enabled = false;
                    btn_Importar.Enabled = false;
                    btn_novoProjeto.Enabled = false;
                    infoEDF.Enabled = true;
                    marcarEventos.Enabled = true;
                    btn_Importar.Enabled = false;
                    btnTemas.Enabled = true;
                    CarregaNomesPadroes(20);
                    if (Arquivos.ArquivoExiste("Padroes_Eventos.txt") == true)
                      ListaPadroes = Arquivos.Importar_Exportar_Padroes_Eventos(); 
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
        //-----------------------------------------------------------------------------------------
        public void CarregaNomesPadroes(int Total)
        {
            string str;
            ListaPadroes = new ListaPadroesEventos[Total];
            for (int i = 0; i < Total; i++)
            {
                str = "Evento" + (i + 1);
                ListaPadroes[i] = new ListaPadroesEventos();
                ListaPadroes[i].CriarLista(20, this.Controls.Find(str, true)[0].Text);
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
            MessageBox.Show("Projeto " + nomeProject + "\nCriado",
                    "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            status_projeto = "Projeto_NOVO";
            ChartInicializarThreads(__numeroDeCanais);
            btn_novoProjeto.Enabled = false;
        }
        //------------------------------------------------------------------------------------------
        //Supende o sistema
        private void btn_Suspender_Click(object sender, EventArgs e)
        {
       
        }
        //------------------------------------------------------------------------------------------
        //Retorna o sistema
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
                Arquivos.Exportar_Padroes_Eventos(ListaPadroes);
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
                            if (result.ChartArea != null)
                                cont = false;
                            if (i == 10)
                                cont = false;
                            i++;
                        }
                        AtualizaFerramentaAtiva("Result null", 2);
                        if (result.ChartArea != null)
                            ExecutaSelecao(result, e);
                        else
                            AtualizaFerramentaAtiva("RESULT NULL 2 - Marque novamente", 2);
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
                result.ChartArea.CursorX.SelectionColor = highlightColor;
                result.ChartArea.CursorX.SetCursorPixelPosition(new PointF(0, 0), false);

                x_Pos = (e.X);
                y_Pos = (e.Y);
                //linha fixa
                VerticalLineAnnotation cursor_vertical = new VerticalLineAnnotation();
                cursor_vertical.AnchorDataPoint = chart1.Series[result.ChartArea.Name].Points[1];
                cursor_vertical.Height = result.ChartArea.Position.Height;
                cursor_vertical.LineColor = highlightColor;
                cursor_vertical.LineWidth = 1;
                cursor_vertical.AnchorX = result.ChartArea.AxisX.PixelPositionToValue(e.X);
                cursor_vertical.AnchorY = result.ChartArea.AxisY.Maximum;
                chart1.Annotations.Add(cursor_vertical);
                numCursor++;
            }
            else if (numCursor == 1 && (result.ChartArea == var_result.ChartArea))
            {
                result.ChartArea.CursorX.AxisType = AxisType.Secondary;
                result.ChartArea.CursorX.LineColor = highlightColor;
                result.ChartArea.CursorX.LineWidth = 1;
                result.ChartArea.CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
                // Set range selection color, specifying transparency of 120
                result.ChartArea.CursorX.SelectionColor = highlightColor;
                result.ChartArea.CursorX.IsUserEnabled = true;
                result.ChartArea.CursorX.IsUserSelectionEnabled = true;
                PointF Padrao_Inicio = new PointF(x_Pos, y_Pos);
                PointF Padrao_Fim = new PointF(e.X, e.Y);
                
                result.ChartArea.CursorX.SetSelectionPixelPosition(Padrao_Inicio, Padrao_Fim, true);
                Padrao_Inicio.X = (float)result.ChartArea.AxisX.PixelPositionToValue(x_Pos);
                Padrao_Fim.X = (float)result.ChartArea.AxisX.PixelPositionToValue(e.X);

               /* RectangleAnnotation highlight = new RectangleAnnotation();
                highlight.AnchorDataPoint = chart1.Series[result.ChartArea.Name].Points[1];
                highlight.LineColor = highlightColor;
                highlight.BackColor = highlightColor;
                highlight.X = result.ChartArea.AxisX.PixelPositionToValue(x_Pos);
                highlight.Y = result.ChartArea.AxisY.Maximum;

                highlight.Width = (result.ChartArea.AxisX.PixelPositionToValue(e.X) - result.ChartArea.AxisX.PixelPositionToValue(x_Pos)) / (Convert.ToInt16(FrequenciaCombo.Text) * 10);
                highlight.Height = result.ChartArea.Position.Height;
                highlight.Visible = true;
                chart1.Annotations.Add(highlight);*/

                Exportar_Padrao_Na_Lista(Padrao_Inicio, Padrao_Fim, result);
                numCursor = 0;//CLICAR + VEZES SEM EFEITO
                //result.ChartArea.CursorX.SetSelectionPixelPosition(new PointF(0, 0), new PointF(0, 0), true);
                result.ChartArea.CursorX.LineColor = Color.LightGray;
                result.ChartArea.CursorX.SetCursorPixelPosition(new PointF(0, 0), true);
                result.ChartArea.CursorX.IsUserEnabled = false;
                result.ChartArea.CursorX.IsUserSelectionEnabled = false;

                chart1.Annotations.Clear();
                Adiciona_linhas_de_tempo();
            }
        }
        //------------------------------------------------------------------------------------------
        private void Exportar_Padrao_Na_Lista(PointF Padrao_Inicio, PointF Padrao_Fim, HitTestResult Canal)
        {
            if (Evento != null)
            {
                for (int i = 0; i <= 20; i++)
                {
                    if (ListaPadroes[i].NomePadrao == Evento)
                    {
                        ListaPadroes[i].SetValorInicio(ListaPadroes[i].GetNumeroEventos(),Padrao_Inicio);
                        ListaPadroes[i].SetValorFim(ListaPadroes[i].GetNumeroEventos(), Padrao_Fim);
                        string dados = Canal.ChartArea.Name;
                        dados = dados.Substring(5);
                        dados = dados.Substring(0, dados.Length);
                        ListaPadroes[i].SetNomesEvento(ListaPadroes[i].GetNumeroEventos(), Evento + "-" + ListaPadroes[i].GetNumeroEventos() + "_" + chart1.Titles[Convert.ToInt16(dados)].Text);
                        ListaPadroes[i].SetNumeroEventos(ListaPadroes[i].GetNumeroEventos() + 1); 
                        i = 100; //Sai do loop
                    }
                }
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
            FormEditorDeEventos EditorEvenForm = new FormEditorDeEventos(ListaPadroes);
            EditorEvenForm.ShowDialog();
        }
        //-----------------------------------------------------------------------------------------
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //adiciona novo check box...(Fazer)
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
                //Propriedades de cada sinal
                chart1.ChartAreas.Add("canal" + i);
                chart1.ChartAreas[i].BackColor = Color.Transparent;
                chart1.ChartAreas[i].AxisX.Enabled = AxisEnabled.False;
                chart1.ChartAreas[i].AxisY.Enabled = AxisEnabled.False;
                chart1.ChartAreas[i].Position.Height = Divisao+10;
                chart1.ChartAreas[i].Position.Width = 96;
                chart1.ChartAreas[i].Position.X = 4;
                chart1.ChartAreas[i].Position.Y = Divisao * i;

            }            
            AdicionaData(0);
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
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation10 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();

            lineAnnotation1.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation2.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation3.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation4.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation5.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation6.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation7.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation8.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation9.LineColor  = System.Drawing.Color.LightGray;
            lineAnnotation10.LineColor = System.Drawing.Color.LightGray;

            lineAnnotation1.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation2.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation3.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation4.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation5.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation6.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation7.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation8.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation9.LineDashStyle = ChartDashStyle.Dash;
            lineAnnotation10.LineDashStyle = ChartDashStyle.Dash;

            lineAnnotation1.ToolTip  = "1";
            lineAnnotation2.ToolTip  = "1";
            lineAnnotation3.ToolTip  = "1";
            lineAnnotation4.ToolTip  = "1";
            lineAnnotation5.ToolTip  = "1";
            lineAnnotation6.ToolTip  = "1";
            lineAnnotation7.ToolTip  = "1";
            lineAnnotation8.ToolTip  = "1";
            lineAnnotation9.ToolTip  = "1";
            lineAnnotation10.ToolTip = "1";

            lineAnnotation1.X = 4;
            lineAnnotation2.X = 4 + 9.6 * 1;
            lineAnnotation3.X = 4 + 9.6 * 2;
            lineAnnotation4.X = 4 + 9.6 * 3;
            lineAnnotation5.X = 4 + 9.6 * 4;
            lineAnnotation6.X = 4 + 9.6 * 5;
            lineAnnotation7.X = 4 + 9.6 * 6;
            lineAnnotation8.X = 4 + 9.6 * 7;
            lineAnnotation9.X = 4 + 9.6 * 8;
            lineAnnotation10.X = 4 + 9.6 * 9;

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

            lineAnnotation1.Height  = 200;
            lineAnnotation2.Height  = 200;
            lineAnnotation3.Height  = 200;
            lineAnnotation4.Height  = 200;
            lineAnnotation5.Height  = 200;
            lineAnnotation6.Height  = 200;
            lineAnnotation7.Height  = 200;
            lineAnnotation8.Height  = 200;
            lineAnnotation9.Height  = 200;
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
        }
        //------------------------------------------------------------------------------------------
        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
        //------------------------------------------------------------------------------------------
        //                              FUNCÕES DA SCROLL BAR
        //------------------------------------------------------------------------------------------
        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {   
            //Atualizar o tempo
            if (e.Type == ScrollEventType.SmallIncrement)
            {
                //"Apaga" 10s Primeiro de sinal, 256 em x
                AdicionaData(e.NewValue * 10);
                Add10sInChart();
            }
            else if (e.Type == ScrollEventType.SmallDecrement)
            {
                AdicionaData(e.NewValue * 10);
            }
            //Atualizar o chart
            for (int i = 0; i < __numeroDeCanais; i++)
            {
                chart1.ChartAreas[i].AxisX.ScaleView.Position = e.NewValue * 256;
            }
         
        }
        //------------------------------------------------------------------------------------------
        private void Add10sInChart()
        {
            if(DataRecords_lidos <= edfFileOutput.FileInfo.NrDataRecords)
            {
                int tempo = DataRecords_lidos * 256;
                DataRecords_lidos++;
                edfFileOutput.ReadDataBlock(DataRecords_lidos);
                for (int j = 0; j < edfFileOutput.SignalInfo.Count; j++)
                    for (int i = 0; i < 256; i++)
                        chart1.Series["canal" + j].Points.AddXY(i + tempo, edfFileOutput.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i]);
            }
        }
        //------------------------------------------------------------------------------------------
        // Função reposalvel por atualizar o tempo atual na tela
        // Caso = 0 -> Incrementa tempo, Caso == 1 -> Decrementa o tempos
        private void AdicionaData(int aux)
        {
            int _min = 0;
            int _seg = 0;
            int _hora = 0;
            _seg = aux;
            if (_seg >= 60)
            {
                _min = _seg / 60;
                _seg = _seg - _min * 60;
                if (_min >= 60)
                {
                    _hora = _min / 60;
                    _min = _min - _hora * 60;
                }
            }
            DateTime dt_chart = new DateTime(2013, 4, 11, _hora, _min, _seg);
            _seg = edfFileOutput.FileInfo.StartTime.Value.Seconds + aux;
            _min = edfFileOutput.FileInfo.StartTime.Value.Minutes;
            _hora = edfFileOutput.FileInfo.StartTime.Value.Hours;
            if (_seg >= 60)
            {
                aux =  _seg / 60;
                _seg = _seg - aux * 60;
                _min = aux + edfFileOutput.FileInfo.StartTime.Value.Minutes;
                if (_min >= 60)
                {
                    aux = _min/60;
                    _hora = aux + edfFileOutput.FileInfo.StartTime.Value.Hours;
                    _min = _min - aux * 60;
                }
            }
            DateTime dt_EEG = new DateTime(2013, 4, 11, _hora, _min, _seg);

            string tempo = dt_EEG.ToString("H:mm:ss") + " (" + dt_chart.ToString("H:mm:ss") + ")";
            lbl_Tempo.Text = tempo;   
        }
        //------------------------------------------------------------------------------------------
        //Auto sets
        private void autoFreqToolStripMenuItem_Click(object sender, EventArgs e)
        {
                chart1.ChartAreas[0].AxisY.Maximum = 250;
                for (int i = 0; i < __numeroDeCanais; i++)
                {
      
                    chart1.ChartAreas[i].Position.Y = 100 / __numeroDeCanais * i;
                }
            
        }
        //------------------------------------------------------------------------------------------
        //Somente Numeros
        private void AmplitudeCombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
                e.Handled = true;
        }
        //------------------------------------------------------------------------------------------
        private void AmplitudeCombo_TextChanged(object sender, EventArgs e)
        {        
            if (AmplitudeCombo.Text != "")
            {
               //chart1.ChartAreas[0].AxisY.Maximum = 250;
               for (int i = 0; i < __numeroDeCanais; i++){
                     chart1.ChartAreas[i].AxisY.ScaleView.Size = Convert.ToDouble(AmplitudeCombo.Text);
               }
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
            MessageBox.Show("Nome Paciente:\n"+edfFileOutput.FileInfo.PatientName
                + "\nData\n" + edfFileOutput.FileInfo.DataExists
                    + "\nHora\n" + edfFileOutput.FileInfo.StartDate
                      + "\nDuração\n" + edfFileOutput.FileInfo.NrDataRecords
                             + "\nVersion\n" + edfFileOutput.FileInfo.Version


                ,"Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //------------------------------------------------------------------------------------------
        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        //--------------------------------------------------------------------------
        private void canal1Canal2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();
            for (int j = 0; j < chart1.Series[0].Points.Count; j++)
            {
                double Y__ = chart1.Series[0].Points[j].YValues[0] - chart1.Series[1].Points[j].YValues[0];
                chart1.Series[2].Points.AddXY(j,Y__);
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
            Evento11.Checked = false;
            Evento12.Checked = false;
            Evento13.Checked = false;
            Evento14.Checked = false;
            Evento15.Checked = false;
            Evento16.Checked = false;
            Evento17.Checked = false;
            Evento18.Checked = false;
            Evento19.Checked = false;
            Evento20.Checked = false;
        }
        //-------------------------------------------------------------------------
        //                          EVENTOS CLICADOS 
        //--------------------------------------------------------------------------
        private void Evento1_Click(object sender, EventArgs e)
        {
            Evento = Evento1.Text;
            SetNenhumEventoMarcado();
            Evento1.Checked = true;
            EventoAtual = 0;
            highlightColor = Color.Lime;
        }
        //--------------------------------------------------------------------------
        private void Evento2_Click(object sender, EventArgs e)
        {
            Evento = Evento2.Text;
            SetNenhumEventoMarcado();
            Evento2.Checked = true;
            EventoAtual = 1;
            highlightColor = Color.Yellow;
        }
        //--------------------------------------------------------------------------
        private void Evento3_Click(object sender, EventArgs e)
        {
            Evento = Evento3.Text;
            SetNenhumEventoMarcado();
            Evento3.Checked = true;
            EventoAtual = 2;
            highlightColor = Color.Red;
        }
        //--------------------------------------------------------------------------
        private void Evento4_Click(object sender, EventArgs e)
        {
            Evento = Evento4.Text;
            SetNenhumEventoMarcado();
            Evento4.Checked = true;
            EventoAtual = 3;
            highlightColor = Color.Orange;
        }
        //--------------------------------------------------------------------------
        private void Evento5_Click(object sender, EventArgs e)
        {
            Evento = Evento5.Text;
            SetNenhumEventoMarcado();
            Evento5.Checked = true;
            EventoAtual = 4;
            highlightColor = Color.RoyalBlue;
        }
        //--------------------------------------------------------------------------
        private void Evento6_Click(object sender, EventArgs e)
        {
            Evento = Evento6.Text;
            SetNenhumEventoMarcado();
            Evento6.Checked = true;
            EventoAtual = 5;
            highlightColor = Color.HotPink;
        }
        //--------------------------------------------------------------------------
        private void Evento7_Click(object sender, EventArgs e)
        {
            Evento = Evento7.Text;
            SetNenhumEventoMarcado();
            Evento7.Checked = true;
            EventoAtual = 6;
            highlightColor = Color.Aqua;
        }
        //--------------------------------------------------------------------------
        private void Evento8_Click(object sender, EventArgs e)
        {
            Evento = Evento8.Text;
            SetNenhumEventoMarcado();
            Evento8.Checked = true;
            EventoAtual = 7;
            highlightColor = Color.Gold;
        }
        //--------------------------------------------------------------------------
        private void Evento9_Click(object sender, EventArgs e)
        {
            Evento = Evento9.Text;
            SetNenhumEventoMarcado();
            Evento9.Checked = true;
            EventoAtual = 8;
            highlightColor = Color.Orchid;
        }
        //--------------------------------------------------------------------------
        private void Evento10_Click(object sender, EventArgs e)
        {
            Evento = Evento10.Text;
            SetNenhumEventoMarcado();
            Evento10.Checked = true;
            EventoAtual = 9;
            highlightColor = Color.Salmon;
        }
        //--------------------------------------------------------------------------
        private void Enveto11_Click(object sender, EventArgs e)
        {
            Evento = Evento11.Text;
            SetNenhumEventoMarcado();
            Evento11.Checked = true;
            EventoAtual = 10;
            highlightColor = Color.PeachPuff;
        }
        //--------------------------------------------------------------------------
        private void Enveto12_Click(object sender, EventArgs e)
        {
            Evento = Evento12.Text;
            SetNenhumEventoMarcado();
            Evento12.Checked = true;
            EventoAtual = 11;
            highlightColor = Color.SkyBlue;
        }
        //--------------------------------------------------------------------------
        private void Enveto13_Click(object sender, EventArgs e)
        {
            Evento = Evento13.Text;
            SetNenhumEventoMarcado();
            Evento13.Checked = true;
            EventoAtual = 12;
            highlightColor = Color.Plum;
        }
        //--------------------------------------------------------------------------
        private void Enveto14_Click(object sender, EventArgs e)
        {
            Evento = Evento14.Text;
            SetNenhumEventoMarcado();
            Evento14.Checked = true;
            EventoAtual = 13;
            highlightColor = Color.MediumSlateBlue;
        }
        //--------------------------------------------------------------------------
        private void Enveto15_Click(object sender, EventArgs e)
        {
            Evento = Evento15.Text;
            SetNenhumEventoMarcado();
            Evento15.Checked = true;
            EventoAtual = 14;
            highlightColor = Color.LightGray;
        }
        //--------------------------------------------------------------------------
        private void Enveto16_Click(object sender, EventArgs e)
        {
            Evento = Evento16.Text;
            SetNenhumEventoMarcado();
            Evento16.Checked = true;
            EventoAtual = 15;
            highlightColor = Color.Brown;
        }
        //--------------------------------------------------------------------------
        private void Enveto17_Click(object sender, EventArgs e)
        {
            Evento = Evento17.Text;
            SetNenhumEventoMarcado();
            Evento17.Checked = true;
            EventoAtual = 16;
            highlightColor = Color.Khaki;
        }
        //--------------------------------------------------------------------------
        private void Enveto18_Click(object sender, EventArgs e)
        {
            Evento = Evento18.Text;
            SetNenhumEventoMarcado();
            Evento18.Checked = true;
            EventoAtual = 17;
            highlightColor = Color.DarkGoldenrod;
        }
        //--------------------------------------------------------------------------
        private void Enveto19_Click(object sender, EventArgs e)
        {
            Evento = Evento19.Text;
            SetNenhumEventoMarcado();
            Evento19.Checked = true;
            EventoAtual = 18;
            highlightColor = Color.YellowGreen;
        }
        //--------------------------------------------------------------------------
        private void Enveto20_Click(object sender, EventArgs e)
        {
             Evento = Evento20.Text;
            SetNenhumEventoMarcado();
            Evento20.Checked = true;
            EventoAtual = 19;
            highlightColor = Color.LightCoral;
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
                if (Evento11.Checked)
                    Evento11.Text = NomeEvento.NomePadrao;
                if (Evento12.Checked)
                    Evento12.Text = NomeEvento.NomePadrao;
                if (Evento13.Checked)
                    Evento13.Text = NomeEvento.NomePadrao;
                if (Evento14.Checked)
                    Evento14.Text = NomeEvento.NomePadrao;
                if (Evento15.Checked)
                    Evento15.Text = NomeEvento.NomePadrao;
                if (Evento16.Checked)
                    Evento16.Text = NomeEvento.NomePadrao;
                if (Evento17.Checked)
                    Evento17.Text = NomeEvento.NomePadrao;
                if (Evento18.Checked)
                    Evento18.Text = NomeEvento.NomePadrao;
                if (Evento19.Checked)
                    Evento19.Text = NomeEvento.NomePadrao;
                if (Evento20.Checked)
                    Evento20.Text = NomeEvento.NomePadrao;
                Evento = NomeEvento.NomePadrao;
            }
        }
        //--------------------------------------------------------------------------
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

        }
        //--------------------------------------------------------------------------
        private void btnEvento1_Click(object sender, EventArgs e)
        {
           
        }

        //-----------------------------------------------------------
       
    }
}
