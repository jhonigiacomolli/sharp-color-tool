using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Sharp_Color_Tool
{
    class LST_Tintas
    {
        public static Int32 N_Totais;
        public static Int32 N_Ajustes;
        public static Int32 N_AjustesExt;
        public static Int32 N_Repesagens;

        public static Int32 N_Totais_Mensal;
        public static Int32 N_Ajustes_Mensal;
        public static Int32 N_AjustesExt_Mensal;
        public static Int32 N_Repesagens_Mensal;

        public static void Tintas_Mensais()
        {
            Total_Ajuste_Mensal();
            Total_AjusteExterno_Mensal();
            Total_Repesagem_Mensal();
            Totais_Mensais();
        }

        public static void Tintas_Diarias()
        {            
            Total_Ajuste_Diario();
            Total_AjusteExterno_Diario();
            Total_Repesagem_Diario();
            Totais_Diarios();
        }

        public static void Totais_Mensais()
        {
            N_Totais_Mensal = N_Ajustes_Mensal + N_AjustesExt_Mensal + N_Repesagens_Mensal;
        }
        public  static void Totais_Diarios()
        {
            N_Totais = N_Ajustes + N_AjustesExt + N_Repesagens;
        }

        public static void Total_Ajuste_Mensal()
        {
            string Data = DateTime.Now.ToString("MM/yyyy");
            string Status1 = "FINALIZADO";
            string Status2 = "EM PRODUÇÃO";
            string Tipo = "AJUSTE";

            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Agendamentos WHERE Status_Operacao like '" + Status2 + "' AND Tipo_OS='" + Tipo + "' OR (Fim like '%" + Data + "%' AND Status_Operacao like '" + Status1 + "' AND Tipo_OS='" + Tipo + "')";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                N_Ajustes_Mensal = 0;
                while (dr.Read())
                {
                    N_Ajustes_Mensal = N_Ajustes_Mensal + 1;
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

        public static void Total_AjusteExterno_Mensal()
        {
            string Data = DateTime.Now.ToString("MM/yyyy");
            string Status1 = "FINALIZADO";
            string Status2 = "EM PRODUÇÃO";
            string Tipo = "AJUSTE EXTERNO";

            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Agendamentos WHERE Status_Operacao like '" + Status2 + "' AND Tipo_OS='" + Tipo + "' OR (Fim like '%" + Data + "%' AND Status_Operacao like '" + Status1 + "' AND Tipo_OS='" + Tipo + "')";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                N_AjustesExt_Mensal = 0;
                while (dr.Read())
                {
                    N_AjustesExt_Mensal = N_AjustesExt_Mensal + 1;
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
        public static void Total_Repesagem_Mensal()
        {
            string Data = DateTime.Now.ToString("MM/yyyy");
            string Status1 = "FINALIZADO";
            string Status2 = "EM PRODUÇÃO";
            string Tipo = "REPESAGEM";

            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Agendamentos WHERE Status_Operacao like '" + Status2 + "' AND Tipo_OS='" + Tipo + "' OR (Fim like '%" + Data + "%' AND Status_Operacao like '" + Status1 + "' AND Tipo_OS='" + Tipo + "')";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                N_Repesagens_Mensal = 0;
                while (dr.Read())
                {
                    N_Repesagens_Mensal = N_Repesagens_Mensal + 1;
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

        public  static void Total_Ajuste_Diario()
        {
            string Data = DateTime.Now.ToString("dd/MM/yyyy");
            string Status1 = "FINALIZADO";
            string Status2 = "EM PRODUÇÃO";
            string Tipo = "AJUSTE";

            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Agendamentos WHERE Status_Operacao like '" + Status2 + "' AND Tipo_OS='" + Tipo + "' OR (Fim like '%" + Data + "%' AND Status_Operacao like '" + Status1 + "' AND Tipo_OS='" + Tipo + "')";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                N_Ajustes = 0;
                while (dr.Read())
                {
                    N_Ajustes = N_Ajustes + 1;
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

        public static void Total_AjusteExterno_Diario()
        {
            string Data = DateTime.Now.ToString("dd/MM/yyyy");
            string Status1 = "FINALIZADO";
            string Status2 = "EM PRODUÇÃO";
            string Tipo = "AJUSTE EXTERNO";

            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Agendamentos WHERE Status_Operacao like '" + Status2 + "' AND Tipo_OS='" + Tipo + "' OR (Fim like '%" + Data + "%' AND Status_Operacao like '" + Status1 + "' AND Tipo_OS='" + Tipo + "')";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                N_AjustesExt = 0;
                while (dr.Read())
                {
                    N_AjustesExt = N_AjustesExt + 1;
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
        public static void Total_Repesagem_Diario()
        {
            string Data = DateTime.Now.ToString("dd/MM/yyyy");
            string Status1 = "FINALIZADO";
            string Status2 = "EM PRODUÇÃO";
            string Tipo = "REPESAGEM";

            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                //abre a conexao
                conn.Open();

                //cria um comando oledb
                OleDbCommand cmd = conn.CreateCommand();
                //define o tipo do comando como texto 
                cmd.CommandText = "Select * from Agendamentos WHERE Status_Operacao like '" + Status2 + "' AND Tipo_OS='" + Tipo + "' OR (Fim like '%" + Data + "%' AND Status_Operacao like '" + Status1 + "' AND Tipo_OS='" + Tipo + "')";

                //executa o comando e gera um datareader
                OleDbDataReader dr = cmd.ExecuteReader();

                N_Repesagens = 0;
                while (dr.Read())
                {
                    N_Repesagens = N_Repesagens + 1;
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

