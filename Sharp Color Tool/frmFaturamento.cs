using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sharp_Color_Tool
{
    public partial class frmFaturamento : Form
    {
        public frmPrincipal frmHome;
        public frmNumeroPedido frmNpedido;
        public string Tipo;
        public string _Destino;
        public frmFaturamento(frmPrincipal frmHome, string tipo)
        {
            InitializeComponent();
            this.frmHome = frmHome;
            Tipo = tipo;
        }
        public frmFaturamento(frmNumeroPedido frmNpedido, frmPrincipal frmHome, string Tipo)
        {
            InitializeComponent();
            this.frmNpedido = frmNpedido;
            this.frmHome = frmHome;
            this.Tipo = Tipo;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtVenda_Validated(object sender, EventArgs e)
        {
            double Venda;

            double Custo = double.Parse(lblCusto.Text);
            if (txtVenda.Text == string.Empty)
            {
                Venda = 0;
            }
            else
            {
                Venda = double.Parse(txtVenda.Text);
                txtVenda.Text = Convert.ToDouble(txtVenda.Text).ToString("N2");

            }
            double Markup = ((Venda / Custo) - 1) * 100;

            lblMarkup.Text = Markup.ToString("N2");

            if (Markup >= Globais.Margen_Sugerida)
            {
                lblMarkup.ForeColor = Color.Green;
                lblPercent.ForeColor = Color.Green;
            }
            else
            {
                lblMarkup.ForeColor = Color.Red;
                lblPercent.ForeColor = Color.Red;
            }



        }

        private void txtVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                //troca o . pela virgula
                e.KeyChar = ',';

                //Verifica se já existe alguma vírgula na string
                if (txtVenda.Text.Contains(","))
                {
                    e.Handled = true; // Caso exista, aborte 
                }
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Enter))
            {
                e.Handled = true;
            }
        }

        private void txtVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
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

        private void cmdSalvar_MouseEnter(object sender, EventArgs e)
        {
            cmdSalvar.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void cmdSalvar_MouseLeave(object sender, EventArgs e)
        {
            cmdSalvar.BackColor = Color.FromArgb(26, 26, 26);
        }

        private void cmdSalvar_Enter(object sender, EventArgs e)
        {
            cmdSalvar.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void cmdSalvar_Leave(object sender, EventArgs e)
        {
            cmdSalvar.BackColor = Color.FromArgb(26, 26, 26);
        }

        private void cmdCancelar_Enter(object sender, EventArgs e)
        {
            cmdCancelar.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void cmdCancelar_Leave(object sender, EventArgs e)
        {

            cmdCancelar.BackColor = Color.FromArgb(26, 26, 26);
        }

        private void cmdCancelar_MouseEnter(object sender, EventArgs e)
        {
            cmdCancelar.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void cmdCancelar_MouseLeave(object sender, EventArgs e)
        {

            cmdCancelar.BackColor = Color.FromArgb(26, 26, 26);
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (txtVenda.Text.Equals(string.Empty) && txtNPedido.Text.Equals(string.Empty))
            {
                Form msg = new frmMensagemPersonalizada("Alerta", "Campo Vazio", "O item não pode ser faturado sem informar o valor no campo!");
                msg.ShowDialog();
            }
            else
            {
                if (Tipo.Equals("INDENIZACAO"))
                {
                    string ID = lblNOS.Text;
                    string ValorVenda = txtVenda.Text;
                    DateTime DataFaturamento = DateTime.Now;
                    string Markup = lblMarkup.Text;
                    string NPedido = txtNPedido.Text;

                    string Origem = "";

                    if (txtTipoOS.Text.Equals("REPESAGEM"))
                    {
                        Origem = string.Concat(Globais.CaminhoTintas, txtTipoOS.Text, " - ", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, ".xlsm");
                    }
                    if (txtTipoOS.Text.Equals("AJUSTE"))
                    {
                        Origem = string.Concat(Globais.CaminhoTintas, lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, ".xlsm");
                    }
                    if (txtTipoOS.Text.Equals("ERRADA"))
                    {
                        Origem = string.Concat(Globais.CaminhoTintas, txtTipoOS.Text, " - ", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, ".xlsm");
                    }

               
                    _Destino = string.Concat(Globais.CaminhoTintas, DateTime.Now.ToString("yyyy"), "\\", "INDENIZAÇÃO", " - ", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, ".xlsm");
                   

                    //try
                    //{
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = true;

                    Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(Origem);

                    Microsoft.Office.Interop.Excel.Worksheet wsOrdemServico = wb.Worksheets[1];

                    wsOrdemServico.Range["H3"].Value = "0.00";

                    wb.Save();
                    wb.Close(false);
                    app.Quit();

                    app = null;
                    wb = null;
                    wsOrdemServico = null;

                    if (System.IO.File.Exists(_Destino))
                    {
                        int Versao = 0;

                        VerificarArquivoExistente(Origem, _Destino, Versao);

                    }
                    else
                    {
                        System.IO.File.Move(Origem, _Destino);
                    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Form messagebox2 = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                    //    messagebox2.Show();
                    //}

                    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                    string comandoSQL = "";

                    comandoSQL = "UPDATE Agendamentos SET Existente='" + null + "', Data_Faturamento='" + DataFaturamento + "', Markup='" + Markup + "', TipoOS='INDENIZAÇÃO', Valor_Venda='" + ValorVenda + "', NumeroPedido='" + NPedido + "', CaminhoOS='" + _Destino + "' WHERE Código=" + int.Parse(ID) + "";

                    OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                    try
                    {
                        //abre a conexao
                        conn.Open();

                        //executa o comando e gera um datareader
                        cmd.ExecuteNonQuery();

                        conn.Close();


                    }

                    catch (OleDbException ex)
                    {
                        Form messagebox2 = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                        messagebox2.Show();
                    }


                    finally
                    {
                        frmHome.carrega_LST_tintas();
                        this.Close();
                    }

                }
                if (Tipo.Equals("NOVO"))
                {
                    string ID = lblNOS.Text;
                    string ValorVenda = txtVenda.Text;
                    DateTime DataFaturamento = DateTime.Now;
                    string Markup = lblMarkup.Text;
                    string NPedido = txtNPedido.Text;

                    string Origem = "";

                    if (txtTipoOS.Text.Equals("REPESAGEM"))
                    {
                        Origem = string.Concat(Globais.CaminhoTintas, txtTipoOS.Text, " - ", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, ".xlsm");
                    }
                    if (txtTipoOS.Text.Equals("AJUSTE"))
                    {
                        Origem = string.Concat(Globais.CaminhoTintas, lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, ".xlsm");
                    }
                    if (txtTipoOS.Text.Equals("ERRADA"))
                    {
                        Origem = string.Concat(Globais.CaminhoTintas, txtTipoOS.Text, " - ", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, ".xlsm");
                    }

                    if (txtTipoOS.Text.Equals("REPESAGEM"))
                    {
                        _Destino = string.Concat(Globais.CaminhoTintas, DateTime.Now.ToString("yyyy"), "\\", txtTipoOS.Text, " - ", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, ".xlsm");
                    }
                    if (txtTipoOS.Text.Equals("AJUSTE"))
                    {
                        _Destino = string.Concat(Globais.CaminhoTintas, DateTime.Now.ToString("yyyy"), "\\", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, ".xlsm");
                    }
                    if (txtTipoOS.Text.Equals("ERRADA"))
                    {
                        _Destino = string.Concat(Globais.CaminhoTintas, DateTime.Now.ToString("yyyy"), "\\", txtTipoOS.Text, " - ", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, ".xlsm");
                    }

                    //try
                    //{
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = false;

                    Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(Origem);

                    Microsoft.Office.Interop.Excel.Worksheet wsOrdemServico = wb.Worksheets[1];

                    wsOrdemServico.Range["H3"].Value = ValorVenda;

                    wb.Save();
                    wb.Close(false);
                    app.Quit();

                    app = null;
                    wb = null;
                    wsOrdemServico = null;

                    if (System.IO.File.Exists(_Destino))
                    {
                        int Versao = 0;

                        VerificarArquivoExistente(Origem, _Destino, Versao);

                    }
                    else
                    {
                        System.IO.File.Move(Origem, _Destino);
                    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Form messagebox2 = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                    //    messagebox2.Show();
                    //}

                    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                    string comandoSQL = "";

                    comandoSQL = "UPDATE Agendamentos SET Existente='" + null + "', Data_Faturamento='" + DataFaturamento + "', Markup='" + Markup + "', Valor_Venda='" + ValorVenda + "', NumeroPedido='" + NPedido + "', CaminhoOS='" + _Destino + "' WHERE Código=" + int.Parse(ID) + "";

                    OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                    try
                    {
                        //abre a conexao
                        conn.Open();

                        //executa o comando e gera um datareader
                        cmd.ExecuteNonQuery();

                        conn.Close();


                    }

                    catch (OleDbException ex)
                    {
                        Form messagebox2 = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                        messagebox2.Show();
                    }


                    finally
                    {
                        frmHome.carrega_LST_tintas();
                        this.Close();
                    }
                }
                if (Tipo.Equals("EDICAO"))
                {
                    string ID = lblNOS.Text;
                    string ValorVenda = txtVenda.Text;
                    DateTime DataFaturamento = DateTime.Now;
                    string Markup = lblMarkup.Text;
                    string NPedido = txtNPedido.Text;

                    string Origem = VerificaCaminhoOS(ID);

                    //try
                    //{
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = false;

                    Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(Origem);

                    Microsoft.Office.Interop.Excel.Worksheet wsOrdemServico = wb.Worksheets[1];

                    wsOrdemServico.Range["H3"].Value = ValorVenda;

                    wb.Save();
                    wb.Close(false);
                    app.Quit();

                    app = null;
                    wb = null;
                    wsOrdemServico = null;

                    //}
                    //catch (Exception ex)
                    //{
                    //    Form messagebox2 = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                    //    messagebox2.Show();
                    //}

                    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                    string comandoSQL = "";

                    comandoSQL = "UPDATE Agendamentos SET Existente='" + null + "', Data_Faturamento='" + DataFaturamento + "', Markup='" + Markup + "', Valor_Venda='" + ValorVenda + "', NumeroPedido='" + NPedido + "' WHERE Código=" + int.Parse(ID) + "";

                    OleDbCommand cmd = new OleDbCommand(comandoSQL, conn);

                    try
                    {
                        //abre a conexao
                        conn.Open();

                        //executa o comando e gera um datareader
                        cmd.ExecuteNonQuery();

                        conn.Close();


                    }

                    catch (OleDbException ex)
                    {
                        Form messagebox2 = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                        messagebox2.Show();
                    }


                    finally
                    {
                        frmHome.carrega_LST_tintas();
                        this.Close();
                    }
                }
            }
        }

        public string VerificaCaminhoOS(string ID)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            string caminho = "";
            conn.Open();
            try
            {
                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Agendamentos where Código like '" + ID + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    caminho = dr["CaminhoOS"].ToString();
                }
                return caminho;
            }
            catch
            {
                return string.Empty;
            }
            
        }

        public void VerificarArquivoExistente(string Origem, string Destino, int Versao)
        {
            try
            {                
                if (txtTipoOS.Text.Equals("REPESAGEM"))
                {
                    Destino = string.Concat(Globais.CaminhoTintas, DateTime.Now.ToString("yyyy"), "\\", txtTipoOS.Text, " - ", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, " (", Versao, ")", ".xlsm");
                }
                if (txtTipoOS.Text.Equals("AJUSTE"))
                {
                    Destino = string.Concat(Globais.CaminhoTintas, DateTime.Now.ToString("yyyy"), "\\", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, " (", Versao + 1, ")", ".xlsm");
                }
                if (txtTipoOS.Text.Equals("ERRADA"))
                {
                    Destino = string.Concat(Globais.CaminhoTintas, DateTime.Now.ToString("yyyy"), "\\", txtTipoOS.Text, " - ", lblCliente.Text, " - ", lblVeiculo.Text, " - ", lblPlaca.Text, " - ", lblCor.Text, " - ", lblSP.Text, " - ", DateTime.Now.ToString("dd"), "_", DateTime.Now.ToString("MM"), "_", DateTime.Now.ToString("yy"), ".xlsm");
                }

                System.IO.File.Move(Origem, Destino);
                _Destino = Destino;
            }
            catch (Exception)
            {
                Versao = Versao + 1;
                VerificarArquivoExistente(Origem, Destino, Versao);

            }
        }
        private void frmFaturamento_Load(object sender, EventArgs e)
        {
            //double Fator = 0.3503;
            //double Posicao = 0.1318;
            //Width = Convert.ToInt32(508 * Globais.Fator_Largura);
            //Height = Convert.ToInt32(410 * Globais.Fator_Altura);

            //cmdCancelar.Width = Convert.ToInt32(Width * Fator);
            //cmdCancelar.Left = Convert.ToInt32((Width * Posicao) + cmdSalvar.Width);
            //cmdSalvar.Width = Convert.ToInt32(Width * Fator);
        }

        private void txtNPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
