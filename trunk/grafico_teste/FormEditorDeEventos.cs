using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbienteRPB
{
    public partial class FormEditorDeEventos : Form
    {
        private int[] ListaNumeroEventos;
        private int Padroes;
        private string[] ListaPadroes;

        public FormEditorDeEventos(int []_ListaEventos, string []_ListaPadroes, int _Padroes)
        {
            ListaNumeroEventos = _ListaEventos;
            Padroes = _Padroes;
            ListaPadroes = _ListaPadroes;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEditorDeEventos_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Padroes; i++)
                comboTiposDeEventos.Items.Add(ListaPadroes[i]);
        }

        private void comboTiposDeEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxEventosPorTipo.Items.Clear();
            for (int i = 0; i < ListaNumeroEventos[comboTiposDeEventos.SelectedIndex]; i++)
            {
                lbxEventosPorTipo.Items.Add(comboTiposDeEventos.SelectedItem.ToString() + "_" + Convert.ToString(i));
            }
        }

        private void lbxEventosPorTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chart1.Series.Count != 0)
            {
                chart1.Series.Remove(chart1.Series["Serie01"]);
                chart1.ChartAreas.Remove(chart1.ChartAreas[0]);
            }
           /* if (openFile.ShowDialog() == DialogResult.OK)
            {
                chart1.ChartAreas.Add("Padrao");
                chart1.Series.Add("Serie01");
                chart1.Series["Serie01"].ChartArea = "Padrao";
                chart1.Series["Serie01"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                System.IO.StreamReader fileR = new System.IO.StreamReader(openFile.FileName);
                edtEvento_Nome.Text = openFile.SafeFileName; //Tirar o resto... 
                string dados;
                dados = fileR.ReadLine();
                dados = dados.Substring(22);
                dados = dados.Substring(0, dados.Length - 1);
                int NumeroDeAmostras = Convert.ToInt16(dados);
                chart1.Series[0].Color = Color.Red;
                for (int i = 0; i <= NumeroDeAmostras; i++)
                {
                    dados = fileR.ReadLine();
                    string x = dados;
                    string y = dados;
                    int X_ = x.IndexOf(" ");
                    x = x.Substring(3);
                    x = x.Substring(0, X_ - 4);
                    y = y.Substring(X_ + 3);
                    y = y.Substring(0, y.Length - 1);
                    chart1.Series[0].Points.AddXY(Convert.ToDouble(x), Convert.ToDouble(y));
                }

            }*/
        }
    }
}
