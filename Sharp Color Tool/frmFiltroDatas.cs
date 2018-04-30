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
    public partial class frmFiltroDatas : Form
    {
        public string Path;
        public string SQL;
        public string Inicio;
        public string Fim;
        public string TIPO;

        public frmFiltroDatas(string Path, string Tipo)
        {
            InitializeComponent();
            this.TIPO = Tipo;
            this.Path = Path;
            
            if (Tipo == "TUDO") { SQL = "SELECT * FROM Agendamentos"; };
            if (Tipo == "DATAS") { SQL = "SELECT * FROM Agendamentos where Fim between @inicio And @fim Order By Fim ASC"; };          
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void cmgGerar_Click_1(object sender, EventArgs e)
        {
            Inicio = txtDataInicio.Value.ToString();
            Fim =txtDataFim.Value.AddDays(1).ToString();

            if (TIPO == "TUDO")
            {
                frmRelatorios Relatorios = new frmRelatorios(Path, SQL);
                Relatorios.Show();
                this.Close();
            }
            if (TIPO == "DATAS")
            {
                frmRelatorios Relatorios = new frmRelatorios(Path, SQL,Inicio, Fim);
                Relatorios.Show();
                this.Close();
            }
        }

        bool mouseDown;
        Point lastLocation;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void lblTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void lblTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
