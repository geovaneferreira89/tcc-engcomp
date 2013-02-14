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
    }
}
