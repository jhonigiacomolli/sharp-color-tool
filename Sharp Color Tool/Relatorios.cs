using System;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Sharp_Color_Tool
{
    class Relatorios
    {
        public static void GeraRelatorio_FiltroData(frmRelatorios Formulario, ReportViewer Relatorio, string Path, string SQL, string Parametro1, string Parametro2)
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

            if (Formulario.InvokeRequired)
            {
                Formulario.Invoke(new Action(() =>
                {
                    Relatorio.Reset();
                    ReportDataSource rds = new ReportDataSource("DataSet_Agendamentos", dt);
                    Relatorio.LocalReport.DataSources.Clear();
                    Relatorio.LocalReport.DataSources.Add(rds);
                    Relatorio.LocalReport.ReportEmbeddedResource = Path;
                    Relatorio.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    Relatorio.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                    Relatorio.ZoomPercent = Globais.ZoomRelatorio;
                    Relatorio.LocalReport.Refresh();
                }));
            }

        }

        public static void GeraRelatorio_FiltroDataCliente(frmRelatorios Formulario, ReportViewer Relatorio, string Path, string SQL, string Parametro1, string Parametro2, string Parametro3)
        {
            OleDbConnection conn = new OleDbConnection(Conexao.Database_Agendamentos);

            DataSet dss = new DataSet();
            OleDbCommand cmd = new OleDbCommand(SQL);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@inicio", Parametro1);
            cmd.Parameters.AddWithValue("@fim", Parametro2);
            cmd.Parameters.AddWithValue("@cliente", Parametro3);
            OleDbDataAdapter da = new OleDbDataAdapter();
            conn.Open();
            da.SelectCommand = cmd;
            da.Fill(dss);
            DataTable dt = dss.Tables[0];

            if (Formulario.InvokeRequired)
            {
                Formulario.Invoke(new Action(() =>
                {
                    Relatorio.Reset();
                    ReportDataSource rds = new ReportDataSource("DataSet_Agendamentos", dt);
                    Relatorio.LocalReport.DataSources.Clear();
                    Relatorio.LocalReport.DataSources.Add(rds);
                    Relatorio.LocalReport.ReportEmbeddedResource = Path;
                    Relatorio.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    Relatorio.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                    Relatorio.ZoomPercent = Globais.ZoomRelatorio;
                    Relatorio.LocalReport.Refresh();
                }));
            }
        }
    }
}
