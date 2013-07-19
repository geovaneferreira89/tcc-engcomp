﻿using System;
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
        public FormEditarNomePadrao()
        {
            InitializeComponent();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (opcao == 1)
            {
                Vetores = Convert.ToDouble(text_NomePadrao.Text);
                TamVetores = Convert.ToDouble(txt_VetorTamanho.Text);
                TreinamentoCom = Convert.ToDouble(TxtTreinarCom.Text);
                UsarCorrelacao = ckb_UseCorrel.Checked;
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
                this.Height = 121;
                lbl_digiteONomeDoPadrao.Text = "Num Vet";
                text_NomePadrao.Text = Convert.ToString(Vetores);
                txt_VetorTamanho.Text = Convert.ToString(TamVetores);
                TxtTreinarCom.Text = Convert.ToString(Vetores);
                this.Text = "Dados de Entrada";
            }
        }
    }
}
