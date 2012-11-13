namespace AmbienteRPB
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.gbx_Chart = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraçõeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaçõesEDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorDePadrõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.check_MostrarCursorX = new System.Windows.Forms.ToolStripMenuItem();
            this.janelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Box_Status = new System.Windows.Forms.StatusStrip();
            this.lbl_ferramentaAtiva = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_x = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_mouseX = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_mouseY = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.saveFileExplorer = new System.Windows.Forms.SaveFileDialog();
            this.openFileExplorer = new System.Windows.Forms.OpenFileDialog();
            this.openFileEDF = new System.Windows.Forms.OpenFileDialog();
            this.ScrollBar = new System.Windows.Forms.HScrollBar();
            this.tool_ControlesProjeto = new System.Windows.Forms.ToolStrip();
            this.btn_novoProjeto = new System.Windows.Forms.ToolStripButton();
            this.btn_Importar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.btn_Suspender = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_MarcarPadroes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.FrequenciaCombo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.AmplitudeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.lbl_cm = new System.Windows.Forms.ToolStripLabel();
            this.lbl_V = new System.Windows.Forms.ToolStripLabel();
            this.gbx_Chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.Box_Status.SuspendLayout();
            this.tool_ControlesProjeto.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_Chart
            // 
            this.gbx_Chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Chart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbx_Chart.Controls.Add(this.chart1);
            this.gbx_Chart.Location = new System.Drawing.Point(1, 21);
            this.gbx_Chart.Name = "gbx_Chart";
            this.gbx_Chart.Size = new System.Drawing.Size(705, 328);
            this.gbx_Chart.TabIndex = 5;
            this.gbx_Chart.TabStop = false;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart1.BackSecondaryColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart1.BorderlineColor = System.Drawing.SystemColors.ControlLightLight;
            this.chart1.Enabled = false;
            this.chart1.Location = new System.Drawing.Point(3, 11);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chart1.Size = new System.Drawing.Size(696, 311);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouse_Mover);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõeToolStripMenuItem,
            this.ferramentasToolStripMenuItem,
            this.mapasToolStripMenuItem,
            this.estatísticasToolStripMenuItem,
            this.verToolStripMenuItem,
            this.janelaToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(1, 1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(453, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraçõeToolStripMenuItem
            // 
            this.configuraçõeToolStripMenuItem.Name = "configuraçõeToolStripMenuItem";
            this.configuraçõeToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.configuraçõeToolStripMenuItem.Text = "Configuraçõe ";
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informaçõesEDFToolStripMenuItem,
            this.editorDePadrõesToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // informaçõesEDFToolStripMenuItem
            // 
            this.informaçõesEDFToolStripMenuItem.Name = "informaçõesEDFToolStripMenuItem";
            this.informaçõesEDFToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.informaçõesEDFToolStripMenuItem.Text = "Informações .EDF";
            this.informaçõesEDFToolStripMenuItem.Click += new System.EventHandler(this.informaçõesEDFToolStripMenuItem_Click);
            // 
            // editorDePadrõesToolStripMenuItem
            // 
            this.editorDePadrõesToolStripMenuItem.Name = "editorDePadrõesToolStripMenuItem";
            this.editorDePadrõesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.editorDePadrõesToolStripMenuItem.Text = "Editor de Padrões";
            this.editorDePadrõesToolStripMenuItem.Click += new System.EventHandler(this.editorDePadrõesToolStripMenuItem_Click);
            // 
            // mapasToolStripMenuItem
            // 
            this.mapasToolStripMenuItem.Name = "mapasToolStripMenuItem";
            this.mapasToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.mapasToolStripMenuItem.Text = "Mapas";
            // 
            // estatísticasToolStripMenuItem
            // 
            this.estatísticasToolStripMenuItem.Name = "estatísticasToolStripMenuItem";
            this.estatísticasToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.estatísticasToolStripMenuItem.Text = "Estatísticas";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.check_MostrarCursorX});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // check_MostrarCursorX
            // 
            this.check_MostrarCursorX.Checked = true;
            this.check_MostrarCursorX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_MostrarCursorX.Name = "check_MostrarCursorX";
            this.check_MostrarCursorX.Size = new System.Drawing.Size(114, 22);
            this.check_MostrarCursorX.Text = "Canal X";
            this.check_MostrarCursorX.CheckedChanged += new System.EventHandler(this.check_MostrarCursorX_CheckedChanged);
            // 
            // janelaToolStripMenuItem
            // 
            this.janelaToolStripMenuItem.Name = "janelaToolStripMenuItem";
            this.janelaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.janelaToolStripMenuItem.Text = "Janela";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // Box_Status
            // 
            this.Box_Status.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Box_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_ferramentaAtiva,
            this.lbl_x,
            this.lbl_Y,
            this.lbl_mouseX,
            this.lbl_mouseY});
            this.Box_Status.Location = new System.Drawing.Point(0, 372);
            this.Box_Status.Name = "Box_Status";
            this.Box_Status.Size = new System.Drawing.Size(709, 22);
            this.Box_Status.TabIndex = 7;
            this.Box_Status.Text = "statusStrip1";
            // 
            // lbl_ferramentaAtiva
            // 
            this.lbl_ferramentaAtiva.ForeColor = System.Drawing.Color.Brown;
            this.lbl_ferramentaAtiva.Name = "lbl_ferramentaAtiva";
            this.lbl_ferramentaAtiva.Size = new System.Drawing.Size(192, 17);
            this.lbl_ferramentaAtiva.Text = "Ferramenta Selecionada: Nenhuma";
            // 
            // lbl_x
            // 
            this.lbl_x.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_x.Name = "lbl_x";
            this.lbl_x.Size = new System.Drawing.Size(17, 17);
            this.lbl_x.Text = "X:";
            // 
            // lbl_Y
            // 
            this.lbl_Y.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Y.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Y.Name = "lbl_Y";
            this.lbl_Y.Size = new System.Drawing.Size(17, 17);
            this.lbl_Y.Text = "Y:";
            // 
            // lbl_mouseX
            // 
            this.lbl_mouseX.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_mouseX.Name = "lbl_mouseX";
            this.lbl_mouseX.Size = new System.Drawing.Size(59, 17);
            this.lbl_mouseX.Text = "Mouse X: ";
            // 
            // lbl_mouseY
            // 
            this.lbl_mouseY.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_mouseY.Name = "lbl_mouseY";
            this.lbl_mouseY.Size = new System.Drawing.Size(56, 17);
            this.lbl_mouseY.Text = "Mouse Y:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(361, 375);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(327, 14);
            this.progressBar.TabIndex = 11;
            this.progressBar.Visible = false;
            // 
            // saveFileExplorer
            // 
            this.saveFileExplorer.CreatePrompt = true;
            this.saveFileExplorer.Filter = "Arquivos de Projeto (*.rpb)|*rpb";
            // 
            // openFileExplorer
            // 
            this.openFileExplorer.Filter = "Arquivos de Projeto (*.rpb)|*.rpb|All files (*.*)|*.*\"";
            // 
            // openFileEDF
            // 
            this.openFileEDF.Filter = "Arquivos EDF (*.edf)|*.edf|All files (*.*)|*.*\"";
            // 
            // ScrollBar
            // 
            this.ScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollBar.Enabled = false;
            this.ScrollBar.LargeChange = 9000;
            this.ScrollBar.Location = new System.Drawing.Point(2, 352);
            this.ScrollBar.Maximum = 20000;
            this.ScrollBar.Name = "ScrollBar";
            this.ScrollBar.Size = new System.Drawing.Size(704, 20);
            this.ScrollBar.SmallChange = 4000;
            this.ScrollBar.TabIndex = 13;
            this.ScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // tool_ControlesProjeto
            // 
            this.tool_ControlesProjeto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_novoProjeto,
            this.btn_Importar,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.btn_Suspender,
            this.toolStripSeparator2,
            this.btn_MarcarPadroes,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.FrequenciaCombo,
            this.lbl_cm,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.AmplitudeCombo,
            this.lbl_V});
            this.tool_ControlesProjeto.Location = new System.Drawing.Point(0, 0);
            this.tool_ControlesProjeto.Name = "tool_ControlesProjeto";
            this.tool_ControlesProjeto.Size = new System.Drawing.Size(709, 25);
            this.tool_ControlesProjeto.TabIndex = 15;
            this.tool_ControlesProjeto.Text = "toolStrip1";
            // 
            // btn_novoProjeto
            // 
            this.btn_novoProjeto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_novoProjeto.Image = ((System.Drawing.Image)(resources.GetObject("btn_novoProjeto.Image")));
            this.btn_novoProjeto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_novoProjeto.Name = "btn_novoProjeto";
            this.btn_novoProjeto.Size = new System.Drawing.Size(23, 22);
            this.btn_novoProjeto.Text = "Novo projeto";
            this.btn_novoProjeto.Click += new System.EventHandler(this.btn_novoProjeto_Click);
            // 
            // btn_Importar
            // 
            this.btn_Importar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Importar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Importar.Image")));
            this.btn_Importar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Importar.Name = "btn_Importar";
            this.btn_Importar.Size = new System.Drawing.Size(23, 22);
            this.btn_Importar.Text = "btn_Importar";
            this.btn_Importar.Click += new System.EventHandler(this.btn_Importar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.btn_Resume_Click);
            // 
            // btn_Suspender
            // 
            this.btn_Suspender.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Suspender.Image = ((System.Drawing.Image)(resources.GetObject("btn_Suspender.Image")));
            this.btn_Suspender.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Suspender.Name = "btn_Suspender";
            this.btn_Suspender.Size = new System.Drawing.Size(23, 22);
            this.btn_Suspender.Text = "btn_Suspender";
            this.btn_Suspender.Click += new System.EventHandler(this.btn_Suspender_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_MarcarPadroes
            // 
            this.btn_MarcarPadroes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_MarcarPadroes.Image = ((System.Drawing.Image)(resources.GetObject("btn_MarcarPadroes.Image")));
            this.btn_MarcarPadroes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_MarcarPadroes.Name = "btn_MarcarPadroes";
            this.btn_MarcarPadroes.Size = new System.Drawing.Size(23, 22);
            this.btn_MarcarPadroes.Text = "btn_MarcarPadrões";
            this.btn_MarcarPadroes.ToolTipText = "Marcar Padroes";
            this.btn_MarcarPadroes.Click += new System.EventHandler(this.btn_MarcarPadrões_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel1.Text = "Freq.";
            // 
            // FrequenciaCombo
            // 
            this.FrequenciaCombo.Name = "FrequenciaCombo";
            this.FrequenciaCombo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FrequenciaCombo.Size = new System.Drawing.Size(75, 25);
            this.FrequenciaCombo.Text = "3";
            this.FrequenciaCombo.TextChanged += new System.EventHandler(this.FrequenciaCombo_TextChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel2.Text = "Amp.";
            // 
            // AmplitudeCombo
            // 
            this.AmplitudeCombo.Name = "AmplitudeCombo";
            this.AmplitudeCombo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AmplitudeCombo.Size = new System.Drawing.Size(75, 25);
            this.AmplitudeCombo.Text = "50";
            this.AmplitudeCombo.TextChanged += new System.EventHandler(this.AmplitudeCombo_TextChanged);
            // 
            // lbl_cm
            // 
            this.lbl_cm.Name = "lbl_cm";
            this.lbl_cm.Size = new System.Drawing.Size(34, 22);
            this.lbl_cm.Text = "cm/s";
            // 
            // lbl_V
            // 
            this.lbl_V.Name = "lbl_V";
            this.lbl_V.Size = new System.Drawing.Size(21, 22);
            this.lbl_V.Text = "uV";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(709, 394);
            this.Controls.Add(this.ScrollBar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.Box_Status);
            this.Controls.Add(this.tool_ControlesProjeto);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbx_Chart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.gbx_Chart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Box_Status.ResumeLayout(false);
            this.Box_Status.PerformLayout();
            this.tool_ControlesProjeto.ResumeLayout(false);
            this.tool_ControlesProjeto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.StatusStrip Box_Status;
        private System.Windows.Forms.ToolStripStatusLabel lbl_x;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Y;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lbl_mouseX;
        private System.Windows.Forms.ToolStripStatusLabel lbl_mouseY;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lbl_ferramentaAtiva;
        private System.Windows.Forms.SaveFileDialog saveFileExplorer;
        private System.Windows.Forms.OpenFileDialog openFileExplorer;
        private System.Windows.Forms.OpenFileDialog openFileEDF;
        private System.Windows.Forms.HScrollBar ScrollBar;
        private System.Windows.Forms.ToolStripMenuItem configuraçõeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatísticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem janelaToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tool_ControlesProjeto;
        private System.Windows.Forms.ToolStripButton btn_novoProjeto;
        private System.Windows.Forms.ToolStripButton btn_Importar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton btn_Suspender;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_MarcarPadroes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox FrequenciaCombo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox AmplitudeCombo;
        private System.Windows.Forms.ToolStripMenuItem check_MostrarCursorX;
        private System.Windows.Forms.ToolStripMenuItem informaçõesEDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorDePadrõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel lbl_cm;
        private System.Windows.Forms.ToolStripLabel lbl_V;
    }
}

