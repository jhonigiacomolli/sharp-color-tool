namespace Sharp_Color_Tool
{
    partial class frmIncluir
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
            System.Windows.Forms.PictureBox pictureBox1;
            System.Windows.Forms.PictureBox picFavIcon;
            this.label1 = new System.Windows.Forms.Label();
            this.txtVeiculo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrevisao = new System.Windows.Forms.DateTimePicker();
            this.txtHorario = new System.Windows.Forms.MaskedTextBox();
            this.cmgGravar = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPlaca = new System.Windows.Forms.MaskedTextBox();
            this.txtCliente = new System.Windows.Forms.ComboBox();
            this.txtPintura = new System.Windows.Forms.ComboBox();
            this.txtGrupoCor = new System.Windows.Forms.ComboBox();
            this.txtPrioridade = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTipoOS = new System.Windows.Forms.ComboBox();
            this.txtCor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMontadora = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodCor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCorpo_Prova = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cboOperador = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            picFavIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(picFavIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(304, 25);
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // picFavIcon
            // 
            picFavIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            picFavIcon.BackgroundImage = global::Sharp_Color_Tool.Properties.Resources.FavIcon_25px_;
            picFavIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            picFavIcon.Location = new System.Drawing.Point(4, 0);
            picFavIcon.Name = "picFavIcon";
            picFavIcon.Size = new System.Drawing.Size(25, 25);
            picFavIcon.TabIndex = 33;
            picFavIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(15, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // txtVeiculo
            // 
            this.txtVeiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVeiculo.Location = new System.Drawing.Point(100, 119);
            this.txtVeiculo.Name = "txtVeiculo";
            this.txtVeiculo.Size = new System.Drawing.Size(219, 20);
            this.txtVeiculo.TabIndex = 2;
            this.txtVeiculo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVeiculo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(15, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Veículo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Placa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(15, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Grupo de Cor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(16, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tipo Pintura";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(16, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Previsão";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(16, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Horario";
            // 
            // txtPrevisao
            // 
            this.txtPrevisao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtPrevisao.Location = new System.Drawing.Point(101, 329);
            this.txtPrevisao.Name = "txtPrevisao";
            this.txtPrevisao.Size = new System.Drawing.Size(219, 20);
            this.txtPrevisao.TabIndex = 10;
            this.txtPrevisao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrevisao_KeyDown);
            // 
            // txtHorario
            // 
            this.txtHorario.Location = new System.Drawing.Point(101, 355);
            this.txtHorario.Mask = "00:00";
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.Size = new System.Drawing.Size(219, 20);
            this.txtHorario.TabIndex = 11;
            this.txtHorario.Text = "0000";
            this.txtHorario.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtHorario.ValidatingType = typeof(System.DateTime);
            this.txtHorario.Enter += new System.EventHandler(this.txtHorario_Enter);
            this.txtHorario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHorario_KeyDown);
            this.txtHorario.Leave += new System.EventHandler(this.txtHorario_Leave);
            // 
            // cmgGravar
            // 
            this.cmgGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmgGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmgGravar.ForeColor = System.Drawing.Color.Silver;
            this.cmgGravar.Location = new System.Drawing.Point(56, 411);
            this.cmgGravar.Name = "cmgGravar";
            this.cmgGravar.Size = new System.Drawing.Size(120, 41);
            this.cmgGravar.TabIndex = 13;
            this.cmgGravar.Text = "Gravar";
            this.cmgGravar.UseVisualStyleBackColor = true;
            this.cmgGravar.Click += new System.EventHandler(this.cmgGravar_Click);
            this.cmgGravar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmgGravar_KeyDown);
            this.cmgGravar.MouseEnter += new System.EventHandler(this.cmgGravar_MouseEnter);
            this.cmgGravar.MouseLeave += new System.EventHandler(this.cmgGravar_MouseLeave);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.ForeColor = System.Drawing.Color.Silver;
            this.cmdCancelar.Location = new System.Drawing.Point(175, 411);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(120, 41);
            this.cmdCancelar.TabIndex = 14;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            this.cmdCancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdCancelar_KeyDown);
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(292, 405);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(27, 20);
            this.txtTipo.TabIndex = 9;
            this.txtTipo.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(291, 405);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(27, 20);
            this.txtID.TabIndex = 15;
            this.txtID.Visible = false;
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(100, 145);
            this.txtPlaca.Mask = ">AAA-0000";
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(219, 20);
            this.txtPlaca.TabIndex = 3;
            this.txtPlaca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlaca_KeyDown);
            this.txtPlaca.Validated += new System.EventHandler(this.txtPlaca_Validated);
            // 
            // txtCliente
            // 
            this.txtCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtCliente.FormattingEnabled = true;
            this.txtCliente.Location = new System.Drawing.Point(100, 92);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(219, 21);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown_1);
            this.txtCliente.Validated += new System.EventHandler(this.txtCliente_Validated);
            // 
            // txtPintura
            // 
            this.txtPintura.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPintura.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtPintura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPintura.FormattingEnabled = true;
            this.txtPintura.Location = new System.Drawing.Point(101, 303);
            this.txtPintura.Name = "txtPintura";
            this.txtPintura.Size = new System.Drawing.Size(219, 21);
            this.txtPintura.TabIndex = 9;
            this.txtPintura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown_1);
            // 
            // txtGrupoCor
            // 
            this.txtGrupoCor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtGrupoCor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtGrupoCor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtGrupoCor.FormattingEnabled = true;
            this.txtGrupoCor.Location = new System.Drawing.Point(100, 171);
            this.txtGrupoCor.Name = "txtGrupoCor";
            this.txtGrupoCor.Size = new System.Drawing.Size(219, 21);
            this.txtGrupoCor.TabIndex = 4;
            this.txtGrupoCor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown_1);
            // 
            // txtPrioridade
            // 
            this.txtPrioridade.Location = new System.Drawing.Point(325, 405);
            this.txtPrioridade.Name = "txtPrioridade";
            this.txtPrioridade.Size = new System.Drawing.Size(27, 20);
            this.txtPrioridade.TabIndex = 17;
            this.txtPrioridade.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(15, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tipo de OS";
            // 
            // txtTipoOS
            // 
            this.txtTipoOS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTipoOS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtTipoOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTipoOS.FormattingEnabled = true;
            this.txtTipoOS.Location = new System.Drawing.Point(100, 64);
            this.txtTipoOS.Name = "txtTipoOS";
            this.txtTipoOS.Size = new System.Drawing.Size(219, 21);
            this.txtTipoOS.TabIndex = 0;
            this.txtTipoOS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTipoOS_KeyDown);
            // 
            // txtCor
            // 
            this.txtCor.Location = new System.Drawing.Point(100, 198);
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(219, 20);
            this.txtCor.TabIndex = 5;
            this.txtCor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCor_KeyDown_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.Location = new System.Drawing.Point(16, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Nome da Cor";
            // 
            // txtMontadora
            // 
            this.txtMontadora.Location = new System.Drawing.Point(100, 224);
            this.txtMontadora.Name = "txtMontadora";
            this.txtMontadora.Size = new System.Drawing.Size(219, 20);
            this.txtMontadora.TabIndex = 6;
            this.txtMontadora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMontadora_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(16, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Montadora";
            // 
            // txtCodCor
            // 
            this.txtCodCor.Location = new System.Drawing.Point(100, 250);
            this.txtCodCor.Name = "txtCodCor";
            this.txtCodCor.Size = new System.Drawing.Size(219, 20);
            this.txtCodCor.TabIndex = 7;
            this.txtCodCor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodCor_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(16, 253);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Código";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(100, 276);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(219, 20);
            this.txtQuantidade.TabIndex = 8;
            this.txtQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantidade_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Silver;
            this.label12.Location = new System.Drawing.Point(16, 279);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Quantidade";
            // 
            // txtCorpo_Prova
            // 
            this.txtCorpo_Prova.Location = new System.Drawing.Point(101, 381);
            this.txtCorpo_Prova.Name = "txtCorpo_Prova";
            this.txtCorpo_Prova.Size = new System.Drawing.Size(219, 20);
            this.txtCorpo_Prova.TabIndex = 12;
            this.txtCorpo_Prova.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCorpo_Prova_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Silver;
            this.label13.Location = new System.Drawing.Point(17, 384);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Corpo de Prova";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Silver;
            this.label14.Location = new System.Drawing.Point(15, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Placa";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(292, 431);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(27, 20);
            this.txtStatus.TabIndex = 16;
            this.txtStatus.Visible = false;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Silver;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(304, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(35, 25);
            this.btnFechar.TabIndex = 25;
            this.btnFechar.Text = "X";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTitulo.Location = new System.Drawing.Point(34, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(154, 13);
            this.lblTitulo.TabIndex = 32;
            this.lblTitulo.Text = "SHARP - Inclusao/Edição";
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            this.lblTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseMove);
            this.lblTitulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseUp);
            // 
            // cboOperador
            // 
            this.cboOperador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboOperador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperador.FormattingEnabled = true;
            this.cboOperador.Location = new System.Drawing.Point(100, 37);
            this.cboOperador.Name = "cboOperador";
            this.cboOperador.Size = new System.Drawing.Size(219, 21);
            this.cboOperador.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Silver;
            this.label15.Location = new System.Drawing.Point(15, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Operador";
            // 
            // frmIncluir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(339, 457);
            this.Controls.Add(this.cboOperador);
            this.Controls.Add(this.label15);
            this.Controls.Add(picFavIcon);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCorpo_Prova);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtCodCor);
            this.Controls.Add(this.txtMontadora);
            this.Controls.Add(this.txtCor);
            this.Controls.Add(this.txtPintura);
            this.Controls.Add(this.txtGrupoCor);
            this.Controls.Add(this.txtTipoOS);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtPrioridade);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmgGravar);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.txtHorario);
            this.Controls.Add(this.txtPrevisao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVeiculo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIncluir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formulario";
            this.Load += new System.EventHandler(this.frmIncluir_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIncluir_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(picFavIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DateTimePicker txtPrevisao;
        public System.Windows.Forms.MaskedTextBox txtHorario;
        public System.Windows.Forms.TextBox txtTipo;
        public System.Windows.Forms.TextBox txtVeiculo;
        public System.Windows.Forms.Button cmgGravar;
        public System.Windows.Forms.Button cmdCancelar;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.MaskedTextBox txtPlaca;
        public System.Windows.Forms.ComboBox txtCliente;
        public System.Windows.Forms.ComboBox txtPintura;
        public System.Windows.Forms.ComboBox txtGrupoCor;
        public System.Windows.Forms.TextBox txtPrioridade;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox txtTipoOS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtCor;
        public System.Windows.Forms.TextBox txtMontadora;
        public System.Windows.Forms.TextBox txtCodCor;
        public System.Windows.Forms.TextBox txtQuantidade;
        public System.Windows.Forms.TextBox txtCorpo_Prova;
        public System.Windows.Forms.TextBox txtStatus;
        public System.Windows.Forms.Button btnFechar;
        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.ComboBox cboOperador;
        private System.Windows.Forms.Label label15;
    }
}