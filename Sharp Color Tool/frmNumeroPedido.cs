using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sharp_Color_Tool
{
    public partial class frmNumeroPedido : Form
    {
        Itens_Lista OS;
        frmPrincipal frmHome;
        public frmNumeroPedido(frmPrincipal frmHome, Itens_Lista OS)
        {
            InitializeComponent();
            this.OS = OS;
            this.frmHome = frmHome;

            cboOperacao.SelectedIndex = 1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;

            if (cboOperacao.Text.Equals("Indenização"))
            {
                Close();
                frmSenha Senha = new frmSenha(frmHome, OS, "INDENIZAÇÃO");
                Senha.Show();
                
            }
            if (cboOperacao.Text.Equals("Faturamento") && txtNumeroPedido.Text != string.Empty)
            {
                if (OS.Existente == "SIM")
                {
                    frmFaturamento frm = new frmFaturamento(this, frmHome, "NOVO");

                    frm.lblNOS.Text = OS.NOS;
                    frm.txtTipoOS.Text = OS.TipoOS;
                    frm.lblCliente.Text = OS.Cliente;
                    frm.lblVeiculo.Text = OS.Veiculo;
                    frm.lblPlaca.Text = OS.Placa;
                    frm.lblCor.Text = OS.Cor;
                    frm.lblSP.Text = OS.TipoPintura;
                    frm.lblQuantidade.Text = OS.Quantidade + " mls";
                    frm.lblCusto.Text = double.Parse(OS.ValorCusto).ToString("N2");
                    if (OS.ValorVenda != "0,00")
                    {
                        double Markup;
                        if (OS.Markup.Equals(string.Empty))
                        {
                            Markup = 0;
                        }
                        else
                        {
                            Markup = double.Parse(OS.Markup);
                        }
                        frm.txtVenda.Text = decimal.Parse(OS.ValorVenda).ToString("N2");
                        frm.lblMarkup.Text = Markup.ToString("N2");
                    }
                    frm.lblSugerido.Text = OS.Valor_Sugerido;
                    frm.lblCarga.Text = OS.Carga;
                    frm.txtNPedido.Text = txtNumeroPedido.Text;
                    frm.txtNPedido.Enabled = true;
                    frm.lblValorPraticado.Text = new Sugestao_Cliente().Sugestao_Valor(OS.Cliente.TrimEnd(), OS.GrupoCores.TrimEnd(), OS.TipoPintura.TrimEnd());

                    frm.Show();

                    Close();
                }

                if (OS.Existente != "SIM" || OS.Existente == string.Empty)
                {
                    Form MSG = new frmMensagemPersonalizada("Questao", "Faturamento", "A OS Nº " + OS.NOS + " ja foi faturada, deseja fazer alguma alteração?");
                    Resultado = MSG.ShowDialog();

                    if (Resultado == DialogResult.OK)
                    {
                        frmFaturamento frm = new frmFaturamento(this, frmHome, "NOVO");

                        frm.lblNOS.Text = OS.NOS;
                        frm.txtTipoOS.Text = OS.TipoOS;
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

                        if (double.Parse(OS.Markup) >= Globais.Margen_Sugerida)
                        {
                            frm.lblMarkup.ForeColor = Color.Green;
                            frm.lblPercent.ForeColor = Color.Green;
                        }
                        else
                        {
                            frm.lblMarkup.ForeColor = Color.Red;
                            frm.lblPercent.ForeColor = Color.Red;
                        }
                        frm.lblValorPraticado.Text = new Sugestao_Cliente().Sugestao_Valor(OS.Cliente.TrimEnd(), OS.GrupoCores.TrimEnd(), OS.TipoPintura.TrimEnd());

                        Close();
                        frm.Show();
                       
                    }
                    
                }
            }
            if(cboOperacao.Text.Equals("Faturamento") && txtNumeroPedido.Text.Equals(string.Empty))
            {
                Form messagebox = new frmMensagemPersonalizada("Critico", "Ação não autorizada", "Você deve inserir o numero do pedido para prosseguir");
                messagebox.ShowDialog();
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNumeroPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cboOperacao_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboOperacao.Text.Equals("Indenização"))
            {
                txtNumeroPedido.Enabled = false;
            }
        }
    }
}
