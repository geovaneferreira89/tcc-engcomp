using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace thread_chart
{
    public class atualiza_sinal
    {
        private Control _Grafico = null;
        private Control _BarraDeProgresso = null;
        private int _NumCanais = 0;
        private delegate void AtualizaChart(double x, double y, int caso, int _VarchartArea_, string Cor);
        private delegate void AtualizaPloter(int valor, int caso);
        private System.Windows.Forms.DataVisualization.Charting.Chart prb = null;
        private System.Windows.Forms.ProgressBar prgbar = null;
        // Controles Projeto
        private Control _ControleProjeto = null;
        private System.Windows.Forms.ToolStrip ControleProjeto = null;
        private delegate void AtualizaControleProjeto(string caso);
        //Status do Projeto 
        private Control _StatusProjeto = null;
        private System.Windows.Forms.StatusStrip StatusProjeto = null;
        private delegate void AtualizaStatusProjeto(string SMS, int caso);
        //amostras sinal de teste
        private int num_de_voltas = 20;
        private double num_de_amostras = 0.5;

        //-------------------------------------------------------------
        public atualiza_sinal(Control Controle, int NumCanais, Control BarraDeProgresso, Control __ControleProjeto, Control __StatusProjeto)
        {
            _Grafico = Controle;
            _NumCanais = NumCanais;
            _BarraDeProgresso = BarraDeProgresso;
            _ControleProjeto = __ControleProjeto;
            _StatusProjeto = __StatusProjeto;
        }
        //-------------------------------------------------------------
        public void Inicializa()
        {
            for (int i = 0; i < _NumCanais; i++)
            {
                Plotar(0, 0, 2, i, " ");
                load_progress_bar(0, 2);
                FuncAtualizaStatusProjeto("...Iniciou", 0);
                double j = 0;
                int inc = 0;
                while (j < num_de_voltas)
                {
                    if (i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21)
                    {
                        Plotar(j, Math.Sin(j), 1, i, "YellowGreen");
                    }
                    if (i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22)
                    {
                        Plotar(j, Math.Cos(j), 1, i, "Blue");
                    }
                    if (i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23)
                    {
                        Plotar(j, Math.Tan(j), 1, i, "Green");
                    }
                    inc++;
                    j += num_de_amostras;
                    Thread.Sleep(1);
                }
                load_progress_bar(inc, 1);
                
            }
            load_progress_bar(0, 3);
            FuncAtualizaStatusProjeto("...terminou", 1);
            FuncAtualizaControleProjeto("Des_btn_Suspender");
        }
        //-------------------------------------------------------------
        private void Plotar(double x, double y, int caso, int _NumCanais_, string Cor)
        {
            if (_Grafico.InvokeRequired)
            {
                _Grafico.BeginInvoke(new AtualizaChart(Plotar), new Object[] { x, y, caso, _NumCanais_, Cor });
            }
            else
            {
                if (caso == 1)
                {
                    if (prb != null)
                    {
                        prb.Series["canal" + _NumCanais_].Color = Color.FromName(Cor);
                        prb.Series["canal" + _NumCanais_].Points.AddXY(x, y);
                    }
                }
                if (caso == 2)
                {
                    prb = _Grafico as System.Windows.Forms.DataVisualization.Charting.Chart;
                    prb.Series.Add("canal" + _NumCanais_);
                    prb.Series["canal" + _NumCanais_].ChartArea = "canal" + _NumCanais_;
                    prb.Series["canal" + _NumCanais_].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    prb.Legends.Clear();
                }
            }
        }
        //-------------------------------------------------------------
        private void load_progress_bar(int valor, int caso)
        {

            if (_BarraDeProgresso.InvokeRequired)
            {
                _BarraDeProgresso.BeginInvoke(new AtualizaPloter(load_progress_bar), new Object[] { valor, caso });
            }
            else
            {
                if (caso == 1)
                {
                    if (prgbar != null)
                    {
                        prgbar.PerformStep();
                    }
                }
                if (caso == 2)  
                {
                    prgbar = _BarraDeProgresso as System.Windows.Forms.ProgressBar;
                    prgbar.Visible = true;
                    prgbar.Maximum = num_de_voltas * _NumCanais;
                }
                if(caso == 3)
                    prgbar.Visible = false;
            }
        }
        //-------------------------------------------------------------
        private void FuncAtualizaControleProjeto(string caso)
        {
            if (_ControleProjeto.InvokeRequired)
            {
                _ControleProjeto.BeginInvoke(new AtualizaControleProjeto(FuncAtualizaControleProjeto), new Object[] { caso });
            }
            else
            {
                if (caso == "Des_btn_Suspender")
                {
                    ControleProjeto = _ControleProjeto as System.Windows.Forms.ToolStrip;
                    ControleProjeto.Items["btn_Suspender"].Enabled = false;
                }
            }
        }
        //-------------------------------------------------------------
        private void FuncAtualizaStatusProjeto(string SMS, int caso)
        {
            if (_StatusProjeto.InvokeRequired)
            {
                _StatusProjeto.BeginInvoke(new AtualizaStatusProjeto(FuncAtualizaStatusProjeto), new Object[] { SMS, caso });
            }
            else
            {
                if (caso == 0)
                {
                    StatusProjeto = _StatusProjeto as System.Windows.Forms.StatusStrip;
                    StatusProjeto.Items["lbl_ferramentaAtiva"].ForeColor = Color.MediumSeaGreen;
                    StatusProjeto.Items["lbl_ferramentaAtiva"].Text = "Ferramenta ativa: Imporando sinais";
                }
                if (caso == 1)
                {
                    StatusProjeto.Items["lbl_ferramentaAtiva"].ForeColor = Color.Brown;
                    StatusProjeto.Items["lbl_ferramentaAtiva"].Text = "Ferramenta ativa: Nenhuma";
                }
            }
        }
        //-------------------------------------------------------------
    }
}