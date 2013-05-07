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
    public partial class FormCarregar_EDF : Form
    {
        private string dirArquivo;     
        //private string initialDirectory = "C:\\";
        private EdfFile _edfFileInput;
        //Atributo que pode ser acessado pelas outras classes, no caso clase GerenArquivos...
        public EdfFile edfFileOutput
        {
            get;
            set;
        }

        public EdfFile edfFileInput
        {
            get;
            set;
        }

        public FormCarregar_EDF(string dirArquivo_)
        {
            dirArquivo = dirArquivo_;
            InitializeComponent();
        }

        private void EDF_Load(object sender, EventArgs e)
        {
             if (dirArquivo != null)
             {
                 _edfFileInput = new EdfFile(dirArquivo, true, true, true, true);
             }
            edfFileInput = _edfFileInput;
            if (edfFileInput.ValidFormat)
            {
                listBox1.Items.Clear();
                //listBox1.Items.Add(string.Format("{0} - {1} ({2}Hz)", k + 1, edfFileInput.SignalInfo[k].SignalLabel, edfFileInput.SignalInfo[k].NrSamples / edfFileInput.FileInfo.SampleRecDuration));
                for (int k = 0; k < edfFileInput.SignalInfo.Count; k++)
                    listBox1.Items.Add(edfFileInput.SignalInfo[k].SignalLabel);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (edfFileOutput == null)
                initializeEDFOutput();

            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
               // edfFileOutput.SignalInfo.Add(edfFileInput.SignalInfo[(int)listBox1.SelectedItems[i]]);
                   //                    addSignal((EDFSignal)listBox1.SelectedItems[i], edfFileInput.retrieveSignalSampleValues((EDFSignal)listBox1.SelectedItems[i]));
                listBox2.Items.Add(listBox1.SelectedItems[i]);
            }
            
        }

        private void initializeEDFOutput()
        {
          //  edfFileOutput = new EdfFile();
          //  edfFileOutput.FileInfo.NrDataFields = edfFileInput.FileInfo.NrDataFields;
            /*edfFileOutput. Header.DurationOfDataRecordInSeconds = edfFileInput.Header.DurationOfDataRecordInSeconds;
            edfFileOutput.Header.NumberOfBytes = edfFileInput.Header.NumberOfBytes;
            edfFileOutput.Header.PatientIdentification = edfFileInput.Header.PatientIdentification;
            edfFileOutput.Header.RecordingIdentification = edfFileInput.Header.RecordingIdentification;
            edfFileOutput.Header.Reserved = edfFileInput.Header.Reserved;
            edfFileOutput.Header.StartDateTime = edfFileInput.Header.StartDateTime;
            edfFileOutput.Header.Version = edfFileInput.Header.Version;
            foreach (EDFDataRecord dr in edfFileInput.DataRecords)
            {
                edfFileOutput.DataRecords.Add(new EDFDataRecord());
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if (edfFileInput == null)
                MessageBox.Show("Nenhum canal selecionado",
                  "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);   
                
            this.Close();
        }

        private void Carregar_EDF_FormClosed(object sender, FormClosedEventArgs e)
        {
            //AtributoAcessadoPorOutroForm = "o form foi fechado";
        }

        private void btn_derivacao_Click(object sender, EventArgs e)
        {
        /*    EDFSignal Teste1  = (EDFSignal)listBox2.SelectedItems[0];// - (EDFSignal)listBox2.SelectedItems[1];
            EDFSignal Teste2 = (EDFSignal)listBox2.SelectedItems[1];
            EDFSignal OUT;
           // foreach (EDFSignal signal in edfFileOutput.Header.Signals)
           // {
                  foreach (EDFDataRecord dataRecord in edfFileOutput.DataRecords)
                  {
                      foreach (float sample1 in dataRecord[Teste1.IndexNumberWithLabel])
                    {
                        //Plotar(num_de_voltas, sample, 1, i, "Blue", signal.Label.ToString().Substring(4));
                        foreach (float sample2 in dataRecord[Teste2.IndexNumberWithLabel])
                        {
                            OUT.IndexNumberWithLabel
                        }
                    }

                  }
           // }
            for (int i = 0; i < listBox2.SelectedItems.Count; i++)
            {
                edfFileOutput.deleteSignal((EDFSignal)listBox2.SelectedItems[i]);

                listBox2.Items.Add(listBox1.SelectedItems[i]);
            }*/
        }
    }
}
