namespace AmbienteRPB
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
            this.lbxEventosPorTipo = new System.Windows.Forms.ListBox();
            this.comboTiposDeEventos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbx_Inicio = new System.Windows.Forms.CheckBox();
            this.txtComents = new System.Windows.Forms.TextBox();
            this.lbl_Coments = new System.Windows.Forms.Label();
            this.cbx_Referencia = new System.Windows.Forms.CheckBox();
            this.cbx_Fim = new System.Windows.Forms.CheckBox();
            this.checkCorrela = new System.Windows.Forms.CheckBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.edtEvento_Nome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxEventosPorTipo
            // 
            this.lbxEventosPorTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxEventosPorTipo.FormattingEnabled = true;
            this.lbxEventosPorTipo.Items.AddRange(new object[] {
            ""});
            this.lbxEventosPorTipo.Location = new System.Drawing.Point(3, 28);
            this.lbxEventosPorTipo.Name = "lbxEventosPorTipo";
            this.lbxEventosPorTipo.Size = new System.Drawing.Size(108, 498);
            this.lbxEventosPorTipo.TabIndex = 25;
            this.lbxEventosPorTipo.SelectedIndexChanged += new System.EventHandler(this.lbxEventosPorTipo_SelectedIndexChanged);
            // 
            // comboTiposDeEventos
            // 
            this.comboTiposDeEventos.FormattingEnabled = true;
            this.comboTiposDeEventos.Location = new System.Drawing.Point(32, 3);
            this.comboTiposDeEventos.Name = "comboTiposDeEventos";
            this.comboTiposDeEventos.Size = new System.Drawing.Size(79, 21);
            this.comboTiposDeEventos.TabIndex = 1;
            this.comboTiposDeEventos.Tag = "";
            this.comboTiposDeEventos.SelectedIndexChanged += new System.EventHandler(this.comboTiposDeEventos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Tipo";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.Location = new System.Drawing.Point(120, 29);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(575, 434);
            this.chart1.TabIndex = 24;
            this.chart1.Text = "chart1";
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // cbx_Inicio
            // 
            this.cbx_Inicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_Inicio.AutoSize = true;
            this.cbx_Inicio.ForeColor = System.Drawing.Color.Blue;
            this.cbx_Inicio.Location = new System.Drawing.Point(122, 472);
            this.cbx_Inicio.Name = "cbx_Inicio";
            this.cbx_Inicio.Size = new System.Drawing.Size(53, 17);
            this.cbx_Inicio.TabIndex = 28;
            this.cbx_Inicio.Text = "Início";
            this.cbx_Inicio.UseVisualStyleBackColor = true;
            this.cbx_Inicio.Click += new System.EventHandler(this.cbx_Inicio_Click);
            // 
            // txtComents
            // 
            this.txtComents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComents.Location = new System.Drawing.Point(474, 4);
            this.txtComents.Name = "txtComents";
            this.txtComents.Size = new System.Drawing.Size(223, 20);
            this.txtComents.TabIndex = 30;
            // 
            // lbl_Coments
            // 
            this.lbl_Coments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Coments.AutoSize = true;
            this.lbl_Coments.Location = new System.Drawing.Point(405, 9);
            this.lbl_Coments.Name = "lbl_Coments";
            this.lbl_Coments.Size = new System.Drawing.Size(66, 13);
            this.lbl_Coments.TabIndex = 29;
            this.lbl_Coments.Text = "Comentário: ";
            // 
            // cbx_Referencia
            // 
            this.cbx_Referencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_Referencia.AutoSize = true;
            this.cbx_Referencia.ForeColor = System.Drawing.Color.Chocolate;
            this.cbx_Referencia.Location = new System.Drawing.Point(122, 488);
            this.cbx_Referencia.Name = "cbx_Referencia";
            this.cbx_Referencia.Size = new System.Drawing.Size(78, 17);
            this.cbx_Referencia.TabIndex = 32;
            this.cbx_Referencia.Text = "Referência";
            this.cbx_Referencia.UseVisualStyleBackColor = true;
            this.cbx_Referencia.Click += new System.EventHandler(this.cbx_Referencia_Click);
            // 
            // cbx_Fim
            // 
            this.cbx_Fim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_Fim.AutoSize = true;
            this.cbx_Fim.ForeColor = System.Drawing.Color.Green;
            this.cbx_Fim.Location = new System.Drawing.Point(122, 504);
            this.cbx_Fim.Name = "cbx_Fim";
            this.cbx_Fim.Size = new System.Drawing.Size(42, 17);
            this.cbx_Fim.TabIndex = 31;
            this.cbx_Fim.Text = "Fim";
            this.cbx_Fim.UseVisualStyleBackColor = true;
            this.cbx_Fim.Click += new System.EventHandler(this.cbx_Fim_Click);
            // 
            // checkCorrela
            // 
            this.checkCorrela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkCorrela.AutoSize = true;
            this.checkCorrela.Location = new System.Drawing.Point(495, 477);
            this.checkCorrela.Name = "checkCorrela";
            this.checkCorrela.Size = new System.Drawing.Size(113, 17);
            this.checkCorrela.TabIndex = 33;
            this.checkCorrela.Text = "Selecionar Padrão";
            this.checkCorrela.UseVisualStyleBackColor = true;
            this.checkCorrela.Click += new System.EventHandler(this.checkCorrela_CheckedChanged);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Location = new System.Drawing.Point(614, 474);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(77, 22);
            this.btnSalvar.TabIndex = 26;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(614, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 22);
            this.button1.TabIndex = 27;
            this.button1.Text = "Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // edtEvento_Nome
            // 
            this.edtEvento_Nome.Location = new System.Drawing.Point(209, 4);
            this.edtEvento_Nome.Name = "edtEvento_Nome";
            this.edtEvento_Nome.Size = new System.Drawing.Size(187, 20);
            this.edtEvento_Nome.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Nome do Evento";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(699, 530);
            this.shapeContainer1.TabIndex = 34;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.rectangleShape1.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.rectangleShape1.Location = new System.Drawing.Point(119, 468);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(576, 60);
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lineShape1.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 116;
            this.lineShape1.X2 = 116;
            this.lineShape1.Y1 = -2;
            this.lineShape1.Y2 = 532;
            // 
            // FormEditorDeEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 530);
            this.Controls.Add(this.edtEvento_Nome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxEventosPorTipo);
            this.Controls.Add(this.comboTiposDeEventos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.cbx_Inicio);
            this.Controls.Add(this.txtComents);
            this.Controls.Add(this.lbl_Coments);
            this.Controls.Add(this.cbx_Referencia);
            this.Controls.Add(this.cbx_Fim);
            this.Controls.Add(this.checkCorrela);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.shapeContainer1);
            this.KeyPreview = true;
            this.Name = "FormEditorDeEventos";
            this.ShowIcon = false;
            this.Text = "Editor De Eventos";
            this.Load += new System.EventHandler(this.FormEditorDeEventos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEditorDeEventos_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxEventosPorTipo;
        private System.Windows.Forms.ComboBox comboTiposDeEventos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox cbx_Inicio;
        private System.Windows.Forms.TextBox txtComents;
        private System.Windows.Forms.Label lbl_Coments;
        private System.Windows.Forms.CheckBox cbx_Referencia;
        private System.Windows.Forms.CheckBox cbx_Fim;
        private System.Windows.Forms.CheckBox checkCorrela;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox edtEvento_Nome;
        private System.Windows.Forms.Label label3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;


    }
}