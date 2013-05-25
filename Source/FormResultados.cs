using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NeuroLoopGainLibrary.Edf;
using Microsoft.VisualBasic;

namespace AmbienteRPB
{
    public partial class FormResultados : Form
    {
        private ListaPadroesEventos[] ListaDeEventos;
        private int numDeCanais;
        private GerenArquivos Arquivos;
        private EdfFile edfFileOutput;

        public FormResultados(ListaPadroesEventos[] _ListaDeEventos, int _numDeCanais, EdfFile _edfFileOutput)
        {
            ListaDeEventos = _ListaDeEventos;
            numDeCanais    = _numDeCanais;
            edfFileOutput  = _edfFileOutput; 
            InitializeComponent();
        }
    }
}
