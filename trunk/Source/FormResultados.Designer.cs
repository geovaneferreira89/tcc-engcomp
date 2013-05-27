namespace AmbienteRPB
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
            this.btn_SinalRetroceder = new System.Windows.Forms.ToolStripButton();
            this.btn_SinalProximo = new System.Windows.Forms.ToolStripButton();
            this.btn_SinalAnterior = new System.Windows.Forms.ToolStripButton();
            this.btn_SinalAvancar = new System.Windows.Forms.ToolStripButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
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
            this.ScrollBar.Location = new System.Drawing.Point(0, 404);
            this.ScrollBar.Maximum = 20000;
            this.ScrollBar.Name = "ScrollBar";
            this.ScrollBar.Size = new System.Drawing.Size(668, 20);
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
            this.Box_Status.Location = new System.Drawing.Point(0, 424);
            this.Box_Status.Name = "Box_Status";
            this.Box_Status.Size = new System.Drawing.Size(668, 22);
            this.Box_Status.TabIndex = 15;
            this.Box_Status.Text = "statusStrip1";
            // 
            // lbl_ferramentaAtiva
            // 
            this.lbl_ferramentaAtiva.ForeColor = System.Drawing.Color.Brown;
            this.lbl_ferramentaAtiva.Name = "lbl_ferramentaAtiva";
            this.lbl_ferramentaAtiva.Size = new System.Drawing.Size(44, 17);
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
            this.lbl_mouseX.Size = new System.Drawing.Size(54, 17);
            this.lbl_mouseX.Text = "Mouse X: ";
            // 
            // lbl_mouseY
            // 
            this.lbl_mouseY.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_mouseY.Name = "lbl_mouseY";
            this.lbl_mouseY.Size = new System.Drawing.Size(51, 17);
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
            this.gbxChart.Size = new System.Drawing.Size(666, 381);
            this.gbxChart.TabIndex = 17;
            this.gbxChart.TabStop = false;
            // 
            // lbl_Tempo
            // 
            this.lbl_Tempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Tempo.AutoSize = true;
            this.lbl_Tempo.BackColor = System.Drawing.Color.White;
            this.lbl_Tempo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tempo.Location = new System.Drawing.Point(3, 362);
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
            this.chart1.Size = new System.Drawing.Size(663, 372);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_SinalRetroceder,
            this.btn_SinalProximo,
            this.btn_SinalAnterior,
            this.btn_SinalAvancar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(668, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_SinalRetroceder
            // 
            this.btn_SinalRetroceder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_SinalRetroceder.Image = ((System.Drawing.Image)(resources.GetObject("btn_SinalRetroceder.Image")));
            this.btn_SinalRetroceder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SinalRetroceder.Name = "btn_SinalRetroceder";
            this.btn_SinalRetroceder.Size = new System.Drawing.Size(27, 22);
            this.btn_SinalRetroceder.Text = "<<";
            this.btn_SinalRetroceder.Click += new System.EventHandler(this.btn_SinalRetroceder_Click);
            // 
            // btn_SinalProximo
            // 
            this.btn_SinalProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_SinalProximo.Image = ((System.Drawing.Image)(resources.GetObject("btn_SinalProximo.Image")));
            this.btn_SinalProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SinalProximo.Name = "btn_SinalProximo";
            this.btn_SinalProximo.Size = new System.Drawing.Size(23, 22);
            this.btn_SinalProximo.Text = "V";
            this.btn_SinalProximo.Click += new System.EventHandler(this.btn_SinalProximo_Click);
            // 
            // btn_SinalAnterior
            // 
            this.btn_SinalAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_SinalAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SinalAnterior.Name = "btn_SinalAnterior";
            this.btn_SinalAnterior.Size = new System.Drawing.Size(23, 22);
            this.btn_SinalAnterior.Text = "^";
            this.btn_SinalAnterior.Click += new System.EventHandler(this.btn_SinalAnterior_Click);
            // 
            // btn_SinalAvancar
            // 
            this.btn_SinalAvancar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_SinalAvancar.Image = ((System.Drawing.Image)(resources.GetObject("btn_SinalAvancar.Image")));
            this.btn_SinalAvancar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_SinalAvancar.Name = "btn_SinalAvancar";
            this.btn_SinalAvancar.Size = new System.Drawing.Size(27, 22);
            this.btn_SinalAvancar.Text = ">>";
            this.btn_SinalAvancar.Click += new System.EventHandler(this.btn_SinalAvancar_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(521, 430);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(127, 12);
            this.progressBar.TabIndex = 19;
            this.progressBar.Visible = false;
            // 
            // FormResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 446);
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
        private System.Windows.Forms.ToolStripButton btn_SinalRetroceder;
        private System.Windows.Forms.ToolStripButton btn_SinalProximo;
        private System.Windows.Forms.ToolStripButton btn_SinalAnterior;
        private System.Windows.Forms.ToolStripButton btn_SinalAvancar;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}