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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();

            lstClientes.GridLines = true;
            lstClientes.FullRowSelect = true;
            lstClientes.AllowColumnReorder = true;
            lstClientes.View = View.Details;
            lstClientes.Columns.Add("ID",50);
            lstClientes.Columns.Add("Cliente", 400);
            lstClientes.Columns.Add("Prioridade", 200);
            lstClientes.Columns.Add("Cod_Prioridade", 20);

            new Clientes().LerClientes(lstClientes);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cmdNovo_Click(object sender, EventArgs e)
        {
            frmCadastroClientes cadastro = new frmCadastroClientes(this);
            cadastro.ShowDialog();
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = new DialogResult();
            Form messagebox = new frmMensagemPersonalizada("Questao", "Exclusão", "Deseja excluir o cliente selecionado?");
            Resultado = messagebox.ShowDialog();

            if (Resultado == DialogResult.OK)
            {
                int ID =int.Parse(lstClientes.FocusedItem.SubItems[0].Text);
                new Clientes().ExcluirCliente(ID);
                new Clientes().LerClientes(lstClientes);
            }
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(lstClientes.FocusedItem.SubItems[0].Text);
            string Cliente = lstClientes.FocusedItem.SubItems[1].Text;
            string Prioridade = lstClientes.FocusedItem.SubItems[2].Text;

            frmCadastroClientes cadastro = new frmCadastroClientes(this,ID,Cliente,Prioridade);
            cadastro.ShowDialog();
        }
    }
}
