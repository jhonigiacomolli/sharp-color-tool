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
        public frmRelatorios(string path)
        {
            InitializeComponent();
            // Path
            this.reportViewer1.LocalReport.ReportEmbeddedResource = path;

            ////Configurando o DataSource
            //foreach(var dataSource in dataSources)
            //{
            //    var reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource(dataSource.Key, dataSource.Value);
            //    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            //}

            //Configurando Parametros
            //if (reportParameters != null)
            //{
            //    var reportParametersCollection = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            //    foreach (var parameter in reportParameters)
            //    {
            //        var reportParameter = new Microsoft.Reporting.WinForms.ReportParameter(parameter.Key, parameter.Value.ToString());
            //    }
            //    this.reportViewer1.LocalReport.SetParameters(reportParametersCollection);
            //}
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
