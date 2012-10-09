using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using EDF;


namespace EDFApplication
{
    public partial class EDFAppWindow : Form
    {

        private EDFFile edfFileInput = null;

        private EDFFile edfFileOutput = null;


        private string initialDirectory = "C:\\";
        public EDFAppWindow()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "EDF files (*.edf)|*.edf|All files (*.*)|*.*";
            dialog.InitialDirectory = initialDirectory;
            dialog.Title = "Select a EDF file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }
            dialog.Dispose();

            if (fileName != null)
            {
                toolStripStatusLabel1.Text = "Opening " + fileName;
                edfFileInput = new EDFFile();
                edfFileInput.readFile(fileName);
            }

            listBox1.Items.Clear();
            foreach (EDFSignal signal in edfFileInput.Header.Signals)
            {
                listBox1.Items.Add(signal);
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
            foreach(EDFDataRecord dr in edfFileInput.DataRecords)
            {
                edfFileOutput.DataRecords.Add(new EDFDataRecord());
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (edfFileOutput != null)
            {
                string fileName = null;
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter =
                   "EDF files (*.edf)|*.edf|All files (*.*)|*.*";
                dialog.InitialDirectory = initialDirectory;
                dialog.Title = "Select a EDF file";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                }
                dialog.Dispose();

                if (fileName != null)
                {

                    toolStripStatusLabel1.Text = "Saving " + fileName;
                    this.edfFileOutput.Header.PatientIdentification.PatientName = txtPatientName.Text;
                    this.edfFileOutput.saveFile(fileName);                    
                }
            }

        }

        private void changePatientNamesBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] fileNames = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "EDF files (*.edf)|*.edf|All files (*.*)|*.*";
            dialog.InitialDirectory = initialDirectory;
            dialog.Title = "Select a EDF file";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileNames = dialog.FileNames;
            }
            dialog.Dispose();

            if (fileNames != null)
            {
                foreach (string fileName in fileNames)
                {
                    statusStrip1.Text = "Opening " + fileName;
                    edfFileOutput = new EDFFile();
                    edfFileOutput.readFile(fileName);
                    if (Path.GetFileName(fileName).Contains("_"))
                    {
                        edfFileOutput.Header.PatientIdentification.PatientCode = Path.GetFileName(fileName).Split('_')[0];
                    }
                    else
                    {
                        edfFileOutput.Header.PatientIdentification.PatientCode = "XXXX";
                    }
                    edfFileOutput.Header.PatientIdentification.PatientBirthDate = edfFileOutput.Header.PatientIdentification.PatientBirthDate.AddYears(10);
                    edfFileOutput.Header.PatientIdentification.PatientName = Path.GetFileName(fileName);
                    edfFileOutput.saveFile(fileName);
                }
            }
            edfFileOutput = null;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (edfFileOutput == null)
                initializeEDFOutput();

            edfFileOutput.addSignal((EDFSignal)listBox1.SelectedItem, edfFileInput.retrieveSignalSampleValues((EDFSignal)listBox1.SelectedItem));
            listBox2.Items.Add(listBox1.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edfFileOutput.deleteSignal((EDFSignal)listBox1.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
        }
        private void convertToCompuMedicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edfFileOutput != null)
            {
                string dirPath = null;
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "Select a File to Export Compumedics to";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dirPath = dialog.SelectedPath;
                }
                dialog.Dispose();
                edfFileOutput.exportAsCompumedics(dirPath);
                clearFiles();
            }

        }

        private void sampleDownToCompuMedicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edfFileOutput != null)
            {

                foreach (EDFSignal signal in edfFileOutput.Header.Signals)
                {

                    foreach (EDFDataRecord dataRecord in edfFileOutput.DataRecords)
                    {
                        float allDataRecordSamples = 0;
                        foreach (float sample in dataRecord[signal.IndexNumberWithLabel])
                        {
                            allDataRecordSamples += sample;
                        }
                        float avgDataRecordSample = (allDataRecordSamples / signal.NumberOfSamplesPerDataRecord);
                        dataRecord[signal.IndexNumberWithLabel] = new List<float>();
                        dataRecord[signal.IndexNumberWithLabel].Add(avgDataRecordSample);
                    }
                    signal.NumberOfSamplesPerDataRecord = 1;
                }
            }
        }

        private void combineSignalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotSupportedException("combineSignalsToolStripMenuItem_Click nothing here!");

        }

        private void clearLoadedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.clearFiles();
        }
        public void clearFiles()
        {
            edfFileInput = null;
            edfFileOutput = null;
            System.GC.Collect();
            listBox1.Items.Clear();
            listBox2.Items.Clear();

        }


    }
}
