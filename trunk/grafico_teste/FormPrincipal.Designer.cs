﻿namespace AmbienteRPB
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
            this.gbxChart = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcarEventos = new System.Windows.Forms.ToolStripMenuItem();
            this.renomearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorDePadrõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canal1Canal2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.check_MostrarCursorX = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btn_Importar = new System.Windows.Forms.ToolStripButton();
            this.btn_novoProjeto = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.btn_Suspender = new System.Windows.Forms.ToolStripButton();
            this.btn_MarcarPadroes = new System.Windows.Forms.ToolStripButton();
            this.lblFreq = new System.Windows.Forms.ToolStripLabel();
            this.FrequenciaCombo = new System.Windows.Forms.ToolStripComboBox();
            this.lbl_cm = new System.Windows.Forms.ToolStripLabel();
            this.lblAmpli = new System.Windows.Forms.ToolStripLabel();
            this.AmplitudeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.lbl_V = new System.Windows.Forms.ToolStripLabel();
            this.gbxEventos = new System.Windows.Forms.GroupBox();
            this.Evento10 = new System.Windows.Forms.CheckBox();
            this.Evento9 = new System.Windows.Forms.CheckBox();
            this.Evento8 = new System.Windows.Forms.CheckBox();
            this.Evento7 = new System.Windows.Forms.CheckBox();
            this.Evento6 = new System.Windows.Forms.CheckBox();
            this.Evento5 = new System.Windows.Forms.CheckBox();
            this.Evento4 = new System.Windows.Forms.CheckBox();
            this.Evento3 = new System.Windows.Forms.CheckBox();
            this.Evento2 = new System.Windows.Forms.CheckBox();
            this.Evento1 = new System.Windows.Forms.CheckBox();
            this.infoEDF = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.Box_Status.SuspendLayout();
            this.tool_ControlesProjeto.SuspendLayout();
            this.gbxEventos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxChart
            // 
            this.gbxChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxChart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxChart.Controls.Add(this.chart1);
            this.gbxChart.Location = new System.Drawing.Point(95, 21);
            this.gbxChart.Name = "gbxChart";
            this.gbxChart.Size = new System.Drawing.Size(721, 379);
            this.gbxChart.TabIndex = 5;
            this.gbxChart.TabStop = false;
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
            this.chart1.Location = new System.Drawing.Point(6, 11);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chart1.Size = new System.Drawing.Size(710, 361);
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
            this.ferramentasToolStripMenuItem,
            this.verToolStripMenuItem,
            this.estatísticasToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(1, 1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(254, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canal1Canal2ToolStripMenuItem,
            this.marcarEventos,
            this.editorDePadrõesToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // marcarEventos
            // 
            this.marcarEventos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renomearToolStripMenuItem,
            this.novoToolStripMenuItem,
            this.excluirToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.marcarEventos.Enabled = false;
            this.marcarEventos.Name = "marcarEventos";
            this.marcarEventos.Size = new System.Drawing.Size(166, 22);
            this.marcarEventos.Text = "Marcar Eventos";
            this.marcarEventos.Click += new System.EventHandler(this.marcarPadrõesToolStripMenuItem_Click);
            // 
            // renomearToolStripMenuItem
            // 
            this.renomearToolStripMenuItem.Name = "renomearToolStripMenuItem";
            this.renomearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.renomearToolStripMenuItem.Text = "Renomear";
            this.renomearToolStripMenuItem.Click += new System.EventHandler(this.renomearToolStripMenuItem_Click);
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.novoToolStripMenuItem.Text = "Novo";
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.excluirToolStripMenuItem.Text = "Excluir";
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click_1);
            // 
            // editorDePadrõesToolStripMenuItem
            // 
            this.editorDePadrõesToolStripMenuItem.Name = "editorDePadrõesToolStripMenuItem";
            this.editorDePadrõesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.editorDePadrõesToolStripMenuItem.Text = "Editor de Padrões";
            this.editorDePadrõesToolStripMenuItem.Click += new System.EventHandler(this.editorDePadrõesToolStripMenuItem_Click);
            // 
            // canal1Canal2ToolStripMenuItem
            // 
            this.canal1Canal2ToolStripMenuItem.Enabled = false;
            this.canal1Canal2ToolStripMenuItem.Name = "canal1Canal2ToolStripMenuItem";
            this.canal1Canal2ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.canal1Canal2ToolStripMenuItem.Text = "Canal 1 - Canal 2";
            this.canal1Canal2ToolStripMenuItem.Click += new System.EventHandler(this.canal1Canal2ToolStripMenuItem_Click);
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
            this.check_MostrarCursorX,
            this.darkThemeToolStripMenuItem,
            this.infoEDF});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // check_MostrarCursorX
            // 
            this.check_MostrarCursorX.Checked = true;
            this.check_MostrarCursorX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_MostrarCursorX.Name = "check_MostrarCursorX";
            this.check_MostrarCursorX.Size = new System.Drawing.Size(163, 22);
            this.check_MostrarCursorX.Text = "Canal X";
            this.check_MostrarCursorX.CheckedChanged += new System.EventHandler(this.check_MostrarCursorX_CheckedChanged);
            // 
            // darkThemeToolStripMenuItem
            // 
            this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            this.darkThemeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.darkThemeToolStripMenuItem.Text = "Dark Theme";
            this.darkThemeToolStripMenuItem.Click += new System.EventHandler(this.darkThemeToolStripMenuItem_Click);
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
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.Box_Status.Location = new System.Drawing.Point(0, 423);
            this.Box_Status.Name = "Box_Status";
            this.Box_Status.Size = new System.Drawing.Size(820, 22);
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
            this.progressBar.Location = new System.Drawing.Point(472, 426);
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
            this.ScrollBar.Location = new System.Drawing.Point(2, 403);
            this.ScrollBar.Maximum = 20000;
            this.ScrollBar.Name = "ScrollBar";
            this.ScrollBar.Size = new System.Drawing.Size(815, 20);
            this.ScrollBar.SmallChange = 4000;
            this.ScrollBar.TabIndex = 13;
            this.ScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // tool_ControlesProjeto
            // 
            this.tool_ControlesProjeto.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tool_ControlesProjeto.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tool_ControlesProjeto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Importar,
            this.btn_novoProjeto,
            this.toolStripButton3,
            this.btn_Suspender,
            this.btn_MarcarPadroes,
            this.lblFreq,
            this.FrequenciaCombo,
            this.lbl_cm,
            this.lblAmpli,
            this.AmplitudeCombo,
            this.lbl_V});
            this.tool_ControlesProjeto.Location = new System.Drawing.Point(0, 0);
            this.tool_ControlesProjeto.Name = "tool_ControlesProjeto";
            this.tool_ControlesProjeto.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tool_ControlesProjeto.Size = new System.Drawing.Size(820, 25);
            this.tool_ControlesProjeto.TabIndex = 15;
            this.tool_ControlesProjeto.Text = "toolStrip1";
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
            // btn_novoProjeto
            // 
            this.btn_novoProjeto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_novoProjeto.Enabled = false;
            this.btn_novoProjeto.Image = ((System.Drawing.Image)(resources.GetObject("btn_novoProjeto.Image")));
            this.btn_novoProjeto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_novoProjeto.Name = "btn_novoProjeto";
            this.btn_novoProjeto.Size = new System.Drawing.Size(23, 22);
            this.btn_novoProjeto.Text = "Novo projeto";
            this.btn_novoProjeto.Click += new System.EventHandler(this.btn_novoProjeto_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Enabled = false;
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
            this.btn_Suspender.Enabled = false;
            this.btn_Suspender.Image = ((System.Drawing.Image)(resources.GetObject("btn_Suspender.Image")));
            this.btn_Suspender.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Suspender.Name = "btn_Suspender";
            this.btn_Suspender.Size = new System.Drawing.Size(23, 22);
            this.btn_Suspender.Text = "btn_Suspender";
            this.btn_Suspender.Click += new System.EventHandler(this.btn_Suspender_Click);
            // 
            // btn_MarcarPadroes
            // 
            this.btn_MarcarPadroes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_MarcarPadroes.Enabled = false;
            this.btn_MarcarPadroes.Image = ((System.Drawing.Image)(resources.GetObject("btn_MarcarPadroes.Image")));
            this.btn_MarcarPadroes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_MarcarPadroes.Name = "btn_MarcarPadroes";
            this.btn_MarcarPadroes.Size = new System.Drawing.Size(23, 22);
            this.btn_MarcarPadroes.Text = "btn_MarcarPadrões";
            this.btn_MarcarPadroes.ToolTipText = "Marcar Padroes";
            this.btn_MarcarPadroes.Click += new System.EventHandler(this.btn_MarcarPadrões_Click);
            // 
            // lblFreq
            // 
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(33, 22);
            this.lblFreq.Text = "Freq.";
            // 
            // FrequenciaCombo
            // 
            this.FrequenciaCombo.BackColor = System.Drawing.SystemColors.Window;
            this.FrequenciaCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "100",
            "200",
            "300"});
            this.FrequenciaCombo.Name = "FrequenciaCombo";
            this.FrequenciaCombo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FrequenciaCombo.Size = new System.Drawing.Size(75, 25);
            this.FrequenciaCombo.Text = "1";
            this.FrequenciaCombo.TextChanged += new System.EventHandler(this.FrequenciaCombo_TextChanged);
            // 
            // lbl_cm
            // 
            this.lbl_cm.Name = "lbl_cm";
            this.lbl_cm.Size = new System.Drawing.Size(34, 22);
            this.lbl_cm.Text = "cm/s";
            // 
            // lblAmpli
            // 
            this.lblAmpli.Name = "lblAmpli";
            this.lblAmpli.Size = new System.Drawing.Size(36, 22);
            this.lblAmpli.Text = "Amp.";
            // 
            // AmplitudeCombo
            // 
            this.AmplitudeCombo.Items.AddRange(new object[] {
            "0",
            "1",
            "10",
            "20",
            "30",
            "40",
            "50",
            "80",
            "100",
            "150",
            "200"});
            this.AmplitudeCombo.Name = "AmplitudeCombo";
            this.AmplitudeCombo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AmplitudeCombo.Size = new System.Drawing.Size(75, 25);
            this.AmplitudeCombo.Text = "50";
            this.AmplitudeCombo.TextChanged += new System.EventHandler(this.AmplitudeCombo_TextChanged);
            // 
            // lbl_V
            // 
            this.lbl_V.Name = "lbl_V";
            this.lbl_V.Size = new System.Drawing.Size(21, 22);
            this.lbl_V.Text = "uV";
            // 
            // gbxEventos
            // 
            this.gbxEventos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxEventos.Controls.Add(this.Evento10);
            this.gbxEventos.Controls.Add(this.Evento9);
            this.gbxEventos.Controls.Add(this.Evento8);
            this.gbxEventos.Controls.Add(this.Evento7);
            this.gbxEventos.Controls.Add(this.Evento6);
            this.gbxEventos.Controls.Add(this.Evento5);
            this.gbxEventos.Controls.Add(this.Evento4);
            this.gbxEventos.Controls.Add(this.Evento3);
            this.gbxEventos.Controls.Add(this.Evento2);
            this.gbxEventos.Controls.Add(this.Evento1);
            this.gbxEventos.Location = new System.Drawing.Point(2, 21);
            this.gbxEventos.Name = "gbxEventos";
            this.gbxEventos.Size = new System.Drawing.Size(89, 379);
            this.gbxEventos.TabIndex = 16;
            this.gbxEventos.TabStop = false;
            // 
            // Evento10
            // 
            this.Evento10.AutoSize = true;
            this.Evento10.Location = new System.Drawing.Point(6, 163);
            this.Evento10.Name = "Evento10";
            this.Evento10.Size = new System.Drawing.Size(75, 17);
            this.Evento10.TabIndex = 9;
            this.Evento10.Text = "Evento 10";
            this.Evento10.UseVisualStyleBackColor = true;
            this.Evento10.Click += new System.EventHandler(this.Evento10_Click);
            // 
            // Evento9
            // 
            this.Evento9.AutoSize = true;
            this.Evento9.Location = new System.Drawing.Point(6, 147);
            this.Evento9.Name = "Evento9";
            this.Evento9.Size = new System.Drawing.Size(75, 17);
            this.Evento9.TabIndex = 8;
            this.Evento9.Text = "Evento 09";
            this.Evento9.UseVisualStyleBackColor = true;
            this.Evento9.Click += new System.EventHandler(this.Evento9_Click);
            // 
            // Evento8
            // 
            this.Evento8.AutoSize = true;
            this.Evento8.Location = new System.Drawing.Point(6, 131);
            this.Evento8.Name = "Evento8";
            this.Evento8.Size = new System.Drawing.Size(75, 17);
            this.Evento8.TabIndex = 7;
            this.Evento8.Text = "Evento 08";
            this.Evento8.UseVisualStyleBackColor = true;
            this.Evento8.Click += new System.EventHandler(this.Evento8_Click);
            // 
            // Evento7
            // 
            this.Evento7.AutoSize = true;
            this.Evento7.Location = new System.Drawing.Point(6, 115);
            this.Evento7.Name = "Evento7";
            this.Evento7.Size = new System.Drawing.Size(75, 17);
            this.Evento7.TabIndex = 6;
            this.Evento7.Text = "Evento 07";
            this.Evento7.UseVisualStyleBackColor = true;
            this.Evento7.Click += new System.EventHandler(this.Evento7_Click);
            // 
            // Evento6
            // 
            this.Evento6.AutoSize = true;
            this.Evento6.Location = new System.Drawing.Point(6, 98);
            this.Evento6.Name = "Evento6";
            this.Evento6.Size = new System.Drawing.Size(75, 17);
            this.Evento6.TabIndex = 5;
            this.Evento6.Text = "Evento 06";
            this.Evento6.UseVisualStyleBackColor = true;
            this.Evento6.Click += new System.EventHandler(this.Evento6_Click);
            // 
            // Evento5
            // 
            this.Evento5.AutoSize = true;
            this.Evento5.Location = new System.Drawing.Point(6, 81);
            this.Evento5.Name = "Evento5";
            this.Evento5.Size = new System.Drawing.Size(75, 17);
            this.Evento5.TabIndex = 4;
            this.Evento5.Text = "Evento 05";
            this.Evento5.UseVisualStyleBackColor = true;
            this.Evento5.Click += new System.EventHandler(this.Evento5_Click);
            // 
            // Evento4
            // 
            this.Evento4.AutoSize = true;
            this.Evento4.Location = new System.Drawing.Point(6, 64);
            this.Evento4.Name = "Evento4";
            this.Evento4.Size = new System.Drawing.Size(75, 17);
            this.Evento4.TabIndex = 3;
            this.Evento4.Text = "Evento 04";
            this.Evento4.UseVisualStyleBackColor = true;
            this.Evento4.Click += new System.EventHandler(this.Evento4_Click);
            // 
            // Evento3
            // 
            this.Evento3.AutoSize = true;
            this.Evento3.Location = new System.Drawing.Point(6, 48);
            this.Evento3.Name = "Evento3";
            this.Evento3.Size = new System.Drawing.Size(75, 17);
            this.Evento3.TabIndex = 2;
            this.Evento3.Text = "Evento 03";
            this.Evento3.UseVisualStyleBackColor = true;
            this.Evento3.Click += new System.EventHandler(this.Evento3_Click);
            // 
            // Evento2
            // 
            this.Evento2.AutoSize = true;
            this.Evento2.Location = new System.Drawing.Point(6, 32);
            this.Evento2.Name = "Evento2";
            this.Evento2.Size = new System.Drawing.Size(75, 17);
            this.Evento2.TabIndex = 1;
            this.Evento2.Text = "Evento 02";
            this.Evento2.UseVisualStyleBackColor = true;
            this.Evento2.Click += new System.EventHandler(this.Evento2_Click);
            // 
            // Evento1
            // 
            this.Evento1.AutoSize = true;
            this.Evento1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Evento1.Location = new System.Drawing.Point(6, 15);
            this.Evento1.Name = "Evento1";
            this.Evento1.Size = new System.Drawing.Size(75, 17);
            this.Evento1.TabIndex = 0;
            this.Evento1.Text = "Evento 01";
            this.Evento1.UseVisualStyleBackColor = true;
            this.Evento1.Click += new System.EventHandler(this.Evento1_Click);
            // 
            // infoEDF
            // 
            this.infoEDF.Enabled = false;
            this.infoEDF.Name = "infoEDF";
            this.infoEDF.Size = new System.Drawing.Size(163, 22);
            this.infoEDF.Text = "Informações EDF";
            this.infoEDF.Click += new System.EventHandler(this.informaçõesEDFToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(820, 445);
            this.Controls.Add(this.tool_ControlesProjeto);
            this.Controls.Add(this.gbxEventos);
            this.Controls.Add(this.ScrollBar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.Box_Status);
            this.Controls.Add(this.gbxChart);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ambiente de Avaliação de Reconhecimento de Padrões Biomédicos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.gbxChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Box_Status.ResumeLayout(false);
            this.Box_Status.PerformLayout();
            this.tool_ControlesProjeto.ResumeLayout(false);
            this.tool_ControlesProjeto.PerformLayout();
            this.gbxEventos.ResumeLayout(false);
            this.gbxEventos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxChart;
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
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatísticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tool_ControlesProjeto;
        private System.Windows.Forms.ToolStripButton btn_novoProjeto;
        private System.Windows.Forms.ToolStripButton btn_Importar;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton btn_Suspender;
        private System.Windows.Forms.ToolStripButton btn_MarcarPadroes;
        private System.Windows.Forms.ToolStripLabel lblFreq;
        private System.Windows.Forms.ToolStripComboBox FrequenciaCombo;
        private System.Windows.Forms.ToolStripLabel lblAmpli;
        private System.Windows.Forms.ToolStripComboBox AmplitudeCombo;
        private System.Windows.Forms.ToolStripMenuItem check_MostrarCursorX;
        private System.Windows.Forms.ToolStripMenuItem editorDePadrõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel lbl_cm;
        private System.Windows.Forms.ToolStripLabel lbl_V;
        private System.Windows.Forms.ToolStripMenuItem darkThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canal1Canal2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcarEventos;
        private System.Windows.Forms.GroupBox gbxEventos;
        private System.Windows.Forms.CheckBox Evento10;
        private System.Windows.Forms.CheckBox Evento9;
        private System.Windows.Forms.CheckBox Evento8;
        private System.Windows.Forms.CheckBox Evento7;
        private System.Windows.Forms.CheckBox Evento6;
        private System.Windows.Forms.CheckBox Evento5;
        private System.Windows.Forms.CheckBox Evento4;
        private System.Windows.Forms.CheckBox Evento3;
        private System.Windows.Forms.CheckBox Evento2;
        private System.Windows.Forms.CheckBox Evento1;
        private System.Windows.Forms.ToolStripMenuItem renomearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoEDF;
    }
}

