using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;

namespace Sharp_Color_Tool
{
    public partial class frmIncluir : Form
    {
        public frmPrincipal frmHome;
        public frmIncluir(frmPrincipal frmHome)
        {
            InitializeComponent();
            this.frmHome = frmHome;
        }

        private void cmgGravar_Click(object sender, EventArgs e)
        {
            string _Tipo = txtTipo.Text;
            string _Status = "Aguardando";
            string _NoPrazo = "NO PRAZO";
            string _Atrasado = "ATRASADO";
            string _CodStatus = "";
            if (txtStatus.Text == "EM PRODUÇÃO")
            {
                _CodStatus = "0";
            }
            if (txtStatus.Text == "PAUSADO")
            {
                _CodStatus = "1";
            }
            if (txtStatus.Text == "AGUARDANDO" || txtStatus.Text == "")
            {
                _CodStatus = "2";
            }
            if (txtStatus.Text == "FINALIZADO")
            {
                _CodStatus = "3";
            }

            if(txtPrioridade.Text=="")
            {
                txtPrioridade.Text = "2";
            }
            
            DateTime agora = DateTime.Now;
            DateTime Previsao = Convert.ToDateTime(string.Concat(txtPrevisao.Text," ",txtHorario.Text,":00"));
            string Previsao_prioridade = Previsao.ToString("yyyy/MM/dd HH:mm:ss");


            if (_Tipo == "Cadastro")
            {

                OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                string comandoSQL = "";

                if (Previsao > agora)
                {
                    comandoSQL = "INSERT INTO Agendamentos(Tipo_OS,Cliente,Veiculo,Placa,Cor,Pintura,Data_Cadastro,Previsao_Entrega,Status_Operacao,Prioridade,Entrega,Grupo_Cores,Montadora,Cod_Cor,Quantidade,Corpo_Prova,Existente,Operador)" +
                        " VALUES ('" + txtTipoOS.Text + "','" + txtCliente.Text + "','" + txtVeiculo.Text + "','" + txtPlaca.Text + "','" + txtCor.Text + "','" + txtPintura.Text + "','" + DateTime.Now.ToShortDateString() + "','" + string.Concat(txtPrevisao.Text, " ", txtHorario.Text, ":00") + "','" + _Status + "','" + string.Concat(_CodStatus, " ", Previsao_prioridade, " ", txtPrioridade.Text) + "','" + _NoPrazo + "','" + txtGrupoCor.Text + "','" + txtMontadora.Text + "','" + txtCodCor.Text + "','" + txtQuantidade.Text + "','" + txtCorpo_Prova.Text + "','" + Ordem_Servico.existente + "','" + cboOperador.Text + "')";
                }

                if (Previsao<=agora)
                {
                    comandoSQL = "INSERT INTO Agendamentos(Tipo_OS,Cliente,Veiculo,Placa,Cor,Pintura,Data_Cadastro,Previsao_Entrega,Status_Operacao,Prioridade,Entrega,Grupo_Cores,Montadora,Cod_Cor,Quantidade,Corpo_Prova,Existente)" +
                        " VALUES ('" + txtTipoOS.Text + "','" + txtCliente.Text + "','" + txtVeiculo.Text + "','" + txtPlaca.Text + "','" + txtCor.Text + "','" + txtPintura.Text + "','" + DateTime.Now.ToShortDateString() + "','" +  string.Concat(txtPrevisao.Text, " ", txtHorario.Text, ":00") + "','" + _Status + "','" + string.Concat(_CodStatus, " ", Previsao_prioridade, " ", txtPrioridade.Text) + "','" + _Atrasado + "','" + txtGrupoCor.Text + "','" + txtMontadora.Text + "','" + txtCodCor.Text + "','" + txtQuantidade.Text + "','" + txtCorpo_Prova.Text + "','" + Ordem_Servico.existente + "','" + cboOperador.Text + "')";

                }
                //cria um comando oledb
                OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                try
                {
                    //abre a conexao
                    conn.Open();

                    //executa o comando e gera um datareader
                    cmd.ExecuteNonQuery();

                    Form messagebox = new frmMensagemPersonalizada("Alerta","Inclusão", "Item incluido com sucesso!");
                    messagebox.ShowDialog();

                    txtCliente.Text = "";
                    txtVeiculo.Text = "";
                    txtPlaca.Text = "";
                    txtCor.Text = "";
                    txtPintura.Text = "";
                    txtPrevisao.Text = "";
                    txtHorario.Text = "";

                    conn.Close();

                    this.Close();

                }

                catch (OleDbException ex)
                {
                    Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                    messagebox.ShowDialog();
                }


                finally
                {

                }
                Ordem_Servico.existente = null;
                 
                frmHome.AtualizaLSTOSAberta();
            }
            if (_Tipo == "Atualizar")
            {
                OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

                string comandoSQL = "";

                this.ObterPrioridade();

                if(Previsao>agora)
                {
                    comandoSQL = "UPDATE Agendamentos SET Cliente='" + txtCliente.Text.Replace("'", "''") + "', Veiculo='" + txtVeiculo.Text + "', Placa='" + txtPlaca.Text + "', Corpo_Prova='" + txtCorpo_Prova.Text + "', Quantidade='" + txtQuantidade.Text + "', Cod_Cor='" + txtCodCor.Text + "', Montadora='" + txtMontadora.Text + "', Grupo_Cores='" + txtGrupoCor.Text + "', Tipo_OS='" + txtTipoOS.Text + "', Cor='" + txtCor.Text + "', Entrega='" + _NoPrazo + "', Operador='" + cboOperador.Text + "', Pintura='" + txtPintura.Text + "', Previsao_Entrega='" + string.Concat(txtPrevisao.Text, " ", txtHorario.Text, ":00") + "', Prioridade='" + string.Concat(_CodStatus, " ", Previsao_prioridade, " ", txtPrioridade.Text) + "' WHERE Código=" + int.Parse(txtID.Text) + "";
                }
                if(Previsao<=agora)
                {
                    comandoSQL = "UPDATE Agendamentos SET Cliente='" + txtCliente.Text.Replace("'", "''") + "', Veiculo='" + txtVeiculo.Text + "', Placa='" + txtPlaca.Text + "', Corpo_Prova='" + txtCorpo_Prova.Text + "', Quantidade='" + txtQuantidade.Text + "', Cod_Cor='" + txtCodCor.Text + "', Montadora='" + txtMontadora.Text + "', Grupo_Cores='" + txtGrupoCor.Text + "', Tipo_OS='" + txtTipoOS.Text + "', Cor='" + txtCor.Text + "', Entrega='" + _Atrasado + "', Operador='" + cboOperador.Text + "', Pintura='" + txtPintura.Text + "', Previsao_Entrega='" + string.Concat(txtPrevisao.Text, " ", txtHorario.Text, ":00") + "', Prioridade='" + string.Concat(_CodStatus, " ", Previsao_prioridade, " ", txtPrioridade.Text) + "' WHERE Código=" + int.Parse(txtID.Text) + "";

                }
                //cria um comando oledb
                OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                try
                {
                    //abre a conexao
                    conn.Open();

                    //executa o comando e gera um datareader
                    cmd.ExecuteNonQuery();

                    Form messagebox = new frmMensagemPersonalizada("Alerta","Alteração", "Dados alterados com sucesso!");
                    messagebox.ShowDialog();

                    txtCliente.Text = "";
                    txtVeiculo.Text = "";
                    txtPlaca.Text = "";
                    txtCor.Text = "";
                    txtPintura.Text = "";
                    txtPrevisao.Text = "";
                    txtHorario.Text = "";

                    conn.Close();

                    this.Close();


                }

                catch (OleDbException ex)
                {
                    Form messagebox = new frmMensagemPersonalizada("Critico","Erro","Error: " + ex.Message);
                    messagebox.ShowDialog();
                }


                finally
                {
                    frmHome.AtualizaLSTOSAberta();
            }

        }

    }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Color CalendarForeColor { get; set; }

