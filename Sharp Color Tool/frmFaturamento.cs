using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sharp_Color_Tool
{
    public partial class frmFaturamento : Form
    {
        public frmPrincipal frmHome;
        public frmFaturamento(frmPrincipal frmHome)
        {
            InitializeComponent();
            this.frmHome = frmHome;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
            double Markup = (Venda / Custo) - 1;

            lblMarkup.Text = string.Format("{0:P2}", Markup);

            if (Markup > (Globais.Margen_Sugerida / 100))
            {
                lblMarkup.ForeColor = Color.Green;
            }
            else
            {
                lblMarkup.ForeColor = Color.Red;
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
            if (txtVenda.Text == string.Empty)
            {
                Form msg = new frmMensagemPersonalizada("Alerta", "Campo Vazio", "O item não pode ser faturado sem informar o valor no campo!");
                msg.ShowDialog();
            }
            else
            {
                string ID = lblNOS.Text;
                string ValorVenda = txtVenda.Text;
                DateTime DataFaturamento = DateTime.Now;
                string Markup = lblMarkup.Text;

                OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                string comandoSQL = "";

                comandoSQL = "UPDATE Agendamentos SET Existente='" + null + "', Data_Faturamento='" + DataFaturamento + "', Markup='" + Markup + "', Valor_Venda='" + ValorVenda + "' WHERE Código=" + int.Parse(ID) + "";

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

        private void frmFaturamento_Load(object sender, EventArgs e)
        {
            double Fator = 0.4382;
            Width = Convert.ToInt32(356 * Globais.Fator_Largura);
            Height = Convert.ToInt32(361 * Globais.Fator_Altura);

            cmdCancelar.Width= Convert.ToInt32(Width * Fator);
            cmdCancelar.Left = Convert.ToInt32((20 * Convert.ToDouble(Globais.Fator_Largura)) + (Width * Fator));
            cmdSalvar.Width = Convert.ToInt32(Width * Fator);
        }
    }
}
