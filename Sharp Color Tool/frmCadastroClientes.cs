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
    public partial class frmCadastroClientes : Form
    {
        public frmClientes frmclientes;
        public int id;
        public frmCadastroClientes(frmClientes frmclientes)
        {
            InitializeComponent();
            this.frmclientes = frmclientes;
        }
        public frmCadastroClientes(frmClientes frmclientes, int ID, string Cliente, string Prioridade)
        {
            id = ID;
            InitializeComponent();
            this.frmclientes = frmclientes;

            txtCliente.Text = Cliente;
            txtPrioridade.DropDownStyle = ComboBoxStyle.DropDown;
            txtPrioridade.Text = Prioridade;
            cmgGravar.Text = "Atualizar";
        }
        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            txtPrioridade.ValueMember.DefaultIfEmpty();
            this.Close();
        }

        private void cmgGravar_Click(object sender, EventArgs e)
        {
            string Cliente = txtCliente.Text;
            string Prioridade = txtPrioridade.Text;
            ListView LST = frmclientes.lstClientes;
            if (cmgGravar.Text == "Gravar")
            {
                new Clientes().CadastraCliente(Cliente, Prioridade);
                new Clientes().LerClientes(frmclientes.lstClientes);
                this.Close();
            }
            if (cmgGravar.Text == "Atualizar")
            {
                new Clientes().EditarCliente(id,Cliente,Prioridade);
                new Clientes().LerClientes(frmclientes.lstClientes);
                this.Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        bool mouseDown;
        Point lastLocation;

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

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
    }
}
