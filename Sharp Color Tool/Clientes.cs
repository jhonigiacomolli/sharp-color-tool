using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Sharp_Color_Tool
{
    public class Clientes
    {

        private int ID { get; set; }
        private string Cliente { get;  set; }
        private string Prioridade { get; set; }
        private int Cod_Prioridade { get; set; }

        public void LerClientes(ListView lst)
        {
            try
            {

                ListView LST = lst;
                ListViewItem item;

                lst.Items.Clear();

                OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();

                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Clientes ORDER BY Cliente ASC";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //inicia leitura do datareader
                while (dr.Read())
                {
                    item = new ListViewItem();
                    item.Text = dr["Código"].ToString();

                    //preenche o listview com itens
                    for (int i = 1; i < dr.FieldCount; i++)
                    {
                        item.SubItems.Add(dr["Cliente"].ToString().ToUpper());
                        item.SubItems.Add(dr["Prioridade"].ToString().ToUpper());
                        item.SubItems.Add(dr["Cod_Prioridade"].ToString());
                    }
                    LST.Items.Add(item);
                }
                //fecha o datareader
                dr.Close();
                conn.Close();
            }
            catch (OleDbException ex)
            {
                Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                messagebox.ShowDialog();
            }
        }

        public void CadastraCliente(string Cliente, string Prioridade)
        {
            try
            {
                if (Prioridade.Equals("ALTA"))
                {
                    Cod_Prioridade = 0;
                }
                if (Prioridade.Equals("MÉDIA"))
                {
                    Cod_Prioridade = 1;
                }
                if (Prioridade.Equals("BAIXA"))
                {
                    Cod_Prioridade = 2;
                }

                OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();

                //define o tipo do comando como texto 
                cmd.CommandText = "INSERT INTO Clientes(Cliente, Prioridade, Cod_Prioridade) VALUES('" + Cliente + "', '" + Prioridade + "', '" + Cod_Prioridade + "')";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                dr.Close();
                conn.Close();

                Form messagebox = new frmMensagemPersonalizada("Alerta", "Erro", "Cliente adicionado com sucesso!");
                messagebox.ShowDialog();
            }
            catch(OleDbException ex)
            {
                Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                messagebox.ShowDialog();
            }
        }

        public void EditarCliente(int ID, string Cliente, string Prioridade)
        {
            try
            {
                if (Prioridade.Equals("ALTA"))
                {
                    Cod_Prioridade = 0;
                }
                if (Prioridade.Equals("MÉDIA"))
                {
                    Cod_Prioridade = 1;
                }
                if (Prioridade.Equals("BAIXA"))
                {
                    Cod_Prioridade = 2;
                }

                OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();

                //define o tipo do comando como texto 
                cmd.CommandText = "UPDATE Clientes SET Cliente='" + Cliente.Replace("'", "''") + "', Prioridade='" + Prioridade + "', Cod_Prioridade='" + Cod_Prioridade + "' WHERE Código=" + ID + "";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                dr.Close();
                conn.Close();

                Form messagebox = new frmMensagemPersonalizada("Alerta", "Erro", "Cliente alterado com sucesso!");
                messagebox.ShowDialog();
            }
            catch (OleDbException ex)
            {
                Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                messagebox.ShowDialog();
            }
        }

        public void ExcluirCliente(int ID)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();

                //define o tipo do comando como texto 
                cmd.CommandText = "DELETE * from Clientes WHERE Código=" + ID + "";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                //fecha o datareader
                dr.Close();
                conn.Close();

                Form messagebox = new frmMensagemPersonalizada("Alerta", "Erro", "Cliente Excluido com sucesso!");
                messagebox.ShowDialog();
            }
            catch (OleDbException ex)
            {
                Form messagebox = new frmMensagemPersonalizada("Critico", "Erro", "Error: " + ex.Message);
                messagebox.ShowDialog();
            }
        }
    }
}
