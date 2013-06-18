namespace AmbienteRPB
{
    partial class FormCarregar_EDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCarregar_EDF));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Montagem1 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_derivacao = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_OK_EDF = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkInverter = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Montagem1);
            this.groupBox1.Controls.Add(this.listBox2);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(109, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 390);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Canais";
            // 
            // btn_Montagem1
            // 
            this.btn_Montagem1.Location = new System.Drawing.Point(154, 86);
            this.btn_Montagem1.Name = "btn_Montagem1";
            this.btn_Montagem1.Size = new System.Drawing.Size(41, 23);
            this.btn_Montagem1.TabIndex = 16;
            this.btn_Montagem1.Text = "M1";
            this.btn_Montagem1.UseVisualStyleBackColor = true;
            this.btn_Montagem1.Click += new System.EventHandler(this.btn_Montagem1_Click);
            // 
            // listBox2
            // 
            this.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(200, 28);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(140, 355);
            this.listBox2.TabIndex = 12;
            this.listBox2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox2_DrawItem);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(144, 355);
            this.listBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(197, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "EDF Selecionados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "EDF Sinais:";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(154, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(154, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_derivacao
            // 
            this.btn_derivacao.Location = new System.Drawing.Point(8, 86);
            this.btn_derivacao.Name = "btn_derivacao";
            this.btn_derivacao.Size = new System.Drawing.Size(83, 23);
            this.btn_derivacao.TabIndex = 16;
            this.btn_derivacao.Text = "Montagem";
            this.btn_derivacao.UseVisualStyleBackColor = true;
            this.btn_derivacao.Click += new System.EventHandler(this.btn_derivacao_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Selecionados";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btn_OK_EDF
            // 
            this.btn_OK_EDF.Location = new System.Drawing.Point(8, 28);
            this.btn_OK_EDF.Name = "btn_OK_EDF";
            this.btn_OK_EDF.Size = new System.Drawing.Size(83, 23);
            this.btn_OK_EDF.TabIndex = 1;
            this.btn_OK_EDF.Text = " Todos";
            this.btn_OK_EDF.UseVisualStyleBackColor = true;
            this.btn_OK_EDF.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkInverter);
            this.groupBox2.Controls.Add(this.btn_OK_EDF);
            this.groupBox2.Controls.Add(this.btn_derivacao);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 390);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Carregar";
            // 
            // checkInverter
            // 
            this.checkInverter.AutoSize = true;
            this.checkInverter.Checked = true;
            this.checkInverter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkInverter.Location = new System.Drawing.Point(8, 115);
            this.checkInverter.Name = "checkInverter";
            this.checkInverter.Size = new System.Drawing.Size(85, 17);
            this.checkInverter.TabIndex = 18;
            this.checkInverter.Text = "Inverte Sinal";
            this.checkInverter.UseVisualStyleBackColor = true;
            // 
            // FormCarregar_EDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 392);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCarregar_EDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abrir Arquivo .EDF";
            this.Load += new System.EventHandler(this.EDF_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_derivacao;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_OK_EDF;
        private System.Windows.Forms.Button btn_Montagem1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkInverter;

    }
}