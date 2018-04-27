using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sharp_Color_Tool
{
    public partial class frmRelatorios : Form
    {
        public frmRelatorios()
        {
            InitializeComponent();
        }

        private void frmRelatorios_Load(object sender, EventArgs e)
        {
            AlterarStringDeConexao();
            this.AgendamentosTableAdapter.Fill(this.Database_AgendamentosDataSet.Agendamentos);
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = Globais.ZoomRelatorio;
            this.reportViewer1.RefreshReport();
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
    }
}
