using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sharp_Color_Tool
{
    class Conexao
    {
        public static string Password_DB = "++060188jhoni.fg";

        public static string Database_Agendamentos = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + @"\Database\Database_Agendamentos.mdb;Persist Security Info=False;Jet OLEDB:Database Password=" + Password_DB + "";
    }
}
