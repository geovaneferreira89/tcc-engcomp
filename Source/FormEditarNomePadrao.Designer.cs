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
            this.SuspendLayout();
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(182, 51);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(86, 24);
            this.btn_salvar.TabIndex = 0;
            this.btn_salvar.Text = "Salvar";
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // text_NomePadrao
            // 
            this.text_NomePadrao.Location = new System.Drawing.Point(10, 25);
            this.text_NomePadrao.Name = "text_NomePadrao";
            this.text_NomePadrao.Size = new System.Drawing.Size(257, 20);
            this.text_NomePadrao.TabIndex = 1;
            // 
            // lbl_digiteONomeDoPadrao
            // 
            this.lbl_digiteONomeDoPadrao.AutoSize = true;
            this.lbl_digiteONomeDoPadrao.Location = new System.Drawing.Point(7, 9);
            this.lbl_digiteONomeDoPadrao.Name = "lbl_digiteONomeDoPadrao";
            this.lbl_digiteONomeDoPadrao.Size = new System.Drawing.Size(123, 13);
            this.lbl_digiteONomeDoPadrao.TabIndex = 2;
            this.lbl_digiteONomeDoPadrao.Text = "Digite o nome do padrão";
            // 
            // FormEditarNomeEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 81);
            this.Controls.Add(this.lbl_digiteONomeDoPadrao);
            this.Controls.Add(this.text_NomePadrao);
            this.Controls.Add(this.btn_salvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEditarNomeEvento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nome Padrão";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.TextBox text_NomePadrao;
        private System.Windows.Forms.Label lbl_digiteONomeDoPadrao;
    }
}