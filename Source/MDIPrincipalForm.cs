//#########################################################################################
//-----------------------------------------------------------------------------------------
//                          UNIVERSIDADE TECNOLÓGICA FEDERAL DO PARANÁ
//                              Trabalho de Conclusão de Curso
//                                Engenharia de Computação 
//
// Geovane Vinicius Ferreira (geovanevinicius89@gmail.com)
// Georgia D
// Orientador: Prof Dr. Miguel
//-----------------------------------------------------------------------------------------
//#########################################################################################
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;
using System.Reflection;
using System.Diagnostics;
using System.Deployment;


namespace AmbienteRPB
{
     
    public partial class MDIPrincipalForm : Form
    {
        FormPrincipal childForm;
        private int childFormNumber = 0;

        public MDIPrincipalForm()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            childForm = new FormPrincipal();
            childForm.MdiParent = this;
            if (childFormNumber != 0)
                childForm.Text = "Novo Projeto " + childFormNumber;
            else
                childForm.Text = "Novo Projeto";
            childFormNumber++;

            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
         
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (FormPrincipal childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIPrincipalForm_Load(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                this.Text = string.Format("Reconhecimento Automatizado de Padrões EEG - v{0}.{1}.{2}.{3}", myVersion.Major, myVersion.Minor, myVersion.Build, myVersion.Revision);
            }
         }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\nUniversidade Tecnológica Federal do Paraná\nEngenharia de Computação\nTrabalho De Conclusão de Curso\nAlunos:\nGeovane Ferreira\nGeorgia\n\nOrientador:\nMiguel\n\nCuritiba 2013",
                "Reconhecimento Automatizado de Padrões EEG",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            MessageBox.Show(path,
              "Reconhecimento Automatizado de Padrões EEG",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = System.IO.Directory.GetParent(path).ToString();
            }
            MessageBox.Show(path,
                 "Reconhecimento Automatizado de Padrões EEG",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void siteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReconhecimentoAutPadroesEEG.Form_Site form = new ReconhecimentoAutPadroesEEG.Form_Site();
            form.MdiParent = this;
            form.Text = "Web Site";
            form.Show();
        }
    }
}
