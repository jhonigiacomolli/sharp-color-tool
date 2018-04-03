using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections.Generic;

namespace Sharp_Color_Tool
{
    class Ordem_Servico
    {
        string _ID { get; set; }
        string _TipoOS { get; set; }
        string _Cliente { get; set; }
        string _Veiculo { get; set; }
        string _Placa { get; set; }
        string _GrupoCOr { get; set; }
        string _Cor { get; set; }
        string _Montadora { get; set; }
        string _CodCOr { get; set; }
        string _Quantidade { get; set; }
        string _SP { get; set; }
        string _CorpoProva { get; set; }

        public static string existente;

        public static void Busca_Placa(string Placa)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            try
            {
                conn.Open();

                OleDbCommand cmd = conn.CreateCommand();
             
                cmd.CommandText = "Select * from Agendamentos where Placa='" + Placa + "'";
     
                OleDbDataReader dr = cmd.ExecuteReader();
                
                List<string> Lista = new List<string>();
                
                while (dr.Read())
                {
                    for (int i = 1; i < dr.FieldCount; i++)
                    {
                        Lista.Add(dr["Placa"].ToString());    
                    }
                }

                if (Lista.Count > 0 && Placa != "   -")
                {
                    Form messagebox = new frmMensagemPersonalizada("Alerta", "Registro Existente", "Ja existe um registro para a placa: " + Placa);
                    messagebox.ShowDialog();
                    existente = "SIM";
                }
                dr.Close();
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução da instrução SQL." +
                        "Erro : " + ex.Message, "SQL");
            }
            finally
            {
                conn.Close();
            }
            
              
        }
    }
}
