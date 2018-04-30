using System;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace Sharp_Color_Tool
{
    class Relatorios
    {
        //private void rptGetDataset()
        //{
        //    DataSet ds = new DataSet();
        //    ds.DataSetName = "dsNewDataSet";
        //    string sql = "";
        //    sql = "SELECT * FROM Agendamentos";
        //    OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        //    ds.GetXmlSchema();
        //    da.Fill(ds);
        //}

        public static void GeraRelatorio(ReportViewer Relatorio, string Path, string SQL)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);
            conn.Open();
            DataSet dss = new DataSet();

            OleDbDataAdapter da = new OleDbDataAdapter(SQL, conn);
            da.Fill(dss);
            DataTable dt = dss.Tables[0];

            Relatorio.Reset();
            ReportDataSource rds = new ReportDataSource("DataSet_Agendamentos", dt);
            Relatorio.LocalReport.DataSources.Clear();
            Relatorio.LocalReport.DataSources.Add(rds);
            Relatorio.LocalReport.ReportEmbeddedResource = Path;
            Relatorio.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            Relatorio.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            Relatorio.ZoomPercent = Globais.ZoomRelatorio;
            Relatorio.LocalReport.Refresh();
        }
        public static void GeraRelatorio_FiltroData(ReportViewer Relatorio, string Path, string SQL, string Parametro1, string Parametro2)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

            DataSet dss = new DataSet();
            OleDbCommand cmd = new OleDbCommand(SQL);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@inicio", Parametro1);
            cmd.Parameters.AddWithValue("@fim", Parametro2);
            OleDbDataAdapter da = new OleDbDataAdapter();
            conn.Open();
            da.SelectCommand = cmd;
            da.Fill(dss);
            DataTable dt = dss.Tables[0];

            Relatorio.Reset();
            ReportDataSource rds = new ReportDataSource("DataSet_Agendamentos", dt);
            Relatorio.LocalReport.DataSources.Clear();
            Relatorio.LocalReport.DataSources.Add(rds);
            Relatorio.LocalReport.ReportEmbeddedResource = Path;
            Relatorio.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            Relatorio.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            Relatorio.ZoomPercent = Globais.ZoomRelatorio;
            Relatorio.LocalReport.Refresh();
        }
    }
}
