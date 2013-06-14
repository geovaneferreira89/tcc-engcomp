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
        private string  dirArquivo;     
        private EdfFile edfComMontagem;
        private bool    MostarTela;
        private int     CountCor = 0;
        //Atributo que pode ser acessado pelas outras classes, no caso clase GerenArquivos...
        //------------------------------------------------------------------------------------------
        public EdfFile edfFileInput
        {
            get;
            set;
        }
        public int NumeroDeCanais
        {
            get;
            set;
        }
        //------------------------------------------------------------------------------------------
        public FormCarregar_EDF(string _dirArquivo, bool _MostarTela)
        {
            dirArquivo = _dirArquivo;
            MostarTela = _MostarTela;
            if (MostarTela)
                InitializeComponent();
            else
            {
                if (dirArquivo != null)
                {
                    edfFileInput = new EdfFile(dirArquivo, true, true, true, true);
                    NumeroDeCanais = edfFileInput.FileInfo.NrSignals;
                }
                this.Close();
            }
        }
        //------------------------------------------------------------------------------------------
        private void EDF_Load(object sender, EventArgs e)
        {
             if (dirArquivo != null)
             {
                 edfFileInput = new EdfFile(dirArquivo, true, true, true, true);
             }
         
            if (edfFileInput.ValidFormat)
            {
                listBox1.Items.Clear();
                for (int k = 0; k < edfFileInput.SignalInfo.Count; k++)
                    listBox1.Items.Add(edfFileInput.SignalInfo[k].SignalLabel);
            }
            NumeroDeCanais = edfFileInput.FileInfo.NrSignals;
        }
        //------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                
                listBox2.Items.Add(listBox1.SelectedItems[i]);
                
            }
        }
        //------------------------------------------------------------------------------------------
        private void btn_Montagem1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add("EEG Fp1-Ref");
            listBox2.Items.Add("EEG F3-Ref");
            
            listBox2.Items.Add("EEG F3-Ref");
            listBox2.Items.Add("EEG C3-Ref");

            listBox2.Items.Add("EEG C3-Ref");
            listBox2.Items.Add("EEG P3-Ref");

            listBox2.Items.Add("EEG P3-Ref");
            listBox2.Items.Add("EEG O1-Ref");

            listBox2.Items.Add("EEG Fp1-Ref");
            listBox2.Items.Add("EEG F7-Ref");
            
            listBox2.Items.Add("EEG F7-Ref");
            listBox2.Items.Add("EEG T3-Ref");

            listBox2.Items.Add("EEG T3-Ref");
            listBox2.Items.Add("EEG T5-Ref");

            listBox2.Items.Add("EEG T5-Ref");
            listBox2.Items.Add("EEG O1-Ref");
            
            listBox2.Items.Add("EEG Fp2-Ref");
            listBox2.Items.Add("EEG F4-Ref");

            listBox2.Items.Add("EEG F4-Ref");
            listBox2.Items.Add("EEG C4-Ref");

            listBox2.Items.Add("EEG C4-Ref");
            listBox2.Items.Add("EEG P4-Ref");

            listBox2.Items.Add("EEG P4-Ref");
            listBox2.Items.Add("EEG O2-Ref");

            listBox2.Items.Add("EEG Fp2-Ref");
            listBox2.Items.Add("EEG F8-Ref");

            listBox2.Items.Add("EEG F8-Ref");
            listBox2.Items.Add("EEG T4-Ref");

            listBox2.Items.Add("EEG T4-Ref");
            listBox2.Items.Add("EEG T6-Ref");

            listBox2.Items.Add("EEG T6-Ref");
            listBox2.Items.Add("EEG O2-Ref");

            listBox2.Items.Add("EEG FZ-Ref");
            listBox2.Items.Add("EEG CZ-Ref");

            listBox2.Items.Add("EEG CZ-Ref");
            listBox2.Items.Add("EEG PZ-Ref");
        }
        //------------------------------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
           if (edfFileInput == null)
                MessageBox.Show("Nenhum canal selecionado",
                  "Reconhecimento Automatizado de Padrões em EEG",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);   
            this.Close();
        }
        //------------------------------------------------------------------------------------------
        private void btn_derivacao_Click(object sender, EventArgs e)
        {
            NumeroDeCanais = listBox2.Items.Count/2;
            int ItemAtual = 0;
            edfComMontagem = new EdfFile(dirArquivo, false, true, false, true);
            float []vector1;
            float []vector2;
            int count = 0;
            int countT = 0;
            vector1 = new float[edfFileInput.SignalInfo[1].BufferOffset * edfFileInput.FileInfo.NrDataRecords];
            vector2 = new float[edfFileInput.SignalInfo[1].BufferOffset * edfFileInput.FileInfo.NrDataRecords];
            int bloco1 = 0;
            int bloco2 = 0;
            int loop = 0;

            for(ItemAtual = 0; ItemAtual < listBox2.Items.Count; )
            {
                //==============================
                //   Derivação com o canal par
                //==============================
                count = 0;
                for(bloco1 = 0; bloco1 < edfFileInput.FileInfo.NrDataRecords; bloco1++)
                {
                    edfFileInput.ReadDataBlock(bloco1);
                    for (int j = 0; j < edfFileInput.SignalInfo.Count; j++)
                    {
                        if (edfFileInput.SignalInfo[j].SignalLabel == listBox2.Items[ItemAtual].ToString())
                        {
                            for (int i = 0; i < edfFileInput.SignalInfo[1].BufferOffset; i++)
                            {
                                vector1[count] = edfFileInput.DataBuffer[edfFileInput.SignalInfo[j].BufferOffset + i];
                                count++;
                            }
                        }
                    }
                }
                ItemAtual++;
                //===================================
                //Derivação com o canal impar (baixo)
                //===================================
                count = 0;
                for(bloco2 = 0; bloco2 < edfFileInput.FileInfo.NrDataRecords; bloco2++)
                {
                    edfFileInput.ReadDataBlock(bloco2);
                    for (int j = 0; j < edfFileInput.SignalInfo.Count; j++)
                    {
                        if (edfFileInput.SignalInfo[j].SignalLabel == listBox2.Items[ItemAtual].ToString())
                        {
                            for (int i = 0; i < edfFileInput.SignalInfo[1].BufferOffset; i++)
                            {
                                vector2[count] = edfFileInput.DataBuffer[edfFileInput.SignalInfo[j].BufferOffset + i];
                                count++;
                            }
                        }
                    }
                }
                ItemAtual++;
                //======================================
                //Realiza a derivação e salva no arquivo
                //======================================
                float inverter = 1;
                if (checkInverter.Checked == true)
                    inverter = -1;

                countT = 0;
                for (bloco2 = 0; bloco2 < edfFileInput.FileInfo.NrDataRecords; bloco2++)
                {
                    edfComMontagem.ReadDataBlock(bloco2);
                    for (int i = 0; i < edfFileInput.SignalInfo[1].BufferOffset; i++)
                    {
                        edfComMontagem.DataBuffer[edfFileInput.SignalInfo[loop].BufferOffset + i] = (short)((inverter) * (vector1[countT] - vector2[countT]));
                        countT++;
                    }
                    edfComMontagem.WriteDataBlock(bloco2);
                }
                loop++;
            }
            //Fim das derivações
            edfFileInput = edfComMontagem;
            this.Close();
        }
        //=------------------------------------------------------------------------------
        //Carrega somente os canais selecionados
        private void button3_Click_1(object sender, EventArgs e)
        {
            NumeroDeCanais = listBox2.Items.Count;
            int ItemAtual = 0;
            edfComMontagem = new EdfFile(dirArquivo, false, true, true, true);
            float []vector1;
            int count = 0;
            int countT = 0;
            vector1 = new float[edfFileInput.SignalInfo[1].BufferOffset * edfFileInput.FileInfo.NrDataRecords];
            int bloco1 = 0;
            int bloco2 = 0;

            for (ItemAtual = 0; ItemAtual < listBox2.Items.Count; )
            {
                //==============================
                //Seleciona o canal 
                //==============================
                count = 0;
                for (bloco1 = 0; bloco1 < edfFileInput.FileInfo.NrDataRecords; bloco1++)
                {
                    edfFileInput.ReadDataBlock(bloco1);
                    for (int j = 0; j < edfFileInput.SignalInfo.Count; j++)
                    {
                        if (edfFileInput.SignalInfo[j].SignalLabel == listBox2.Items[ItemAtual].ToString())
                        {
                            for (int i = 0; i < edfFileInput.SignalInfo[1].BufferOffset; i++)
                            {
                                vector1[count] = edfFileInput.DataBuffer[edfFileInput.SignalInfo[j].BufferOffset + i];
                                count++;
                            }
                            j = edfFileInput.SignalInfo.Count + 1;//sai fora
                        }
                    }
                }
                count = 0;
                float inverter = 1;
                if (checkInverter.Checked == true)
                    inverter = -1;

                countT = 0;
                for (bloco2 = 0; bloco2 < edfFileInput.FileInfo.NrDataRecords; bloco2++)
                {
                    edfComMontagem.ReadDataBlock(bloco2);
                    for (int i = 0; i < edfFileInput.SignalInfo[1].BufferOffset; i++)
                    {
                        edfComMontagem.DataBuffer[edfFileInput.SignalInfo[ItemAtual].BufferOffset + i] = (short)(inverter * vector1[countT]);
                        countT++;
                    }
                    edfComMontagem.WriteDataBlock(bloco2);
                }
                ItemAtual++;
                edfFileInput = edfComMontagem;
                this.Close();
            }
        }
        //----------------------------------------------------------------------------------
        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            if (CountCor < 2)
            {
                CountCor++;
                myBrush = Brushes.Red;
            }
            else
            {
                if (CountCor == 3)
                    CountCor = 0;
                else
                    CountCor++;
               myBrush = Brushes.White;
            }
            if ((e.Index+1) == listBox2.Items.Count)
                CountCor = 0;

            e.Graphics.FillRectangle(myBrush, e.Bounds);

            if (e.Index > -1)
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                e.Font, Brushes.Black, e.Bounds);

            e.DrawFocusRectangle();
        }
        //----------------------------------------------------------------------------------
    }
}
