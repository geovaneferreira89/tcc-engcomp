namespace AmbienteRPB
{
    partial class Carregar_EDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Carregar_EDF));
            this.button2 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_OK_EDF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_derivacao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(162, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "<--";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(209, 27);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(137, 264);
            this.listBox2.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "-->";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "EDF Sinais:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(144, 264);
            this.listBox1.TabIndex = 9;
            // 
            // btn_OK_EDF
            // 
            this.btn_OK_EDF.Location = new System.Drawing.Point(12, 307);
            this.btn_OK_EDF.Name = "btn_OK_EDF";
            this.btn_OK_EDF.Size = new System.Drawing.Size(63, 23);
            this.btn_OK_EDF.TabIndex = 1;
            this.btn_OK_EDF.Text = "Carregar";
            this.btn_OK_EDF.UseVisualStyleBackColor = true;
            this.btn_OK_EDF.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "EDF Selecionados:";
            // 
            // btn_derivacao
            // 
            this.btn_derivacao.Location = new System.Drawing.Point(209, 307);
            this.btn_derivacao.Name = "btn_derivacao";
            this.btn_derivacao.Size = new System.Drawing.Size(75, 23);
            this.btn_derivacao.TabIndex = 16;
            this.btn_derivacao.Text = "-";
            this.btn_derivacao.UseVisualStyleBackColor = true;
            this.btn_derivacao.Click += new System.EventHandler(this.btn_derivacao_Click);
            // 
            // Carregar_EDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 350);
            this.Controls.Add(this.btn_derivacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_OK_EDF);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Carregar_EDF";
            this.Text = "Abrir Arquivo .EDF";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Carregar_EDF_FormClosed);
            this.Load += new System.EventHandler(this.EDF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_OK_EDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_derivacao;
    }
}