using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NeuroLoopGainLibrary.Edf;

namespace AmbienteRPB
{
    public partial class InfoEDF : Form
    {
        private EdfFile EDF;
        public InfoEDF(EdfFile EDF_)
        {
            EDF =  EDF_;
            InitializeComponent();
        }

        private void InfoEDF_Load(object sender, EventArgs e)
        {

           label1.Text = "Nome do Paciente: " + EDF.FileInfo.Patient;
           label2.Text = "Nascimento: " + EDF.FileInfo.PatientBirthDate;
           label3.Text = "Sexo: " + EDF.FileInfo.PatientGender;
           label4.Text = "Outras Informações: " + EDF.FileInfo.PatientOtherInfo;
           label5.Text = "Hora: " + EDF.FileInfo.StartDate;
           label6.Text = "Duração: " + EDF.FileInfo.NrDataRecords;
           label7.Text = "Inicio do Exame: " + EDF.FileInfo.StartTime;
           label8.Text = "Fim do Exame: " + EDF.FileInfo.EndDateTime;
           label9.Text = "Version: " + EDF.FileInfo.Version;

           label10.Text = EDF.FileInfo.Recording;

        }
    }
}
