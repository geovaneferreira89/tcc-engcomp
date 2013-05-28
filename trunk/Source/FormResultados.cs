﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NeuroLoopGainLibrary.Edf;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Runtime.InteropServices;
using NeuroLoopGainLibrary.Edf;

namespace AmbienteRPB
{
    public partial class FormResultados : Form
    {
        //-------------------------------------------
        private ListaPadroesEventos[] ListaDeEventos;
        private int numeroDeCanais;
        private GerenArquivos Arquivos;
        private EdfFile edfFileOutput;
        private int CanalAtual = 0;
        private int DataRecords_lidos = 10;
        private int Scroll_Click_Escala_Seg = 10; //tempo em segundos de tela
        private double[] vector_evento;
        private string end_EDF;
        private Thread Thread_;
        //-------------------------------------------
        public FormResultados(ListaPadroesEventos[] _ListaDeEventos, int _numDeCanais, string _end_EDF)
        {
            end_EDF        = _end_EDF;
            ListaDeEventos = _ListaDeEventos;
            numeroDeCanais = _numDeCanais;
            Arquivos       = new GerenArquivos();
            edfFileOutput  = Arquivos.Abrir_Projeto_EDF(end_EDF, false); 
            InitializeComponent();
        }
        //------------------------------------------------------------------------------------------
        private void FormResultados_Shown(object sender, EventArgs e)
        {
            double Divisao = 100 / (double)3;
            float _aux;
            _aux = (float)Divisao;
            for (int i = 0; i < 3; i++)
            {   //Propriedades de cada sinal
                chart1.ChartAreas.Add("canal" + i);
                chart1.ChartAreas[i].BackColor      = Color.Transparent;
                chart1.ChartAreas[i].AxisX.Enabled  = AxisEnabled.False;
                chart1.ChartAreas[i].AxisY.Enabled  = AxisEnabled.False;
                chart1.ChartAreas[i].Position.Height= _aux+3;//+10 os sinais sobreescrevem
                chart1.ChartAreas[i].Position.Width = 96;
                chart1.ChartAreas[i].Position.X     = 4;
                chart1.ChartAreas[i].Position.Y     = _aux * i;
            }
            AdicionaData(0);
            Adiciona_linhas_de_tempo();

            Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar,edfFileOutput, CanalAtual,"PlotaSinalEEG",vector_evento);
            Thread Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
            Thread_.Start();
            chart1.Enabled = true;
        }
        //------------------------------------------------------------------------------------------
        private void Adiciona_linhas_de_tempo()
        {
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

            lineAnnotation1.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation2.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation3.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation4.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation5.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation6.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation7.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation8.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation9.LineDashStyle  = ChartDashStyle.Dash;
            lineAnnotation10.LineDashStyle = ChartDashStyle.Dash;

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
        }
        //------------------------------------------------------------------------------------------
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
                aux = _seg / 60;
                _seg = _seg - aux * 60;
                _min = aux + edfFileOutput.FileInfo.StartTime.Value.Minutes;
                if (_min >= 60)
                {
                    aux = _min / 60;
                    _hora = aux + edfFileOutput.FileInfo.StartTime.Value.Hours;
                    _min = _min - aux * 60;
                }
            }
            DateTime dt_EEG = new DateTime(2013, 4, 11, _hora, _min, _seg);

            string tempo = dt_EEG.ToString("H:mm:ss") + " (" + dt_chart.ToString("H:mm:ss") + ")";
            lbl_Tempo.Text = tempo;
        }
        //------------------------------------------------------------------------------------------
        //Mudança de sinal
        private void btn_SinalProximo_Click(object sender, EventArgs e)
        {

        }

        private void btn_SinalAnterior_Click(object sender, EventArgs e)
        {

        }
        //------------------------------------------------------------------------------------------
        //Mudança no eixo de tempo do sinal
        private void btn_SinalAvancar_Click(object sender, EventArgs e)
        {

        }

        private void btn_SinalRetroceder_Click(object sender, EventArgs e)
        {

        }
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
            for (int i = 0; i < chart1.ChartAreas.Count(); i++)
                chart1.ChartAreas[CanalAtual].AxisX.ScaleView.Position = e.NewValue * 256; 
        }
        //------------------------------------------------------------------------------------------
        private void AddSegInChart()
        {
            for (int k = 0; k < Scroll_Click_Escala_Seg; k++)
            {
                if (DataRecords_lidos <= edfFileOutput.FileInfo.NrDataRecords)
                {
                    int excluir;
                    int tempo = DataRecords_lidos * 256;
                    edfFileOutput.ReadDataBlock(DataRecords_lidos);
                    DataRecords_lidos++;
                    //Cada ao fim deste for, é adiciocionado somente 1s em todos os canais
                    for (int j = 0; j < edfFileOutput.SignalInfo.Count; j++)
                    {
                        for (int i = 0; i < 256; i++)
                        {
                            if (j == CanalAtual)
                                chart1.Series["canal" + j].Points.AddY(edfFileOutput.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i]);
                            else
                                excluir = edfFileOutput.DataBuffer[edfFileOutput.SignalInfo[j].BufferOffset + i];
                        }
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormEditorDeEventos selecionar_evento = new FormEditorDeEventos(ListaDeEventos, end_EDF);
            selecionar_evento.ShowDialog();
            if (selecionar_evento.vector != null)
            {
                vector_evento = new double[selecionar_evento.vector.Count()];
                vector_evento = selecionar_evento.vector;
                DialogResult resposta = MessageBox.Show("Deseja iniciar a correlação?", "Reconhecimento Automatizado de Padrões EEG", MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                    inicia_correlacao();
            }
        }
        //------------------------------------------------------------------------------------------
        //Passar para thread depois... 
        private void inicia_correlacao()
        {
           chart1.Series["canal" + 1].Points.Clear();
            
            Correlacao objCliente = new Correlacao(chart1, progressBar, ScrollBar, edfFileOutput, CanalAtual, "Correlacao", vector_evento);
            Thread_ = new Thread(new ThreadStart(objCliente.Inicializa));
            Thread_.Start();
        }

        private void btn_Suspender_Click(object sender, EventArgs e)
        {
            Thread_.Suspend();
        }
        //------------------------------------------------------------------------------------------
     }
}