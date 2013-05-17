﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NeuroLoopGainLibrary.Edf;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.IO;

namespace AmbienteRPB
{
    class GerenArquivos
    {
        private System.Windows.Forms.DataVisualization.Charting.Chart chart = null;
        private System.IO.StreamWriter fileW;
        private System.IO.StreamReader fileR;
        private EdfFile edfFileOutput;
        public string path;

        //Verifica se o Arquivo existe----------------------------------------------------------
        public bool ArquivoExiste(string Arquivo_Nome)
        {
            try
            {
                fileR = new System.IO.StreamReader(Arquivo_Nome);
                fileR.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Obtem Path ---------------------------------------------------------------------------
        public void PathUser()
        {
            path = System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
                path = System.IO.Directory.GetParent(path).ToString();
            path += "\\Eventos EEG\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

        }
        //Get Path -----------------------------------------------------------------------------
        public string getPathUser()
        {
            PathUser();
            return path;
        }

        //Salvar Projeto Como ----------------------------------------------------------------
        public void Salva_Projeto(string diretorio, int __numeroDeCanais, Control _Chart)
        {
            chart = _Chart as System.Windows.Forms.DataVisualization.Charting.Chart;
            string Dados_Saida; //= {"[NumDeCanais = X]","[Canal 1 = XXXXXXXX]","[Canal 2 = YYYYYY]"};
            Dados_Saida = "[NumDeCanais = " + __numeroDeCanais + "]";
            fileW = new System.IO.StreamWriter(diretorio, true);
            fileW.WriteLine(Dados_Saida);
            for (int i = 0; i < __numeroDeCanais; i++)
            {
                Dados_Saida = " ";
                fileW.WriteLine(Dados_Saida);
                Dados_Saida = "[Canal " + i + "]";
                fileW.WriteLine(Dados_Saida);
                Dados_Saida = "[Num de Pontos = " + chart.Series[i].Points.Count + "]";
                fileW.WriteLine(Dados_Saida);
                for (int j = 0; j < chart.Series[i].Points.Count; j++)
                {
                    Dados_Saida = "" + chart.Series[i].Points[j];
                    fileW.WriteLine(Dados_Saida);
                }
            }
            fileW.Close();
            MessageBox.Show("Projeto:\n" + diretorio + "\n\nSalvado com sucesso!",
               "Reconhecimento Automatizado de Padrões EEG",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Abrir Projeto  --------------------------------------------------------------------
        public int Abrir_Projeto(string diretorio)
        {
            fileR = new System.IO.StreamReader(diretorio);
            string dados;
            dados = fileR.ReadLine();
            dados = dados.Substring(15);
            dados = dados.Substring(0, dados.Length - 1);
            MessageBox.Show("Projeto:\n" + diretorio + "\n\n" + dados,
               "Reconhecimento Automatizado de Padrões EEG",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Convert.ToInt32(dados);
        }
        //Abrir Projeto EDF  -----------------------------------------------------------------
        public EdfFile Abrir_Projeto_EDF(string diretorio, bool SelecionarCanais)
        {
            FormCarregar_EDF formEDF = new FormCarregar_EDF(diretorio, SelecionarCanais);
            if (SelecionarCanais)
                formEDF.ShowDialog();
            edfFileOutput = formEDF.edfFileInput;
            return edfFileOutput;
        }
        //Exportao Padrao & Eventos-----------------------------------------------------------
        public void Exportar_Padroes_Eventos(ListaPadroesEventos[] Lista)
        {
            PathUser();
            int EvenTotal = 0;
            string _path = path;
            _path += "Padroes_Eventos.txt";

            fileW = new System.IO.StreamWriter(_path, false);
            fileW.WriteLine("[Num de Padroes = 20]");
            for (int i = 0; i < 20; i++)
            {
                fileW.WriteLine("[Padrao = " + Lista[i].GetNomePadrao() + "]");
                EvenTotal = Lista[i].GetNumeroEventos();
                fileW.WriteLine("[Eventos= " + EvenTotal + "]");
                if (EvenTotal != 0)
                {
                    for (int j = 0; j < EvenTotal; j++)
                    {
                        fileW.WriteLine("[Evento = " + Lista[i].GetNomesEvento(j) + "]");
                        fileW.WriteLine("[Inicio = " + Lista[i].GetValorInicio(j) + "]");
                        fileW.WriteLine("[Meio   = " + Lista[i].GetValorMeio(j) + "]");
                        fileW.WriteLine("[Fim    = " + Lista[i].GetValorFim(j) + "]");
                        fileW.WriteLine("[DPCanal= " + Lista[i].GetChartDataPoint(j) + "]");
                        fileW.WriteLine("[Coment = " + Lista[i].GetComentario(j) + "]");
                        fileW.WriteLine("[Color  = " + Lista[i].GetCorDeFundo(j).Name + "]");
                        fileW.WriteLine("[Compri = " + Lista[i].GetWidth(j) + "]");
                    }
                }
            }
            fileW.Close();
        }
        //Importar Padrao & Eventos------------------------------------------------------------
        public ListaPadroesEventos[] Importar_Exportar_Padroes_Eventos()
        {
            PathUser();
            string _path = path;
            _path += "Padroes_Eventos.txt";
            ListaPadroesEventos[] Lista = new ListaPadroesEventos[20];
            try
            {
                fileR = new System.IO.StreamReader(_path);
                string dados;
                int NUM = Convert.ToInt16(LerLinha(17));
                Lista = new ListaPadroesEventos[NUM];
                for (int i = 0; i < NUM; i++)
                {
                    Lista[i] = new ListaPadroesEventos();
                    Lista[i].CriarLista(0, "Null", 600);
                    //Nome do Padrao
                    Lista[i].SetNomePadrao(LerLinha(10));
                    dados = LerLinha(10);
                    Lista[i].SetNumeroEventos(Convert.ToInt16(dados));
                    if (Convert.ToInt16(dados) != 0)
                    {
                        int VarCont = Convert.ToInt16(dados);
                        PointF Aux = new PointF(0, 0);
                        string Aux_;
                        int OffSets;
                        for (int j = 0; j < VarCont; j++)
                        {
                            //Nome do Evento 
                            Lista[i].SetNomesEvento(j, LerLinha(10));
                            //Valor Inicial
                            Aux_ = LerLinha(13);
                            dados = Aux_;
                            OffSets = Aux_.IndexOf(", ");
                            Aux.X = float.Parse(Aux_.Substring(0, OffSets));
                            OffSets = OffSets + 4;
                            Aux.Y = float.Parse(dados.Substring(OffSets, dados.Length - OffSets - 1));
                            Lista[i].SetValorInicio(j, Aux);
                            //Valor Referencia
                            Aux_ = LerLinha(13);
                            dados = Aux_;
                            OffSets = Aux_.IndexOf(", ");
                            Aux.X = float.Parse(Aux_.Substring(0, OffSets));
                            OffSets = OffSets + 4;
                            Aux.Y = float.Parse(dados.Substring(OffSets, dados.Length - OffSets - 1));
                            Lista[i].SetValorMeio(j, Aux);
                            //Valor Final
                            Aux_ = LerLinha(13);
                            dados = Aux_;
                            OffSets = Aux_.IndexOf(", ");
                            Aux.X = float.Parse(Aux_.Substring(0, OffSets));
                            OffSets = OffSets + 4;
                            Aux.Y = float.Parse(dados.Substring(OffSets, dados.Length - OffSets - 1));
                            Lista[i].SetValorFim(j, Aux);
                            //Data point do canal
                            Lista[i].SetChartDataPoint(j, Convert.ToInt16(LerLinha(10)));
                            //Comentario
                            Lista[i].SetComentario(j, LerLinha(10));
                            //Cor
                            Lista[i].SetCorDeFundo(j, Color.FromName(LerLinha(10)));
                            //Comprimento
                            Lista[i].SetWidth(j, float.Parse(LerLinha(10)));
                        }

                    }
                }
                fileR.Close();
                return Lista;
            }
            catch
            {
                fileR.Close();
                MessageBox.Show("Erro ao carregar arquivo",
                       "Reconhecimento Automatizado de Padrões EEG",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }
        //Ler Linha    -----------------------------------------------------------------
        private string LerLinha(int Offset)
        {
            string dados;
            dados = fileR.ReadLine();
            dados = dados.Substring(Offset);
            dados = dados.Substring(0, dados.Length - 1);
            return dados;
        }
        //Cria Licença-----------------------------------------------------------------
        public void CriarLicenca(string Name, string email, string serial)
        {
            PathUser();
            string _path = path;
            _path += "RegSW.lic";
            fileW = new System.IO.StreamWriter(_path, false);
            fileW.WriteLine("[Nome   = " + Name + "]");
            fileW.WriteLine("[Email  = " + email + "]");
            fileW.WriteLine("[Meio   = " + serial + "]");
            fileW.Close();
            MessageBox.Show("Licença ativada",
                             "Reconhecimento Automatizado de Padrões EEG",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Verifica Licença Existe------------------------------------------------------
        public bool VerificaLicencaExiste()
        {
            string lic = System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
                lic = System.IO.Directory.GetParent(lic).ToString();
            lic += "\\Eventos EEG\\RegSW.lic";
            if (!File.Exists(lic))
                return false;
            else
                return true;

        }
        //---------------------------------------------------------------------
    }
}
