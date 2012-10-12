using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EDF;


namespace AmbienteRPB
{
    public partial class Carregar_EDF : Form
    {
        private string dirArquivo;     
        //private string initialDirectory = "C:\\";
        private System.IO.StreamWriter fileW;
        
        //Atributo que pode ser acessado pelas outras classes, no caso clase GerenArquivos...
        public EDFFile edfFileOutput
        {
            get;
            set;
        }

        public EDFFile edfFileInput
        {
            get;
            set;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (edfFileOutput == null)
                initializeEDFOutput();

            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                edfFileOutput.addSignal((EDFSignal)listBox1.SelectedItems[i], edfFileInput.retrieveSignalSampleValues((EDFSignal)listBox1.SelectedItems[i]));
                listBox2.Items.Add(listBox1.SelectedItems[i]);
            }
        }

        private void initializeEDFOutput()
        {
            edfFileOutput = new EDFFile();
            edfFileOutput.Header.DurationOfDataRecordInSeconds = edfFileInput.Header.DurationOfDataRecordInSeconds;
            edfFileOutput.Header.NumberOfBytes = edfFileInput.Header.NumberOfBytes;
            edfFileOutput.Header.PatientIdentification = edfFileInput.Header.PatientIdentification;
            edfFileOutput.Header.RecordingIdentification = edfFileInput.Header.RecordingIdentification;
            edfFileOutput.Header.Reserved = edfFileInput.Header.Reserved;
            edfFileOutput.Header.StartDateTime = edfFileInput.Header.StartDateTime;
            edfFileOutput.Header.Version = edfFileInput.Header.Version;
            foreach (EDFDataRecord dr in edfFileInput.DataRecords)
            {
                edfFileOutput.DataRecords.Add(new EDFDataRecord());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if (edfFileOutput == null)
                MessageBox.Show("Nenhum canal selecionado",
                  "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);   
                
            this.Close();
        }

        private void Carregar_EDF_FormClosed(object sender, FormClosedEventArgs e)
        {
            //AtributoAcessadoPorOutroForm = "o form foi fechado";
        }
    }
}
