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
    public partial class FormEditarNomePadrao : Form
    {
        //Atributo que pode ser acessado pelas outras classes, no caso clase GerenArquivos...
        public int opcao
        {
            get;
            set;
        }
        public String NomePadrao
        {
            get;
            set;
        }
        public double Vetores
        {
            get;
            set;
        }
        public double TamVetores
        {
            get;
            set;
        }
        public double TreinamentoCom
        {
            get;
            set;
        }
        public bool UsarCorrelacao
        {
            get;
            set;
        }
        public bool UsarListaDeTodosEnventos
        {
            get;
            set;
        }
        public int NumPadroes
        {
            get;
            set;
        }

        public bool UsarReferencia
        {
            get;
            set;
        }

        public bool DebugMode
        {
            get;
            set;
        }
        public FormEditarNomePadrao()
        {
            InitializeComponent();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (opcao == 1 || opcao == 2)
            {
                Vetores = Convert.ToDouble(text_NomePadrao.Text);
                TamVetores = Convert.ToDouble(txt_VetorTamanho.Text);
                TreinamentoCom = Convert.ToDouble(TxtTreinarCom.Text);
                if (ckb_UseCorrel.Checked) 
                   UsarCorrelacao = true;
                if (ckb_ListaToda.Checked)
                {
                    UsarListaDeTodosEnventos = true;
                    NumPadroes = Convert.ToInt32(txtPadroes.Text);
                }
                else
                    NumPadroes = 1;
                if (ckReferencia.Checked)
                    UsarReferencia = true;
                if (ckbDebug.Checked)
                    DebugMode = true;
                else
                    DebugMode = false;
                opcao = 100;
                this.Close();
            }
            else if (text_NomePadrao.Text != "")
            {
                NomePadrao = text_NomePadrao.Text;
                this.Close();
            }
        }

        private void FormEditarNomePadrao_Shown(object sender, EventArgs e)
        {
            if (opcao == 1)
            {
                this.Height = 145;
                this.Width = 304;
                //btn_salvar.Location = new Point(164, 153); 
                lbl_digiteONomeDoPadrao.Text = "Total";
                label2.Visible = false;
                TxtTreinarCom.Visible = false;

                ckReferencia.Location = new Point(ckReferencia.Location.X, 67);
                ckb_ListaToda.Location = new Point(ckb_ListaToda.Location.X, 67);
                ckb_UseCorrel.Location = new Point(ckb_UseCorrel.Location.X, 90);
                ckbDebug.Location = new Point(ckbDebug.Location.X, 90); 

                text_NomePadrao.Text = Convert.ToString(Vetores);
                txt_VetorTamanho.Text = Convert.ToString(TamVetores);
                TxtTreinarCom.Text = Convert.ToString(Vetores);
                txtPadroes.Text = "1";
                UsarReferencia = false;
                this.Text = "Configuração MLP";
            }
            if (opcao == 2)
            {
                this.Height = 169;
                this.Width = 304;
               // btn_salvar.Location = new Point(164, 153);
                lbl_digiteONomeDoPadrao.Text = "Total";
                label2.Text = "Matriz [x:x]";
                text_NomePadrao.Text = Convert.ToString(Vetores);
                txt_VetorTamanho.Text = Convert.ToString(50);
                TxtTreinarCom.Text = Convert.ToString(10);
                txtPadroes.Text = "1";
                UsarReferencia = true;
                ckReferencia.Checked = true;
                ckb_ListaToda.Visible = false;
                this.Text = "Configuração Kohonen";
            }
        }

        private void ckb_ListaToda_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_ListaToda.Checked)
                txtPadroes.Enabled = true;
            else
            {
                txtPadroes.Text = "1";
                txtPadroes.Enabled = false;
            }
        }

        private void ckReferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckb_ListaToda.Checked)
                txt_VetorTamanho.Text = Convert.ToString(TamVetores);
            else
                txt_VetorTamanho.Text = "50";
        }
    }
}
