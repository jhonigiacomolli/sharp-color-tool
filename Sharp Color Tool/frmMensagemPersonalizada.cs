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
    public partial class frmMensagemPersonalizada : Form
    {
        public frmMensagemPersonalizada(string Tipo,string Titulo, string Mensagem)
        {
            InitializeComponent();

            if (Tipo == "Critico")
            {
                lblTitulo.Text = Titulo;
                txtMensagem.Text = Mensagem;
                btnNo.Visible = false;
                btnYes.Visible = false;
                btnOK.Visible = true;
                picIcone.Image = Properties.Resources.Icone_Critico;
            }

            if (Tipo == "Alerta")
            {
                lblTitulo.Text = Titulo;
                txtMensagem.Text = Mensagem;
                btnNo.Visible = false;
                btnYes.Visible = false;
                btnOK.Visible = true;
                picIcone.Image = Properties.Resources.Icone_Exclamação;
            }

            if (Tipo == "Questao")
            {
                lblTitulo.Text = Titulo;
                txtMensagem.Text = Mensagem;
                btnNo.Visible = true;
                btnYes.Visible = true;
                btnOK.Visible = false;
                picIcone.Image = Properties.Resources.Icone_Interogação;
            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmMensagemPersonalizada_Load(object sender, EventArgs e)
        {
            Width = Convert.ToInt32(428 * Globais.Fator_Largura);
            Height = Convert.ToInt32(139 * Globais.Fator_Altura);
        }
    }
}
