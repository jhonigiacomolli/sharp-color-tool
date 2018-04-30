using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Reporting.WinForms;


namespace Sharp_Color_Tool
{
    public partial class frmRelatorios : Form
    {
        public string Path;
        public string SQL;
 
        public frmRelatorios(string path, string SQL)
        {
            InitializeComponent();
            this.Path = path;
            this.SQL = SQL;

            AlterarStringDeConexao();
            Relatorios.GeraRelatorio(this.reportViewer1, Path, SQL);
        }
        public frmRelatorios(string path, string SQL, string PArametro1, string Parametro2)
        {
            InitializeComponent();
            this.Path = path;
            this.SQL = SQL;
            AlterarStringDeConexao();
            Relatorios.GeraRelatorio_FiltroData(this.reportViewer1, Path, SQL,PArametro1, Parametro2);
        }

        private void frmRelatorios_Load(object sender, EventArgs e)
        {
            
        }

        private void AlterarStringDeConexao()
        {
            var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            var connectionStrings = config.ConnectionStrings;
            foreach (System.Configuration.ConnectionStringSettings connectionString in connectionStrings.ConnectionStrings)
            {
                connectionString.ConnectionString = string.Format(Conexao.Database_Agendamentos, Environment.CurrentDirectory);
            }
            config.Save(System.Configuration.ConfigurationSaveMode.Modified);
            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
