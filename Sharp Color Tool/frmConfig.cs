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
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();


            Globais.Config();
            new Globais().Preenche_PainelConfig(this);            
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

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdGravar_Click(object sender, EventArgs e)
        {
            string OSModelo = txtCaminhoModelo.Text;
            string Backup = txtCaminhoBackup.Text;
            int Repesagem =(Int32)txtTempoRepesagem.Value;
            int OSFim = (Int32)txtNumeroOSFim.Value;
            int CL_NOS = (Int32)txtCL_NOS.Value;
            int CL_DtCadastro = (Int32)txtCL_DataCadastro.Value;
            int CL_TipoOS = (Int32)txtCL_TipoOS.Value;
            int CL_Cliente = (Int32)txtCL_Cliente.Value;
            int CL_Veiculo = (Int32)txtCL_Veiculo.Value;
            int CL_Placa = (Int32)txtCL_Placa.Value;
            int CL_GrupoCores = (Int32)txtCL_GrupoCores.Value;
            int CL_Montadora = (Int32)txtCL_Montadora.Value;
            int CL_COdCOr = (Int32)txtCL_CodigoCor.Value;
            int CL_Qnt = (Int32)txtCL_Quantidade.Value;
            int CL_Pintura = (Int32)txtCL_SP.Value;
            int CL_Colorista = (Int32)txtCL_Colorista.Value;
            int CL_Cor = (Int32)txtCL_Cor.Value;
            int CL_CorpoProva = (Int32)txtCL_CorpoProva.Value;
            int CL_Prioridade = (Int32)txtCL_Prioridade.Value;
            int CL_Status = (Int32)txtCL_Status.Value;
            int CL_Inicio = (Int32)txtCL_Inicio.Value;
            int CL_Fim = (Int32)txtCL_Fim.Value;
            int CL_Tempo = (Int32)txtCL_Tempo.Value;
            int CL_Entrega = (Int32)txtCL_Entrega.Value;
            int CL_dtFaturamento = (Int32)txtCL_DataFaturamento.Value;
            int CL_Custo = (Int32)txtCL_ValorCusto.Value;
            int CL_Venda = (Int32)txtCL_ValorVenda.Value;
            int CL_Markup = (Int32)txtCL_Markup.Value;
            int CL_Chapinhas = (Int32)txtCL_Chapinhas.Value;
            int CL_Previsao = (Int32)txtCL_Previsao.Value;
            int Margem = (Int32)txtMargemSugerida.Value;
            int Zoom = (Int32)txtZoomRelatorio.Value;

            new Globais().Atualizar_Configuracoes(OSModelo,Backup,Repesagem,OSFim,CL_NOS,CL_DtCadastro,CL_TipoOS,CL_Cliente,CL_Veiculo,CL_Placa,CL_GrupoCores,CL_Montadora,CL_COdCOr,CL_Qnt,CL_Pintura,CL_Colorista,CL_Cor,CL_CorpoProva,CL_Prioridade,CL_Status,CL_Inicio,CL_Fim,CL_Tempo,CL_Entrega,CL_dtFaturamento,CL_Custo,CL_Venda,CL_Markup,CL_Chapinhas,CL_Previsao,Margem,Zoom);
            Globais.Config();
            this.Close();
        }
    }
}
