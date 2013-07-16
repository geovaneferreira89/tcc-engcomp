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
            this.SuspendLayout();
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(219, 7);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(51, 22);
            this.btn_salvar.TabIndex = 0;
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
            this.lbl_digiteONomeDoPadrao.Location = new System.Drawing.Point(9, 13);
            this.lbl_digiteONomeDoPadrao.Name = "lbl_digiteONomeDoPadrao";
            this.lbl_digiteONomeDoPadrao.Size = new System.Drawing.Size(44, 13);
            this.lbl_digiteONomeDoPadrao.TabIndex = 2;
            this.lbl_digiteONomeDoPadrao.Text = "Padrão ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tam Vetor";
            // 
            // txt_VetorTamanho
            // 
            this.txt_VetorTamanho.Location = new System.Drawing.Point(69, 34);
            this.txt_VetorTamanho.Name = "txt_VetorTamanho";
            this.txt_VetorTamanho.Size = new System.Drawing.Size(146, 20);
            this.txt_VetorTamanho.TabIndex = 3;
            // 
            // FormEditarNomePadrao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 34);
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
    }
}