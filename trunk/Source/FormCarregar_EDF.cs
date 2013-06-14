﻿using System;
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
        private EdfFile edfComMontagem;
        private bool    MostarTela;
        //Atributo que pode ser acessado pelas outras classes, no caso clase GerenArquivos...
        //------------------------------------------------------------------------------------------
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
                    _edfFileInput = new EdfFile(dirArquivo, true, true, true, true);
                    NumeroDeCanais = _edfFileInput.FileInfo.NrSignals;
                }
                edfFileInput = _edfFileInput;
                this.Close();
            }
        }
        //------------------------------------------------------------------------------------------
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
                for (int k = 0; k < edfFileInput.SignalInfo.Count; k++)
                    listBox1.Items.Add(edfFileInput.SignalInfo[k].SignalLabel);
            }
            NumeroDeCanais = _edfFileInput.FileInfo.NrSignals;
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
            vector1 = new float[256 * _edfFileInput.FileInfo.NrDataRecords];
            vector2 = new float[256 * _edfFileInput.FileInfo.NrDataRecords];
            int bloco1 = 0;
            int bloco2 = 0;

            for(ItemAtual = 0; ItemAtual < listBox2.Items.Count; )
            {
                //==============================
                //derivação com o canal par
                //==============================
                count = 0;
                for(bloco1 = 0; bloco1 < _edfFileInput.FileInfo.NrDataRecords; bloco1++)
                {
                    _edfFileInput.ReadDataBlock(bloco1);
                    for (int j = 0; j < _edfFileInput.SignalInfo.Count; j++)
                    {
                        if (_edfFileInput.SignalInfo[j].SignalLabel == listBox2.Items[ItemAtual].ToString())
                        {
                            for (int i = 0; i < 256; i++)
                            {
                                vector1[count] = _edfFileInput.DataBuffer[_edfFileInput.SignalInfo[j].BufferOffset + i];
                                count++;
                            }
                        }
                    }
                }
                ItemAtual++;
                //===================================
                //derivação com o canal impar (baixo)
                //===================================
                count = 0;
                for(bloco2 = 0; bloco2 < _edfFileInput.FileInfo.NrDataRecords; bloco2++)
                {
                    _edfFileInput.ReadDataBlock(bloco2);
                    for (int j = 0; j < _edfFileInput.SignalInfo.Count; j++)
                    {
                        if (_edfFileInput.SignalInfo[j].SignalLabel == listBox2.Items[ItemAtual].ToString())
                        {
                            for (int i = 0; i < 256; i++)
                            {
                                vector2[count] = _edfFileInput.DataBuffer[_edfFileInput.SignalInfo[j].BufferOffset + i];
                                count++;
                            }
                        }
                    }
                }
                ItemAtual++;
                //======================================
                //Realiza a derivação e salva no arquivo
                //======================================
                countT = 0;
                for(bloco2 = 0; bloco2 < edfComMontagem.FileInfo.NrDataRecords; bloco2++)
                {
                    edfComMontagem.ReadDataBlock(bloco2);
                    for(int i = 0; i < 256; i++)
                    {
                        edfComMontagem.DataBuffer[((ItemAtual-2)*256) + i] = (short)(vector1[countT] - vector2[countT]);
                        countT++;
                    }
                    edfComMontagem.WriteDataBlock(bloco2);
                }
            }
            //Fim das derivações
            //NumeroDeCanaiscount = edfComMontagem.SignalInfo.Count();
           // while(NumeroDeCanais < edfComMontagem.SignalInfo.Count())
           //     edfComMontagem.SignalInfo.RemoveAt(NumeroDeCanais);
            edfFileInput = edfComMontagem;
            this.Close();
        }
        //------------------------------------------------------------------------------------------
    }
}
