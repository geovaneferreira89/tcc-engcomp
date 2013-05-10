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
        //Plotar sinais na tela----------------------------------------------------------
        private Thread ThreadChart;
        private int __numeroDeCanais = 23;
        private int DataRecords_lidos = 10;
        private int Scroll_Click_Escala_Seg = 10;
        //-------------------------------------------------------------------------------
        private int numCursor = 0;
        private int mostrarCursores = 0;
        private double x_Pos, y_Pos;
        private String nomeProject = "Sem nome";
        private string status_projeto = "Projeto_NOVO";
        private EdfFile edfFileOutput = null;
        private HitTestResult var_result;
        //Geren Arquivos-----------------------------------------------------------------
        private GerenArquivos Arquivos;
        //Marção de Padrões e seus Eventos-----------------------------------------------
        private ListaPadroesEventos[] ListaPadroes;
        String Evento;
        Color highlightColor;
        ToolTip tooltip = new ToolTip();
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
          //------------------------------------------------------------------------------------------
        private void FormPrincipal_Load(object sender, EventArgs e)
        {

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
               DialogResult resposta = MessageBox.Show("Deseja salvar a lista de pradrões e eventos?", "Reconhecimento de Padrões EEG", MessageBoxButtons.YesNo);
               if (resposta == DialogResult.Yes)
               {
                   Arquivos.Exportar_Padroes_Eventos(ListaPadroes);
                   MessageBox.Show("Salvo com sucesso!", "Reconhecimento de Padrões EEG");
               }
            }
        }
        //------------------------------------------------------------------------------------------
        // Ferramenta de importar sinais EEG de arquivo .EDF
        private void btn_Importar_Click(object sender, EventArgs e)
        {
            openFileEDF.InitialDirectory = Arquivos.getPathUser();
            if (openFileEDF.ShowDialog() == DialogResult.OK)
            {
                nomeProject = openFileEDF.FileName;
                edfFileOutput = Arquivos.Abrir_Projeto_EDF(nomeProject, false);//desabilitado a escolha dos canais
                if (edfFileOutput != null)
                {
                    status_projeto = "Projeto_EDF";
                    AtualizaFerramentaAtiva("Abrir arquivo .EDF", 1, Color.Green);
                    __numeroDeCanais = edfFileOutput.SignalInfo.Count;
                    ChartInicializarThreads(__numeroDeCanais);
                    btn_novoProjeto.Enabled = false;
                    btn_Importar.Enabled = false;
                    btn_novoProjeto.Enabled = false;
                    infoEDF.Enabled = true;
                    marcarEventos.Enabled = true;
                    btn_Importar.Enabled = false;
                    CarregaNomesPadroes(20);
                    string aux_path = Arquivos.getPathUser();
                        aux_path += "Padroes_Eventos.txt";
                    if (Arquivos.ArquivoExiste(aux_path) == true)
                      ListaPadroes = Arquivos.Importar_Exportar_Padroes_Eventos(); 
                }
                else
                    AtualizaFerramentaAtiva("Nenhum sinal selecionado!", 2, Color.Red);
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
                AtualizaFerramentaAtiva("Abrir projeto não implentado!", 2, Color.Red); 
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
            if (mostrarCursores != 0)
            {//Marcar um evento
                MarcarSelecao(e);
            }
            else
            {//Mudar a cor do canal
                MudarCorChart(e);
            }
        }
        //-----------------------------------------------------------------------------------------
        //Check box responsavel por Mostra o cursor no eixo X dos gráficos
        private void MudarCorChart(MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y, true);
            if (result.Series != null)
            {
                if(colorDialog1.ShowDialog() == DialogResult.OK){
                    result.Series.Color = colorDialog1.Color;
                }
            }
        }
        //------------------------------------------------------------------------------------------
        // Mostra o cursor no eixo X dos gráficos
        private void mouse_Mover(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if (result.ChartArea != null)
            {
                double pointXPixel = result.ChartArea.AxisX.PixelPositionToValue(e.X);
                double pointYPixel = result.ChartArea.AxisY.PixelPositionToValue(e.Y);
                lbl_x.Text = "Valor X: " +  pointXPixel.ToString("f4");
                lbl_Y.Text = "Valor Y: " + pointYPixel.ToString("f4");
            }
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
                AtualizaFerramentaAtiva("", 0,Color.Gray);
                mostrarCursores = 1;
                AtualizaFerramentaAtiva("Marcar Eventos", 1, Color.Green);
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
                AtualizaFerramentaAtiva("", 0,Color.Green);
                Arquivos.Exportar_Padroes_Eventos(ListaPadroes);
            }
        }
        //------------------------------------------------------------------------------------------
        //Define uma seleção afim de ser um padrão. 
        private void MarcarSelecao(MouseEventArgs e)
        {
            string sms;
            if (numCursor == 0)
                sms = "Inicio";
            else
                sms = "Fim";
                HitTestResult result = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
                    if (result.Series != null)
                    {
                        AtualizaFerramentaAtiva(sms + " marcado.", 2, Color.Green);
                        ExecutaSelecao(result, e, 0);
                    }
                    else
                    {
                        //Caso não encontrado nenhum resultado para onde foi clicado, o sofware 
                        //faz uma varredura de no maximo elemtos acima, evita transtornos... 
                        bool cont = true;
                        int i = 1;
                        while(cont)
                        {
                            result = chart1.HitTest(e.X + i, e.Y, ChartElementType.DataPoint);
                            if (result.Series != null)
                                cont = false;
                            if (i == 10)
                                cont = false;
                            if(cont)
                                i++;
                        }
                        AtualizaFerramentaAtiva(sms + " marcado. - Forçado", 2, Color.Orange);
                        if (result.Series != null)
                        {
                            ExecutaSelecao(result, e, i);
                        }
                        else
                            AtualizaFerramentaAtiva("Marque novamente (clique proximo ao sinal) - ERRO", 2, Color.Red);
                    }
        }
        //------------------------------------------------------------------------------------------
        private void ExecutaSelecao(HitTestResult result, MouseEventArgs e, int offsetX)
        {
            if (numCursor == 0)
            {
                var_result = result;
                chart1.Annotations.Clear();
                Adiciona_linhas_de_tempo();
                result.ChartArea.CursorX.SelectionColor = highlightColor;
                result.ChartArea.CursorX.SetCursorPixelPosition(new PointF(0, 0), false);

                x_Pos = (e.X + offsetX);
                y_Pos = (e.Y);
                //linha fixa
                VerticalLineAnnotation cursor_vertical = new VerticalLineAnnotation();
                cursor_vertical.AnchorDataPoint = chart1.Series[result.ChartArea.Name].Points[1];
                cursor_vertical.Height = result.ChartArea.Position.Height;
                cursor_vertical.LineColor = highlightColor;
                cursor_vertical.LineWidth = 1;
                cursor_vertical.AnchorX = result.ChartArea.AxisX.PixelPositionToValue(e.X + offsetX);
                cursor_vertical.AnchorY = result.ChartArea.AxisY.Maximum;
                chart1.Annotations.Add(cursor_vertical);
                numCursor++;
                AtualizaFerramentaAtiva("Inicio de envento marcado", 2, Color.Green);
            }
            else if (numCursor == 1 && (result.ChartArea == var_result.ChartArea))
            {
                result.ChartArea.CursorX.AxisType = AxisType.Secondary;
                result.ChartArea.CursorX.LineColor = highlightColor;
                result.ChartArea.CursorX.LineWidth = 1;
                result.ChartArea.CursorX.SetCursorPixelPosition(new PointF(e.X + offsetX, e.Y), true);
                // Set range selection color, specifying transparency of 120
                result.ChartArea.CursorX.SelectionColor = highlightColor;
                result.ChartArea.CursorX.IsUserEnabled = true;
                result.ChartArea.CursorX.IsUserSelectionEnabled = true;
                
                PointF Padrao_Inicio = new PointF((float)x_Pos, (float)y_Pos);
                PointF Padrao_Fim = new PointF((e.X + offsetX), e.Y);
                //Colore a região do evento
                result.ChartArea.CursorX.SetSelectionPixelPosition(Padrao_Inicio, Padrao_Fim, true);
                Padrao_Inicio.X = (float)result.ChartArea.AxisX.PixelPositionToValue(x_Pos);
                Padrao_Fim.X = (float)result.ChartArea.AxisX.PixelPositionToValue(e.X+offsetX);
                AtualizaFerramentaAtiva("Fim de envento marcado", 2,Color.Green);
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
                Padrao_Inicio = new PointF((float)result.ChartArea.AxisX.PixelPositionToValue(x_Pos), (float)result.ChartArea.AxisY.PixelPositionToValue(y_Pos));
                Padrao_Fim = new PointF((float)result.ChartArea.AxisX.PixelPositionToValue(e.X + offsetX), (float)result.ChartArea.AxisY.PixelPositionToValue(e.Y));
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
                MessageBox.Show("Selecione um tipo de envento antes, Padrão descartado", "Reconhecimento de Padrões EEG", MessageBoxButtons.OK);
        }
        //------------------------------------------------------------------------------------------       
        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListaPadroes == null)
            {
                string aux_path = Arquivos.getPathUser();
                aux_path += "Padroes_Eventos.txt";
                if (Arquivos.ArquivoExiste(aux_path) == true)
                {
                    ListaPadroes = Arquivos.Importar_Exportar_Padroes_Eventos();
                    CarregarEditorDeEventos();
                }
                else
                    MessageBox.Show("Nenhum evento marcado ainda", "Reconhecimento de Padrões EEG", MessageBoxButtons.OK);
            }
            else
                  CarregarEditorDeEventos();
        }
        //------------------------------------------------------------------------------------------       
        private void CarregarEditorDeEventos()
        {
            if (chart1.Series.Count != 0)
            {
                FormEditorDeEventos EditorEvenForm = new FormEditorDeEventos(ListaPadroes, nomeProject);
                EditorEvenForm.ShowDialog();
            }
            else
                MessageBox.Show("Nenhum EDF carregado", "Reconhecimento de Padrões EEG", MessageBoxButtons.OK);
        }
        //-----------------------------------------------------------------------------------------
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //adiciona novo check box...(Fazer)
        }
        //------------------------------------------------------------------------------------------
        //                              ->   Ferramenta ativa <-
        //------------------------------------------------------------------------------------------
        private void AtualizaFerramentaAtiva(string ferramenta, int opcao, Color CorDeInfo)
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
                toolInfo.ForeColor = CorDeInfo;
                toolInfo.Text = ferramenta;
            }

        }
        //------------------------------------------------------------------------------------------
        //           -> Inicializa Thread responsalvel pela aquisição do sinal. <-
        //------------------------------------------------------------------------------------------
        private void ChartInicializarThreads(int numeroDeCanais)
        {
            double Divisao = 100 / (double)numeroDeCanais;
            float _aux;
            _aux = (float)Divisao;
            for (int i = 0; i < numeroDeCanais; i++)
            {   //Propriedades de cada sinal
                chart1.ChartAreas.Add("canal" + i);
                chart1.ChartAreas[i].BackColor = Color.Transparent;
                chart1.ChartAreas[i].AxisX.Enabled = AxisEnabled.False;
                chart1.ChartAreas[i].AxisY.Enabled = AxisEnabled.False;
                chart1.ChartAreas[i].Position.Height = _aux+5;//+10 os sinais sobreescrevem
                chart1.ChartAreas[i].Position.Width = 96;
                chart1.ChartAreas[i].Position.X = 4;
                chart1.ChartAreas[i].Position.Y = _aux * i;
            }
            AdicionaData(0);
            Adiciona_linhas_de_tempo();
            if (status_projeto == "Projeto_EDF")
            {
                atualiza_sinal objCliente = new atualiza_sinal(chart1, numeroDeCanais, progressBar, tool_ControlesProjeto, Box_Status, status_projeto, edfFileOutput, ScrollBar);
                ThreadChart = new Thread(new ThreadStart(objCliente.Inicializa));
                ThreadChart.Start();
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
        //                              FUNCÕES DA SCROLL BAR
        //------------------------------------------------------------------------------------------
        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {   
            //Atualizar o tempo
            if (e.Type == ScrollEventType.SmallIncrement)
            {
                //"Apaga" 1s Primeiro de sinal, 256 em x
                AdicionaData(e.NewValue + Scroll_Click_Escala_Seg);
                AddSegInChart();
            }
            else if (e.Type == ScrollEventType.SmallDecrement)
            {
                AdicionaData(e.NewValue + Scroll_Click_Escala_Seg);
            }
            //Atualizar o chart
            for (int i = 0; i < __numeroDeCanais; i++)
            {
                chart1.ChartAreas[i].AxisX.ScaleView.Position = e.NewValue * 256; //* Scroll_Click_Escala_Seg;
            }
         
        }
        //-----------------------------------------------------------------------------------------
        //Mudar a escala de visualização de telas por clicque
        private void segundoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_tempo_s.Text = sender.ToString();
            if (sender.ToString() == "1 s")
            {
                Scroll_Click_Escala_Seg = 1;
                ScrollBar.SmallChange = 1;//segundos
                ScrollBar.LargeChange = 1;//segundos
            }
            if (sender.ToString() == "5 s")
            {
                Scroll_Click_Escala_Seg = 5;
                ScrollBar.SmallChange = 5;//segundos
                ScrollBar.LargeChange = 5;//segundos
            }
            if (sender.ToString() == "10 s")
            {
                Scroll_Click_Escala_Seg = 10;
                ScrollBar.SmallChange = 10;//segundos
                ScrollBar.LargeChange = 10;//segundos
            }

        }
        //------------------------------------------------------------------------------------------
        private void AddSegInChart()
        {
            for(int k=0; k < Scroll_Click_Escala_Seg; k++){
                if(DataRecords_lidos <= edfFileOutput.FileInfo.NrDataRecords)
                {
                    int tempo = DataRecords_lidos * 256;
                    DataRecords_lidos++;
                    edfFileOutput.ReadDataBlock(DataRecords_lidos);
                    //Cada ao fim deste for, é adiciocionado somente 1s em todos os canais
                    for (int j = 0; j < edfFileOutput.SignalInfo.Count; j++)
                        for (int i = 0; i < 256; i++)
                            chart1.Series["canal" + j].Points.AddY(edfFileOutput.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i]);
                }
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
                    chart1.ChartAreas[i].Position.Y = 100 / __numeroDeCanais * i;
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
        private void canal1Canal2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();
            for (int j = 0; j < chart1.Series[0].Points.Count; j++)
            {
                double Y__ = chart1.Series[0].Points[j].YValues[0] - chart1.Series[1].Points[j].YValues[0];
                chart1.Series[2].Points.AddXY(j,Y__);
            }
            MessageBox.Show("Derivação entre canais");
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
            string str;
            for (int i = 0; i < 20; i++)
            {
                str = "Evento" + (i + 1);  
                CheckBox chebox_events = this.Controls.Find(str, true)[0] as CheckBox;
                chebox_events.Checked = false;
            }
        }
        //-------------------------------------------------------------------------
        //                          EVENTOS CLICADOS 
        //--------------------------------------------------------------------------
        private void Evento_Click(object sender, EventArgs e)
        {
            CheckBox chebox_events = this.Controls.Find(((Control)sender).Name, true)[0] as CheckBox;
            Evento = chebox_events.Text;
            SetNenhumEventoMarcado();
            chebox_events.Checked = true;
            if (((Control)sender).Name == "Evento1")
                highlightColor = Color.Lime;
            if (((Control)sender).Name == "Evento2")
                highlightColor = Color.Yellow;
            if (((Control)sender).Name == "Evento3")
                highlightColor = Color.Red;
            if (((Control)sender).Name == "Evento4")
                highlightColor = Color.Orange;
            if (((Control)sender).Name == "Evento5")
                highlightColor = Color.RoyalBlue;
            if (((Control)sender).Name == "Evento6")
                highlightColor = Color.HotPink;
            if (((Control)sender).Name == "Evento7")
                highlightColor = Color.Aqua;
            if (((Control)sender).Name == "Evento8")
                highlightColor = Color.Gold;
            if (((Control)sender).Name == "Evento9")
                highlightColor = Color.Orchid;
            if (((Control)sender).Name == "Evento10")
                highlightColor = Color.Salmon;
            if (((Control)sender).Name == "Evento11")
                highlightColor = Color.PeachPuff;
            if (((Control)sender).Name == "Evento12")
                highlightColor = Color.SkyBlue;
            if (((Control)sender).Name == "Evento13")
                highlightColor = Color.Plum;
            if (((Control)sender).Name == "Evento14")
                highlightColor = Color.MediumSlateBlue;
            if (((Control)sender).Name == "Evento15")
                highlightColor = Color.LightGray;
            if (((Control)sender).Name == "Evento16")
                highlightColor = Color.Brown;
            if (((Control)sender).Name == "Evento17")
                highlightColor = Color.Khaki;
            if (((Control)sender).Name == "Evento18")
                highlightColor = Color.DarkGoldenrod;
            if (((Control)sender).Name == "Evento19")
                highlightColor = Color.YellowGreen;
            if (((Control)sender).Name == "Evento20")
                highlightColor = Color.LightCoral;
        }
        //--------------------------------------------------------------------------
        //Renomear o nome de algum padrão 
        private void renomearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Evento != null)
            {
                FormEditarNomePadrao NomeEvento = new FormEditarNomePadrao();
                NomeEvento.ShowDialog();
                string str;
                for (int i = 1; i <= 20; i++)
                {
                    str = "Evento" + i;
                    CheckBox chebox_events = this.Controls.Find(str, true)[0] as CheckBox;
                    if (chebox_events.Checked)
                    {
                        chebox_events.Text = NomeEvento.NomePadrao;
                        i = 30;
                    }
                }
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
        //------------------------------------------------------------------------
        //Imprimir tela
        private void imprimirEEGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Printing.PrintPreview();
        }
        //------------------------------------------------------------------------
        //Atalhos via teclado... 
        private void FormPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Control:
                    {
                        // Fazer, ativa a opçao de selecionar vários canais
                        break;
                    }
            }
        }
        //------------------------------------------------------------------------
        private void FormPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Control:
                    // Fazer, desativa a opçao de selecionar vários canais
                    break;
            }
        }
        //------------------------------------------------------------------------
        //------------------------------------------------------------------------
        //------------------------------------------------------------------------
    }
}
