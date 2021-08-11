using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Sharp_Color_Tool
{
    public partial class frmSenha : Form
    {
        Itens_Lista OS;
        frmPrincipal frmHome;
        string TIPO;
        public frmSenha(frmPrincipal frmHome, Itens_Lista OS, string TIPO)
        {
            InitializeComponent();
            this.OS = OS;
            this.frmHome = frmHome;
            this.TIPO = TIPO;
        }
        
        public bool VerificaUsuario(string usuario, string senha)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            bool situacao = false;
            conn.Open();
            try
            {
                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Usuarios where Usuario like '" + usuario + "' and Senha like '" + senha + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                string _usuario="";
                string _senha="";

                //inicia leitura do datareader
                while (dr.Read())
                {
                    _usuario = dr["Usuario"].ToString();
                    _senha = dr["Senha"].ToString();
                }
                
                if(_usuario.Equals(usuario) && _senha.Equals(senha))
                {
                    situacao = true;
                }
                else
                {
                    situacao = false;
                }
            }
            catch
            {
                situacao = false;
            }   
            
            return situacao;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text != string.Empty && txtUsuario.Text != string.Empty)
            {
                bool usu = VerificaUsuario(txtUsuario.Text, txtSenha.Text);
                if (usu.Equals(true))
                {
                    if (TIPO.Equals("FATURAMENTO"))
                    {
                        frmFaturamento frm = new frmFaturamento(frmHome, "EDICAO");

                        frm.txtTipoOS.Text = OS.TipoOS;
                        frm.lblNOS.Text = OS.NOS;
                        frm.lblCliente.Text = OS.Cliente;
                        frm.lblVeiculo.Text = OS.Veiculo;
                        frm.lblPlaca.Text = OS.Placa;
                        frm.lblCor.Text = OS.Cor;
                        frm.lblSP.Text = OS.TipoPintura;
                        frm.lblQuantidade.Text = OS.Quantidade + " mls";
                        frm.lblCusto.Text = double.Parse(OS.ValorCusto).ToString("N2");
                        if (OS.ValorVenda != "0,00")
                        {
                            double Markup = double.Parse(OS.Markup);

                            frm.txtVenda.Text = decimal.Parse(OS.ValorVenda).ToString("N2");
                            frm.lblMarkup.Text = Markup.ToString("N2");
                        }
                        frm.lblSugerido.Text = OS.Valor_Sugerido;
                        frm.lblCarga.Text = OS.Carga;
                        frm.txtNPedido.Text = OS.NumeroPedido;

                        if (double.Parse(OS.Markup) >= Globais.Margen_Sugerida)
                        {
                            frm.lblMarkup.ForeColor = System.Drawing.Color.Green;
                            frm.lblPercent.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            frm.lblMarkup.ForeColor = System.Drawing.Color.Red;
                            frm.lblPercent.ForeColor = System.Drawing.Color.Red;
                        }
                        frm.txtNPedido.Enabled = true;
                        Close();
                        frm.ShowDialog();
                    }

                    if (TIPO.Equals("INDENIZAÇÃO"))
                    {
                        frmFaturamento frm = new frmFaturamento(frmHome, "INDENIZACAO");

                        frm.lblNOS.Text = OS.NOS;
                        frm.txtTipoOS.Text = OS.TipoOS;
                        frm.lblCliente.Text = OS.Cliente;
                        frm.lblVeiculo.Text = OS.Veiculo;
                        frm.lblPlaca.Text = OS.Placa;
                        frm.lblCor.Text = OS.Cor;
                        frm.lblSP.Text = OS.TipoPintura;
                        frm.lblQuantidade.Text = OS.Quantidade + " mls";
                        frm.lblCusto.Text = double.Parse(OS.ValorCusto).ToString("N2");
                        frm.txtVenda.Text = "0,00";
                        frm.txtVenda.Enabled = false;
                        frm.lblMarkup.Text = "-100";
                        frm.lblMarkup.ForeColor = System.Drawing.Color.Red;
                        frm.lblPercent.ForeColor = System.Drawing.Color.Red;
                        frm.lblSugerido.Text = OS.Valor_Sugerido;
                        frm.lblCarga.Text = OS.Carga;
                        frm.lblValorPraticado.Text = new Sugestao_Cliente().Sugestao_Valor(OS.Cliente.TrimEnd(), OS.GrupoCores.TrimEnd(), OS.TipoPintura.TrimEnd());
                        Close();
                        frm.Show();
                    }
                    
                }
                if (usu.Equals(false))
                {
                    frmMensagemPersonalizada msg = new frmMensagemPersonalizada("Alerta", "Dados Inválidos", "Usuario e senha incorretos!");
                    msg.ShowDialog();
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
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
