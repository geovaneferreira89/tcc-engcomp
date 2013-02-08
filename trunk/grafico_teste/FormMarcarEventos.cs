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
    public partial class FormMarcarEventos : Form
    {
        public String Evento
        {
            get;
            set;
        }
        public FormMarcarEventos()
        {
            InitializeComponent();
        }

        public void SetNenhumEventoMarcado()
        {
            Evento1.Checked = false;
            Evento2.Checked = false;
            Evento3.Checked = false;
            Evento4.Checked = false;
            Evento5.Checked = false;
            Evento6.Checked = false;
            Evento7.Checked = false;
            Evento8.Checked = false;
            Evento9.Checked = false;
            Evento10.Checked = false;
            Evento11.Checked = false;
            Evento12.Checked = false;
            Evento13.Checked = false;
            Evento14.Checked = false;
            Evento15.Checked = false;
            Evento16.Checked = false;
            Evento17.Checked = false;
            Evento18.Checked = false;
            Evento19.Checked = false;
            Evento20.Checked = false;
        }

        private void Evento01_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento1.Text;
            SetNenhumEventoMarcado();
            Evento1.Checked = true;
        }

        private void Evento2_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento2.Text;
            SetNenhumEventoMarcado();
            Evento2.Checked = true;
        }
        private void Evento3_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento3.Text;
            SetNenhumEventoMarcado();
            Evento3.Checked = true;
        }

        private void Evento4_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento4.Text;
            SetNenhumEventoMarcado();
            Evento4.Checked = true;
        }

        private void Evento5_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento5.Text;
            SetNenhumEventoMarcado();
            Evento5.Checked = true;
        }

        private void Evento6_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento6.Text;
            SetNenhumEventoMarcado();
            Evento6.Checked = true;
        }

        private void Evento7_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento7.Text;
            SetNenhumEventoMarcado();
            Evento7.Checked = true;
        }

        private void Evento8_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento8.Text;
            SetNenhumEventoMarcado();
            Evento8.Checked = true;
        }

        private void Evento9_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento9.Text;
            SetNenhumEventoMarcado();
            Evento9.Checked = true;
        }

        private void Evento10_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento10.Text;
            SetNenhumEventoMarcado();
            Evento10.Checked = true;
        }

        private void Evento11_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento11.Text;
            SetNenhumEventoMarcado();
            Evento11.Checked = true;
        }

        private void Evento12_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento12.Text;
            SetNenhumEventoMarcado();
            Evento12.Checked = true;
        }

        private void Evento13_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento13.Text;
            SetNenhumEventoMarcado();
            Evento13.Checked = true;
        }

        private void Evento14_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento14.Text;
            SetNenhumEventoMarcado();
            Evento14.Checked = true;
        }

        private void Evento15_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento15.Text;
            SetNenhumEventoMarcado();
            Evento15.Checked = true;
        }

        private void Evento16_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento16.Text;
            SetNenhumEventoMarcado();
            Evento16.Checked = true;
        }

        private void Evento17_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento17.Text;
            SetNenhumEventoMarcado();
            Evento17.Checked = true;
        }

        private void Evento18_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento18.Text;
            SetNenhumEventoMarcado();
            Evento18.Checked = true;
        }

        private void Evento19_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento19.Text;
            SetNenhumEventoMarcado();
            Evento19.Checked = true;
        }

        private void Evento20_CheckedChanged(object sender, EventArgs e)
        {
            Evento = Evento20.Text;
            SetNenhumEventoMarcado();
            Evento20.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Evento != "")
            {
                FormEditarNomeEvento NomeEvento = new FormEditarNomeEvento();
                NomeEvento.ShowDialog();
      
                if(Evento1.Checked)
                    Evento1.Text = NomeEvento.NomePadrao;
                if (Evento2.Checked)
                    Evento2.Text = NomeEvento.NomePadrao;
                if (Evento3.Checked)
                    Evento3.Text = NomeEvento.NomePadrao;
                if (Evento4.Checked)
                    Evento4.Text = NomeEvento.NomePadrao;
                if (Evento5.Checked)
                    Evento5.Text = NomeEvento.NomePadrao;
                if (Evento6.Checked)
                    Evento6.Text = NomeEvento.NomePadrao;
                if (Evento7.Checked)
                    Evento7.Text = NomeEvento.NomePadrao;
                if (Evento8.Checked)
                    Evento8.Text = NomeEvento.NomePadrao;
                if (Evento9.Checked)
                    Evento9.Text = NomeEvento.NomePadrao;
                if (Evento10.Checked)
                    Evento10.Text = NomeEvento.NomePadrao;
                if (Evento11.Checked)
                    Evento11.Text = NomeEvento.NomePadrao;
                if (Evento12.Checked)
                    Evento12.Text = NomeEvento.NomePadrao;
                if (Evento13.Checked)
                    Evento13.Text = NomeEvento.NomePadrao;
                if (Evento14.Checked)
                    Evento14.Text = NomeEvento.NomePadrao;
                if (Evento15.Checked)
                    Evento15.Text = NomeEvento.NomePadrao;
                if (Evento16.Checked)
                    Evento16.Text = NomeEvento.NomePadrao;
                if (Evento17.Checked)
                    Evento17.Text = NomeEvento.NomePadrao;
                if (Evento18.Checked)
                    Evento18.Text = NomeEvento.NomePadrao;
                if (Evento19.Checked)
                    Evento19.Text = NomeEvento.NomePadrao;
                if (Evento20.Checked)
                    Evento20.Text = NomeEvento.NomePadrao;
                Evento = NomeEvento.NomePadrao;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
