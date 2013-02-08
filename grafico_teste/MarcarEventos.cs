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
    public partial class MarcarEventos : Form
    {
        public String Evento
        {
            get;
            set;
        }
        public MarcarEventos()
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
            Evento = "Evento1";
            SetNenhumEventoMarcado();
            Evento1.Checked = true;
        }

        private void Evento2_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento2";
            SetNenhumEventoMarcado();
            Evento2.Checked = true;
        }
        private void Evento3_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento3";
            SetNenhumEventoMarcado();
            Evento3.Checked = true;
        }

        private void Evento4_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento4";
            SetNenhumEventoMarcado();
            Evento4.Checked = true;
        }

        private void Evento5_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento5";
            SetNenhumEventoMarcado();
            Evento5.Checked = true;
        }

        private void Evento6_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento6";
            SetNenhumEventoMarcado();
            Evento6.Checked = true;
        }

        private void Evento7_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento7";
            SetNenhumEventoMarcado();
            Evento7.Checked = true;
        }

        private void Evento8_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento8";
            SetNenhumEventoMarcado();
            Evento8.Checked = true;
        }

        private void Evento9_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento9";
            SetNenhumEventoMarcado();
            Evento9.Checked = true;
        }

        private void Evento10_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento10";
            SetNenhumEventoMarcado();
            Evento10.Checked = true;
        }

        private void Evento11_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento11";
            SetNenhumEventoMarcado();
            Evento11.Checked = true;
        }

        private void Evento12_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento12";
            SetNenhumEventoMarcado();
            Evento12.Checked = true;
        }

        private void Evento13_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento13";
            SetNenhumEventoMarcado();
            Evento13.Checked = true;
        }

        private void Evento14_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento14";
            SetNenhumEventoMarcado();
            Evento14.Checked = true;
        }

        private void Evento15_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento15";
            SetNenhumEventoMarcado();
            Evento15.Checked = true;
        }

        private void Evento16_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento16";
            SetNenhumEventoMarcado();
            Evento16.Checked = true;
        }

        private void Evento17_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento17";
            SetNenhumEventoMarcado();
            Evento17.Checked = true;
        }

        private void Evento18_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento18";
            SetNenhumEventoMarcado();
            Evento18.Checked = true;
        }

        private void Evento19_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento19";
            SetNenhumEventoMarcado();
            Evento19.Checked = true;
        }

        private void Evento20_CheckedChanged(object sender, EventArgs e)
        {
            Evento = "Evento20";
            SetNenhumEventoMarcado();
            Evento20.Checked = true;
        }
    }
}
