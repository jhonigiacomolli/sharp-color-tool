using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sharp_Color_Tool
{
    public partial class frmOS : Form
    {
        public frmPrincipal frmHome;
        public List<Itens_Lista> LISTA;
        public string NOS;
        public double Custo;
        public double Sugerido;
        public double QNT;
        public double Margem;
        public double ConsumoVerniz;
        public int NumeroChapinhas;
        string TipoEmbalagem;
        string ValorEmbalagem;
        string PadraoPesagem;

        public frmOS(frmPrincipal frmHome, List<Itens_Lista> lista)
        {
            InitializeComponent();

            this.frmHome = frmHome;
            this.LISTA = lista;
            this.NOS = LISTA[0].NOS;
            QNT = Convert.ToDouble(LISTA[0].Quantidade);
            lstPigmentos.GridLines = true;
            lstPigmentos.View = View.Details;
            lstPigmentos.FullRowSelect = true;
            lstPigmentos.AllowColumnReorder = true;

            lstPigmentos.Columns.Add("Cód", 0);
            lstPigmentos.Columns.Add("NOS", 0);
            lstPigmentos.Columns.Add("Cód Pigemnto", 0);
            lstPigmentos.Columns.Add("PIGMENTO", 90, HorizontalAlignment.Left);
            lstPigmentos.Columns.Add("PE", 0);
            lstPigmentos.Columns.Add("1ª Pesagem", 90, HorizontalAlignment.Right);
            lstPigmentos.Columns.Add("2ª Pesagem", 90, HorizontalAlignment.Right);
            lstPigmentos.Columns.Add("Ajuste", 70, HorizontalAlignment.Right);
            lstPigmentos.Columns.Add("Valor", 70, HorizontalAlignment.Right);

            CarregaLST(NOS);
            Preenche_CBO_Clientes();
            Preenche_CBO_Cores();
            Preenche_CBO_Operador();
            Preenche_CBO_SP();
            Preenche_CBO_TipoOS();
            Preenche_CBO_Balanca();
            Preenche_CBO_Embalagem();
            Preencher_N_Chapinhas();


            txtNOS.Text = LISTA[0].NOS;
            cboTipoOS.Text = LISTA[0].TipoOS;
            cboCliente.Text = LISTA[0].Cliente;
            txtVeiculo.Text = LISTA[0].Veiculo;
            txtPlaca.Text = LISTA[0].Placa;
            cboGrupoCores.Text = LISTA[0].GrupoCores;
            txtCor.Text = LISTA[0].Cor;
            txtMontadora.Text = LISTA[0].Montadora;
            txtCodCor.Text = LISTA[0].Codigo;
            txtQNT.Text = LISTA[0].Quantidade;
            QNT = Convert.ToDouble(LISTA[0].Quantidade);
            cboSP.Text = LISTA[0].TipoPintura;
            txtCorpoProva.Text = LISTA[0].CorpoProva;
            cboColorista.Text = LISTA[0].Colorista;
            txtPrevisao.Text = LISTA[0].Previsao.ToString();

            AtualizDados();
        }

        public void AtualizDados()
        {
            BuscaInfoCliente();
            CalculoEmbalagem();

            txtCusto.Text = SomarCusto().ToString("N2");
            BuscarConfig();
            txtPesoTotal.Text = SomarPesoTotal().ToString("N2");
            txtVolumeTotal.Text = SomarVolumeTotal().ToString("N2");
        }

        public void CarregaLST(string NOS)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

            try
            {
                //limpa o listview
                lstPigmentos.Items.Clear();

                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from OS where NumeroOS='" + NOS + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //define um item listview
                ListViewItem item;

                //inicia leitura do datareader
                while (dr.Read())
                {
                    item = new ListViewItem();
                    item.Text = dr["Código"].ToString();

                    //preenche o listview com itens
                    for (int i = 1; i < dr.FieldCount; i++)
                    {
                        item.SubItems.Add(dr["NumeroOS"].ToString().ToUpper());
                        item.SubItems.Add(dr["Cod_Pigmento"].ToString().ToUpper());
                        item.SubItems.Add(dr["Descricao"].ToString().ToUpper());
                        item.SubItems.Add(dr["PE"].ToString().ToUpper());
                        item.SubItems.Add(dr["1Pesagem"].ToString().ToUpper());
                        item.SubItems.Add(dr["2Pesagem"].ToString().ToUpper());
                        item.SubItems.Add(dr["Ajuste"].ToString().ToUpper());
                        item.SubItems.Add(Convert.ToDouble(dr["valor"]).ToString("N2").ToUpper());
                    }

                    lstPigmentos.Items.Add(item);
                }
                dr.Close();
                conn.Close();
            }
            catch (OleDbException ex)
            {
                Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                messagebox.ShowDialog();
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
                    cboCliente.Items.Add(dr["Cliente"].ToString().ToUpper());
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
                cmd.CommandText = "Select * from Sistema_Pintura ORDER BY Sistema_Pintura ASC";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    cboSP.Items.Add(dr["Sistema_Pintura"].ToString().ToUpper());
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
                    cboTipoOS.Items.Add(dr["Tipo_OS"].ToString().ToUpper());
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
                    cboColorista.Items.Add(dr["usuario"].ToString().ToUpper());
                }
                cboColorista.SelectedIndex = 0;
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
                    cboGrupoCores.Items.Add(dr["Cor"].ToString().ToUpper().TrimEnd());
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

        public void Preenche_CBO_Balanca()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Balanca";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    cboBalança.Items.Add(dr["Descricao"].ToString().ToUpper());
                }
                cboBalança.SelectedIndex = 0;
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
        public void Preenche_CBO_Embalagem()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Embalagem";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    cboEmbalagem.Items.Add(dr["Descricao"].ToString().ToUpper());
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

        private void frmOS_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height < 530)
            {
                pnInfo.Visible = false;
            }
            if (this.Height > 530)
            {
                pnInfo.Visible = true;
            }
            if (this.Width < 550)
            {
                pnInfo.Visible = false;
            }
            if (this.Width > 550)
            {
                pnInfo.Visible = true;
            }
        }

        bool mouseDown;
        Point lastLocation;

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
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

        public bool CE = false;
        public bool CD = false;
        public bool CSE = false;
        public bool CSD = false;
        public bool CIE = false;
        public bool CID = false;

        private void btnCanto_SE_Click(object sender, EventArgs e)
        {
            if (CSE.Equals(false))
            {
                Width = Convert.ToInt32(Globais.Atual_Width / 2);
                Height = Convert.ToInt32((Globais.Atual_Height - 40) / 2);

                Location = new Point(0, 0);
                pnInfo.Visible = false;
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.33);
                pnLST.Location = new Point(12, 126);
                btnCanto_SE.BackColor = Color.Blue;
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                CSE = true;
                CSD = false;
                CIE = false;
                CID = false;
                CE = false;
                CD = false;
                return;
            }
            if (CSE.Equals(true))
            {
                Width = 610;
                Height = 650;
                Location = new Point(Convert.ToInt32(Globais.Atual_Width - Width) / 2, (Convert.ToInt32(Globais.Atual_Height - Height)) / 2);
                pnInfo.Visible = true;
                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.44);
                pnLST.Location = new Point(12, 241);
                CSE = false;
                CSD = false;
                CIE = false;
                CID = false;
                CE = false;
                CD = false;
                return;
            }

        }

        private void btnCanto_SD_Click(object sender, EventArgs e)
        {
            if (CSD.Equals(false))
            {
                Width = Convert.ToInt32(Globais.Atual_Width / 2);
                Height = Convert.ToInt32((Globais.Atual_Height - 40) / 2);

                Location = new Point(Width + 1, 0);
                pnInfo.Visible = false;
                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.Blue;
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.33);
                pnLST.Location = new Point(12, 126);
                CSE = false;
                CSD = true;
                CIE = false;
                CID = false;
                CE = false;
                CD = false;
                return;
            }
            if (CSD.Equals(true))
            {
                Width = 610;
                Height = 650;
                Location = new Point(Convert.ToInt32(Globais.Atual_Width - Width) / 2, (Convert.ToInt32(Globais.Atual_Height - Height)) / 2);
                pnInfo.Visible = true;
                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.44);
                pnLST.Location = new Point(12, 241);
                CSE = false;
                CSD = false;
                CIE = false;
                CID = false;
                CE = false;
                CD = false;
                return;
            }
        }

        private void btnCanto_IE_Click(object sender, EventArgs e)
        {
            if (CIE.Equals(false))
            {
                Width = Convert.ToInt32(Globais.Atual_Width / 2);
                Height = Convert.ToInt32((Globais.Atual_Height - 40) / 2);

                Location = new Point(0, Height + 1);
                pnInfo.Visible = false;
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.33);
                pnLST.Location = new Point(12, 126);
                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.Blue;
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                CSE = false;
                CSD = false;
                CIE = true;
                CID = false;
                CE = false;
                CD = false;
                return;
            }
            if (CIE.Equals(true))
            {
                Width = 610;
                Height = 650;
                Location = new Point(Convert.ToInt32(Globais.Atual_Width - Width) / 2, (Convert.ToInt32(Globais.Atual_Height - Height)) / 2);
                pnInfo.Visible = true;
                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.44);
                pnLST.Location = new Point(12, 241);
                CSE = false;
                CSD = false;
                CIE = false;
                CID = false;
                CE = false;
                CD = false;
                return;
            }
        }

        private void btnCanto_ID_Click(object sender, EventArgs e)
        {
            if (CID.Equals(false))
            {
                Width = Convert.ToInt32(Globais.Atual_Width / 2);
                Height = Convert.ToInt32((Globais.Atual_Height - 40) / 2);

                Location = new Point(Width + 1, Height + 1);
                pnInfo.Visible = false;
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.33);
                pnLST.Location = new Point(12, 126);
                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.Blue;
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                CSE = false;
                CSD = false;
                CIE = false;
                CID = true;
                CE = false;
                CD = false;
                return;
            }
            if (CID.Equals(true))
            {
                Width = 610;
                Height = 650;
                Location = new Point(Convert.ToInt32(Globais.Atual_Width - Width) / 2, (Convert.ToInt32(Globais.Atual_Height - Height)) / 2);
                pnInfo.Visible = true;
                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.44);
                pnLST.Location = new Point(12, 241);
                CSE = false;
                CSD = false;
                CIE = false;
                CID = false;
                CE = false;
                CD = false;
                return;
            }
        }

        private void btnCantoEsquerdo_Click(object sender, EventArgs e)
        {
            if (CE.Equals(false))
            {
                Width = Convert.ToInt32(Globais.Atual_Width / 2);
                Height = Convert.ToInt32(Globais.Atual_Height - 40);
                Location = new Point(0, 0);
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.688);
                pnLST.Location = new Point(11, Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.266));

                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.Blue;
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                CSE = false;
                CSD = false;
                CIE = false;
                CID = false;
                CE = true;
                CD = false;
                return;
            }
            if (CE.Equals(true))
            {
                Width = 610;
                Height = 650;
                Location = new Point(Convert.ToInt32(Globais.Atual_Width - Width) / 2, (Convert.ToInt32(Globais.Atual_Height - Height)) / 2);
                pnInfo.Visible = true;
                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.44);
                pnLST.Location = new Point(12, 241);
                CSE = false;
                CSD = false;
                CIE = false;
                CID = false;
                CE = false;
                CD = false;
                return;
            }
        }

        private void btnCantoDireito_Click(object sender, EventArgs e)
        {
            if (CD.Equals(false))
            {
                Width = Convert.ToInt32(Globais.Atual_Width / 2);
                Height = Convert.ToInt32(Globais.Atual_Height - 35);
                Location = new Point(Width + 1, 0);

                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.688);
                pnLST.Location = new Point(11, Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.266));

                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.Blue;
                CSE = false;
                CSD = false;
                CIE = false;
                CID = false;
                CE = false;
                CD = true;
                return;

            }
            if (CD.Equals(true))
            {
                Width = 610;
                Height = 650;
                Location = new Point(Convert.ToInt32(Globais.Atual_Width - Width) / 2, (Convert.ToInt32(Globais.Atual_Height - Height)) / 2);
                pnInfo.Visible = true;
                btnCanto_SE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_SD.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_IE.BackColor = Color.FromArgb(100, 100, 100);
                btnCanto_ID.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoEsquerdo.BackColor = Color.FromArgb(100, 100, 100);
                btnCantoDireito.BackColor = Color.FromArgb(100, 100, 100);
                pnLST.Height = Convert.ToInt32(Convert.ToDouble(Globais.Atual_Height) * 0.44);
                pnLST.Location = new Point(12, 241);
                CSE = false;
                CSD = false;
                CIE = false;
                CID = false;
                CE = false;
                CD = false;
                return;
            }
        }

        public double SomarCusto()
        {
            double total = 0;
            for (int i = 0; i < lstPigmentos.Items.Count; i++)
            {
                total = total + Convert.ToDouble(lstPigmentos.Items[i].SubItems[8].Text);
            }
            Custo = total + Convert.ToDouble(ValorEmbalagem);
            Custo = (Custo / 1000) * QNT;

            return Custo;
        }
        public void BuscarConfig()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * FROM Config";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    Margem = (Convert.ToDouble(dr["Margem_Sugerida"].ToString().ToUpper()) / 100) + 1;
                    ConsumoVerniz = Convert.ToDouble(dr["ConsumoVerniz"].ToString().ToUpper());
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
            txtSugerido.Text = (Custo * Margem).ToString("N2");
            txtReposicao.Text = (NumeroChapinhas * ConsumoVerniz).ToString("N1");
        }



        public double SomarPesoTotal()
        {
            double total = 0;
            for (int i = 0; i < lstPigmentos.Items.Count; i++)
            {
                string CP1 = lstPigmentos.Items[i].SubItems[5].Text;
                string CP2 = lstPigmentos.Items[i].SubItems[6].Text;
                string CP3 = lstPigmentos.Items[i].SubItems[7].Text;

                if (CP1.Equals(string.Empty))
                {
                    CP1 = "0";
                }
                if (CP2.Equals(string.Empty))
                {
                    CP2 = "0";
                }
                if (CP3.Equals(string.Empty))
                {
                    CP3 = "0";
                }

                total = total + Convert.ToDouble(CP1) + Convert.ToDouble(CP2) + Convert.ToDouble(CP3);
            }
            return total;
        }

        public double SomarVolumeTotal()
        {
            double total = 0;
            for (int i = 0; i < lstPigmentos.Items.Count; i++)
            {
                string PE = lstPigmentos.Items[i].SubItems[4].Text;
                string CP1 = lstPigmentos.Items[i].SubItems[5].Text;
                string CP2 = lstPigmentos.Items[i].SubItems[6].Text;
                string CP3 = lstPigmentos.Items[i].SubItems[7].Text;

                if (CP1.Equals(string.Empty))
                {
                    CP1 = "0";
                }
                if (CP2.Equals(string.Empty))
                {
                    CP2 = "0";
                }
                if (CP3.Equals(string.Empty))
                {
                    CP3 = "0";
                }
                CP1 = (Convert.ToDouble(CP1) * Convert.ToDouble(PE)).ToString();
                CP2 = (Convert.ToDouble(CP2) * Convert.ToDouble(PE)).ToString();
                CP3 = (Convert.ToDouble(CP3) * Convert.ToDouble(PE)).ToString();

                total = total + Convert.ToDouble(CP1) + Convert.ToDouble(CP2) + Convert.ToDouble(CP3);
            }
            return total;
        }

        public void Preencher_N_Chapinhas()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select Contador_Chapinhas FROM Agendamentos WHERE Código LIKE '" + NOS + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    NumeroChapinhas = Convert.ToInt32(dr["Contador_Chapinhas"].ToString().ToUpper());
                }
                txtContador.Text = NumeroChapinhas.ToString();
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

        private void txtQNT_Validated(object sender, EventArgs e)
        {
            QNT = Convert.ToDouble(txtQNT.Text);
            txtCusto.Text = SomarCusto().ToString("N2");
            BuscarConfig();
        }

        private void txtQNT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
            AtualizDados();
        }

        private void txtQNT_Click(object sender, EventArgs e)
        {
            txtQNT.SelectAll();
        }

        private void txtQNT_Enter(object sender, EventArgs e)
        {
            txtQNT.SelectAll();
        }
        private void cboTipoOS_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void cboColorista_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void cboBalança_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void cboCliente_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
            AtualizDados();
        }

        private void txtCor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void cboSP_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void cboGrupoCores_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void txtVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void txtPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }

        }

        private void txtMontadora_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void txtCodCor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void txtCorpoProva_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void cboEmbalagem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }
        public void BuscaInfoCliente()
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Clientes WHERE Cliente LIKE '" + LISTA[0].Cliente + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    TipoEmbalagem = dr["TipoEmbalagem"].ToString().ToUpper();
                    PadraoPesagem = dr["PadraoPesagem"].ToString().ToUpper();

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
        public void CalculoEmbalagem()
        {
            string Embalagem = "";
            int referencia = 0;

            if (QNT <= Globais.Embalagem_Criterio1 && TipoEmbalagem.Equals("PLÁSTICO"))
            {
                referencia = 700;
            }
            if (QNT > Globais.Embalagem_Criterio1 && QNT <= Globais.Embalagem_Criterio2 && TipoEmbalagem.Equals("PLÁSTICO"))
            {
                referencia = 2200;
            }
            if (QNT <= Globais.Embalagem_Criterio3 && TipoEmbalagem.Equals("METAL"))
            {
                referencia = 1000;
            }
            if (QNT > Globais.Embalagem_Criterio3 && QNT <= Globais.Embalagem_Criterio4 && TipoEmbalagem.Equals("METAL"))
            {
                referencia = 3600;
            }


            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Embalagem WHERE Volume LIKE '" + referencia + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    Embalagem = dr["Descricao"].ToString().ToUpper();
                    ValorEmbalagem = dr["Valor"].ToString().ToUpper();
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                cboEmbalagem.Text = Embalagem;
                //fecha a conexao
                conn.Close();
            }
        }

        private void cboCliente_Validated(object sender, EventArgs e)
        {
            LISTA[0].Cliente = cboCliente.Text;
            AtualizDados();
        }

        private void cboCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            LISTA[0].Cliente = cboCliente.Text;
            AtualizDados();
        }

        private void cboEmbalagem_SelectedValueChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Embalagem WHERE Descricao LIKE '" + cboEmbalagem.Text + "'";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    ValorEmbalagem = dr["Valor"].ToString().ToUpper();
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

            BuscaInfoCliente();
            txtCusto.Text = SomarCusto().ToString("N2");
            BuscarConfig();
            txtPesoTotal.Text = SomarPesoTotal().ToString("N2");
            txtVolumeTotal.Text = SomarVolumeTotal().ToString("N2");
        }
        
        //public void PreencheCBOPigmentos(ComboBox CBO)
        //{
        //    OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
        //    try
        //    {
        //        //abre a conexao
        //        conn.Open();

        //        //cria um comando oledb
        //        OleDbCommand cmd = conn.CreateCommand();
        //        //define o tipo do comando como texto 
        //        cmd.CommandText = "Select * from Pigmentos";

        //        //executa o comando e gera um datareader
        //        OleDbDataReader dr = cmd.ExecuteReader();

        //        //inicia leitura do datareader
        //        while (dr.Read())
        //        {
        //            CBO.Items.Add(dr["Apelido_Pigmento"].ToString().ToUpper());
        //        }
        //    }
        //    catch (System.Data.OleDb.OleDbException ex)
        //    {
        //        MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
        //                "Erro : " + ex.Message, "SQL");
        //    }
        //    finally
        //    {
        //        //fecha a conexao
        //        conn.Close();
        //    }
        //}

        private void btnImportaFormula_Click(object sender, EventArgs e)
        {

            List<TextBox> Campos = new List<TextBox>();
            List<Int32> IndexPigmentos = new List<int>();
            frmIncluirPesagem FRMPESAGEM = new frmIncluirPesagem(Campos, IndexPigmentos);
            int Alturatxt = 20;
            int AlturaFRM = 105;
            int Larguratxt = 130;
            int Larguracbo = 120;
            int Local_Vertical = 70;
            int Local_txtPeso1_H = Larguracbo + 10;
            int tabindex = 0;

            for (int i=0; i<lstPigmentos.Items.Count; i++)
            {
                //Cria Dinamicamente os Combobox dos Pigmentos;
                Local_Vertical = Local_Vertical + Alturatxt + 5;

                ComboBox CboPigmento = new ComboBox();
                CboPigmento.Size = new Size(Larguracbo, Alturatxt);
                CboPigmento.Location = new Point(10, (Local_Vertical));
                CboPigmento.TabIndex = tabindex +1 ;

                FRMPESAGEM.Controls.Add(CboPigmento);
                FRMPESAGEM.PreencheCBOPigmentos(CboPigmento);
                CboPigmento.Text = lstPigmentos.Items[i].SubItems[3].Text;
                CboPigmento.Enabled = false;

                //Cria Dinamicamente os Textbox dos Pigmentos;
                TextBox txtPeso1 = new TextBox();
                txtPeso1.Size = new Size(Larguratxt, Alturatxt+1);
                txtPeso1.TabIndex = tabindex + 1;
                txtPeso1.Location = new Point(Local_txtPeso1_H, (Local_Vertical));
                txtPeso1.KeyDown += new KeyEventHandler(FRMPESAGEM.txtPigmento_KeyDown);
                txtPeso1.Validated += new EventHandler(FRMPESAGEM.txPigmento_Validated);
                FRMPESAGEM.Controls.Add(txtPeso1);
                Campos.Add(txtPeso1);
                IndexPigmentos.Add(Convert.ToInt32(lstPigmentos.Items[i].Text));           

                AlturaFRM = AlturaFRM + 5 + Alturatxt;
            }
            FRMPESAGEM.Height = AlturaFRM + 20;
            int LocalV = Location.Y + ((Height / 2) - (FRMPESAGEM.Height / 2));
            int LocalH = Location.X + ((Width / 2) - (FRMPESAGEM.Width / 2));
            FRMPESAGEM.Location = new Point(LocalH, LocalV);
            FRMPESAGEM.ShowDialog();
        }

        
    }
}
