using System.Windows.Forms;

namespace Sharp_Color_Tool
{
    class Conexao
    {
        public static string Password_DB = "++060188jhoni.fg";

        public static string Database_Agendamentos = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + Application.StartupPath + @"\Database\Database_Agendamentos.mdb;Persist Security Info=False;Jet OLEDB:Database Password=" + Password_DB + "";
        //public static string Database_Agendamentos = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + System.IO.File.ReadAllText(@"C:\\Sharp Color Tool\Database\Conn.txt") + ";Persist Security Info=False;Jet OLEDB:Database Password = " + Password_DB + "";
    }
}
