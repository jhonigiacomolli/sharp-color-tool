namespace Sharp_Color_Tool
{
    partial class frmNumeroPedido
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
            System.Windows.Forms.PictureBox picFavIcon;
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.txtNumeroPedido = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.cboOperacao = new System.Windows.Forms.ComboBox();
            picFavIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(picFavIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // picFavIcon
            // 
            picFavIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            picFavIcon.BackgroundImage = global::Sharp_Color_Tool.Properties.Resources.FavIcon_25px_;
            picFavIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            picFavIcon.Location = new System.Drawing.Point(3, 0);
            picFavIcon.Name = "picFavIcon";
            picFavIcon.Size = new System.Drawing.Size(25, 25);
            picFavIcon.TabIndex = 36;
            picFavIcon.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTitulo.Location = new System.Drawing.Point(34, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(111, 13);
            this.lblTitulo.TabIndex = 35;
            this.lblTitulo.Text = "Numero do Pedido";
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            this.lblTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseMove);
            this.lblTitulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseUp);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Silver;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(332, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(35, 25);
            this.btnFechar.TabIndex = 33;
            this.btnFechar.Text = "X";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 25);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // txtMensagem
            // 
            this.txtMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensagem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.txtMensagem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtMensagem.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtMensagem.Location = new System.Drawing.Point(25, 77);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(310, 41);
            this.txtMensagem.TabIndex = 37;
            this.txtMensagem.Text = "Insira abaixo o numero do PEDIDO a qual se destina esta tinta";
            this.txtMensagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumeroPedido
            // 
            this.txtNumeroPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtNumeroPedido.Location = new System.Drawing.Point(99, 114);
            this.txtNumeroPedido.Name = "txtNumeroPedido";
            this.txtNumeroPedido.Size = new System.Drawing.Size(169, 23);
            this.txtNumeroPedido.TabIndex = 0;
            this.txtNumeroPedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroPedido_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnOK.Location = new System.Drawing.Point(99, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(169, 32);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboOperacao
            // 
            this.cboOperacao.DisplayMember = "0";
            this.cboOperacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboOperacao.FormattingEnabled = true;
            this.cboOperacao.Items.AddRange(new object[] {
            "Indenização",
            "Faturamento"});
            this.cboOperacao.Location = new System.Drawing.Point(99, 40);
            this.cboOperacao.Name = "cboOperacao";
            this.cboOperacao.Size = new System.Drawing.Size(169, 21);
            this.cboOperacao.TabIndex = 2;
            this.cboOperacao.SelectedValueChanged += new System.EventHandler(this.cboOperacao_SelectedValueChanged);
            // 
            // frmNumeroPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(367, 197);
            this.Controls.Add(this.txtNumeroPedido);
            this.Controls.Add(this.cboOperacao);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(picFavIcon);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtMensagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNumeroPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNumeroPedido";
            ((System.ComponentModel.ISupportInitialize)(picFavIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.TextBox txtNumeroPedido;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.ComboBox cboOperacao;
    }
}