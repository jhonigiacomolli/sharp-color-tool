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
    public partial class frmIncluirPesagem : Form
    {
        public List<TextBox> CamposTexto;
        public List<Int32> IndexPigmentos;
        public frmIncluirPesagem(List<TextBox> CamposTexto, List<Int32> IndexPigmentos)
        {
            InitializeComponent();
            this.CamposTexto = CamposTexto;
            this.IndexPigmentos = IndexPigmentos;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void txtPigmento_KeyDown(object sender, KeyEventArgs e)
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
        public void txtPigmento_KeyPress(object sender, KeyEventArgs e)
        {
            foreach (Control txt in this.Controls)
            {
                if (txt is TextBox)
                {
                    if (txt.CanSelect == true)
                    {
                        if (txt.Text != string.Empty)
                        {
                            txt.Text = Convert.ToDouble(AjustarNumero(txt.Text)).ToString("N1");
                        }
                    }
                }
            }
            
        }
        public void txPigmento_Validated(object sender, EventArgs e)
        {
            foreach (Control txt in this.Controls)
            {
                if(txt is TextBox)
                {
                    if(txt.CanSelect == true)
                    {
                        if (txt.Text != string.Empty)
                        {
                            string novoNumero = "";
                            string numero = txt.Text;
                            char[] arr = numero.ToCharArray();
                            foreach (char item in arr)
                            {
                                //verifico se existe alguma ponto no "numero" digitado
                                if (item.ToString() != ".")
                                {
                                    //cada vez que o item for diferente de ponto
                                    //adiciona seu valor ao do novoNumero
                                    novoNumero += item.ToString();
                                }
                                else if (item.ToString() == ".")
                                {
                                    //caso o item seja uma ponto ele o substitui 
                                    //altomaticamente a ponto por virgula
                                    novoNumero += ",";
                                }
                            }
                            //crio uma variavel de retorno decimal e especifico
                            //quantas casas iram aparecer depois da virgula e 
                            //retorno seu valor
                            txt.Text = novoNumero;
                        }
                    }
                }
            }
        }

        public double AjustarNumero(string numero)
        {
            string novoNumero = "";
            char[] arr = numero.ToCharArray();
            foreach (char item in arr)
            {
                //verifico se existe alguma ponto no "numero" digitado
                if (item.ToString() != ".")
                {
                    //cada vez que o item for diferente de ponto
                    //adiciona seu valor ao do novoNumero
                    novoNumero += item.ToString();
                }
                else if (item.ToString() == ".")
                {
                    //caso o item seja uma ponto ele o substitui 
                    //altomaticamente a ponto por virgula
                    novoNumero += ",";
                }
            }
            //crio uma variavel de retorno decimal e especifico
            //quantas casas iram aparecer depois da virgula e 
            //retorno seu valor
            double retorno = Convert.ToDouble(novoNumero);
            return retorno;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //string mensagem="";
            //for (int i=0; i < CamposTexto.Count; i++)
            //{
            //    mensagem = string.Concat(mensagem, "ID: ", IndexPigmentos[i].ToString() , " | Peso: ", CamposTexto[i].Text, "\n");
            //}
            //MessageBox.Show(mensagem);
        }

        private void btnNovoPigemento_Click(object sender, EventArgs e)
        {
            int UltimaPosicao = 0;
            int numerocampo = 0;

            if (CamposTexto.Count > 0)
            {
                for (int i = 0; i < CamposTexto.Count; i++)
                {
                    UltimaPosicao = CamposTexto[i].Location.Y;
                    numerocampo = numerocampo + 1;
                }
                int Local_Vertical = UltimaPosicao + CamposTexto[0].Height + 5;

                //Cria dinamicamente o Combobox Pigmentos
                ComboBox cboPigmento = new ComboBox();

                cboPigmento.Size = new Size(120,20);
                cboPigmento.Location = new Point(10, (Local_Vertical));
                cboPigmento.KeyDown += new KeyEventHandler(txtPigmento_KeyDown);
                cboPigmento.Name = "cboPigmento" + (numerocampo + 1);
                cboPigmento.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                Controls.Add(cboPigmento);
                PreencheCBOPigmentos(cboPigmento);

                //Cria Dinamicamente o Textbox Quantidade
                TextBox txtPigmento1 = new TextBox();

                txtPigmento1.Size = new Size(130, 21);
                txtPigmento1.Location = new Point(cboPigmento.Width + 10, Local_Vertical);
                txtPigmento1.KeyDown += new KeyEventHandler(txtPigmento_KeyDown);
                txtPigmento1.Validated += new EventHandler(txPigmento_Validated);

                Controls.Add(txtPigmento1);
                CamposTexto.Add(txtPigmento1);

                Height = Height + cboPigmento.Height + 5;

                cboPigmento.Select();
                txtPigmento1.TabIndex = cboPigmento.TabIndex + 1;
                btnGravar.TabIndex = txtPigmento1.TabIndex + 1;
            }
            else
            {
                ComboBox cboPigmento = new ComboBox();
                cboPigmento.Size = new Size(120, 20);
                cboPigmento.Location = new Point(10,95);
                cboPigmento.TabIndex = 1;
                cboPigmento.Name = "cboPigmento" + (numerocampo + 1);
                Controls.Add(cboPigmento);
                PreencheCBOPigmentos(cboPigmento);

                //Cria Dinamicamente o Textbox Quantidade
                TextBox txtPigmento1 = new TextBox();

                txtPigmento1.Size = new Size(130, 21);
                txtPigmento1.Location = new Point(cboPigmento.Width + 10, 95);

                Controls.Add(txtPigmento1);
                CamposTexto.Add(txtPigmento1);

                Height = Height + cboPigmento.Height + 5;
            }
        }
        public void PreencheCBOPigmentos(ComboBox CBO)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Pigmentos";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    CBO.Items.Add(dr["Apelido_Pigmento"].ToString().ToUpper());
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
    }
}