        private void frmIncluir_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        private void txtVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void txtCor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPintura_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPrevisao_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtHorario_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtCliente_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (txtCliente.Text != "")
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:

                        this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                        e.Handled = true;
                        e.SuppressKeyPress = true;

                        this.ObterPrioridade();

                        if (txtPrioridade.Text==string.Empty)
                        {
                            txtCliente.ForeColor = System.Drawing.Color.Red;
                        }
                        break;

                    

                    case Keys.Escape:
                        this.Close();
                        break;

                }

            }
            
        }

        public void Preenche_CBO_Clientes()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Clientes";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    txtCliente.Items.Add(dr["Cliente"].ToString().ToUpper());
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
        }

        public void Preenche_CBO_SP()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Sistema_Pintura";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    txtPintura.Items.Add(dr["Sistema_Pintura"].ToString().ToUpper());
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
        }

        public void Preenche_CBO_TipoOS()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from TipoOS";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    txtTipoOS.Items.Add(dr["Tipo_OS"].ToString().ToUpper());
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
        }
        public void Preenche_CBO_Operador()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from usuarios ORDER BY usuario ASC";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    cboOperador.Items.Add(dr["usuario"].ToString().ToUpper());
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
        }
        public void Preenche_CBO_Cores()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Cores";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    txtGrupoCor.Items.Add(dr["Cor"].ToString().ToUpper());
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
        }

        public void ObterPrioridade()
        {

            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                string Cliente = txtCliente.Text;

                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Clientes WHERE Cliente like '" + Cliente + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    txtPrioridade.Text = dr["Cod_Prioridade"].ToString();             
                }
                //fecha o datareader
                dr.Close();

            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                //fecha a conexao
                conn.Close();
            }
        }
        private void cmgGravar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;                    
            }
        }

        private void cmdCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;


            }
        }

        private void frmIncluir_Load(object sender, EventArgs e)
        {
            
        }
        
        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            txtPrioridade.Text = string.Empty;
            txtCliente.ForeColor = System.Drawing.Color.Black;
        }

        private void txtCliente_Validated(object sender, EventArgs e)
        {
            this.ObterPrioridade();

            if(txtPrioridade.Text==string.Empty)
            {
                txtPrioridade.Text = "2";
                txtCliente.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void cmgGravar_MouseEnter(object sender, EventArgs e)
        {
            //cmgGravar.ForeColor = System.Drawing.Color.FromArgb(192,0,0);
        }

        private void cmgGravar_MouseLeave(object sender, EventArgs e)
        {
            //cmgGravar.ForeColor = System.Drawing.Color.Silver;
        }

        private void txtTipoOS_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtCor_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtMontadora_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtCodCor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtCorpo_Prova_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtHorario_Enter(object sender, EventArgs e)
        {
            txtHorario.Clear();
        }

        private void txtHorario_Leave(object sender, EventArgs e)
        {
            if(txtHorario.Text=="__:__")
            {
                Int32 _tempo = Convert.ToInt32(Globais.TempoRepesagemAuto);
                DateTime _Pesagem = DateTime.Now.AddMinutes(_tempo);
                txtHorario.Text = _Pesagem.ToShortTimeString();
            }
        }

        private void txtPlaca_Validated(object sender, EventArgs e)
        {
            
            Ordem_Servico.Busca_Placa(txtPlaca.Text);
        }


        bool mouseDown;
        Point lastLocation;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void lblTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void lblTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
