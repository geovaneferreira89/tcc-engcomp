using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;
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
         
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\nUniversidade Tecnológica Federal do Paraná\nEngenharia de Computação\nTrabalho De Conclusão de Curso\nAlunos: Geovane Ferreira\n              Georgia\nOrientador: Miguel\nCuritiba 2013",
                "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            MessageBox.Show(path,
              "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = System.IO.Directory.GetParent(path).ToString();
            }
            MessageBox.Show(path,
                 "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
