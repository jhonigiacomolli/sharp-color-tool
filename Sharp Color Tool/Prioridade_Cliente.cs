using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Sharp_Color_Tool
{
    class Prioridade_Cliente
    {
        public string Prioridade { get; set; }

        public void ObterPrioridade(string Cliente)
        {
            Prioridade_Cliente P = new Prioridade_Cliente();

            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
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
                 Prioridade = dr["Cod_Prioridade"].ToString();
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
    }
}
