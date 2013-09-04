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
            this.btn_SinalProximo = new System.Windows.Forms.ToolStripButton();
            this.btn_SinalAnterior = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.correlaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segundaCorrelacao = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.kohonenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redeMLPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarRedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarRedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMarcacoes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.opcCANAL = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboFrequencia = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ampliMAIS = new System.Windows.Forms.ToolStripButton();
            this.ampliMENOS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.offsetCIMA = new System.Windows.Forms.ToolStripButton();
            this.offsetBAIXO = new System.Windows.Forms.ToolStripButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SMS_Box = new System.Windows.Forms.RichTextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Aumentar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAnalise = new System.Windows.Forms.ToolStripSplitButton();
            this.AnaliseMLP = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ScrollBar.Location = new System.Drawing.Point(0, 515);
            this.ScrollBar.Maximum = 20000;
            this.ScrollBar.Name = "ScrollBar";
            this.ScrollBar.Size = new System.Drawing.Size(836, 20);
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
            this.Box_Status.Location = new System.Drawing.Point(0, 535);
            this.Box_Status.Name = "Box_Status";
            this.Box_Status.Size = new System.Drawing.Size(836, 22);
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
            this.gbxChart.Size = new System.Drawing.Size(834, 384);
            this.gbxChart.TabIndex = 17;
            this.gbxChart.TabStop = false;
            // 
            // lbl_Tempo
            // 
            this.lbl_Tempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Tempo.AutoSize = true;
            this.lbl_Tempo.BackColor = System.Drawing.Color.White;
            this.lbl_Tempo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tempo.Location = new System.Drawing.Point(3, 366);
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
            this.chart1.Size = new System.Drawing.Size(831, 375);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_SinalProximo,
            this.btn_SinalAnterior,
            this.toolStripSeparator9,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.btnMarcacoes,
            this.toolAnalise,
            this.toolStripSeparator8,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.toolStripSeparator7,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.toolStripLabel4,
            this.opcCANAL,
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.comboFrequencia,
            this.toolStripSeparator11,
            this.toolStripLabel2,
            this.ampliMAIS,
            this.ampliMENOS,
            this.toolStripSeparator12,
            this.toolStripLabel3,
            this.offsetCIMA,
            this.offsetBAIXO});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(836, 25);
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
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.correlaçãoToolStripMenuItem,
            this.segundaCorrelacao,
            this.toolStripSeparator10,
            this.kohonenToolStripMenuItem,
            this.redeMLPToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(66, 22);
            this.toolStripDropDownButton1.Text = "Técnicas";
            // 
            // correlaçãoToolStripMenuItem
            // 
            this.correlaçãoToolStripMenuItem.Name = "correlaçãoToolStripMenuItem";
            this.correlaçãoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.correlaçãoToolStripMenuItem.Text = "Correlação";
            this.correlaçãoToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // segundaCorrelacao
            // 
            this.segundaCorrelacao.Enabled = false;
            this.segundaCorrelacao.Name = "segundaCorrelacao";
            this.segundaCorrelacao.Size = new System.Drawing.Size(152, 22);
            this.segundaCorrelacao.Text = "2ª Correlação ";
            this.segundaCorrelacao.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(149, 6);
            // 
            // kohonenToolStripMenuItem
            // 
            this.kohonenToolStripMenuItem.Name = "kohonenToolStripMenuItem";
            this.kohonenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kohonenToolStripMenuItem.Text = "Kohonen";
            this.kohonenToolStripMenuItem.Click += new System.EventHandler(this.BTN_Kohonen_Click);
            // 
            // redeMLPToolStripMenuItem
            // 
            this.redeMLPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvarRedeToolStripMenuItem,
            this.importarRedeToolStripMenuItem,
            this.toolStripSeparator13});
            this.redeMLPToolStripMenuItem.Name = "redeMLPToolStripMenuItem";
            this.redeMLPToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redeMLPToolStripMenuItem.Text = "Rede MLP";
            this.redeMLPToolStripMenuItem.Click += new System.EventHandler(this.btn_BackPropagation_Click);
            // 
            // salvarRedeToolStripMenuItem
            // 
            this.salvarRedeToolStripMenuItem.Enabled = false;
            this.salvarRedeToolStripMenuItem.Name = "salvarRedeToolStripMenuItem";
            this.salvarRedeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salvarRedeToolStripMenuItem.Text = "Salvar Rede";
            this.salvarRedeToolStripMenuItem.Click += new System.EventHandler(this.salvarRedeToolStripMenuItem_Click);
            // 
            // importarRedeToolStripMenuItem
            // 
            this.importarRedeToolStripMenuItem.Name = "importarRedeToolStripMenuItem";
            this.importarRedeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importarRedeToolStripMenuItem.Text = "Importar Rede";
            this.importarRedeToolStripMenuItem.Click += new System.EventHandler(this.importarRedeToolStripMenuItem_Click);
            // 
            // btnMarcacoes
            // 
            this.btnMarcacoes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMarcacoes.Image = ((System.Drawing.Image)(resources.GetObject("btnMarcacoes.Image")));
            this.btnMarcacoes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarcacoes.Name = "btnMarcacoes";
            this.btnMarcacoes.Size = new System.Drawing.Size(71, 22);
            this.btnMarcacoes.Text = "Marcações ";
            this.btnMarcacoes.Click += new System.EventHandler(this.btnMarcacoes_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel4.Text = "Canal";
            // 
            // opcCANAL
            // 
            this.opcCANAL.Name = "opcCANAL";
            this.opcCANAL.Size = new System.Drawing.Size(20, 25);
            this.opcCANAL.Text = "1";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel1.Text = "Freq.";
            // 
            // comboFrequencia
            // 
            this.comboFrequencia.Name = "comboFrequencia";
            this.comboFrequencia.Size = new System.Drawing.Size(75, 25);
            this.comboFrequencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboFrequencia_KeyDown);
            this.comboFrequencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboFrequencia_KeyPress);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel2.Text = "Amp.";
            // 
            // ampliMAIS
            // 
            this.ampliMAIS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ampliMAIS.Image = ((System.Drawing.Image)(resources.GetObject("ampliMAIS.Image")));
            this.ampliMAIS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ampliMAIS.Name = "ampliMAIS";
            this.ampliMAIS.Size = new System.Drawing.Size(23, 22);
            this.ampliMAIS.Text = "toolStripButton1";
            this.ampliMAIS.Click += new System.EventHandler(this.toolStripButton1_Click_2);
            // 
            // ampliMENOS
            // 
            this.ampliMENOS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ampliMENOS.Image = ((System.Drawing.Image)(resources.GetObject("ampliMENOS.Image")));
            this.ampliMENOS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ampliMENOS.Name = "ampliMENOS";
            this.ampliMENOS.Size = new System.Drawing.Size(23, 22);
            this.ampliMENOS.Text = "toolStripButton2";
            this.ampliMENOS.Click += new System.EventHandler(this.ampliMENOS_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel3.Text = "Offset";
            // 
            // offsetCIMA
            // 
            this.offsetCIMA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.offsetCIMA.Image = ((System.Drawing.Image)(resources.GetObject("offsetCIMA.Image")));
            this.offsetCIMA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.offsetCIMA.Name = "offsetCIMA";
            this.offsetCIMA.Size = new System.Drawing.Size(23, 22);
            this.offsetCIMA.Text = "toolStripButton1";
            this.offsetCIMA.Click += new System.EventHandler(this.offsetCIMA_Click);
            // 
            // offsetBAIXO
            // 
            this.offsetBAIXO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.offsetBAIXO.Image = ((System.Drawing.Image)(resources.GetObject("offsetBAIXO.Image")));
            this.offsetBAIXO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.offsetBAIXO.Name = "offsetBAIXO";
            this.offsetBAIXO.Size = new System.Drawing.Size(23, 22);
            this.offsetBAIXO.Text = "toolStripButton2";
            this.offsetBAIXO.Click += new System.EventHandler(this.offsetBAIXO_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBar.Location = new System.Drawing.Point(593, 537);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(240, 19);
            this.progressBar.TabIndex = 19;
            this.progressBar.Visible = false;
            // 
            // SMS_Box
            // 
            this.SMS_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SMS_Box.Location = new System.Drawing.Point(2, 408);
            this.SMS_Box.Name = "SMS_Box";
            this.SMS_Box.Size = new System.Drawing.Size(830, 105);
            this.SMS_Box.TabIndex = 20;
            this.SMS_Box.Text = "";
            this.SMS_Box.Visible = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(755, 412);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(23, 19);
            this.btn_Close.TabIndex = 21;
            this.btn_Close.Text = "↓";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Visible = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Aumentar
            // 
            this.btn_Aumentar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Aumentar.Location = new System.Drawing.Point(784, 412);
            this.btn_Aumentar.Name = "btn_Aumentar";
            this.btn_Aumentar.Size = new System.Drawing.Size(23, 19);
            this.btn_Aumentar.TabIndex = 22;
            this.btn_Aumentar.Text = "↑";
            this.btn_Aumentar.UseVisualStyleBackColor = true;
            this.btn_Aumentar.Visible = false;
            this.btn_Aumentar.Click += new System.EventHandler(this.btn_Aumentar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Arquivos XML (*.xml)|*xml";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(149, 6);
            // 
            // toolAnalise
            // 
            this.toolAnalise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolAnalise.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnaliseMLP});
            this.toolAnalise.Enabled = false;
            this.toolAnalise.Image = ((System.Drawing.Image)(resources.GetObject("toolAnalise.Image")));
            this.toolAnalise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAnalise.Name = "toolAnalise";
            this.toolAnalise.Size = new System.Drawing.Size(61, 22);
            this.toolAnalise.Text = "Análise";
            // 
            // AnaliseMLP
            // 
            this.AnaliseMLP.Name = "AnaliseMLP";
            this.AnaliseMLP.Size = new System.Drawing.Size(152, 22);
            this.AnaliseMLP.Text = "MLP ";
            this.AnaliseMLP.Click += new System.EventHandler(this.AnaliseMLP_Click);
            // 
            // FormResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 557);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Aumentar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbxChart);
            this.Controls.Add(this.ScrollBar);
            this.Controls.Add(this.Box_Status);
            this.Controls.Add(this.SMS_Box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormResultados";
            this.Text = "Técnicas de Reconhecimento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormResultados_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormResultados_FormClosed);
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
        private System.Windows.Forms.RichTextBox SMS_Box;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ToolStripComboBox comboFrequencia;
        private System.Windows.Forms.Button btn_Aumentar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnMarcacoes;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton ampliMAIS;
        private System.Windows.Forms.ToolStripButton ampliMENOS;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton offsetCIMA;
        private System.Windows.Forms.ToolStripButton offsetBAIXO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem correlaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kohonenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redeMLPToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox opcCANAL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem segundaCorrelacao;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem salvarRedeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarRedeToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripSplitButton toolAnalise;
        private System.Windows.Forms.ToolStripMenuItem AnaliseMLP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
    }
}