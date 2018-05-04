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
        public string Cliente;

        public frmFiltroDatas(string Path, string Tipo)
        {
            InitializeComponent();
            this.TIPO = Tipo;
            this.Path = Path;
            
            if (Tipo == "DATAS") { SQL = "SELECT * FROM Agendamentos where Fim between @inicio And @fim Order By Fim ASC"; };
            if (Tipo == "DATAS-CLIENTE") { SQL = "SELECT * FROM Agendamentos where Fim between @inicio And @fiM AND Cliente=@Cliente Order By Fim ASC"; };
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void cmgGerar_Click_1(object sender, EventArgs e)
        {
            Inicio = txtDataInicio.Value.ToString();
            Fim =txtDataFim.Value.AddDays(1).ToString();
            Cliente = txtCliente.Text;

            if (TIPO == "DATAS")
            {
                this.Close();
                frmRelatorios Relatorios = new frmRelatorios(Path, SQL,Inicio, Fim);
                Relatorios.ShowDialog();               
            }
            if (TIPO == "DATAS-CLIENTE")
            {
                this.Close();
                frmRelatorios Relatorios = new frmRelatorios(Path, SQL, Inicio, Fim, Cliente);
                Relatorios.ShowDialog();
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

        private void frmFiltroDatas_Resize(object sender, EventArgs e)
        {
            if (this.Width < 500)
            {
                txtCliente.Visible = false;
                lblCliente.Visible = false;
            }
            else
            {
                txtCliente.Visible = true;
                lblCliente.Visible = true;
            }
            cmgGerar.Location = new Point((this.Size.Width/2)-(cmgGerar.Width/2),76);
        }
    }
}
