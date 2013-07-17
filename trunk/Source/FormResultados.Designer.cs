﻿namespace AmbienteRPB
{
    partial class FormResultados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResultados));
            this.ScrollBar = new System.Windows.Forms.HScrollBar();
            this.Box_Status = new System.Windows.Forms.StatusStrip();
            this.lbl_ferramentaAtiva = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_x = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_mouseX = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_mouseY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbxChart = new System.Windows.Forms.GroupBox();
            this.lbl_Tempo = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_SinalProximo = new System.Windows.Forms.ToolStripButton();
            this.btn_SinalAnterior = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.btn_Suspender = new System.Windows.Forms.ToolStripButton();
            this.CorrelAgain = new System.Windows.Forms.ToolStripButton();
            this.BTN_Kohonen = new System.Windows.Forms.ToolStripButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SMS_Box = new System.Windows.Forms.RichTextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.comboFrequencia = new System.Windows.Forms.ToolStripComboBox();
            this.btn_Aumentar = new System.Windows.Forms.Button();
            this.Box_Status.SuspendLayout();
            this.gbxChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScrollBar
            // 
            this.ScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollBar.LargeChange = 900;
            this.ScrollBar.Location = new System.Drawing.Point(0, 396);
            this.ScrollBar.Maximum = 20000;
            this.ScrollBar.Name = "ScrollBar";
            this.ScrollBar.Size = new System.Drawing.Size(740, 20);
            this.ScrollBar.SmallChange = 900;
            this.ScrollBar.TabIndex = 16;
            this.ScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // Box_Status
            // 
            this.Box_Status.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Box_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_ferramentaAtiva,
            this.lbl_x,
            this.lbl_Y,
            this.lbl_mouseX,
            this.lbl_mouseY,
            this.toolInfo});
            this.Box_Status.Location = new System.Drawing.Point(0, 416);
            this.Box_Status.Name = "Box_Status";
            this.Box_Status.Size = new System.Drawing.Size(740, 22);
            this.Box_Status.TabIndex = 15;
            this.Box_Status.Text = "statusStrip1";
            // 
            // lbl_ferramentaAtiva
            // 
            this.lbl_ferramentaAtiva.ForeColor = System.Drawing.Color.Brown;
            this.lbl_ferramentaAtiva.Name = "lbl_ferramentaAtiva";
            this.lbl_ferramentaAtiva.Size = new System.Drawing.Size(49, 17);
            this.lbl_ferramentaAtiva.Text = "Iniciado";
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
            // toolInfo
            // 
            this.toolInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInfo.Name = "toolInfo";
            this.toolInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // gbxChart
            // 
            this.gbxChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxChart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gbxChart.Controls.Add(this.lbl_Tempo);
            this.gbxChart.Controls.Add(this.chart1);
            this.gbxChart.Location = new System.Drawing.Point(0, 22);
            this.gbxChart.Name = "gbxChart";
            this.gbxChart.Size = new System.Drawing.Size(738, 265);
            this.gbxChart.TabIndex = 17;
            this.gbxChart.TabStop = false;
            // 
            // lbl_Tempo
            // 
            this.lbl_Tempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Tempo.AutoSize = true;
            this.lbl_Tempo.BackColor = System.Drawing.Color.White;
            this.lbl_Tempo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tempo.Location = new System.Drawing.Point(3, 247);
            this.lbl_Tempo.Name = "lbl_Tempo";
            this.lbl_Tempo.Size = new System.Drawing.Size(102, 14);
            this.lbl_Tempo.TabIndex = 18;
            this.lbl_Tempo.Text = "00:00:00 (00:00:00)";
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
            this.chart1.Location = new System.Drawing.Point(1, 7);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chart1.Size = new System.Drawing.Size(735, 256);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_SinalProximo,
            this.btn_SinalAnterior,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.btn_Suspender,
            this.CorrelAgain,
            this.BTN_Kohonen,
            this.comboFrequencia});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(740, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_SinalProximo
            // 
            this.btn_SinalProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_SinalProximo.Image = ((System.Drawing.Image)(resources.GetObject("btn_SinalProximo.Image")));
            this.btn_SinalProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SinalProximo.Name = "btn_SinalProximo";
            this.btn_SinalProximo.Size = new System.Drawing.Size(23, 22);
            this.btn_SinalProximo.Text = "V";
            this.btn_SinalProximo.Click += new System.EventHandler(this.btn_SinalProximo_Click);
            // 
            // btn_SinalAnterior
            // 
            this.btn_SinalAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_SinalAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btn_SinalAnterior.Image")));
            this.btn_SinalAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SinalAnterior.Name = "btn_SinalAnterior";
            this.btn_SinalAnterior.Size = new System.Drawing.Size(23, 22);
            this.btn_SinalAnterior.Text = "^";
            this.btn_SinalAnterior.Click += new System.EventHandler(this.btn_SinalAnterior_Click);
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
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
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
            // CorrelAgain
            // 
            this.CorrelAgain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CorrelAgain.Image = ((System.Drawing.Image)(resources.GetObject("CorrelAgain.Image")));
            this.CorrelAgain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CorrelAgain.Name = "CorrelAgain";
            this.CorrelAgain.Size = new System.Drawing.Size(23, 22);
            this.CorrelAgain.Text = "toolStripButton1";
            this.CorrelAgain.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // BTN_Kohonen
            // 
            this.BTN_Kohonen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTN_Kohonen.Image = ((System.Drawing.Image)(resources.GetObject("BTN_Kohonen.Image")));
            this.BTN_Kohonen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_Kohonen.Name = "BTN_Kohonen";
            this.BTN_Kohonen.Size = new System.Drawing.Size(59, 22);
            this.BTN_Kohonen.Text = "Kohonen";
            this.BTN_Kohonen.Click += new System.EventHandler(this.BTN_Kohonen_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBar.Location = new System.Drawing.Point(497, 418);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(240, 19);
            this.progressBar.TabIndex = 19;
            this.progressBar.Visible = false;
            // 
            // SMS_Box
            // 
            this.SMS_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SMS_Box.Location = new System.Drawing.Point(2, 289);
            this.SMS_Box.Name = "SMS_Box";
            this.SMS_Box.Size = new System.Drawing.Size(734, 105);
            this.SMS_Box.TabIndex = 20;
            this.SMS_Box.Text = "";
            this.SMS_Box.Visible = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(659, 293);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(23, 19);
            this.btn_Close.TabIndex = 21;
            this.btn_Close.Text = "↓";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Visible = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // comboFrequencia
            // 
            this.comboFrequencia.Name = "comboFrequencia";
            this.comboFrequencia.Size = new System.Drawing.Size(75, 25);
            this.comboFrequencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboFrequencia_KeyDown);
            // 
            // btn_Aumentar
            // 
            this.btn_Aumentar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Aumentar.Location = new System.Drawing.Point(688, 293);
            this.btn_Aumentar.Name = "btn_Aumentar";
            this.btn_Aumentar.Size = new System.Drawing.Size(23, 19);
            this.btn_Aumentar.TabIndex = 22;
            this.btn_Aumentar.Text = "↑";
            this.btn_Aumentar.UseVisualStyleBackColor = true;
            this.btn_Aumentar.Visible = false;
            this.btn_Aumentar.Click += new System.EventHandler(this.btn_Aumentar_Click);
            // 
            // FormResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 438);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Aumentar);
            this.Controls.Add(this.SMS_Box);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbxChart);
            this.Controls.Add(this.ScrollBar);
            this.Controls.Add(this.Box_Status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormResultados";
            this.Text = "Técnica de Reconhecimento -- Correlação ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormResultados_Shown);
            this.Box_Status.ResumeLayout(false);
            this.Box_Status.PerformLayout();
            this.gbxChart.ResumeLayout(false);
            this.gbxChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar ScrollBar;
        private System.Windows.Forms.StatusStrip Box_Status;
        private System.Windows.Forms.ToolStripStatusLabel lbl_ferramentaAtiva;
        private System.Windows.Forms.ToolStripStatusLabel lbl_x;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Y;
        private System.Windows.Forms.ToolStripStatusLabel lbl_mouseX;
        private System.Windows.Forms.ToolStripStatusLabel lbl_mouseY;
        private System.Windows.Forms.ToolStripStatusLabel toolInfo;
        private System.Windows.Forms.GroupBox gbxChart;
        private System.Windows.Forms.Label lbl_Tempo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_SinalProximo;
        private System.Windows.Forms.ToolStripButton btn_SinalAnterior;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton btn_Suspender;
        private System.Windows.Forms.ToolStripButton CorrelAgain;
        private System.Windows.Forms.ToolStripButton BTN_Kohonen;
        private System.Windows.Forms.RichTextBox SMS_Box;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ToolStripComboBox comboFrequencia;
        private System.Windows.Forms.Button btn_Aumentar;
    }
}