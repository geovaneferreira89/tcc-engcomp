﻿namespace AmbienteRPB
{
    partial class FormEditorDeEventos
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
            this.gbxEditorDeEventos = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.edtEvento_Nome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.comboTiposDeEventos = new System.Windows.Forms.ComboBox();
            this.lbxEventosPorTipo = new System.Windows.Forms.ListBox();
            this.gbxEditorDeEventos.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxEditorDeEventos
            // 
            this.gbxEditorDeEventos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxEditorDeEventos.Controls.Add(this.button1);
            this.gbxEditorDeEventos.Controls.Add(this.button2);
            this.gbxEditorDeEventos.Controls.Add(this.groupBox4);
            this.gbxEditorDeEventos.Controls.Add(this.groupBox1);
            this.gbxEditorDeEventos.Controls.Add(this.chart1);
            this.gbxEditorDeEventos.Location = new System.Drawing.Point(4, 4);
            this.gbxEditorDeEventos.Name = "gbxEditorDeEventos";
            this.gbxEditorDeEventos.Size = new System.Drawing.Size(725, 391);
            this.gbxEditorDeEventos.TabIndex = 0;
            this.gbxEditorDeEventos.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(657, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 21);
            this.button1.TabIndex = 16;
            this.button1.Text = "Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(596, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 21);
            this.button2.TabIndex = 15;
            this.button2.Text = "Salvar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.edtEvento_Nome);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(4, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(711, 37);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // edtEvento_Nome
            // 
            this.edtEvento_Nome.Location = new System.Drawing.Point(99, 11);
            this.edtEvento_Nome.Name = "edtEvento_Nome";
            this.edtEvento_Nome.Size = new System.Drawing.Size(606, 20);
            this.edtEvento_Nome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nome do Evento";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lbxEventosPorTipo);
            this.groupBox1.Controls.Add(this.comboTiposDeEventos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Location = new System.Drawing.Point(3, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 341);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Location = new System.Drawing.Point(615, 262);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(136, 35);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Freq.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Amp.";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(98, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(32, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "50";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(26, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "3";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.Location = new System.Drawing.Point(131, 57);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(587, 301);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tipo";
            // 
            // comboTiposDeEventos
            // 
            this.comboTiposDeEventos.FormattingEnabled = true;
            this.comboTiposDeEventos.Items.AddRange(new object[] {
            "Espicula",
            ".",
            ".",
            ".",
            ".",
            "testes"});
            this.comboTiposDeEventos.Location = new System.Drawing.Point(33, 13);
            this.comboTiposDeEventos.Name = "comboTiposDeEventos";
            this.comboTiposDeEventos.Size = new System.Drawing.Size(79, 21);
            this.comboTiposDeEventos.TabIndex = 14;
            this.comboTiposDeEventos.Tag = "";
            this.comboTiposDeEventos.Text = "espicula";
            // 
            // lbxEventosPorTipo
            // 
            this.lbxEventosPorTipo.FormattingEnabled = true;
            this.lbxEventosPorTipo.Items.AddRange(new object[] {
            ""});
            this.lbxEventosPorTipo.Location = new System.Drawing.Point(7, 39);
            this.lbxEventosPorTipo.Name = "lbxEventosPorTipo";
            this.lbxEventosPorTipo.Size = new System.Drawing.Size(104, 290);
            this.lbxEventosPorTipo.TabIndex = 15;
            // 
            // FormEditorDeEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 397);
            this.Controls.Add(this.gbxEditorDeEventos);
            this.Name = "FormEditorDeEventos";
            this.Text = "Editor De Eventos";
            this.gbxEditorDeEventos.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxEditorDeEventos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox edtEvento_Nome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox lbxEventosPorTipo;
        private System.Windows.Forms.ComboBox comboTiposDeEventos;
        private System.Windows.Forms.Label label4;

    }
}