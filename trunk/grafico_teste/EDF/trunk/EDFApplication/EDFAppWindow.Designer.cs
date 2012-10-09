namespace EDFApplication
{
    partial class EDFAppWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePatientNamesBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combineSignalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLoadedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToCompuMedicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleDownToCompuMedicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.testingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(505, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.changePatientNamesBatchToolStripMenuItem,
            this.combineSignalsToolStripMenuItem,
            this.clearLoadedFilesToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // changePatientNamesBatchToolStripMenuItem
            // 
            this.changePatientNamesBatchToolStripMenuItem.Name = "changePatientNamesBatchToolStripMenuItem";
            this.changePatientNamesBatchToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.changePatientNamesBatchToolStripMenuItem.Text = "Change Patient Names Batch";
            this.changePatientNamesBatchToolStripMenuItem.Click += new System.EventHandler(this.changePatientNamesBatchToolStripMenuItem_Click);
            // 
            // combineSignalsToolStripMenuItem
            // 
            this.combineSignalsToolStripMenuItem.Name = "combineSignalsToolStripMenuItem";
            this.combineSignalsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.combineSignalsToolStripMenuItem.Text = "Combine Signals";
            this.combineSignalsToolStripMenuItem.Click += new System.EventHandler(this.combineSignalsToolStripMenuItem_Click);
            // 
            // clearLoadedFilesToolStripMenuItem
            // 
            this.clearLoadedFilesToolStripMenuItem.Name = "clearLoadedFilesToolStripMenuItem";
            this.clearLoadedFilesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.clearLoadedFilesToolStripMenuItem.Text = "Clear Loaded Files";
            this.clearLoadedFilesToolStripMenuItem.Click += new System.EventHandler(this.clearLoadedFilesToolStripMenuItem_Click);
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToCompuMedicsToolStripMenuItem,
            this.sampleDownToCompuMedicsToolStripMenuItem});
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.testingToolStripMenuItem.Text = "Testing";
            // 
            // convertToCompuMedicsToolStripMenuItem
            // 
            this.convertToCompuMedicsToolStripMenuItem.Name = "convertToCompuMedicsToolStripMenuItem";
            this.convertToCompuMedicsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.convertToCompuMedicsToolStripMenuItem.Text = "Convert to CompuMedics";
            this.convertToCompuMedicsToolStripMenuItem.Click += new System.EventHandler(this.convertToCompuMedicsToolStripMenuItem_Click);
            // 
            // sampleDownToCompuMedicsToolStripMenuItem
            // 
            this.sampleDownToCompuMedicsToolStripMenuItem.Name = "sampleDownToCompuMedicsToolStripMenuItem";
            this.sampleDownToCompuMedicsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.sampleDownToCompuMedicsToolStripMenuItem.Text = "Sample Down and to 1Hz";
            this.sampleDownToCompuMedicsToolStripMenuItem.Click += new System.EventHandler(this.sampleDownToCompuMedicsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(505, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(121, 47);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(338, 20);
            this.txtPatientName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Patient Name";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 122);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(144, 147);
            this.listBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "EDF Signals:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "-->";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(212, 122);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(137, 147);
            this.listBox2.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "<--";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EDFAppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 404);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EDFAppWindow";
            this.Text = "EDF Application";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem changePatientNamesBatchToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToCompuMedicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sampleDownToCompuMedicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combineSignalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLoadedFilesToolStripMenuItem;

    }
}

