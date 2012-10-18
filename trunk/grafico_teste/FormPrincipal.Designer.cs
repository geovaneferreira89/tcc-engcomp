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
            this.Box_Status = new System.Windows.Forms.StatusStrip();
            this.lbl_ferramentaAtiva = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_x = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_mouseX = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_mouseY = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.janelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_ControlesProjeto = new System.Windows.Forms.ToolStrip();
            this.btn_Resume = new System.Windows.Forms.ToolStripButton();
            this.btn_Suspender = new System.Windows.Forms.ToolStripButton();
            this.btn_MarcarPadrões = new System.Windows.Forms.ToolStripButton();
            this.tool_ControlesGerais = new System.Windows.Forms.ToolStrip();
            this.btn_novoProjeto = new System.Windows.Forms.ToolStripButton();
            this.btn_Importar = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.saveFileExplorer = new System.Windows.Forms.SaveFileDialog();
            this.openFileExplorer = new System.Windows.Forms.OpenFileDialog();
            this.check_MostrarCursorX = new System.Windows.Forms.CheckBox();
            this.openFileEDF = new System.Windows.Forms.OpenFileDialog();
            this.ScrollBar = new System.Windows.Forms.HScrollBar();
            this.gbx_Escala = new System.Windows.Forms.GroupBox();
            this.AmplitudeCombo = new System.Windows.Forms.TextBox();
            this.FrequenciaCombo = new System.Windows.Forms.ComboBox();
            this.gbx_Chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.Box_Status.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tool_ControlesProjeto.SuspendLayout();
            this.tool_ControlesGerais.SuspendLayout();
            this.gbx_Escala.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_Chart
            // 
            this.gbx_Chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Chart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbx_Chart.Controls.Add(this.chart1);
            this.gbx_Chart.Location = new System.Drawing.Point(3, 52);
            this.gbx_Chart.Name = "gbx_Chart";
            this.gbx_Chart.Size = new System.Drawing.Size(703, 268);
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
            this.chart1.Location = new System.Drawing.Point(6, 10);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chart1.Size = new System.Drawing.Size(692, 252);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouse_Mover);
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
            this.Box_Status.Location = new System.Drawing.Point(0, 341);
            this.Box_Status.Name = "Box_Status";
            this.Box_Status.Size = new System.Drawing.Size(711, 22);
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
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.configuraçõeToolStripMenuItem,
            this.ferramentasToolStripMenuItem,
            this.mapasToolStripMenuItem,
            this.estatísticasToolStripMenuItem,
            this.verToolStripMenuItem,
            this.janelaToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(711, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carregarToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // carregarToolStripMenuItem
            // 
            this.carregarToolStripMenuItem.Name = "carregarToolStripMenuItem";
            this.carregarToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.carregarToolStripMenuItem.Text = "Carregar";
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // configuraçõeToolStripMenuItem
            // 
            this.configuraçõeToolStripMenuItem.Name = "configuraçõeToolStripMenuItem";
            this.configuraçõeToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.configuraçõeToolStripMenuItem.Text = "Configuraçõe ";
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
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
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.verToolStripMenuItem.Text = "Ver";
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
            // tool_ControlesProjeto
            // 
            this.tool_ControlesProjeto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tool_ControlesProjeto.Dock = System.Windows.Forms.DockStyle.None;
            this.tool_ControlesProjeto.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_ControlesProjeto.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tool_ControlesProjeto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Resume,
            this.btn_Suspender,
            this.btn_MarcarPadrões});
            this.tool_ControlesProjeto.Location = new System.Drawing.Point(152, 24);
            this.tool_ControlesProjeto.Name = "tool_ControlesProjeto";
            this.tool_ControlesProjeto.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tool_ControlesProjeto.Size = new System.Drawing.Size(87, 31);
            this.tool_ControlesProjeto.TabIndex = 9;
            this.tool_ControlesProjeto.Text = "toolStrip1";
            // 
            // btn_Resume
            // 
            this.btn_Resume.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Resume.Enabled = false;
            this.btn_Resume.Image = ((System.Drawing.Image)(resources.GetObject("btn_Resume.Image")));
            this.btn_Resume.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Resume.Name = "btn_Resume";
            this.btn_Resume.Size = new System.Drawing.Size(28, 28);
            this.btn_Resume.Text = "Iniciar aquisição de sinal";
            this.btn_Resume.Click += new System.EventHandler(this.btn_Resume_Click);
            // 
            // btn_Suspender
            // 
            this.btn_Suspender.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Suspender.Enabled = false;
            this.btn_Suspender.Image = ((System.Drawing.Image)(resources.GetObject("btn_Suspender.Image")));
            this.btn_Suspender.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Suspender.Name = "btn_Suspender";
            this.btn_Suspender.Size = new System.Drawing.Size(28, 28);
            this.btn_Suspender.Text = "Pausar Aquisição de Sinal";
            this.btn_Suspender.Click += new System.EventHandler(this.btn_Suspender_Click);
            // 
            // btn_MarcarPadrões
            // 
            this.btn_MarcarPadrões.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_MarcarPadrões.Enabled = false;
            this.btn_MarcarPadrões.Image = ((System.Drawing.Image)(resources.GetObject("btn_MarcarPadrões.Image")));
            this.btn_MarcarPadrões.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_MarcarPadrões.Name = "btn_MarcarPadrões";
            this.btn_MarcarPadrões.Size = new System.Drawing.Size(28, 28);
            this.btn_MarcarPadrões.Text = "Definir Conjunto de Padrões";
            this.btn_MarcarPadrões.Click += new System.EventHandler(this.btn_MarcarPadrões_Click);
            // 
            // tool_ControlesGerais
            // 
            this.tool_ControlesGerais.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tool_ControlesGerais.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tool_ControlesGerais.CanOverflow = false;
            this.tool_ControlesGerais.Dock = System.Windows.Forms.DockStyle.None;
            this.tool_ControlesGerais.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tool_ControlesGerais.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tool_ControlesGerais.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_novoProjeto,
            this.btn_Importar,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton});
            this.tool_ControlesGerais.Location = new System.Drawing.Point(0, 24);
            this.tool_ControlesGerais.Name = "tool_ControlesGerais";
            this.tool_ControlesGerais.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tool_ControlesGerais.Size = new System.Drawing.Size(152, 31);
            this.tool_ControlesGerais.TabIndex = 1;
            this.tool_ControlesGerais.Text = "toolStrip2";
            // 
            // btn_novoProjeto
            // 
            this.btn_novoProjeto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_novoProjeto.Image = ((System.Drawing.Image)(resources.GetObject("btn_novoProjeto.Image")));
            this.btn_novoProjeto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_novoProjeto.Name = "btn_novoProjeto";
            this.btn_novoProjeto.Size = new System.Drawing.Size(28, 28);
            this.btn_novoProjeto.Text = "Novo projeto";
            this.btn_novoProjeto.Click += new System.EventHandler(this.btn_novoProjeto_Click);
            // 
            // btn_Importar
            // 
            this.btn_Importar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Importar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Importar.Image")));
            this.btn_Importar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Importar.Name = "btn_Importar";
            this.btn_Importar.Size = new System.Drawing.Size(28, 28);
            this.btn_Importar.Text = "Importar Arquivo";
            this.btn_Importar.Click += new System.EventHandler(this.btn_Importar_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.openToolStripButton.Text = "Abrir Projeto";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Enabled = false;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.saveToolStripButton.Text = "Salvar Projeto";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Enabled = false;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.printToolStripButton.Text = "Imprimir";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(364, 345);
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
            // check_MostrarCursorX
            // 
            this.check_MostrarCursorX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.check_MostrarCursorX.AutoSize = true;
            this.check_MostrarCursorX.Checked = true;
            this.check_MostrarCursorX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_MostrarCursorX.Location = new System.Drawing.Point(168, 12);
            this.check_MostrarCursorX.Name = "check_MostrarCursorX";
            this.check_MostrarCursorX.Size = new System.Drawing.Size(66, 17);
            this.check_MostrarCursorX.TabIndex = 12;
            this.check_MostrarCursorX.Text = "Cursor X";
            this.check_MostrarCursorX.UseVisualStyleBackColor = true;
            this.check_MostrarCursorX.CheckedChanged += new System.EventHandler(this.check_MostrarCursorX_CheckedChanged);
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
            this.ScrollBar.Location = new System.Drawing.Point(7, 321);
            this.ScrollBar.Name = "ScrollBar";
            this.ScrollBar.Size = new System.Drawing.Size(698, 20);
            this.ScrollBar.TabIndex = 13;
            this.ScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // gbx_Escala
            // 
            this.gbx_Escala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Escala.Controls.Add(this.AmplitudeCombo);
            this.gbx_Escala.Controls.Add(this.FrequenciaCombo);
            this.gbx_Escala.Controls.Add(this.check_MostrarCursorX);
            this.gbx_Escala.Location = new System.Drawing.Point(464, 20);
            this.gbx_Escala.Name = "gbx_Escala";
            this.gbx_Escala.Size = new System.Drawing.Size(242, 36);
            this.gbx_Escala.TabIndex = 14;
            this.gbx_Escala.TabStop = false;
            // 
            // AmplitudeCombo
            // 
            this.AmplitudeCombo.Enabled = false;
            this.AmplitudeCombo.Location = new System.Drawing.Point(95, 10);
            this.AmplitudeCombo.Name = "AmplitudeCombo";
            this.AmplitudeCombo.Size = new System.Drawing.Size(57, 20);
            this.AmplitudeCombo.TabIndex = 13;
            this.AmplitudeCombo.Text = "50 µ/V";
            this.AmplitudeCombo.TextChanged += new System.EventHandler(this.AmplitudeCombo_TextChanged);
            // 
            // FrequenciaCombo
            // 
            this.FrequenciaCombo.Enabled = false;
            this.FrequenciaCombo.FormattingEnabled = true;
            this.FrequenciaCombo.Items.AddRange(new object[] {
            "1,0 cm/s",
            "2,0 cm/s",
            "3,0 cm/s"});
            this.FrequenciaCombo.Location = new System.Drawing.Point(6, 10);
            this.FrequenciaCombo.Name = "FrequenciaCombo";
            this.FrequenciaCombo.Size = new System.Drawing.Size(84, 21);
            this.FrequenciaCombo.TabIndex = 10;
            this.FrequenciaCombo.Tag = "Frequencia";
            this.FrequenciaCombo.Text = "1,0 cm/s";
            this.FrequenciaCombo.TextChanged += new System.EventHandler(this.FrequenciaCombo_TextChanged);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(711, 363);
            this.Controls.Add(this.gbx_Escala);
            this.Controls.Add(this.ScrollBar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tool_ControlesGerais);
            this.Controls.Add(this.tool_ControlesProjeto);
            this.Controls.Add(this.Box_Status);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbx_Chart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.Text = "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.gbx_Chart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.Box_Status.ResumeLayout(false);
            this.Box_Status.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tool_ControlesProjeto.ResumeLayout(false);
            this.tool_ControlesProjeto.PerformLayout();
            this.tool_ControlesGerais.ResumeLayout(false);
            this.tool_ControlesGerais.PerformLayout();
            this.gbx_Escala.ResumeLayout(false);
            this.gbx_Escala.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tool_ControlesProjeto;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btn_Suspender;
        private System.Windows.Forms.ToolStripButton btn_Resume;
        private System.Windows.Forms.ToolStripButton btn_MarcarPadrões;
        private System.Windows.Forms.ToolStripButton btn_Importar;
        private System.Windows.Forms.ToolStripButton btn_novoProjeto;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripStatusLabel lbl_mouseX;
        private System.Windows.Forms.ToolStripStatusLabel lbl_mouseY;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lbl_ferramentaAtiva;
        public System.Windows.Forms.ToolStrip tool_ControlesGerais;
        private System.Windows.Forms.SaveFileDialog saveFileExplorer;
        private System.Windows.Forms.OpenFileDialog openFileExplorer;
        private System.Windows.Forms.CheckBox check_MostrarCursorX;
        private System.Windows.Forms.OpenFileDialog openFileEDF;
        private System.Windows.Forms.HScrollBar ScrollBar;
        private System.Windows.Forms.ToolStripMenuItem configuraçõeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatísticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem janelaToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbx_Escala;
        private System.Windows.Forms.TextBox AmplitudeCombo;
        private System.Windows.Forms.ComboBox FrequenciaCombo;
    }
}

