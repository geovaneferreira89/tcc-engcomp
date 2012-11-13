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
    public partial class Form_SalvarPadrao : Form
    {
        //Atributo que pode ser acessado pelas outras classes, no caso clase GerenArquivos...
        public String NomePadrao
        {
            get;
            set;
        }
        public Form_SalvarPadrao()
        {
            InitializeComponent();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            NomePadrao = text_NomePadrao.Text;
            this.Close();
        }
    }
}
