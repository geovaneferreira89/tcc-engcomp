using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EDF;


namespace grafico_teste
{
    public partial class Carregar_EDF : Form
    {
        private string dirArquivo;
        private EDFFile edfFileInput = null;


        public Carregar_EDF(string dirArquivo_)
        {
            dirArquivo = dirArquivo_;
            InitializeComponent();
        }

        private void EDF_Load(object sender, EventArgs e)
        {
             if (dirArquivo != null)
             {
                 edfFileInput = new EDFFile();
                 edfFileInput.readFile(dirArquivo);
             }

             listBox1.Items.Clear();
             foreach (EDFSignal signal in edfFileInput.Header.Signals)
             {
                listBox1.Items.Add(signal);
             }
        }
    }
}
