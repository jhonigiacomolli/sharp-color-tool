namespace Sharp_Color_Tool
{
    partial class frmIncluirPesagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIncluirPesagem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnNovoPigemento = new System.Windows.Forms.Button();
            this.btnExcluirPigmento = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            picFavIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(picFavIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picFavIcon
            // 
            picFavIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            picFavIcon.BackgroundImage = global::Sharp_Color_Tool.Properties.Resources.FavIcon_25px_;
            picFavIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            picFavIcon.Location = new System.Drawing.Point(5, 0);
            picFavIcon.Name = "picFavIcon";
            picFavIcon.Size = new System.Drawing.Size(25, 25);
            picFavIcon.TabIndex = 69;
            picFavIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.btnFechar);
            this.panel1.Controls.Add(picFavIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 25);
            this.panel1.TabIndex = 71;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTitulo.Location = new System.Drawing.Point(35, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(58, 13);
            this.lblTitulo.TabIndex = 68;
            this.lblTitulo.Text = "Pesagem";
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Silver;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(235, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(35, 25);
            this.btnFechar.TabIndex = 66;
            this.btnFechar.Text = "X";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnNovoPigemento
            // 
            this.btnNovoPigemento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoPigemento.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNovoPigemento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoPigemento.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNovoPigemento.Location = new System.Drawing.Point(9, 31);
            this.btnNovoPigemento.Name = "btnNovoPigemento";
            this.btnNovoPigemento.Size = new System.Drawing.Size(253, 30);
            this.btnNovoPigemento.TabIndex = 72;
            this.btnNovoPigemento.Text = "Incluir Pigmento";
            this.btnNovoPigemento.UseVisualStyleBackColor = false;
            this.btnNovoPigemento.Click += new System.EventHandler(this.btnNovoPigemento_Click);
            // 
            // btnExcluirPigmento
            // 
            this.btnExcluirPigmento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluirPigmento.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExcluirPigmento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirPigmento.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcluirPigmento.Location = new System.Drawing.Point(9, 63);
            this.btnExcluirPigmento.Name = "btnExcluirPigmento";
            this.btnExcluirPigmento.Size = new System.Drawing.Size(253, 30);
            this.btnExcluirPigmento.TabIndex = 73;
            this.btnExcluirPigmento.Text = "Excluir Pigmento";
            this.btnExcluirPigmento.UseVisualStyleBackColor = false;
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGravar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGravar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGravar.Location = new System.Drawing.Point(0, 323);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(270, 30);
            this.btnGravar.TabIndex = 20;
            this.btnGravar.Text = "Salvar";
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // frmIncluirPesagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(270, 353);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnExcluirPigmento);
            this.Controls.Add(this.btnNovoPigemento);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIncluirPesagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmIncluirPesagem";
            ((System.ComponentModel.ISupportInitialize)(picFavIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Button btnFechar;
        public System.Windows.Forms.Button btnNovoPigemento;
        public System.Windows.Forms.Button btnExcluirPigmento;
        public System.Windows.Forms.Button btnGravar;
    }
}