using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Media;
using Microsoft.Reporting.WinForms;


namespace Sharp_Color_Tool
{
    public partial class frmRelatorios : Form
    {
        public string Path;
        public string SQL;
        public string Parametro1;
        public string Parametro2;
        public string Parametro3;


        public frmRelatorios(string path, string SQL, string PArametro1, string Parametro2)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(0,0);
            this.Visible = false;
            this.Path = path;
            this.SQL = SQL;
            this.Parametro1 = PArametro1;
            this.Parametro2 = Parametro2;
            this.DesktopLocation = new System.Drawing.Point(0,0);
            bgwProgresso.RunWorkerAsync("DATAS");
        }
        public frmRelatorios(string path, string SQL, string PArametro1, string Parametro2, string Parametro3)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(0, 0);
            this.Visible = false;
            this.Path = path;
            this.SQL = SQL;
            this.Parametro1 = PArametro1;
            this.Parametro2 = Parametro2;
            this.Parametro3 = Parametro3;
            this.DesktopLocation = new System.Drawing.Point(0, 0);
            bgwProgresso.RunWorkerAsync("DATAS-CLIENTE");

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgwProgresso_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (e.Argument.Equals("DATAS"))
            {
                Relatorios.GeraRelatorio_FiltroData(this, this.reportViewer1, Path, SQL, Parametro1, Parametro2);
            }
            if (e.Argument.Equals("DATAS-CLIENTE"))
            {
                Relatorios.GeraRelatorio_FiltroDataCliente(this, this.reportViewer1, Path, SQL, Parametro1, Parametro2,Parametro3);
            }
        }
        
        private void bgwProgresso_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.Size = new System.Drawing.Size((Int32)Globais.Atual_Width, (Int32)(Globais.Atual_Height - 40));
        }

        
    }
}
