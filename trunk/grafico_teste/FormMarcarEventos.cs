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
                NovoNomeEvento(Evento,NomeEvento.NomePadrao);
            }
        }
        public void NovoNomeEvento(string nome, string novo_nome)
        {
            switch (nome)
            {
                case ("Evento1"):
                    {
                        Evento1.Text = novo_nome;
                        break;
                    }
                case ("Evento2"):
                    {
                        Evento2.Text = novo_nome;
                        break;
                    }
                case ("Evento3"):
                    {
                        Evento3.Text = novo_nome;
                        break;
                    }
                case ("Evento4"):
                    {
                        Evento4.Text = novo_nome;
                        break;
                    }
                case ("Evento5"):
                    {
                        Evento5.Text = novo_nome;
                        break;
                    }
                case ("Evento6"):
                    {
                        Evento6.Text = novo_nome;
                        break;
                    }
                case ("Evento7"):
                    {
                        Evento7.Text = novo_nome;
                        break;
                    }
                case ("Evento8"):
                    {
                        Evento8.Text = novo_nome;
                        break;
                    }
                case ("Evento9"):
                    {
                        Evento9.Text = novo_nome;
                        break;
                    }
                case ("Evento10"):
                    {
                        Evento10.Text = novo_nome;
                        break;
                    }
                case ("Evento11"):
                    {
                        Evento11.Text = novo_nome;
                        break;
                    }
                case ("Evento12"):
                    {
                        Evento12.Text = novo_nome;
                        break;
                    }
                case ("Evento13"):
                    {
                        Evento13.Text = novo_nome;
                        break;
                    }
                case ("Evento14"):
                    {
                        Evento14.Text = novo_nome;
                        break;
                    }
                case ("Evento15"):
                    {
                        Evento15.Text = novo_nome;
                        break;
                    }
                case ("Evento16"):
                    {
                        Evento16.Text = novo_nome;
                        break;
                    }
                case ("Evento17"):
                    {
                        Evento17.Text = novo_nome;
                        break;
                    }
                case ("Evento18"):
                    {
                        Evento18.Text = novo_nome;
                        break;
                    }
                case ("Evento19"):
                    {
                        Evento19.Text = novo_nome;
                        break;
                    }
                case ("Evento20"):
                    {
                        Evento20.Text = novo_nome;
                        break;
                    }
              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
