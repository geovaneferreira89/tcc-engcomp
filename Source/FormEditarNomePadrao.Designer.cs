namespace AmbienteRPB
{
    partial class FormEditarNomePadrao
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
            this.btn_salvar = new System.Windows.Forms.Button();
            this.text_NomePadrao = new System.Windows.Forms.TextBox();
            this.lbl_digiteONomeDoPadrao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_VetorTamanho = new System.Windows.Forms.TextBox();
            this.TxtTreinarCom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckb_UseCorrel = new System.Windows.Forms.CheckBox();
            this.ckb_ListaToda = new System.Windows.Forms.CheckBox();
            this.txtPadroes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckReferencia = new System.Windows.Forms.CheckBox();
            this.ckbDebug = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(226, 7);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(51, 22);
            this.btn_salvar.TabIndex = 1;
            this.btn_salvar.Text = "Ok";
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // text_NomePadrao
            // 
            this.text_NomePadrao.Location = new System.Drawing.Point(69, 9);
            this.text_NomePadrao.Name = "text_NomePadrao";
            this.text_NomePadrao.Size = new System.Drawing.Size(146, 20);
            this.text_NomePadrao.TabIndex = 1;
            // 
            // lbl_digiteONomeDoPadrao
            // 
            this.lbl_digiteONomeDoPadrao.AutoSize = true;
            this.lbl_digiteONomeDoPadrao.Location = new System.Drawing.Point(5, 12);
            this.lbl_digiteONomeDoPadrao.Name = "lbl_digiteONomeDoPadrao";
            this.lbl_digiteONomeDoPadrao.Size = new System.Drawing.Size(44, 13);
            this.lbl_digiteONomeDoPadrao.TabIndex = 2;
            this.lbl_digiteONomeDoPadrao.Text = "Padrão ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tam Vetor";
            // 
            // txt_VetorTamanho
            // 
            this.txt_VetorTamanho.Location = new System.Drawing.Point(69, 38);
            this.txt_VetorTamanho.Name = "txt_VetorTamanho";
            this.txt_VetorTamanho.Size = new System.Drawing.Size(146, 20);
            this.txt_VetorTamanho.TabIndex = 2;
            // 
            // TxtTreinarCom
            // 
            this.TxtTreinarCom.Location = new System.Drawing.Point(69, 64);
            this.TxtTreinarCom.Name = "TxtTreinarCom";
            this.TxtTreinarCom.Size = new System.Drawing.Size(146, 20);
            this.TxtTreinarCom.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Treinar Com";
            // 
            // ckb_UseCorrel
            // 
            this.ckb_UseCorrel.AutoSize = true;
            this.ckb_UseCorrel.Location = new System.Drawing.Point(7, 113);
            this.ckb_UseCorrel.Name = "ckb_UseCorrel";
            this.ckb_UseCorrel.Size = new System.Drawing.Size(102, 17);
            this.ckb_UseCorrel.TabIndex = 6;
            this.ckb_UseCorrel.Text = "Usar Correlação";
            this.ckb_UseCorrel.UseVisualStyleBackColor = true;
            // 
            // ckb_ListaToda
            // 
            this.ckb_ListaToda.AutoSize = true;
            this.ckb_ListaToda.Checked = true;
            this.ckb_ListaToda.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_ListaToda.Location = new System.Drawing.Point(128, 90);
            this.ckb_ListaToda.Name = "ckb_ListaToda";
            this.ckb_ListaToda.Size = new System.Drawing.Size(148, 17);
            this.ckb_ListaToda.TabIndex = 4;
            this.ckb_ListaToda.Text = "Todos eventos do padrão";
            this.ckb_ListaToda.UseVisualStyleBackColor = true;
            this.ckb_ListaToda.CheckedChanged += new System.EventHandler(this.ckb_ListaToda_CheckedChanged);
            // 
            // txtPadroes
            // 
            this.txtPadroes.Enabled = false;
            this.txtPadroes.Location = new System.Drawing.Point(69, 185);
            this.txtPadroes.Name = "txtPadroes";
            this.txtPadroes.Size = new System.Drawing.Size(146, 20);
            this.txtPadroes.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(10, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Padrões";
            // 
            // ckReferencia
            // 
            this.ckReferencia.AutoSize = true;
            this.ckReferencia.Location = new System.Drawing.Point(7, 90);
            this.ckReferencia.Name = "ckReferencia";
            this.ckReferencia.Size = new System.Drawing.Size(103, 17);
            this.ckReferencia.TabIndex = 5;
            this.ckReferencia.Text = "Usar Referencia";
            this.ckReferencia.UseVisualStyleBackColor = true;
            this.ckReferencia.CheckedChanged += new System.EventHandler(this.ckReferencia_CheckedChanged);
            // 
            // ckbDebug
            // 
            this.ckbDebug.AutoSize = true;
            this.ckbDebug.Location = new System.Drawing.Point(128, 113);
            this.ckbDebug.Name = "ckbDebug";
            this.ckbDebug.Size = new System.Drawing.Size(88, 17);
            this.ckbDebug.TabIndex = 11;
            this.ckbDebug.Text = "Modo Debug";
            this.ckbDebug.UseVisualStyleBackColor = true;
            // 
            // FormEditarNomePadrao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 38);
            this.Controls.Add(this.ckbDebug);
            this.Controls.Add(this.ckReferencia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPadroes);
            this.Controls.Add(this.ckb_ListaToda);
            this.Controls.Add(this.ckb_UseCorrel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtTreinarCom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_VetorTamanho);
            this.Controls.Add(this.lbl_digiteONomeDoPadrao);
            this.Controls.Add(this.text_NomePadrao);
            this.Controls.Add(this.btn_salvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEditarNomePadrao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nome Padrão";
            this.Shown += new System.EventHandler(this.FormEditarNomePadrao_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.TextBox text_NomePadrao;
        private System.Windows.Forms.Label lbl_digiteONomeDoPadrao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_VetorTamanho;
        private System.Windows.Forms.TextBox TxtTreinarCom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckb_UseCorrel;
        private System.Windows.Forms.CheckBox ckb_ListaToda;
        private System.Windows.Forms.TextBox txtPadroes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckReferencia;
        private System.Windows.Forms.CheckBox ckbDebug;
    }
}